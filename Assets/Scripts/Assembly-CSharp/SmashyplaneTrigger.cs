using System;
using UnityEngine;

// Token: 0x0200014E RID: 334
public class SmashyplaneTrigger : MonoBehaviour
{
	// Token: 0x06000A35 RID: 2613 RVA: 0x0003E12C File Offset: 0x0003C52C
	private void OnTriggerEnter(Collider coll)
	{
		if (!this.triggered)
		{
			if (this.isLeft)
			{
				this.myParent.smashLeftWing();
			}
			if (this.isRight)
			{
				this.myParent.smashRightWing();
			}
			if (this.isBody)
			{
				this.myParent.smashMiddle();
			}
		}
	}

	// Token: 0x04000954 RID: 2388
	public bool isLeft;

	// Token: 0x04000955 RID: 2389
	public bool isRight;

	// Token: 0x04000956 RID: 2390
	public bool isBody;

	// Token: 0x04000957 RID: 2391
	public SmashyPlane myParent;

	// Token: 0x04000958 RID: 2392
	private bool triggered;
}
