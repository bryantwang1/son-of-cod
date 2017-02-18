using System;
using System.ComponentModel.DataAnnotations;

namespace SonOfCodSeafood.Models
{
    public class NewsletterMember
    {
        [Key]
        public int NewsletterMemberId { get; set; }
        [Required]
        public string FirstName { get; set; }
        [Required]
        public string LastName { get; set; }
        [Required]
        public string Email { get; set; }
        [Required]
        public DateTime Birthday { get; set; }

        public NewsletterMember()
        {

        }
    }
}
