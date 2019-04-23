using System.ComponentModel.DataAnnotations;

namespace WebApplication2.ViewModels.User
{
    public class ChangeUserInfoVm
    {
        [DataType(DataType.Password)]
        public string Password { get; set; }
        [DataType(DataType.Password)]
        public string ConfirmPassword { get; set; }

        public bool HideResults { get; set; }
    }
}