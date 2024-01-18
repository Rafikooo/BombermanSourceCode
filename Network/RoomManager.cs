using Photon.Pun;
using Photon.Realtime;
using UnityEngine;

namespace Network
{
	public abstract class RoomManager
	{
		static string _roomName;

		public static void SetRoomName(string roomName)
		{
			_roomName = roomName;
		}

		public static void JoinRoom()
		{

			if (!PhotonNetwork.IsConnected)
			{
				throw new System.Exception("Not Connected to Photon!\n");
			}

			if (string.IsNullOrEmpty(_roomName))
			{
				throw new System.Exception("Room name is empty!\n");
			}

			var roomOptions = new RoomOptions();
			var typedLobby = new TypedLobby(_roomName, LobbyType.Default);
			PhotonNetwork.JoinOrCreateRoom(_roomName, roomOptions, typedLobby);

		}

		public static bool IsConnectedToRoom()
		{
			return PhotonNetwork.IsConnected && PhotonNetwork.InRoom;
		}


		public static void LeaveRoom()
		{
			PhotonNetwork.LeaveRoom();
		}

		public static bool IsValidRoomName()
		{
			return !string.IsNullOrEmpty(_roomName);
		}
	}
}
