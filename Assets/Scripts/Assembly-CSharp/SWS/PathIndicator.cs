using System;
using System.Collections;
using UnityEngine;

namespace SWS
{
	// Token: 0x02000104 RID: 260
	public class PathIndicator : MonoBehaviour
	{
		// Token: 0x06000713 RID: 1811 RVA: 0x0002E966 File Offset: 0x0002CD66
		private void Start()
		{
			this.pSys = base.GetComponentInChildren<ParticleSystem>();
			base.StartCoroutine("EmitParticles");
		}

		// Token: 0x06000714 RID: 1812 RVA: 0x0002E980 File Offset: 0x0002CD80
		private IEnumerator EmitParticles()
		{
			yield return new WaitForEndOfFrame();
			for (;;)
			{
				float rot = (base.transform.eulerAngles.y + this.modRotation) * 0.0174532924f;
				this.pSys.startRotation = rot;
				this.pSys.Emit(1);
				yield return new WaitForSeconds(0.2f);
			}
			yield break;
		}

		// Token: 0x04000617 RID: 1559
		public float modRotation;

		// Token: 0x04000618 RID: 1560
		private ParticleSystem pSys;
	}
}
