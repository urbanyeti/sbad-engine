using System;
using System.Collections.Generic;
using System.Linq;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using SBad.Visual.Sprites;
using SBad.Visual.UI.Buttons;

namespace SBad.Visual.UI
{
    public class Row : VisualElement
    {
        public List<IVisualElement> Elements { get; set; } = new List<IVisualElement>();

        public Row AddElement(IVisualElement element)
        {
            element.Container = this;
            Elements.Add(element);
            _ResizeElements();
            _RepositionElements();
            if (element is IButton button)
            {
                _AddButton(button);
            }
            return this;
        }

        private Vector2 _GetCombinedElementPosition()
        {
            int elementWidth = Elements.Sum(x => x.Padding.Left + x.Width + x.Padding.Right);
            int elementHeight = Elements.Max(x => x.Height);

            return BoundaryBox.PositionOn(elementWidth, elementHeight, Alignment);
        }

        public override void Draw(SpriteBatch spriteBatch, TextureFrameStore textureFrames)
        {
            if (Color != null)
            {
                this.ColorFill(spriteBatch, textureFrames);
            }

            Elements.ForEach(x => x.Draw(spriteBatch, textureFrames));

            if (BorderWidth > 0)
            {
                this.DrawBorder(spriteBatch, textureFrames);
            }
        }

        private void _ResizeElements()
        {
            // Resize widths
            int fixedWidth = Elements.Where(x => !x.AutoWidth).Sum(x => x.Width);
            int remainderWidth = Width - fixedWidth;

            List<IVisualElement> autoElements = Elements.Where(x => x.AutoWidth).ToList();
            if (autoElements.Count > 0)
            {
                int newWidth = remainderWidth / autoElements.Count;
                autoElements.ForEach(x => x.SetWidth(newWidth));
            }

            // Resize heights
            Elements.ForEach(x =>
            {
                if (x.AutoHeight)
                {
                    x.SetHeight(Height);
                }
            });
        }

        private void _RepositionElements()
        {
            Vector2 alignedPosition = _GetCombinedElementPosition();
            int runningX = (int)Math.Ceiling(alignedPosition.X);
            int y = (int)alignedPosition.Y;

            for (int i = 0; i < Elements.Count; i++)
            {
                IVisualElement element = Elements[i];
                element.SetPosition(new Vector2(
                    element.Padding.Left + runningX,
                    y + element.Padding.Top));

                runningX += element.Padding.Left + element.Width + element.Padding.Right;
            }
        }

        private void _AddButton(IButton button)
        {
            var container = this.Container;
            while(container.Container != null)
            {
                container = container.Container;
            }
            if (container is Window window)
            {
                window.Buttons.Add(button);
            }
        }
    }
}
