namespace RefactoringObjectOrientationAbusers.SwitchStatements.Correct
{
    public class CargoPlane : Plane
    {
        public override int Type { get { return Cargo; } }

        public override double GetCapacity()
        {
            return 10000;
        }
    }
}
