using System;
using UnityEngine;

// Token: 0x0200014B RID: 331
public class QuickCone : MonoBehaviour
{
	// Token: 0x06000A2A RID: 2602 RVA: 0x0003DFA9 File Offset: 0x0003C3A9
	private void OnTriggerEnter(Collider otherCollider)
	{
	}

	// Token: 0x06000A2B RID: 2603 RVA: 0x0003DFAB File Offset: 0x0003C3AB
	private float rv()
	{
		return 0.5f - UnityEngine.Random.value;
	}
}
