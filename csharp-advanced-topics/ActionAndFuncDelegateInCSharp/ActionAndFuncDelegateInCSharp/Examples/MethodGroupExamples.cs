using ActionAndFuncDelegateInCSharp.Model;

namespace ActionAndFuncDelegateInCSharp.Examples
{
    public class MethodGroupExamples
    {
        public void Execute()
        {

            void InspectText(Button button) { /* logic */}

            new List<Button>().ForEach(InspectText);

            // Without method group, we would have needed to write above as below which is a little uglier!
            new List<Button>().ForEach(x => InspectText(x));
        }
    }
}