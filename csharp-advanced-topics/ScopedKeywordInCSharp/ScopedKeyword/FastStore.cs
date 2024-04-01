namespace ScopedKeyword;

public ref struct FastStore<T>
{
	private Span<T> _values;
	public int Length { get => _values.Length; }

	public FastStore()
	{
		_values = new T[3];
	}

	public void Clone(scoped ReadOnlySpan<T> values)
	{
		if (values.Length != 3)
			throw new ArgumentException($"'{nameof(values)}' must contain 3 items");

		values.CopyTo(_values);
	}
}