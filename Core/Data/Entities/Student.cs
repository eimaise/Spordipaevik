using System;
using System.Collections.Generic;

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
        public bool InviteSent => Invite != null;
        public bool RegisteredInSystem { get; private set; }
        public virtual Invite Invite { get; set; }
        public int? InviteId { get; set; }
        
        //TODO: oleks vaja privateiks muuta, 
        public virtual ICollection<Result> Results { get; set; }
        public void AddInvite(Invite invite)
        {
            Invite = invite;
        }

        public void MarkInviteUsed()
        {
            Invite.MarkInviteUsed();
            RegisteredInSystem = true;
        }
    }


    public enum Gender
    {
        Man=1,
        Woman=2
    }
}