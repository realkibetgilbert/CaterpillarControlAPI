using System.ComponentModel.DataAnnotations;

namespace CaterpillarControlService.API.Dtos.Auth
{
    
        public class LoginDto
        {
            [Required(ErrorMessage = "Email is required")]
            public string Email { get; set; }

            [Required(ErrorMessage = "Password is required")]
            [DataType(DataType.Password)]
            public string Password { get; set; }
        }
    
}
