using System;
using System.Collections.Generic;
using System.Diagnostics;

namespace ImageUtopia.Utils;

public static class ResultExtensions
{
	public static IEnumerable<T> ResultOrDebug<T, TE>(this IEnumerable<Result<T, TE>> results) where T : class where TE : Exception
	{
		foreach (var result in results)
		{
			if (result.IsOk) {
				yield return result.Unwrap();
			} else {
				Debug.WriteLine(result.UnwrapErr().Message);
			}
		}
	}
}