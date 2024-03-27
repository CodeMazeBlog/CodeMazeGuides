namespace ScopedKeyword;

public class Program
{
	static void Main(string[] args)
	{
		Span<int> heights = stackalloc int[3] { -5, 10, -1 };
		new FastStore<int>().Clone(heights);
	}
}