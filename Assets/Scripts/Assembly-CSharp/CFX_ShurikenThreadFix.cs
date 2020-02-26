using System;
using System.Collections;
using UnityEngine;

// Token: 0x02000118 RID: 280
public class CFX_ShurikenThreadFix : MonoBehaviour
{
	// Token: 0x0600077D RID: 1917 RVA: 0x000323C4 File Offset: 0x000307C4
	private void OnEnable()
	{
		this.systems = base.GetComponentsInChildren<ParticleSystem>();
		foreach (ParticleSystem particleSystem in this.systems)
		{
			particleSystem.enableEmission = false;
		}
		base.StartCoroutine("WaitFrame");
	}

	// Token: 0x0600077E RID: 1918 RVA: 0x00032410 File Offset: 0x00030810
	private IEnumerator WaitFrame()
	{
		yield return null;
		foreach (ParticleSystem particleSystem in this.systems)
		{
			particleSystem.enableEmission = true;
			particleSystem.Play(true);
		}
		yield break;
	}

	// Token: 0x04000694 RID: 1684
	private ParticleSystem[] systems;
}
