using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MovieSystem.Models
{
    public class PersonGenre
    {
        [Key]
        public int Id { get; set; }
        [ForeignKey("Person")]
        [Required]
        public int PersonId { get; set; }
        public virtual Person Person { get; set; }
        [ForeignKey("Genre")]
        [Required]
        public int GenreId { get; set; }
        public virtual Genre Genre { get; set; }
    }
}
