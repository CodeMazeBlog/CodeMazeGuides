namespace ActionAndFuncDelegateInCSharp.Model
{
    public class Control
    {
        public int OperateCount { get; set; }

        public void Operate()
        {
            OperateCount++;
        }
    }
}