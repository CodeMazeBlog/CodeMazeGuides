using System;
using RequestBodyRead.Entities.Models;

namespace RequestBodyRead.Repository
{
	public static class DataBaseMockup
	{
		public static List<User> Users { get; set; } = new List<User>
		{
            new User
            {
                Id = new Guid("ddf4f0a8-09c9-4b39-b722-ae15d8449eae"),
                FirstName = "John",
                LastName = "Doe",
                Email = "john.doe@somealias.com"
            },
            new User
            {
                Id = new Guid("9d2dbd63-5202-414c-a0d6-e14fa1b0f868"),
                FirstName = "Jane",
                LastName = "Smith",
                Email = "jane.smith@somealias.com"
            },
            new User
            {
                Id = new Guid("b2d93023-29de-4738-bff0-28754b97116c"),
                FirstName = "Sara",
                LastName = "Brown",
                Email = "sara.brown@somealias.com"
            }
        };
	}
}

