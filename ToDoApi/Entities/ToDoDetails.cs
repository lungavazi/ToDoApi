using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace ToDoApi.Entities
{
    [Table("TodoDetails")]
    public class ToDoDetails
    {
        [Key]
        public int Id { get; set; }
        [Required]
        public int ToDoId { get; set; }
        [MaxLength(100)]
        public string Description { get; set; }
        public double Cost { get; set; }
    }
}
