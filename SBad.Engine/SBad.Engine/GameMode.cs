using SBad.Core.Structures;
using SBad.Visual;
using SBad.Visual.UI.Buttons;

namespace SBad
{
    public abstract class GameMode
    {
        public GameMode()
        {
            VisualElements = new DictionaryStore<IVisualElement>();
            Buttons = new DictionaryStore<IButton>();
        }
        public DictionaryStore<IVisualElement> VisualElements { get; private set; }
        public DictionaryStore<IButton> Buttons { get; private set; }

        public abstract void LoadContent();
    }
}
