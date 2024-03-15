namespace RefactoringObjectOrientationAbusers.SwitchStatements.Correct
{
    public class PassengerPlane : Plane
    {
        public override int Type { get { return Passenger; } }

        public override double GetCapacity()
        {
            return 2000;
        }
    }
}
