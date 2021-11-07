using Microsoft.Xna.Framework;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SBad.Visual
{
	public interface IVisualElement : IDraw
	{
		Alignment Alignment { get; set; }
		IVisualElement Container { get; set; }
		Padding Padding { get; set; }
        Color Color { get; set; }
        Color BorderColor { get; set; }
        int BorderWidth { get; set; }
        bool AutoHeight { get; set; }
        bool AutoWidth { get; set; }
        void SetWidth(int width);
        void SetHeight(int height);
	}
}
