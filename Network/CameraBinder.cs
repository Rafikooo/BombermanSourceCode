using System;
using System.Collections;
using Cinemachine;
using Photon.Pun;
using UnityEngine;

namespace Network
{
	public class CameraBinder : MonoBehaviourPunCallbacks
	{
		CinemachineVirtualCamera _virtualCamera;

		PhotonView _photonView;

		IEnumerator Start()
		{
			yield return new WaitForSeconds(1.5f);

			_photonView = GetComponent<PhotonView>();
			_virtualCamera = FindObjectOfType<CinemachineVirtualCamera>();

			if (!_photonView)
			{
				throw new Exception("Component PhotonView not found");
			}

			if (!_virtualCamera)
			{
				throw new Exception("No virtual camera found to bind");
			}

			if (_photonView.IsMine)
			{
				var transform1 = transform;
				_virtualCamera.Follow = transform1;
				_virtualCamera.LookAt = transform1;
			}
		}
	}
}
