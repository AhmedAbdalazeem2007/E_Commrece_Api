﻿namespace Api_PL.Dtos
{
    public class RegisterDto
    {
        [Required]
        public string DisplayName {  get; set; }
        [Required]
        [EmailAddress]
        public string Email { get; set; }
        [Required]
        [RegularExpression("")]
        public string Password { get; set; }
        [Required]
        [Phone] 
        public string PhoneNumber { get; set; }
    }
}
