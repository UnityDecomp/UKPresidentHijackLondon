using System;
using UnityEngine;

// Token: 0x02000142 RID: 322
public class HideMesh : MonoBehaviour
{
	// Token: 0x06000A0E RID: 2574 RVA: 0x0003DAD4 File Offset: 0x0003BED4
	private void Start()
	{
		if (base.GetComponent<Light>())
		{
			base.GetComponent<Light>().enabled = false;
		}
		if (base.GetComponent<Renderer>())
		{
			base.GetComponent<Renderer>().enabled = false;
		}
		UnityEngine.Object.DestroyImmediate(base.GetComponent<Renderer>());
		UnityEngine.Object.DestroyImmediate(this);
	}
}
