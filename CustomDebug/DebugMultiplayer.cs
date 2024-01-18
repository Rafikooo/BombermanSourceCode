using Network;
using UnityEngine;
using Photon.Pun;
using Photon.Realtime;
using UnityEngine.SceneManagement;

namespace CustomDebug
{
	public class DebugMultiplayer : MonoBehaviourPunCallbacks
	{
		void Start()
		{
			gameObject.AddComponent<Connection>();
		}

		public override void OnConnectedToMaster()
		{
			_joinRoom();
		}

		public override void OnJoinedRoom()
		{
			UnityEngine.SceneManagement.SceneManager.LoadScene("GUI", LoadSceneMode.Additive);
		}

		public override void OnCreatedRoom()
		{
		}

		static void _joinRoom()
		{
			PhotonNetwork.JoinOrCreateRoom(
				"Room",
				new RoomOptions(),
				TypedLobby.Default
			);
		}

	}
}
