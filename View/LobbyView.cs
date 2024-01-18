using TMPro;
using UnityEngine;
using UnityEngine.UI;

namespace View
{
	public class LobbyView : MonoBehaviour
	{
		public Text status;

		public Text players;

		public Button joinRoom;

		public Button ready;

		public void UpdateLobbyStatus(string lobbyStatus)
		{
			status.text = lobbyStatus;
		}

		public void UpdatePlayersList(string players)
		{
			this.players.text = players;
		}

		public void EnableJoinRoomButton()
		{
			joinRoom.interactable = true;
		}

		public void DisableJoinRoomButton()
		{
			joinRoom.interactable = false;
		}

		public void ChangeLeaveRoomToJoinRoomButtonLabel()
		{
			joinRoom.GetComponentInChildren<Text>().text = "Join Room";
		}

		public void ChangeJoinRoomToLeaveRoomButtonLabel()
		{
			joinRoom.GetComponentInChildren<Text>().text = "Leave Room";
		}

		public void ChangeReadyNotReadyToReadyButtonLabel()
		{
			ready.GetComponentInChildren<Text>().text = "Ready!";
		}

		public void ChangeReadyToNotReadyButtonLabel()
		{
			ready.GetComponentInChildren<Text>().text = "Not Ready";
		}

		public void EnableReadyButton()
		{
			ready.interactable = true;
		}

		public void ChangeReadyToUnready()
		{
			ready.GetComponentInChildren<Text>().text = "Not Ready";
		}

		public void ChangeUnreadyToReady()
		{
			ready.GetComponentInChildren<Text>().text = "Ready!";
		}
	}
}
