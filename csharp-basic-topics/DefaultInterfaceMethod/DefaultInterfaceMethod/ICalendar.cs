namespace DefaultInterfaceMethod
{
    public interface ICalendar
    {
        public DateTime Date { get; set; }

        public string ShowMessage()
        {
            return "Default Calendar";
        }
    }
}
