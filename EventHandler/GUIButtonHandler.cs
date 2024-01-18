using MyEvent;
using UnityEngine;

namespace EventHandler
{
	public class ReadyButtonHandler : MonoBehaviour
	{
		void OnReadyButtonClick()
		{
			GUIEvents.OnReadyButtonClicked += HandleReadyButtonClicked;
		}

		void HandleReadyButtonClicked()
		{

		}
	}
}
