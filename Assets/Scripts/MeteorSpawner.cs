using System.Collections;
using UnityEngine;

public class MeteorSpawner : MonoBehaviour {

	public GameObject meteorPrefab;
	public float distance = 20f;
	public float spawnDelay = 1f;
	public Transform meteorParent;

	void Start ()
	{
		StartCoroutine(SpawnMeteor());
	}

	IEnumerator SpawnMeteor()
	{
		Vector3 pos = Random.onUnitSphere * distance;
		GameObject meteor = Instantiate(meteorPrefab, pos, Quaternion.identity);
		meteor.transform.parent = meteorParent;

		yield return new WaitForSeconds(1f);

		StartCoroutine(SpawnMeteor());
	}

}
