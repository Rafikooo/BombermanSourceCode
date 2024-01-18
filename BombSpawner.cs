using Photon.Pun;
using UnityEngine;

public class BombSpawner : MonoBehaviour
{
	public GameObject bombPrefab;

	string _bombPrefabName;

	PhotonView _photonView;

	void Start()
	{
		_photonView = GetComponent<PhotonView>();
		_bombPrefabName = bombPrefab.name;
	}

	void Update()
	{
		if (Input.GetKeyDown(KeyCode.Space) && _photonView.IsMine)
		{
			PhotonNetwork.Instantiate(
				_bombPrefabName,
				PlayerPositionProvider.GetGridPosition(transform.position),
				Quaternion.identity
			);
		}
	}
}
