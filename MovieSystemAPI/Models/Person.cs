using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MovieSystem.Models
{
    public class Person
    {
        [Key]
        public int Id { get; set; }
        [Required]
        [DisplayName("First Name")]
        [StringLength(50)]
        public string? FirstName { get; set; }
        [Required]
        [DisplayName("Last Name")]
        [StringLength(50)]
        public string? LastName { get; set; }
        [Required]
        [StringLength(100)]
        public string? Email { get; set; }
    }
}
