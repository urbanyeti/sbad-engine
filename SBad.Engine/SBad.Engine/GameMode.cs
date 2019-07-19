using SBad.Core.Structures;
using SBad.Visual;
using SBad.Visual.UI;
using SBad.Visual.UI.Buttons;
using System.Collections.Generic;
using System.Linq;

namespace SBad.Engine
{
    public abstract class GameMode
    {
        public GameMode()
        {
            VisualElements = new DictionaryStore<IVisualElement>();
        }

        public DictionaryStore<IVisualElement> VisualElements { get; private set; }
        public IEnumerable<IButton> Buttons =>
            VisualElements
                .Where(x => x is Window)
                .Select(x => x as Window)
                .SelectMany(x => x.Buttons);

        public abstract void LoadContent();
    }
}
