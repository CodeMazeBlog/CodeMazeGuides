using System.Text;

namespace MethodOverridingInCSharp
{
    public class Cube : Shape
    {
        public int Edge { get; set; }

        public override string Draw()
        {
            var builder = new StringBuilder();

            builder.AppendLine(base.Draw());
            builder.AppendLine($"Drawing a cube with edges of length, width, and height of {Edge} units");

            return builder.ToString();
        }
    }
}
