using System;
namespace RequestBodyRead.Shared.DataTransferObjects
{
	public record UserForCreationAndUpdateDto
	{
        public string? FirstName { get; set; }

        public string? LastName { get; set; }

        public string? Email { get; set; }
    }
}

