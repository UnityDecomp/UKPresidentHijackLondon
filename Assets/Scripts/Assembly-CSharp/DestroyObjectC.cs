using System;
using UnityEngine;

// Token: 0x02000061 RID: 97
public class DestroyObjectC : MonoBehaviour
{
	// Token: 0x0600037C RID: 892 RVA: 0x00012816 File Offset: 0x00010C16
	private void Start()
	{
		UnityEngine.Object.Destroy(base.gameObject, this.duration);
	}

	// Token: 0x0400028B RID: 651
	public float duration = 1.5f;
}
