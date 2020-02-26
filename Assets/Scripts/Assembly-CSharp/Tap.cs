using System;
using UnityEngine;

// Token: 0x020000B4 RID: 180
public class Tap : MonoBehaviour
{
	// Token: 0x06000522 RID: 1314 RVA: 0x00027364 File Offset: 0x00025764
	private void OnEnable()
	{
		EasyTouch.On_SimpleTap += this.On_SimpleTap;
	}

	// Token: 0x06000523 RID: 1315 RVA: 0x00027377 File Offset: 0x00025777
	private void OnDisable()
	{
		this.UnsubscribeEvent();
	}

	// Token: 0x06000524 RID: 1316 RVA: 0x0002737F File Offset: 0x0002577F
	private void OnDestroy()
	{
		this.UnsubscribeEvent();
	}

	// Token: 0x06000525 RID: 1317 RVA: 0x00027387 File Offset: 0x00025787
	private void UnsubscribeEvent()
	{
		EasyTouch.On_SimpleTap -= this.On_SimpleTap;
	}

	// Token: 0x06000526 RID: 1318 RVA: 0x0002739C File Offset: 0x0002579C
	private void On_SimpleTap(Gesture gesture)
	{
		if (gesture.pickObject == base.gameObject)
		{
			base.gameObject.GetComponent<Renderer>().material.color = new Color(UnityEngine.Random.Range(0f, 1f), UnityEngine.Random.Range(0f, 1f), UnityEngine.Random.Range(0f, 1f));
		}
	}
}
