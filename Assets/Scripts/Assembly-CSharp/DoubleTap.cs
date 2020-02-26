using System;
using UnityEngine;

// Token: 0x020000AF RID: 175
public class DoubleTap : MonoBehaviour
{
	// Token: 0x060004FF RID: 1279 RVA: 0x00026C69 File Offset: 0x00025069
	private void OnEnable()
	{
		EasyTouch.On_DoubleTap += this.On_DoubleTap;
	}

	// Token: 0x06000500 RID: 1280 RVA: 0x00026C7C File Offset: 0x0002507C
	private void OnDisable()
	{
		this.UnsubscribeEvent();
	}

	// Token: 0x06000501 RID: 1281 RVA: 0x00026C84 File Offset: 0x00025084
	private void OnDestroy()
	{
		this.UnsubscribeEvent();
	}

	// Token: 0x06000502 RID: 1282 RVA: 0x00026C8C File Offset: 0x0002508C
	private void UnsubscribeEvent()
	{
		EasyTouch.On_DoubleTap -= this.On_DoubleTap;
	}

	// Token: 0x06000503 RID: 1283 RVA: 0x00026CA0 File Offset: 0x000250A0
	private void On_DoubleTap(Gesture gesture)
	{
		if (gesture.pickObject == base.gameObject)
		{
			base.gameObject.GetComponent<Renderer>().material.color = new Color(UnityEngine.Random.Range(0f, 1f), UnityEngine.Random.Range(0f, 1f), UnityEngine.Random.Range(0f, 1f));
		}
	}
}
