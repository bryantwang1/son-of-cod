using System;
using System.ComponentModel.DataAnnotations;

namespace SonOfCodSeafood.Models
{
    public class NewsletterMember
    {
        [Key]
        public int NewsletterMemberId { get; set; }
        [Required]
        [StringLength(60, MinimumLength = 1)]
        public string FirstName { get; set; }
        [Required]
        [StringLength(60, MinimumLength = 1)]
        public string LastName { get; set; }
        [Required]
        [StringLength(200, MinimumLength = 1)]
        public string Email { get; set; }
        [Required]
        public DateTime Birthday { get; set; }

        public NewsletterMember()
        {

        }
    }
}
