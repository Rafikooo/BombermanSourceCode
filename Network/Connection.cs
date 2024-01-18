using UnityEngine;
using Photon.Pun;

namespace Network
{
	public class Connection : MonoBehaviourPunCallbacks
	{
		static Connection _instance;

		void Awake()
		{
			if (_instance == null)
			{
				_instance = this;
				DontDestroyOnLoad(gameObject);
				PhotonNetwork.AutomaticallySyncScene = true;

				Debug.Log(
					PhotonNetwork.ConnectUsingSettings() ? "Connected to server\n " : "Falling Connecting to Server\n");
			}
			else if (_instance != this)
			{
				Destroy(gameObject);
			}
		}

		public override void OnConnectedToMaster()
		{
			base.OnConnectedToMaster();
		}

		public override void OnJoinedLobby()
		{
		}

		public override void OnJoinedRoom()
		{
		}


		// void LoadArena()
		// {
		// 	if (PhotonNetwork.CurrentRoom.PlayerCount > 1 || Application.isEditor)
		// 	{
		// 		PhotonNetwork.LoadLevel("LEVEL_01");
		// 		// SceneManager.LoadScene("GameplayOverlay", LoadSceneMode.Additive);
		//
		// 		StartCoroutine(LoadUIAdditively());
		// 	}
		// 	else
		// 	{
		//
		// 	}
		// }
		//
		// static IEnumerator LoadUIAdditively()
		// {
		// 	yield return new WaitUntil(() => PhotonNetwork.LevelLoadingProgress >= 1);
		//
		// 	SceneManager.LoadScene("GameplayOverlay", LoadSceneMode.Additive);
		// }
	}
}
