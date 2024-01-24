using System;
using System.Diagnostics;

namespace ImageUtopia.Utils;

public readonly struct Result<T, TE> where T : class where TE : Exception
{
	private readonly T? _result;
	private readonly TE? _exception;
	
	private Result(T? result, TE? exception) {
		_result = result;
		_exception = exception;
	}
	
	public static Result<T, TE> Ok(T result) => new(result, default);
	public static Result<T, TE> Err(TE exception) => new(default, exception);
	
	public bool IsOk => _result != null;
	public bool IsErr => _result == null;
	
	public T Unwrap() => (_result, _exception) switch
	{
		(null, not null) => throw _exception,
		(not null, null) => _result,
		(_, _) => throw new UnreachableException()
	};
	
	public TE UnwrapErr() => (_result, _exception) switch
	{
		(null, not null) => _exception,
		(not null, null) => throw new InvalidOperationException("Cannot unwrap error of Ok result"),
		(_, _) => throw new UnreachableException()
	};
	
	public T UnwrapOrDefault(T defaultValue) => (_result, _exception) switch
	{
		(null, not null) => defaultValue,
		(not null, null) => _result,
		(_, _) => throw new UnreachableException()
	};
	
	public Result<TO, TE> Map<TO>(Func<T, TO> mapper) where TO : class =>
		(_result, _exception) switch
		{
			(null, not null) => Result<TO, TE>.Err(_exception),
			(not null, null) => Result<TO, TE>.Ok(mapper(_result)),
			(_, _) => throw new UnreachableException()
		};
	
	public static implicit operator Result<T, TE>(T value) => Ok(value);
	public static implicit operator Result<T, TE>(TE exception) => Err(exception);
	public TO Match<TO>(Func<T, TO> success, Func<TE, TO> failure) =>
		!IsErr ? success(_result!) : failure(_exception!);
}