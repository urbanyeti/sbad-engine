using System;

namespace SBad.Visual.UI.Buttons
{
	public class ButtonFactory : IFactory<IButton>
	{
		private readonly IVisualElement _Container;
		private readonly IButtonBuilder _buttonBuilder;
		public ButtonFactory(IVisualElement container, IButtonBuilder builder)
		{
			_Container = container;
			_buttonBuilder = builder;
		}

		public IFactoryJob<IButton> Build()
		{
			return new ButtonFactoryJob(_buttonBuilder);
		}

		public IFactoryJob<IButton> Build(string name, int position, ButtonLayout buttonLayout, Action<IButton> action)
		{
			_buttonBuilder.SetName(name);
			_buttonBuilder.SetSize();
			_buttonBuilder.SetVisual();
			_buttonBuilder.SetPosition(buttonLayout, _Container.BoundaryBox, position);
			_buttonBuilder.SetHoverAnimation();
			_buttonBuilder.SetClickAnimation();
			_buttonBuilder.SetAction(action);
			return Build();
		}

		public IButton Execute()
		{
			return _buttonBuilder.Execute();
		}
	}

	public class ButtonFactoryJob : IFactoryJob<IButton>
	{
		public ButtonFactoryJob(IButtonBuilder builder)
		{
			_buttonBuilder = builder;
		}

		private readonly IButtonBuilder _buttonBuilder;

		public IButton Run()
		{
			return _buttonBuilder.Execute();
		}
	}
}
