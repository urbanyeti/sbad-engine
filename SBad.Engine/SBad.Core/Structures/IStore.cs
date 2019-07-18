using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SBad.Core.Structures
{
	public interface IStore<T> : IEnumerable<T>
	{
		bool Contains(string key);
		IStore<T> Add(T item);
		IStore<T> Remove(string key);
		T this[string key] { get; set; }

		void ForEach(Action<T> action);
	}
}
