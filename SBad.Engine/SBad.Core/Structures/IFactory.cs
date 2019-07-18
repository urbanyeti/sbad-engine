using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SBad
{
	public interface IFactory<T>
	{
		IFactoryJob<T> Build();
	}

	public interface IFactoryJob<T>
	{
		T Run();
	}
}
