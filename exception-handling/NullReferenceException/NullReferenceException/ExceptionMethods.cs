namespace NullReference
{
    public class ExceptionMethods
    {
        public List<string> StudentList() 
        {
            List<string> studentList = null;

            studentList.Add("John Doe");

            return studentList;
        }

        public List<string> FixedStudentList()
        {
            var studentList = new List<string>();

            studentList.Add("John Doe");

            return studentList;
        }

        public int[] RandomNumbers()
        {
            var rand = new Random();

            int[] numbers = null;

            for (int i = 0; i < numbers.Length; i++) 
            {
                numbers[i] = rand.Next();
            }
         
            return numbers;
        }

        public int[] FixedRandomNumbers()
        {
            var rand = new Random();

            var numbers = new int[50];

            for (int i = 0; i < numbers.Length; i++)
            {
                numbers[i] = rand.Next();
            }

            return numbers;
        }

        public string Teachers(string searchString)
        {
            var personObj = new Teacher();
            
            var people = personObj.AddRange(new string[] { "John", "Mary", "Jane", "Usher", "Andrew", "Grace", "Aston", "Sheila" });
            var result = Array.Find(people, p => p.FirstName == searchString);
            
            return result.ToString();
        }

        public string FixedTeachers(string searchString)
        {
            var personObj = new Teacher();

            var people = personObj.AddRange(new string[] { "John", "Mary", "Jane", "Usher", "Andrew", "Grace", "Aston", "Sheila" });
            var result = Array.Find(people, p => p.FirstName == searchString);

            if (result != null)
            {
                return result.ToString();
            }
            else
            {
                return $"{searchString} could not be found";
            }
        }

        public string[] CapitalizeNames() 
        {
            var names = new string[] { "John", "Mary", null, null, "Andrew", "Grace", "Aston", "Sheila" };

            for (int i = 0; i < names.Length; i++)
            {
                names[i] = names[i].ToUpper();
            }

            return names;
        }

        public string[] FixedCapitalizeNames()
        {
            var names = new string[] { "John", "Mary", null, null, "Andrew", "Grace", "Aston", "Sheila" };

            for(int i = 0; i < names.Length; i++)
            {
                if (!string.IsNullOrEmpty(names[i])) 
                {
                    names[i] = names[i].ToUpper();
                }
            }

            return names;
        }

        public List<string> PopulateList(List<string> peopleNames) 
        {
            var names = new string[] { "John", "Mary", "Andrew", "Grace", "Aston", "Sheila" };

            foreach (var person in names) 
            {
                peopleNames.Add(person);
            }
                
            return peopleNames;
        }

        public List<string> FixedPopulateList(List<string> peopleNames)
        {
            var names = new string[] { "John", "Mary", "Andrew", "Grace", "Aston", "Sheila" };

            if (peopleNames == null) 
            {
                peopleNames = new List<string>();
            }

            foreach (var person in names) 
            {
                peopleNames.Add(person);
            }
                
            return peopleNames;
        }
    }
}
