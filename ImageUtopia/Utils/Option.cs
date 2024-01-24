using System;

namespace ImageUtopia.Utils;

public readonly struct Option<T> where T : class
{
	private readonly T? _value;

	private Option(T? value) {
		_value = value;
	}

	public static Option<T> Some(T value) => new(value);
	public static Option<T> None() => new(default);

	public bool IsSome => _value != null;
	public bool IsNone => _value == null;

	public T Unwrap() => _value switch
	{
		null => throw new InvalidOperationException("Option is empty"),
		_ => _value
	};
	
	public T UnwrapOrDefault(T defaultValue) => _value switch
	{
		null => defaultValue,
		_ => _value
	};
	
	public T Expect(string message) => _value switch
	{
		null => throw new InvalidOperationException(message),
		_ => _value
	};
	
	public Option<TO> Map<TO>(Func<T, TO> mapper) where TO : class, IEquatable<TO> => _value switch
	{
		null => Option<TO>.None(),
		_ => Option<TO>.Some(mapper(_value)),
	};

	public static implicit operator Option<T>(T value) => Some(value);
}