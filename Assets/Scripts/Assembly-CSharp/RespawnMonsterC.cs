using System;
using System.Collections;
using UnityEngine;

// Token: 0x02000088 RID: 136
public class RespawnMonsterC : MonoBehaviour
{
	// Token: 0x06000431 RID: 1073 RVA: 0x0001BCB0 File Offset: 0x0001A0B0
	private void Start()
	{
		base.StartCoroutine(this.Delay());
	}

	// Token: 0x06000432 RID: 1074 RVA: 0x0001BCC0 File Offset: 0x0001A0C0
	private IEnumerator Delay()
	{
		GameObject[] spawnpoints = GameObject.FindGameObjectsWithTag(this.pointName);
		if (spawnpoints.Length > 0)
		{
			Transform spawnpoint = spawnpoints[UnityEngine.Random.Range(0, spawnpoints.Length)].transform;
			yield return new WaitForSeconds(this.delay);
			Vector3 ranPos = spawnpoint.position;
			ranPos.x += UnityEngine.Random.Range(0f, this.randomPoint);
			ranPos.z += UnityEngine.Random.Range(0f, this.randomPoint);
			GameObject mon = UnityEngine.Object.Instantiate<GameObject>(this.enemy, ranPos, Quaternion.identity);
			mon.name = this.enemy.name;
			UnityEngine.Object.Destroy(base.gameObject, 1f);
		}
		else
		{
			UnityEngine.Object.Destroy(base.gameObject, this.delay + 1f);
		}
		yield break;
	}

	// Token: 0x040003F0 RID: 1008
	public GameObject enemy;

	// Token: 0x040003F1 RID: 1009
	public string pointName = "SpawnPoint";

	// Token: 0x040003F2 RID: 1010
	public float delay = 3f;

	// Token: 0x040003F3 RID: 1011
	public float randomPoint = 10f;
}
