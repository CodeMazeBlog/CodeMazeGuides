namespace WorkingWithRestSharp.DataTransferObject
{
    public class UserList : PagingInformation
    {
        public List<UserData> Data { get; set; }
        public Support Support { get; set; }
    }
}
