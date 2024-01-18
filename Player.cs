using System.Collections;
using Destruction;
using Model;
using UnityEngine;
using Photon.Pun;
using StarterAssets;

public class Player : MonoBehaviour, IExplosionAffectable
{
	AudioSource _deathSound;

	void Start()
	{
		_deathSound = GetComponent<AudioSource>();
	}

	public void ReactToExplosion()
	{
		GameplayModel.SetPlayerDead();
		_deathSound.Play();

		var controller = gameObject.GetComponent<ThirdPersonController>();
		if (controller != null)
		{
			controller.enabled = false;
		}

		var meshRenderer = gameObject.GetComponent<MeshRenderer>();
		if (meshRenderer != null)
		{
			meshRenderer.enabled = false;
		}

		var skinnedMeshRenderer = gameObject.GetComponentInChildren<SkinnedMeshRenderer>();
		if (skinnedMeshRenderer != null)
		{
			skinnedMeshRenderer.enabled = false;
		}

		StartCoroutine(DestroyPlayer());
	}

	IEnumerator DestroyPlayer()
	{
		yield return new WaitForSeconds(_deathSound.clip.length);
		PhotonNetwork.Destroy(gameObject);
	}

	public void EnableMovement()
	{
		gameObject.GetComponent<ThirdPersonController>().enabled = true;
	}

	public void DisableMovement()
	{
		gameObject.GetComponent<ThirdPersonController>().enabled = false;
	}
}
