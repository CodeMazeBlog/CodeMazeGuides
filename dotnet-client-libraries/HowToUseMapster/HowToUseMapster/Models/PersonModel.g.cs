using System;
using HowToUseMapster.Data;

namespace HowToUseMapster.Data
{
    public partial class PersonModel
    {
        public string? Title { get; set; }
        public string? FirstName { get; set; }
        public string? LastName { get; set; }
        public DateTime? DateOfBirth { get; set; }
        public AddressModel? Address { get; set; }
    }
}