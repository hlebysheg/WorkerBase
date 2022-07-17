using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace WorkerBase.models
{
    [Table("Worker")]
    public class Worker
    {
        [Key]
        public int Id { get; set; }

        [Required]
        [MaxLength(25), MinLength(4)]
        public string FullName { get; set; }

        [Required]
        public DateTime BirhtDay { get; set; }

        [Required]
        public double Salary { get; set; }

        [Required]
        public DateTime WorkDay { get; set; }

        [Required]
        public string DepName { get; set; }
    }
}
