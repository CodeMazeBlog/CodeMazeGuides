namespace RefactoringObjectOrientationAbusers.SwitchStatements.Correct
{
    public class MilitaryPlane : Plane
    {
        public override int Type { get { return Military; } }

        public override double GetCapacity()
        {
            return 50000;
        }
    }
}
