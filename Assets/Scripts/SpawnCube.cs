using UnityEngine;

public class SpawnCube : MonoBehaviour {

	[SerializeField]
	GameObject spawnPrefab = null;

	[SerializeField]
	float spawnChancePerSecond = 1.0f;
	
	void OnDrawGizmos() {
		Gizmos.DrawWireCube(transform.position, transform.localScale);
	}

	Vector3 GenerateSpawnLocation() {
		return new Vector3(
			Random.Range(transform.position.x - transform.localScale.x/2, transform.position.x + transform.localScale.x/2),
			Random.Range(transform.position.y - transform.localScale.y/2, transform.position.y + transform.localScale.y/2),
			Random.Range(transform.position.z - transform.localScale.z/2, transform.position.z + transform.localScale.z/2)
		);
	}

	void FixedUpdate () {
		float r = Random.Range(0.0f, 1.0f);
		if (r < spawnChancePerSecond * Time.fixedDeltaTime) {
			Instantiate(spawnPrefab, GenerateSpawnLocation(), Quaternion.identity);
		}
	}
}
