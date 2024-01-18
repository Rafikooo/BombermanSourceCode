using System;
using Unity.VisualScripting;

namespace MyEvent
{
	public static class GUIEvents
	{
		public static event Action OnReadyButtonClicked;

		public static void InvokeOnReadyButtonClicked()
		{
			OnReadyButtonClicked?.Invoke();
		}
	}
}
