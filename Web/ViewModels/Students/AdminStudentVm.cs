namespace WebApplication2.ViewModels.Students
{
    public class AdminStudentVm
    {
        public int Id { get; set; }
        public string StudentCardNr { get; set; }
        public bool InviteSent { get; set; }
        public string Email { get; set; }
        public bool RegisteredInSystem { get; set; }
        public string ActivationLink { get; set; }
        public string Name { get; set; }
    }
}