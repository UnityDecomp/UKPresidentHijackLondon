using System;
using UnityEngine;

// Token: 0x020000A6 RID: 166
[Serializable]
public class TimedObjectDestructor : MonoBehaviour
{
	// Token: 0x06000243 RID: 579 RVA: 0x0001CD44 File Offset: 0x0001AF44
	public TimedObjectDestructor()
	{
		this.timeOut = 1f;
	}

	// Token: 0x06000244 RID: 580 RVA: 0x0001CD58 File Offset: 0x0001AF58
	public virtual void Awake()
	{
		this.Invoke("DestroyNow", this.timeOut);
	}

	// Token: 0x06000245 RID: 581 RVA: 0x0001CD6C File Offset: 0x0001AF6C
	public virtual void DestroyNow()
	{
		if (this.detachChildren)
		{
			this.transform.DetachChildren();
		}
		UnityEngine.Object.DestroyObject(this.gameObject);
	}

	// Token: 0x06000246 RID: 582 RVA: 0x0001CD90 File Offset: 0x0001AF90
	public virtual void Main()
	{
	}

	// Token: 0x040003BC RID: 956
	public float timeOut;

	// Token: 0x040003BD RID: 957
	public bool detachChildren;
}
