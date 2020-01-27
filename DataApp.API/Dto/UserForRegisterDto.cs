using System.ComponentModel.DataAnnotations;

namespace DataApp.API.Dto
{
    public class UserForRegisterDto
    {

        [Required]
        public string Username { get; set; }

        [Required]
        [StringLength(8,MinimumLength=4,ErrorMessage="Pssword length should be between 4 and 8")]
        public string Password { get; set; }
    }
}