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
	
	public T UnwrapOrDefault(T defaultValue) => (_result, _exception) switch
	{
		(null, not null) => defaultValue,
		(not null, null) => _result,
		(_, _) => throw new UnreachableException()
	};
}