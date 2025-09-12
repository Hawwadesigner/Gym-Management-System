using GYM_System.Models;
using System;

namespace GYM_System.Helper
{
    public static class MemberInputHelper
    {
        public static MemberModel ShowMemberData(MemberModel member)
        {
            PersonDisplayHelper.ShowCurrentBasicData(member); // Show Basic Data

            Console.WriteLine($"\nDate Of Birth: {member.DateOfBirth}" +
                              $"\nCity: {member.Address.City}" +
                              $"\nRegion: {member.Address.Region}" +
                              $"\nStreet: {member.Address.Street}" +
                              $"\nBuilding: {member.Address.Building}");
            Console.WriteLine("\n--------------------------------------------");
            return member;
        }

        public static MemberModel FillMemberData(MemberModel member, bool IsUpdate = false)
        {
            if (IsUpdate == true)
            {
                ShowMemberData(member);
            }

            PersonInputHelper.FillBasicData(member, IsUpdate); // Fill Basic Data

            // Date of Birth
            var dateOfBirth = InputHelper.ReadString($"-> Enter Date Of Birth (yyyy/MM/dd){(IsUpdate ? $"(leave empty to keep '{member.DateOfBirth}')" : "")}: ");
            if (!string.IsNullOrWhiteSpace(dateOfBirth) && DateTime.TryParse(dateOfBirth, out DateTime updateDateOfBirth))
                member.DateOfBirth = updateDateOfBirth;

            // City
            var city = InputHelper.ReadString($"-> Enter City{(IsUpdate ? $"(leave empty to keep '{member.Address.City}')" : "")}: ");
            if (!string.IsNullOrWhiteSpace(city))
                member.Address.City = city;

            // Region
            var region = InputHelper.ReadString($"-> Enter Region{(IsUpdate ? $"(leave empty to keep '{member.Address.Region}')" : "")}: ");
            if (!string.IsNullOrWhiteSpace(region))
                member.Address.Region = region;

            // Street
            var street = InputHelper.ReadString($"-> Enter Street{(IsUpdate ? $"(leave empty to keep '{member.Address.Street}')" : "")}: ");
            if (!string.IsNullOrWhiteSpace(street))
                member.Address.Street = street;

            // Building
            var building = InputHelper.ReadString($"-> Enter Building{(IsUpdate ? $"(leave empty to keep '{member.Address.Building}')" : "")}: ");
            if (!string.IsNullOrWhiteSpace(building) && int.TryParse(building, out int updateBuilding))
                member.Address.Building = updateBuilding;

            return member;
        }

    }
}
