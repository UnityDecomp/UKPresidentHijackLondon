using System;
using System.Collections;
using UnityEngine;
using UnityEngine.UI;

// Token: 0x020001E2 RID: 482
public class Fader : MonoBehaviour
{
	// Token: 0x06000C7F RID: 3199 RVA: 0x0004EBE8 File Offset: 0x0004CFE8
	private void Start()
	{
		if (base.GetComponent<Image>())
		{
			this.faderImage = base.GetComponent<Image>();
		}
	}

	// Token: 0x06000C80 RID: 3200 RVA: 0x0004EC06 File Offset: 0x0004D006
	public void ExecuteFading()
	{
		if (!this.faderImage && base.GetComponent<Image>())
		{
			this.faderImage = base.GetComponent<Image>();
		}
		base.StartCoroutine(this.FadingRoutine());
	}

	// Token: 0x06000C81 RID: 3201 RVA: 0x0004EC44 File Offset: 0x0004D044
	private IEnumerator FadingRoutine()
	{
		Color col = this.faderImage.color;
		do
		{
			yield return new WaitForSeconds(0.02f);
			this.count += 0.1f;
			col = this.faderImage.color;
			col.a = this.count;
			this.faderImage.color = col;
		}
		while (this.count < 1f);
		this.count = 1f;
		col = this.faderImage.color;
		col.a = this.count;
		this.faderImage.color = col;
		yield return new WaitForSeconds(0.5f);
		do
		{
			yield return new WaitForSeconds(0.02f);
			this.count -= 0.1f;
			col = this.faderImage.color;
			col.a = this.count;
			this.faderImage.color = col;
		}
		while (this.count > 0f);
		this.count = 0f;
		col = this.faderImage.color;
		col.a = this.count;
		this.faderImage.color = col;
		base.gameObject.SetActive(false);
		yield break;
	}

	// Token: 0x04000CE7 RID: 3303
	public Image faderImage;

	// Token: 0x04000CE8 RID: 3304
	private float count;
}
