using System;
using System.Collections;
using UnityEngine;

// Token: 0x02000060 RID: 96
public class DamagePopupC : MonoBehaviour
{
	// Token: 0x06000378 RID: 888 RVA: 0x00012709 File Offset: 0x00010B09
	private void Start()
	{
		UnityEngine.Object.Destroy(base.gameObject, this.duration);
		base.StartCoroutine(this.Glide());
	}

	// Token: 0x06000379 RID: 889 RVA: 0x0001272C File Offset: 0x00010B2C
	private IEnumerator Glide()
	{
		int a = 0;
		while (a < 100)
		{
			this.glide += 2;
			yield return new WaitForSeconds(0.03f);
		}
		yield break;
	}

	// Token: 0x0600037A RID: 890 RVA: 0x00012747 File Offset: 0x00010B47
	private void OnGUI()
	{
	}

	// Token: 0x04000286 RID: 646
	private Vector3 targetScreenPosition;

	// Token: 0x04000287 RID: 647
	public string damage = string.Empty;

	// Token: 0x04000288 RID: 648
	public GUIStyle fontStyle;

	// Token: 0x04000289 RID: 649
	public float duration = 0.5f;

	// Token: 0x0400028A RID: 650
	private int glide = 50;
}
