using MongoDB.Bson;
using MongoDB.Bson.Serialization.Attributes;
using System.ComponentModel.DataAnnotations;

namespace GettingStartedASPNETMongoDB.Models
{
    public class Course
    {
        [BsonId]
        [BsonRepresentation(BsonType.ObjectId)]
        public string Id { get; set; }

        [Required(ErrorMessage = "Course name is required")]
        public string Name { get; set; }

        [Required(ErrorMessage = "Course code is required")]
        public string Code { get; set; }
    }
}