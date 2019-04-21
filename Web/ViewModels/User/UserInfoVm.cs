using System.ComponentModel.DataAnnotations;

namespace WebApplication2.ViewModels.User
{
    public class UserInfoVm
    {
        public bool IsStudent { get; set; }
        public bool IsResultsHidden { get; set; }
        [DataType(DataType.Password)]
        public string Password { get; set; }
        [DataType(DataType.Password)]
        public string ConfirmPassword { get; set; }
    }
}