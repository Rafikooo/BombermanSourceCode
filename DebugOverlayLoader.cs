using UnityEngine;
using UnityEngine.SceneManagement;

public class DebugOverlayLoader : MonoBehaviour
{
	[SerializeField] private string uiSceneName = "GameplayOverlay";

	void Start()
	{
		if (UnityEngine.SceneManagement.SceneManager.GetSceneByName(uiSceneName).isLoaded)
		{
			return;
		}

		UnityEngine.SceneManagement.SceneManager.LoadScene(uiSceneName, LoadSceneMode.Additive);
	}
}
