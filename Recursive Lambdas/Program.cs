using System;

namespace Test
{
	class Program
	{
		delegate Func<Targ, TResult> Recursive<Targ, TResult>(Recursive<Targ, TResult> r);

		static void Main(string[] args)
		{
			Func<int, int> fib = Y<int, int>(f => n => n > 1 ? f(n - 1) + f(n - 2) : n);
			Func<int, int> fac = Y<int, int>(f => n => n == 1 ? n : n * f(n - 1));
		}

		static Func<Targ, TResult> Y<Targ, TResult>(Func<Func<Targ, TResult>, Func<Targ, TResult>> f)
		{
			Recursive<Targ, TResult> rec = r => a => f(r(r))(a);
			return rec(rec);
		}
	}
}
