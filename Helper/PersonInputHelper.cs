using GYM_System.Models;
using System;

namespace GYM_System.Helper
{
    public static class PersonInputHelper
    {
        public static T FillBasicData<T>(T entity, bool IsUpdate = false) where T : PersonModel
        {
            // FullName
            var fullName = InputHelper.ReadString($"-> Enter Full Name{(IsUpdate ? $"(leave empty to keep '{entity.FullName}')" : "")}: ");
            if (!string.IsNullOrWhiteSpace(fullName))
                entity.FullName = fullName;

            // Phone
            var phone = InputHelper.ReadString($"-> Enter Phone{(IsUpdate ? $"(leave empty to keep '{entity.Phone}')" : "")}: ");
            if (!string.IsNullOrWhiteSpace(phone))
                entity.Phone = phone;

            // Email
            var email = InputHelper.ReadString($"-> Enter Email{(IsUpdate ? $"(leave empty to keep '{entity.Email}')" : "")}: ");
            if (!string.IsNullOrWhiteSpace(email))
                entity.Email = email;

            return entity;
        }

    }
}
