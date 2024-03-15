using System.Text;
using System.Text.Json;

namespace CustomNamingPolicy;

public class NodeSeparatorPolicy : JsonNamingPolicy
{
    public override string ConvertName(string name)
    {
        if (name is null)
        {
            throw new ArgumentNullException(nameof(name));
        }
        var sb = new StringBuilder();
        sb.Append(char.ToLower(name[0]));
        for (int i = 1; i < name.Length; i++)
        {
            if (char.IsUpper(name[i]))
            {
                sb.Append($"/{char.ToLower(name[i])}");
            }
            else
            {
                sb.Append(name[i]);
            }
        }
        return sb.ToString();
    }
}
