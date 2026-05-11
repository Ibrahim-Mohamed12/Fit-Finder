using DAL.Entities;
using DAL.Entities.Enums;
using System.ComponentModel.DataAnnotations;

namespace FitFinderProject.PL.Models
{
    public class SignUpViewModel
    {
        [Required(ErrorMessage = "Name is required.")]
        public string Name { get; set; }
        [Required(ErrorMessage = "Email is required.")]
        [EmailAddress(ErrorMessage = "Invalid email address.")]
        public string Email { get; set; }
        [Required(ErrorMessage = "Password is required.")]
        public string Password { get; set; }

        [Compare("Password", ErrorMessage = "Passwords do not match.")]
        [Required(ErrorMessage = "Confirm Password is required.")]
        public string ConfirmPassword { get; set; }
        [Required(ErrorMessage = "Gender is required.")]
        public string Gender { get; set; }
    }

    public static class SignUpViewModelExtensions
    {
        public static ApplicationUser ToUser(this SignUpViewModel model)
        {
            return new ApplicationUser
            {
                UserName = model.Name,
                Email = model.Email,
                PasswordHash = model.Password,
                Gender = (Gender)Enum.Parse(typeof(Gender), model.Gender),
                Address = string.Empty,
                ProfileImgUrl = string.Empty,

            };
        }
    }
}