using System;
using UnityEngine;

// Token: 0x02000097 RID: 151
public class SwitchAimModeC : MonoBehaviour
{
	// Token: 0x06000486 RID: 1158 RVA: 0x0002312B File Offset: 0x0002152B
	private void Update()
	{
		if (Input.GetKeyDown("p"))
		{
			this.SwitchMode();
		}
	}

	// Token: 0x06000487 RID: 1159 RVA: 0x00023144 File Offset: 0x00021544
	private void SwitchMode()
	{
		AttackTriggerC component = base.GetComponent<AttackTriggerC>();
	}

	// Token: 0x0400048B RID: 1163
	public float targetHeightNormal = 1.6f;

	// Token: 0x0400048C RID: 1164
	public float targetHeightRayCast = 1.2f;
}
