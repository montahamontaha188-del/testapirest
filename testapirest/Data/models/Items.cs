using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace testapirest.Data.models
{
    public class Items
    {
        [Key]
        public int Id { get; set; }
        [MaxLength(100)]
        public string Name { get; set; }
        public double Price {  get; set; }
        [ForeignKey(nameof(category))]
        public int CategoryId { get; set; }
        public Category category { get; set; }

    }
}
