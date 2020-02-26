using System;
using UnityEngine;

// Token: 0x0200003E RID: 62
[Serializable]
public class DestroyObject : MonoBehaviour
{
	// Token: 0x060000B7 RID: 183 RVA: 0x00009A94 File Offset: 0x00007C94
	public DestroyObject()
	{
		this.duration = 1.5f;
	}

	// Token: 0x060000B8 RID: 184 RVA: 0x00009AA8 File Offset: 0x00007CA8
	public virtual void Start()
	{
		UnityEngine.Object.Destroy(this.gameObject, this.duration);
	}

	// Token: 0x060000B9 RID: 185 RVA: 0x00009ABC File Offset: 0x00007CBC
	public virtual void Main()
	{
	}

	// Token: 0x04000158 RID: 344
	public float duration;
}
