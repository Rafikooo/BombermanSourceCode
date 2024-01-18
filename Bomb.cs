using Destruction;
using UnityEngine;

public class Bomb : MonoBehaviour
{
	public ParticleSystem explosionEffect;

	AudioSource _explosionSound;

	const float DetonationTime = 1f;


	void Start()
	{
		_explosionSound = GetComponent<AudioSource>();
		Invoke(nameof(Detonate), DetonationTime);
	}

	void Detonate()
	{
		Vector3 bombPosition = transform.position;

		var explosionInstance = Instantiate(explosionEffect, bombPosition, Quaternion.identity);
		explosionInstance.Play();
		_explosionSound.PlayOneShot(_explosionSound.clip);

		for (var x = -3; x <= 3; x++)
		{
			if (x == 0) continue;

			DestroyDestructible(new Vector3(bombPosition.x + (EnvironmentParameters.GridScale*x), 0, bombPosition.z));
		}

		for (var z = -3; z <= 3; z++)
		{
			if (z == 0) continue;
			DestroyDestructible(new Vector3(bombPosition.x, 0, bombPosition.z + (EnvironmentParameters.GridScale*z)));
		}

		DestroyDestructible(bombPosition);

		Destroy(gameObject, _explosionSound.clip.length);
	}

	void DestroyDestructible(Vector3 position)
	{
		var explosionInstance = Instantiate(explosionEffect, position, Quaternion.identity);
		explosionInstance.Play();

		Collider[] hitColliders = Physics.OverlapSphere(position, EnvironmentParameters.ExplosionRadius);
		foreach (Collider hitCollider in hitColliders)
		{
			IExplosionAffectable explosionAffectable = hitCollider.GetComponent<IExplosionAffectable>();

			explosionAffectable?.ReactToExplosion();
		}
	}
}
