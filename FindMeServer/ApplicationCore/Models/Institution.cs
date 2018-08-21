using ApplicationCore.DataTransferObjects;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace ApplicationCore.Models
{
    [Table("Institutions")]
    public class Institution
    {
        [Key]
        public int Id { get; set; }
        [Required]
        public int CityId { get; set; }
        [Required]
        public int InstitutionTypeId { get; set; }
        [Required, MinLength(6), MaxLength(300)]
        public string Password { get; set; }
        [Required, MaxLength(50)]
        public string Name { get; set; }
        [Required, MaxLength(50)]
        public string Address { get; set; }
        [Required]
        public string Phone { get; set; }
        [Required, MaxLength(20)]
        public string OpeningHours { get; set; }
        [MaxLength(50)]
        public string Website { get; set; }
        [Required]
        public bool IsAdmin { get; set; }
        public virtual InstitutionType InstitutionType { get; set; }
        public virtual City City { get; set; }
    }
}