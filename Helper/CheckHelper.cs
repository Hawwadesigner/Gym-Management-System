using GYM_System.Exceptions;
using GYM_System.Models;
using GYM_System.Services;
using System;

namespace GYM_System.Helper
{
    public static class CheckHelper
    {
        public static (string phone, MemberModel member)? CheckAndReturnByPhone<T>(BaseService<T> service, string entityName) where T : class
        {
            var phone = InputHelper.ReadString($"-> Enter {entityName} Phone: ");
            var member = service.GetByPhone(phone);
            if (member == null)
                throw new NotFoundException<T>();
            return (phone, member);
        }

        public static (int id, T entity)? CheckAndReturn<T>(BaseService<T> service, string entityName) where T : class 
        {
            var id = InputHelper.ReadInt($"-> Enter {entityName} ID: ");
            var entity = service.GetById(id);
            if (entity == null)
                throw new NotFoundException<T>();
            return (id, entity);
        }

        // The names in the signature (id, entity) are just tuple labels, 
        // not actual variables inside the method body.
        public static (int id, T entity)? CheckAndConfirmAction<T>(BaseService<T> service, string entityName, string actionVerb, string actionPastVerb) where T : class
        {
            var result = CheckAndReturn<T>(service, entityName);
            if (result == null) return null;

            Console.Write($"Are you sure you want to {actionVerb} this");
            Console.Write(service is SubscriptionService ? "Member" : $"{entityName}? (y/n): ");

            var confirmation = Console.ReadLine().Trim().ToLower();
            if (confirmation != "y")
            {
                Console.WriteLine($"\n\n{actionPastVerb} cancelld!");
                return null;
            }
            return result;
        }
    }
}
