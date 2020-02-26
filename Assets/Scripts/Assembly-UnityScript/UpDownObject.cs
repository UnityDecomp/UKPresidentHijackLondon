using System;
using UnityEngine;

// Token: 0x020000A5 RID: 165
[Serializable]
public class UpDownObject : MonoBehaviour
{
	// Token: 0x06000240 RID: 576 RVA: 0x0001CC84 File Offset: 0x0001AE84
	public UpDownObject()
	{
		this.moveY = 5f;
		this.duration = 1f;
	}

	// Token: 0x06000241 RID: 577 RVA: 0x0001CCA4 File Offset: 0x0001AEA4
	public virtual void Update()
	{
		this.transform.Translate(this.moveX * Time.deltaTime, this.moveY * Time.deltaTime, this.moveZ * Time.deltaTime);
		if (this.wait >= this.duration)
		{
			this.moveX *= (float)-1;
			this.moveY *= (float)-1;
			this.moveZ *= (float)-1;
			this.wait = (float)0;
		}
		else
		{
			this.wait += Time.deltaTime;
		}
	}

	// Token: 0x06000242 RID: 578 RVA: 0x0001CD40 File Offset: 0x0001AF40
	public virtual void Main()
	{
	}

	// Token: 0x040003B7 RID: 951
	public float moveX;

	// Token: 0x040003B8 RID: 952
	public float moveY;

	// Token: 0x040003B9 RID: 953
	public float moveZ;

	// Token: 0x040003BA RID: 954
	private float wait;

	// Token: 0x040003BB RID: 955
	public float duration;
}
