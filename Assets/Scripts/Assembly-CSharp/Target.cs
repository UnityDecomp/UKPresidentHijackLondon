using System;
using UnityEngine;

// Token: 0x02000213 RID: 531
public class Target : MonoBehaviour
{
	// Token: 0x06000DAE RID: 3502 RVA: 0x00057A3C File Offset: 0x00055E3C
	private void Start()
	{
		GameObject[] array = GameObject.FindGameObjectsWithTag("Player");
		foreach (GameObject gameObject in array)
		{
			if (gameObject.activeSelf)
			{
				this.player = gameObject;
			}
		}
	}

	// Token: 0x06000DAF RID: 3503 RVA: 0x00057A80 File Offset: 0x00055E80
	private void Update()
	{
		if (this.player)
		{
			base.transform.LookAt(this.player.transform);
		}
	}

	// Token: 0x04000E6C RID: 3692
	private GameObject player;
}
