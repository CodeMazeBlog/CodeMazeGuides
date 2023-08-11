namespace StringFormattableString
{
    public class FormattableStringsMethods
    {
        public string StringExample() 
        {
            var studentName = "John";
            var studentAge = 30;
            var message = $"My name is {studentName} and I am {studentAge} years old.";

            return message;
        }

        public FormattableString FormattableStringExample() 
        {
            var studentName = "John";
            var studentAge = 30;
            FormattableString message = $"My name is {studentName} and I am {studentAge} years old.";

            return message;
        }


    }
}
