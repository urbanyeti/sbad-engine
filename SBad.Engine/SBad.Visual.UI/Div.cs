using System.Collections.Generic;
using System.Linq;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using SBad.Visual;
using SBad.Visual.Sprites;

namespace SBad.Visual.UI
{
	public class Div : VisualElement
	{
        public Color Color { get; set; }
		public List<Row> Rows { get; set; } = new List<Row>();

		public Div AddRow(Row row)
		{
			row.Container = this;
			Rows.Add(row);
            _ResizeRows();
            _RepositionRows();

            return this;
		}

		public Div AddRow(Alignment alignment, Padding padding)
		{
			var row = new Row
			{
				Container = this,
				Alignment = alignment,
				Width = Width,
				Padding = padding
			};
			return AddRow(row);
		}

		public override void Draw(SpriteBatch spriteBatch, TextureFrameStore textureFrames)
		{
            if (BorderWidth > 0)
            {
                this.DrawBorder(spriteBatch, textureFrames, BorderWidth, Color);
            }
			Rows.ForEach(x => x.Draw(spriteBatch, textureFrames));
		}

        private Vector2 _GetCombinedRowPosition()
        {
            int rowWidth = Rows.Max(x => x.Width);
            int rowHeight = Rows.Sum(x => x.Padding.Top + x.Height + x.Padding.Bottom);

            return BoundaryBox.PositionOn(rowWidth, rowHeight, Alignment);
        }

        private void _ResizeRows()
        {
            // Resize heights
            int fixedHeight = Rows.Where(x => !x.AutoHeight).Sum(x => x.Height);
            int remainderHeight = Height - fixedHeight;

            List<Row> autoRows = Rows.Where(x => x.AutoHeight).ToList();
            if (autoRows.Count > 0)
            {
                int newHeight = remainderHeight / autoRows.Count;
                autoRows.ForEach(x => x.Height = newHeight);
            }

            // Resize widths
            Rows.ForEach(x =>
            {
                if (x.AutoWidth)
                {
                    x.Width = Width;
                }
            });
        }


        private void _RepositionRows()
		{
            Vector2 alignedPosition = _GetCombinedRowPosition();
            int x = (int)alignedPosition.X;
            int runningY = (int)alignedPosition.Y;

            for (int i = 0; i < Rows.Count; i++)
            {
                Row row = Rows[i];
                row.SetPosition(new Vector2(
                    row.Padding.Left + x,
                    runningY + row.Padding.Top));

                runningY += row.Padding.Top + row.Height + row.Padding.Bottom;
            }
		}
	}
}
