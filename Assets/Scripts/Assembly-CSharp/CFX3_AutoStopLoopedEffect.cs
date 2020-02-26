using System;
using UnityEngine;

// Token: 0x02000112 RID: 274
[RequireComponent(typeof(ParticleSystem))]
public class CFX3_AutoStopLoopedEffect : MonoBehaviour
{
	// Token: 0x06000764 RID: 1892 RVA: 0x00031738 File Offset: 0x0002FB38
	private void OnEnable()
	{
		this.d = this.effectDuration;
	}

	// Token: 0x06000765 RID: 1893 RVA: 0x00031748 File Offset: 0x0002FB48
	private void Update()
	{
		if (this.d > 0f)
		{
			this.d -= Time.deltaTime;
			if (this.d <= 0f)
			{
				base.GetComponent<ParticleSystem>().Stop(true);
				CFX3_Demo_Translate component = base.gameObject.GetComponent<CFX3_Demo_Translate>();
				if (component != null)
				{
					component.enabled = false;
				}
			}
		}
	}

	// Token: 0x04000679 RID: 1657
	public float effectDuration = 2.5f;

	// Token: 0x0400067A RID: 1658
	private float d;
}
