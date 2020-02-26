using System;
using UnityEngine;

// Token: 0x02000117 RID: 279
[RequireComponent(typeof(Light))]
public class CFX_LightIntensityFade : MonoBehaviour
{
	// Token: 0x06000779 RID: 1913 RVA: 0x000322B5 File Offset: 0x000306B5
	private void Start()
	{
		this.baseIntensity = base.GetComponent<Light>().intensity;
	}

	// Token: 0x0600077A RID: 1914 RVA: 0x000322C8 File Offset: 0x000306C8
	private void OnEnable()
	{
		this.p_lifetime = 0f;
		this.p_delay = this.delay;
		if (this.delay > 0f)
		{
			base.GetComponent<Light>().enabled = false;
		}
	}

	// Token: 0x0600077B RID: 1915 RVA: 0x00032300 File Offset: 0x00030700
	private void Update()
	{
		if (this.p_delay > 0f)
		{
			this.p_delay -= Time.deltaTime;
			if (this.p_delay <= 0f)
			{
				base.GetComponent<Light>().enabled = true;
			}
			return;
		}
		if (this.p_lifetime / this.duration < 1f)
		{
			base.GetComponent<Light>().intensity = Mathf.Lerp(this.baseIntensity, this.finalIntensity, this.p_lifetime / this.duration);
			this.p_lifetime += Time.deltaTime;
		}
		else if (this.autodestruct)
		{
			UnityEngine.Object.Destroy(base.gameObject);
		}
	}

	// Token: 0x0400068D RID: 1677
	public float duration = 1f;

	// Token: 0x0400068E RID: 1678
	public float delay;

	// Token: 0x0400068F RID: 1679
	public float finalIntensity;

	// Token: 0x04000690 RID: 1680
	private float baseIntensity;

	// Token: 0x04000691 RID: 1681
	public bool autodestruct;

	// Token: 0x04000692 RID: 1682
	private float p_lifetime;

	// Token: 0x04000693 RID: 1683
	private float p_delay;
}
