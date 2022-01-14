namespace WorkingWithRestSharp
{
    public class UserDetails
    {
        public int Page { get; set; }
        public int Per_Page { get; set; }
        public int Total { get; set; }
        public int Total_Pages { get; set; }
        public List<UserData> Data { get; set; }
        public Support Support { get; set; }
    }

    public class Support
    {
        public string Url { get; set; }
        public string Text { get; set; }
    }

    public class UserData
    {
        public int Id { get; set; }
        public string Email { get; set; }
        public string First_Name { get; set; }
        public string Last_Name { get; set; }
        public string Avatar { get; set; }
    }

    public class SingleUserDetails
    {
        public UserData Data { get; set; }
        public Support Support { get; set; }
    }

    public class UserJobDetailsRequest
    {
        public string Name { get; set; }
        public string Job { get; set; }
    }

    public class UserJobDetails
    {
        public string Name { get; set; }
        public string Job { get; set; }
        public string Id { get; set; }
        public string CreatedAt { get; set; }
    }


    public class UpdateUserJobDetailsRequest
    {
        public string Id { get; set; }
        public string Name { get; set; }
        public string Job { get; set; }
    }

    public class UpdateUserJobDetails
    {
        public string Name { get; set; }
        public string Job { get; set; }
        public string UpdatedAt { get; set; }
    }

    public class DeleteResponse
    {
        public string Message { get; set; }
    }

}