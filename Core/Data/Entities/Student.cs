using System.Collections.Generic;
using System.Linq;
using WebApplication2.Data.Entities;

namespace Core.Data.Entities
{
    public class Student 
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public int SchoolClassId { get; set; }
        public virtual SchoolClass SchoolClass { get; set; }
        public string Email { get; set; }
        public string StudentCardNumber { get; set; }
        public Gender Gender { get; set; }
        public bool InviteSent { get; set; }
        public bool RegisteredInSystem { get; set; }
        public virtual Invite Invite { get; set; }
        public int? InviteId { get; set; }
        
        //TODO: oleks vaja privateiks muuta, 
        public virtual ICollection<Result> Results { get; set; }
    }
    public class TeacherRegistration
    {
        public int Id { get; set; }
        public string Token { get; set; }
        public bool Used { get; set; }
        public string Email { get; set; }
    }
    public class Invite
    {
        public int Id { get; set; }
        public int StudentId { get; set; }
        public virtual Student Student { get; set; }
        public string Token { get; set; }
        public bool Used { get; set; }
        public string Email { get; set; }
    }
   

    public enum Gender
    {
        Man=1,
        Woman=2
    }
}