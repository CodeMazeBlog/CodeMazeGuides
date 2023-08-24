using System.Collections.Generic;

namespace Writer.Tests.Mock.Models
{
    public class WriterMock
    {
        public List<Api.Models.Writer> GetAll()
        {
            return new List<Writer.Api.Models.Writer>()
            {
                new Writer.Api.Models.Writer
                {
                    Id = 1,
                    Name = "Leanne Graham"

                },
                new Writer.Api.Models.Writer
                {
                    Id = 2,
                    Name = "Ervin Howell"
                }
            };
        }

        public Api.Models.Writer Get()
        {
            return new Writer.Api.Models.Writer
            {
                Id = 1,
                Name = "Leanne Graham"
            };
        }

        public Api.Models.Writer? GetNotFound()
        {
            return default;
        }

        public Api.Models.Writer Insert()
        {
            return new Api.Models.Writer 
            { 
                Id = 3, 
                Name = "Glenna Reichert" 
            };
        }
    }
}
