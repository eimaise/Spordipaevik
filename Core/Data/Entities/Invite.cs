using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Core.Data.Entities
{
    public class Invite : BaseEntity
    {
        public Invite(int studentId, string token, bool used, string email)
        {
            StudentId = studentId;
            Token = token;
            Used = used;
            Email = email;
        }
        public void MarkInviteUsed()
        {
            Used = true;
        }
        public int StudentId { get; private set; }
        public string Token { get; private set; }
        public bool Used { get; private set; }
        public string Email { get; private set; }
        public class InviteConfiguration : IEntityTypeConfiguration<Invite>
        {
            public void Configure(EntityTypeBuilder<Invite> builder)
            {
                builder.Property(p => p.StudentId);
            }
        }
    }
}