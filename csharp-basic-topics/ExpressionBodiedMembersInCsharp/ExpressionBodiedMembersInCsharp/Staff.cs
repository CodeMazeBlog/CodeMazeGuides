namespace ExpressionBodiedMembersInCsharp
{
    public class Staff {
        
        private readonly string[] _staff = { "John", "Mary", "Derrick", "Paul", "Lisa" }; 
        
        public string this[int index] 
        { 
            get => _staff[index]; 
            set => _staff[index] = value; 
        }
    }
}