using System.Collections;
using UnityEngine;
using Photon.Pun;

namespace Network
{
    public class PlayersSpawner : MonoBehaviourPunCallbacks
    {
        public GameObject playerPrefab;

        public Transform[] spawnPoints;

        public IEnumerator Start()
        {
            while (!PhotonNetwork.IsConnectedAndReady || !PhotonNetwork.InRoom)
            {
                yield return null;
            }

            if (PhotonNetwork.IsMasterClient)
            {
                PhotonNetwork.Instantiate(playerPrefab.name, spawnPoints[0].position, Quaternion.identity);
            }
            else
            {
                PhotonNetwork.Instantiate(playerPrefab.name, spawnPoints[1].position, Quaternion.identity);
            }
        }
    }
}
