using System;
using UnityEngine;

// Token: 0x0200005A RID: 90
[Serializable]
public class LockMouse : MonoBehaviour
{
	// Token: 0x0600011D RID: 285 RVA: 0x0000F290 File Offset: 0x0000D490
	public virtual void Start()
	{
		Screen.lockCursor = true;
	}

	// Token: 0x0600011E RID: 286 RVA: 0x0000F298 File Offset: 0x0000D498
	public virtual void Main()
	{
	}
}
