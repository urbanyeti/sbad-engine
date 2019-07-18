using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;

namespace SBad.Core.Structures
{
	public class DictionaryStore<T> : IStore<T> where T : IIdentity
	{
		private Dictionary<string, T> _Items = new Dictionary<string, T>();

		public IStore<T> Add(T item)
		{
			_Items.Add(item.Id, item);
			return this;
		}

		public IStore<T> Remove(string key)
		{
			if (_Items.ContainsKey(key))
			{
				_Items.Remove(key);
			}
			return this;
		}

		public bool Contains(string key)
		{
			return _Items.ContainsKey(key);
		}

		public IEnumerator<T> GetEnumerator() { return _Items.Values.ToList().GetEnumerator(); }

		IEnumerator IEnumerable.GetEnumerator() { return GetEnumerator(); }

		public void ForEach(Action<T> action)
		{
			_Items.Values.ToList().ForEach(action);
		}

		public T this[string key]
		{
			get { return _Items[key]; }
			set { _Items[key] = value; }
		}
	}
}
