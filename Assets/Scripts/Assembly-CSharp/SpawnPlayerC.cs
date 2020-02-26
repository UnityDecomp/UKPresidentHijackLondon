using System;
using UnityEngine;

// Token: 0x02000092 RID: 146
public class SpawnPlayerC : MonoBehaviour
{
	// Token: 0x06000464 RID: 1124 RVA: 0x00020EBC File Offset: 0x0001F2BC
	private void Start()
	{
		GameObject gameObject = GameObject.FindWithTag("Player");
		if (!gameObject)
		{
			GameObject gameObject2 = UnityEngine.Object.Instantiate<GameObject>(this.player, base.transform.position, base.transform.rotation);
			this.mainCam = GameObject.FindWithTag("MainCamera").transform;
			Screen.lockCursor = true;
			GameObject[] array = GameObject.FindGameObjectsWithTag("Enemy");
			foreach (GameObject gameObject3 in array)
			{
				if (gameObject3)
				{
					gameObject3.GetComponent<AIsetC>().followTarget = gameObject2.transform;
				}
			}
			return;
		}
		string spawnPointName = gameObject.GetComponent<StatusC>().spawnPointName;
		GameObject gameObject4 = GameObject.Find(spawnPointName);
		if (gameObject4)
		{
			gameObject.transform.position = gameObject4.transform.position;
			gameObject.transform.rotation = gameObject4.transform.rotation;
		}
		GameObject gameObject5 = gameObject.GetComponent<AttackTriggerC>().Maincam.gameObject;
		if (!gameObject5)
		{
			return;
		}
		GameObject[] array3 = GameObject.FindGameObjectsWithTag("MainCamera");
		foreach (GameObject gameObject6 in array3)
		{
			if (gameObject6 != gameObject5)
			{
				UnityEngine.Object.Destroy(gameObject6.gameObject);
			}
		}
	}

	// Token: 0x04000445 RID: 1093
	public GameObject player;

	// Token: 0x04000446 RID: 1094
	private Transform mainCam;
}
