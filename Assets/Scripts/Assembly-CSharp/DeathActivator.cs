using System;
using UnityEngine;

// Token: 0x020001E0 RID: 480
public class DeathActivator : MonoBehaviour
{
	// Token: 0x06000C71 RID: 3185 RVA: 0x0004E8E4 File Offset: 0x0004CCE4
	private void Start()
	{
		for (int i = 0; i < this.squad1death.Length; i++)
		{
			this.squad1death[i].SetActive(false);
		}
		this.squad1death[gameplay.count].SetActive(true);
	}

	// Token: 0x04000CDD RID: 3293
	public GameObject[] squad1death;
}
