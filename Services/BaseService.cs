using GYM_System.Data;
using GYM_System.Exceptions;
using GYM_System.Helper;
using GYM_System.Models;
using System;
using static Microsoft.EntityFrameworkCore.DbLoggerCategory;

namespace GYM_System.Services
{
    public class BaseService<T> where T : class
    {
        // Initialization
        protected readonly AppDbContext _context;

        // Constructor
        public BaseService(AppDbContext context)
        {
            _context = context;
        }

        // CRUD
        public virtual void Add(T entity)
        {
            _context.Set<T>().Add(entity);

            try
            {
                _context.SaveChanges();
            }
            catch(Exception ex) { Console.WriteLine($"\n\nError: {ex.Message}"); }
        }
        public void Update(T entity)
        {
            _context.Set<T>().Update(entity);

            try
            {
                _context.SaveChanges();
            }
            catch(Exception ex) { Console.WriteLine($"\n\nError: {ex.Message}"); }
        }
        public virtual void Delete(int id)
        {
            var entity = _context.Set<T>().Find(id);
            if (entity == null)
                throw new NotFoundException<T>();

            _context.Remove(entity);
            _context.SaveChanges();
        }
        
        public T? GetById(int id) => _context.Set<T>().Find(id);
        public MemberModel? GetByPhone(string phone) => _context.Set<MemberModel>().FirstOrDefault(x=> x.Phone == phone);
        public IEnumerable<T> GetAllLazy()
        {
            foreach (var entity in _context.Set<T>())
                yield return entity;
        }
    }
}
