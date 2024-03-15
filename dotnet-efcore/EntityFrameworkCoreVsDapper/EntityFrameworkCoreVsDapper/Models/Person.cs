using System.ComponentModel.DataAnnotations.Schema;

namespace EntityFrameworkCoreVsDapper.Models
{
    public class Person
    {
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int Id { get; set; }
        public string Name { get; set; }
    }
}
