using TMPro;
using UnityEngine;
using UnityEngine.UI;

namespace View
{
	public class GUIView : MonoBehaviour
	{
		public Text countdown;

		public TMP_Text launch;

		public TMP_Text gameover;

		public void UpdateRemainingTime(int remainingTimeInSeconds)
		{
			var minutes = remainingTimeInSeconds / 60;
			var seconds = remainingTimeInSeconds % 60;

			countdown.text = $"{minutes:00}:{seconds:00}";
		}

		public void UpdateCenterText(string text)
		{
			launch.text = text;
		}

		public void ShowGameOverText()
		{
			gameover.enabled = true;
		}
	}
}
