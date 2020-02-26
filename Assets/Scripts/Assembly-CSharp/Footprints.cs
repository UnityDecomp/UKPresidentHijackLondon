using System;
using System.Collections;
using UnityEngine;

// Token: 0x020001E3 RID: 483
public class Footprints : MonoBehaviour
{
	// Token: 0x06000C83 RID: 3203 RVA: 0x0004EEF5 File Offset: 0x0004D2F5
	private void Start()
	{
		base.StartCoroutine(this.wait());
	}

	// Token: 0x06000C84 RID: 3204 RVA: 0x0004EF04 File Offset: 0x0004D304
	private IEnumerator wait()
	{
		yield return new WaitForSeconds(this.stayForTime);
		UnityEngine.Object.Destroy(base.gameObject);
		yield break;
	}

	// Token: 0x04000CE9 RID: 3305
	public float stayForTime = 4f;
}
