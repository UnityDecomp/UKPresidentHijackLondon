using System;
using UnityEngine;

// Token: 0x02000148 RID: 328
public class NotDestroy : MonoBehaviour
{
	// Token: 0x06000A22 RID: 2594 RVA: 0x0003DDDD File Offset: 0x0003C1DD
	private void Awake()
	{
		UnityEngine.Object.DontDestroyOnLoad(base.gameObject);
	}
}
