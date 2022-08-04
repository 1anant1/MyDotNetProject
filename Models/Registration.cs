using System.ComponentModel.DataAnnotations;

namespace Registration_Form.Models

{
    public class Login
    {
        [Required(ErrorMessage = "This field can not be empty")]
        public string UserName { get; set; }
        [Required(ErrorMessage = "This field can not be empty")]
        public string ConfirmPassword { get; set; }

    }
    public class Registration : Login
    {
        [Key]
        public int Id { get; set; }
        [Required(ErrorMessage = "This field can not be empty")]
        public string FisrtName { get; set; }
        [Required(ErrorMessage = "This field can not be empty")]
        public string LastName { get; set; }
        
        [Required(ErrorMessage ="Password is required")]
        [StringLength(255,ErrorMessage ="Must be between 5 and 255 characters",MinimumLength =5)]
        [DataType(DataType.Password)]
        public string CreatePassword { get; set; }
        [Required(ErrorMessage ="Password do not match")]
        [StringLength(255,ErrorMessage = "Must be between 5 and 255 characters", MinimumLength = 5)]
        [DataType(DataType.Password)]
        [Compare("CreatePassword")]
        public string ConfirmPassword { get; set; }
        public string Address { get; set; }
        [Required(ErrorMessage = "Mobile no. is required")]
        [RegularExpression("^(?!0+$)(\\+\\d{1,3}[- ]?)?(?!0+$)\\d{10,15}$", ErrorMessage = "Please enter valid phone no.")]
        public string PhoneNo { get; set; }
        public string Gender { get; set; }
        [DataType(DataType.EmailAddress)]
        public string Email { get; set; }

        public DateTime dateTime { get; set; } = DateTime.Now; 
    }
}
