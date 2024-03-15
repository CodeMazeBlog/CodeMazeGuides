using System.ComponentModel.DataAnnotations.Schema;

namespace EFInserts_EF6;

public class Model
{
    public class Person
    {
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int PersonId { get; set; }
        public string Name { get; set; }
    }
}