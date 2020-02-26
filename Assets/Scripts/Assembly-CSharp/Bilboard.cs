using System;
using UnityEngine;

// Token: 0x020001D7 RID: 471
public class Bilboard : MonoBehaviour
{
	// Token: 0x06000C38 RID: 3128 RVA: 0x0004D600 File Offset: 0x0004BA00
	private void Start()
	{
		base.Invoke("findTarget", 0.5f);
	}

	// Token: 0x06000C39 RID: 3129 RVA: 0x0004D614 File Offset: 0x0004BA14
	private void Update()
	{
		if (this.player)
		{
			base.transform.LookAt(base.transform.position + this.player.transform.rotation * Vector3.forward, this.player.transform.rotation * Vector3.up);
		}
	}

	// Token: 0x06000C3A RID: 3130 RVA: 0x0004D680 File Offset: 0x0004BA80
	private void findTarget()
	{
		try
		{
			this.player = GameObject.FindGameObjectWithTag("Player").transform;
		}
		catch (Exception ex)
		{
			if (!this.player)
			{
				this.player = GameObject.FindGameObjectWithTag("Dragable").transform;
			}
		}
	}

	// Token: 0x04000CAB RID: 3243
	private Transform player;
}
