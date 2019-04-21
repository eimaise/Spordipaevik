using System.Collections.Generic;
using Microsoft.AspNetCore.Identity;

namespace Core.Data.Entities
{
    public class ApplicationUser : IdentityUser
    {
        public ApplicationUser() : base(){}
        public string Name { get; set; }
        public bool HideResults { get; set; }
//        public virtual ICollection<IdentityRole> UserRoles { get; set; }
    }
//    public class ApplicationUserRole  : IdentityUserRole<string>
//    {
////        public virtual ApplicationUser User { get; set; }
////        public virtual ApplicationRole Role { get; set; }
//    }
//    public class ApplicationRole : IdentityRole
//    {
//        public virtual  ICollection<ApplicationUserRole> UserRoles { get; set; }
//    }

    public static class Role
    {
        public static string Teacher => "Teacher";
        public static string Admin => "Admin";
        public static string Student => "Student";
    }
}