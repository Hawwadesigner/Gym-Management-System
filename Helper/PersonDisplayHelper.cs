using GYM_System.Models;
using System;

namespace GYM_System.Helper
{
    public static class PersonDisplayHelper
    {
        public static T ShowCurrentBasicData<T>(T entity) where T : PersonModel
        {
            Console.WriteLine("\n\n--------------------------------------------");
            Console.WriteLine("               CURRENT DATA                 ");
            Console.WriteLine("\n--------------------------------------------");
            Console.WriteLine($"ID: {entity.Id}" +
                              $"\nFullName: {entity.FullName}" +
                              $"\nPhone: {entity.Phone}" +
                              $"\nEmail: {entity.Email}");

            return entity;
        }
    }
}
