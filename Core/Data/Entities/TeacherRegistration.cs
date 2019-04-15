namespace Core.Data.Entities
{
    public class TeacherRegistration
    {
        public int Id { get; set; }
        public string Token { get; set; }
        public bool Used { get; set; }
        public string Email { get; set; }
    }
}