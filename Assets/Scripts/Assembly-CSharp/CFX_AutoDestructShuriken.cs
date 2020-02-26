using System;
using System.Collections;
using UnityEngine;

// Token: 0x02000115 RID: 277
[RequireComponent(typeof(ParticleSystem))]
public class CFX_AutoDestructShuriken : MonoBehaviour
{
	// Token: 0x06000774 RID: 1908 RVA: 0x00032170 File Offset: 0x00030570
	private void OnEnable()
	{
		base.StartCoroutine("CheckIfAlive");
	}

	// Token: 0x06000775 RID: 1909 RVA: 0x00032180 File Offset: 0x00030580
	private IEnumerator CheckIfAlive()
	{
		do
		{
			yield return new WaitForSeconds(0.5f);
		}
		while (base.GetComponent<ParticleSystem>().IsAlive(true));
		if (this.OnlyDeactivate)
		{
			base.gameObject.SetActive(false);
		}
		else
		{
			UnityEngine.Object.Destroy(base.gameObject);
		}
		yield break;
	}

	// Token: 0x0400068C RID: 1676
	public bool OnlyDeactivate;
}
