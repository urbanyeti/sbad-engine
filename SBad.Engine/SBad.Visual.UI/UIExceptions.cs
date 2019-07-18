using System;
using System.Runtime.Serialization;

namespace SBad.Visual.UI
{
	[Serializable]
	internal class ButtonBuildFailure : Exception
	{
		public ButtonBuildFailure()
		{
		}

		public ButtonBuildFailure(string message) : base(message)
		{
		}

		public ButtonBuildFailure(string message, Exception innerException) : base(message, innerException)
		{
		}

		protected ButtonBuildFailure(SerializationInfo info, StreamingContext context) : base(info, context)
		{
		}
	}

	[Serializable]
	internal class PictureBuildFailure : Exception
	{
		public PictureBuildFailure()
		{
		}

		public PictureBuildFailure(string message) : base(message)
		{
		}

		public PictureBuildFailure(string message, Exception innerException) : base(message, innerException)
		{
		}

		protected PictureBuildFailure(SerializationInfo info, StreamingContext context) : base(info, context)
		{
		}
	}
}