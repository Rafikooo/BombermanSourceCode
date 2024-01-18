using System;
using Model;
using Network;
using Photon.Pun;
using UnityEngine;
using UnityEngine.UI;
using View;

namespace Controller
{
	public class LobbyController : MonoBehaviourPunCallbacks
	{
		LobbyView _lobbyView;

		void Start()
		{
			_lobbyView = FindObjectOfType<LobbyView>();

			if (_lobbyView == null)
			{
				throw new Exception("LobbyView not found, please add it to the Canvas in the scene");
			}

			_lobbyView.status.text = "Enter Nickname and Room Name";
		}

		public void UpdateNickName(Text nickName)
		{
			GameplayModel.SetNickName(nickName.text);

			if (GameplayModel.IsValidNickName() && RoomManager.IsValidRoomName())
			{

				_lobbyView.EnableJoinRoomButton();
			}
		}

		public void UpdateRoomName(Text roomName)
		{
			RoomManager.SetRoomName(roomName.text);

			if (GameplayModel.IsValidNickName() && RoomManager.IsValidRoomName())
			{
				_lobbyView.EnableJoinRoomButton();
			}
			else
			{
				_lobbyView.DisableJoinRoomButton();
			}
		}

		public void JoinRoom()
		{
			_lobbyView.joinRoom.interactable = false;
			RoomManager.JoinRoom();
			_lobbyView.status.text = "Joining Room...";
		}

		public void LeaveRoom()
		{
			RoomManager.LeaveRoom();
			_lobbyView.ChangeLeaveRoomToJoinRoomButtonLabel();
			_lobbyView.status.text = "Room Left";
		}

		public override void OnJoinedRoom()
		{
			_lobbyView.joinRoom.interactable = true;
			_lobbyView.ChangeJoinRoomToLeaveRoomButtonLabel();
			_lobbyView.EnableReadyButton();
			_lobbyView.status.text = "Room Joined";
			_lobbyView.UpdatePlayersList(GameplayModel.GetPlayersNames());
		}

		public override void OnPlayerEnteredRoom(Photon.Realtime.Player newPlayer)
		{
			_lobbyView.UpdatePlayersList(GameplayModel.GetPlayersNames());
		}

		public void SetPlayerReady()
		{
			GameplayModel.SetPlayerReady();
			// _lobbyView.ChangeReadyToUnready();
		}

		public void SetPlayerUnready()
		{
			GameplayModel.SetPlayerUnready();
			// _lobbyView.ChangeUnreadyToReady();
		}
	}
}
