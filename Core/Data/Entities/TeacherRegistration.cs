namespace Core.Data.Entities
{
    public class TeacherRegistration
    {
        public TeacherRegistration(string token, bool used, string email)
        {
            Token = token;
            Used = used;
            Email = email;
        }

        protected TeacherRegistration()
        {

        }
        public int Id { get; private set; }
        public string Token { get; private set; }
        public bool Used { get; private set; }
        public string Email { get; private set; }

        public void SetTokenStatus(bool status)
        {
            Used = status;
        }
    }
}