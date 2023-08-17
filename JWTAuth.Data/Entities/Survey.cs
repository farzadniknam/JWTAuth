using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;

namespace JWTAuth.Data.Entities
{
    [Table("surveys")]
    public class Survey
    {
        public Survey() { }

        [Key]
        public int Id { get; set; }
        public int CreatedBy { get; set; }
        public DateTime CreatedDate { get; set; }
        public Nullable<int> ModifiedBy { get; set; }
        public Nullable<DateTime> ModifiedDate { get; set; }
        public bool IsActive { get; set; } = false;
        public string Title { get; set; }
        public string Description { get; set; }
    }
}
