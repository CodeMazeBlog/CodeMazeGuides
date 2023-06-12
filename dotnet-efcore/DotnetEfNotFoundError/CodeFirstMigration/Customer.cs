namespace CodeFirstMigration
{
    public class Customer
    {
        public Guid Id { get; }
        public string? FirstName { get;  }
        public string? LastName { get;  }
        public int Age { get; set; }
        public string? Address { get;  }
        public string? CardNumber { get; }

        public Customer(Guid id, string? firstName, string? lastName, int age, string? address, string? cardNumber)
        {
            Id = id;
            FirstName = firstName;
            LastName = lastName;
            Age = age;
            Address = address;
            CardNumber = cardNumber;
        }
    }
}
