namespace ActionFuncDelegatesCSharp
{
    public class Subscriber
    {
        private string name;
        private int id;
        public Subscriber(Publisher pub, string name, int id)
        {
            this.name = name;
            this.id = id;
            pub.GetMemberDetails += ProvideMemberDetails;
        }

        private Tuple<string, int> ProvideMemberDetails()
        {
            return Tuple.Create(name, id);
        }
    }
}
