using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MovieSystem.Models
{
    public class MovieGenre
    {
        [Key]
        public int Id { get; set; }
        [ForeignKey("Movie")]
        [Required]
        public int MovieId { get; set; }
        public virtual Movie Movie { get; set; }
        [ForeignKey("Genre")]
        [Required]
        public int GenreId { get; set; }
        public virtual Genre Genre { get; set; }
    }
}
