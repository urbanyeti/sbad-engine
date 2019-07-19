using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using SBad.Core.Structures;
using SBad.Visual.Sprites;
using SBad.Visual.UI.Buttons;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SBad.Visual.UI
{
    public class Window : VisualElement
    {
        public List<Div> Divs { get; } = new List<Div>();
        public DictionaryStore<IButton> Buttons { get; private set; } = new DictionaryStore<IButton>();

        public Window AddDiv(Div div)
        {
            div.Container = this;
            Divs.Add(div);
            _ResizeDivs();
            _RepositionDivs();
            return this;
        }

        public override void Draw(SpriteBatch spriteBatch, TextureFrameStore textureFrames)
        {
            this.DrawBorder(spriteBatch, textureFrames, BorderWidth, BorderColor);
            Divs.ForEach(x => x.Draw(spriteBatch, textureFrames));
        }

        private void _ResizeDivs()
        {
            // Resize widths
            int fixedWidth = Divs.Where(x => !x.AutoWidth).Sum(x => x.Width);
            int remainderWidth = Width - fixedWidth;

            List<Div> autoDivs = Divs.Where(x => x.AutoWidth).ToList();
            if (autoDivs.Count > 0)
            {
                int newWidth = remainderWidth / autoDivs.Count;
                autoDivs.ForEach(x => x.Width = newWidth);
            }

            // Resize heights
            Divs.ForEach(x =>
            {
                if (x.AutoHeight)
                {
                    x.Height = Height;
                }
            });
        }

        private Vector2 _GetCombinedDivPosition()
        {
            int divWidth = Divs.Sum(x => x.Padding.Left + x.Width + x.Padding.Right);
            int divHeight = Divs.Max(x => x.Height);

            return BoundaryBox.PositionOn(divWidth, divHeight, Alignment);
        }

        private void _RepositionDivs()
        {
            Vector2 alignedPosition = _GetCombinedDivPosition();
            int runningX = (int)alignedPosition.X;
            int y = (int)alignedPosition.Y;

            for (int i = 0; i < Divs.Count; i++)
            {
                Div div = Divs[i];
                div.SetPosition(new Vector2(
                    div.Padding.Left + runningX,
                    y + div.Padding.Top));

                runningX += div.Padding.Left + div.Width + div.Padding.Right;
            }
        }
    }
}
