using System.ComponentModel.DataAnnotations;

namespace CaterpillarControlService.API.Dtos.Auth
{
    public class RegisterUserDto
    {
        [Required(ErrorMessage = "First Name is Required")]
        public string FirstName { get; set; }
        [Required(ErrorMessage = "First Name is Required")]
        public string LastName { get; set; }
        [Required(ErrorMessage = "Email is Required"), EmailAddress]
        public string Email { get; set; }
        [Required(ErrorMessage = "Password is required")]
        [DataType(DataType.Password)]
        public string Password { get; set; }
    }
}
