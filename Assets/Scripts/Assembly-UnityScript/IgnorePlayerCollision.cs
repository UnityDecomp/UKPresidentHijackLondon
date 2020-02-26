using System;
using UnityEngine;

// Token: 0x02000053 RID: 83
[Serializable]
public class IgnorePlayerCollision : MonoBehaviour
{
	// Token: 0x060000FF RID: 255 RVA: 0x0000BBB8 File Offset: 0x00009DB8
	public virtual void Update()
	{
		if (!this.player)
		{
			this.player = GameObject.FindWithTag("Player");
			if (this.player)
			{
				Physics.IgnoreCollision(this.player.GetComponent<Collider>(), this.GetComponent<Collider>());
			}
		}
	}

	// Token: 0x06000100 RID: 256 RVA: 0x0000BC0C File Offset: 0x00009E0C
	public virtual void Main()
	{
	}

	// Token: 0x040001CA RID: 458
	private GameObject player;
}
