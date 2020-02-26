using System;
using UnityEngine;

// Token: 0x02000116 RID: 278
public class CFX_AutodestructWhenNoChildren : MonoBehaviour
{
	// Token: 0x06000777 RID: 1911 RVA: 0x00032285 File Offset: 0x00030685
	private void Update()
	{
		if (base.transform.childCount == 0)
		{
			UnityEngine.Object.Destroy(base.gameObject);
		}
	}
}
