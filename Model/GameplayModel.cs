using System.Linq;
using ExitGames.Client.Photon;
using Photon.Pun;
using UnityEngine;

namespace Model
{
	public class GameplayModel : MonoBehaviourPunCallbacks
	{
		const int MaxPlayers = 4;

		string[] _playerNames;

		public override void OnJoinedRoom()
		{
			InitPlayerProperties();
		}

		static void InitPlayerProperties()
		{
			PhotonNetwork.LocalPlayer.SetCustomProperties(new Hashtable{
				{"IsReady", false},
				{"IsAlive", true}
			});
		}

		public static void SetNickName(string nickName)
		{
			PhotonNetwork.LocalPlayer.NickName = nickName;
		}

		public static void SetPlayerReady()
		{
			if (
				PhotonNetwork.LocalPlayer.CustomProperties.ContainsKey("IsReady") &&
				PhotonNetwork.LocalPlayer.CustomProperties["IsReady"] is bool isReady
			)
			{
				PhotonNetwork.LocalPlayer.SetCustomProperties(new Hashtable{{"IsReady", !isReady}});
			}
			else
			{
				PhotonNetwork.LocalPlayer.SetCustomProperties(new Hashtable{{"IsReady", true}});
			}


			if (!IsReadyToStart()) return;

			PhotonNetwork.LoadLevel("LEVEL_01");
		}

		public override void OnPlayerPropertiesUpdate(Photon.Realtime.Player targetPlayer, Hashtable changedProps)
		{

		}

		public static bool IsValidNickName()
		{
			return PhotonNetwork.LocalPlayer.NickName.Length > 0;
		}

		public static string GetPlayersNames()
		{
			return string.Join(", ", PhotonNetwork.PlayerList.Select(player => player.NickName).ToArray());
		}

		static bool IsReadyToStart()
		{
			return HasEnoughPlayers() && AllPlayersReady();
		}

		static bool IsRoomFull()
		{
			return PhotonNetwork.CurrentRoom.PlayerCount == MaxPlayers;
		}

		static bool HasEnoughPlayers()
		{
			return PhotonNetwork.CurrentRoom.PlayerCount >= GameParameters.MinimalPlayersToStart;
		}

		public static void SetPlayerUnready()
		{
			PhotonNetwork.LocalPlayer.SetCustomProperties(new Hashtable{{"IsReady", false}});
		}

		static bool AllPlayersReady()
		{
			return PhotonNetwork.PlayerList.All(
				player => (bool)player.CustomProperties["IsReady"]
			);
		}

		public static void SetPlayerDead()
		{
			PhotonNetwork.LocalPlayer.SetCustomProperties(new Hashtable{{"IsAlive", false}});
		}

		public static string GetGameResult()
		{
			var alivePlayers = PhotonNetwork.PlayerList.Where(
				player => (bool)player.CustomProperties["IsAlive"]
			).ToArray();

			return alivePlayers.Length switch{
				1 => alivePlayers[0].NickName + " won!",
				0 => "Draw!",
				_ => "Game over!"
			};
		}
	}
}
