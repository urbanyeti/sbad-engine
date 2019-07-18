using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SBad.Visual
{
	[Flags]
	public enum Alignment
	{
		Center = 0,
		Left = 1,
		Right = 2,
		Top = 4,
		Bottom = 8
	}

	public struct Padding
	{
		public Padding(int top, int right, int bottom, int left)
		{
			Top = top;
			Right = right;
			Bottom = bottom;
			Left = left;
		}

		public int Top { get; }
		public int Right { get; }
		public int Bottom { get; }
		public int Left { get; }
	}
}
