using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace StaticClasses
{
    public class CollegeStudent
    {
        //private fields 
        private string _name;

        //non-static properties
        public int Id { get; set; }
        public string Name { get { return _name; } set => _name = value; }
        public DateTime DateOfBirth { get; set; }

        //non-static methods
        //function to return the student's age
        public int CalculateAge(DateTime DateOfBirth)
        {
            //get today's date 
            var today = DateTime.Today;

            //calculate age
            var age =today.Year - DateOfBirth.Year;

            //Go back to the previous year in case the student was born on a leap year
            if (DateOfBirth.Date > today.AddYears(-age))
            {
                age--;
            }
            return age;
        }

        //function to return the student's details on the screen
        public string StudentDetails()
        {
            var studentDetails = string.Empty;
            studentDetails = Name + " " + DateOfBirth + " " + CalculateAge(DateOfBirth);
            return studentDetails;
        }
    }
}
