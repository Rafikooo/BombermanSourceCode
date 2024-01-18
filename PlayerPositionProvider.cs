using UnityEngine;

public class PlayerPositionProvider : MonoBehaviour
{
	public Transform player;
	public GameObject planePrefab;
	private Vector3 _playerGridPosition;
	const float Offset = 0.1f;

	void Update()
	{
		// _playerGridPosition = GetGridPosition(player.position);
		//
		// if (!Input.GetKeyDown(KeyCode.Space)) return;
		//
		// ShowPlayerPosition();
		// HighlightAdjacentTiles();
	}

	public static Vector3 GetGridPosition(Vector3 worldPosition)
	{
		int x = Mathf.RoundToInt(worldPosition.x);
		int z = Mathf.RoundToInt(worldPosition.z);

		return new Vector3(x, Offset, z);
	}

	void ShowPlayerPosition()
	{
		var bombRange = Instantiate(planePrefab, _playerGridPosition, Quaternion.identity);
		Destroy(bombRange, 1);
	}

	void HighlightAdjacentTiles()
	{
		for (int x = -3; x <= 3; x++)
		{
			if (x == 0) continue;
			HighlightTile(new Vector3(x * EnvironmentParameters.GridScale, 0, 0));;
		}

		for (int z = -3; z <= 3; z++)
		{
			if (z == 0) continue;
			HighlightTile(new Vector3(0, 0, z * EnvironmentParameters.GridScale));;
		}
	}

	void HighlightTile(Vector3 position)
	{
		var tilePosition = _playerGridPosition + new Vector3(position.x, Offset, position.z);
		var bombRange = Instantiate(planePrefab, tilePosition, Quaternion.identity);

		Destroy(bombRange, 1);
	}
}
