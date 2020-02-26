using System;
using UnityEngine;

// Token: 0x02000064 RID: 100
public class DontDestroyOnloadC : MonoBehaviour
{
	// Token: 0x06000387 RID: 903 RVA: 0x00012E2C File Offset: 0x0001122C
	private void Awake()
	{
		UnityEngine.Object.DontDestroyOnLoad(base.transform.gameObject);
	}
}
