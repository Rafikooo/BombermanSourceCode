using Photon.Pun;
using UnityEngine;

public class SceneManager : MonoBehaviourPunCallbacks
{
	readonly string[] _levels = new string[] {
		"LEVEL_01",
		"LEVEL_02",
		"LEVEL_03",
	};

	public void LoadMainMenu()
	{
		UnityEngine.SceneManagement.SceneManager.LoadScene("MainMenu");
	}

	public void LoadCharacterSelect()
	{
		UnityEngine.SceneManagement.SceneManager.LoadScene("CharacterSelect");
	}

	public void LoadLobby()
	{
		UnityEngine.SceneManagement.SceneManager.LoadScene("Lobby");
	}

	public void QuitGame()
	{
		Application.Quit();
	}
}
