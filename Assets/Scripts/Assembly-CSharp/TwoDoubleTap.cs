using System;
using UnityEngine;

// Token: 0x020000BA RID: 186
public class TwoDoubleTap : MonoBehaviour
{
	// Token: 0x0600054C RID: 1356 RVA: 0x00027C93 File Offset: 0x00026093
	private void OnEnable()
	{
		EasyTouch.On_DoubleTap2Fingers += this.On_DoubleTap2Fingers;
	}

	// Token: 0x0600054D RID: 1357 RVA: 0x00027CA6 File Offset: 0x000260A6
	private void OnDisable()
	{
		this.UnsubscribeEvent();
	}

	// Token: 0x0600054E RID: 1358 RVA: 0x00027CAE File Offset: 0x000260AE
	private void OnDestroy()
	{
		this.UnsubscribeEvent();
	}

	// Token: 0x0600054F RID: 1359 RVA: 0x00027CB6 File Offset: 0x000260B6
	private void UnsubscribeEvent()
	{
		EasyTouch.On_DoubleTap2Fingers -= this.On_DoubleTap2Fingers;
	}

	// Token: 0x06000550 RID: 1360 RVA: 0x00027CCC File Offset: 0x000260CC
	private void On_DoubleTap2Fingers(Gesture gesture)
	{
		if (gesture.pickObject == base.gameObject)
		{
			base.gameObject.GetComponent<Renderer>().material.color = new Color(UnityEngine.Random.Range(0f, 1f), UnityEngine.Random.Range(0f, 1f), UnityEngine.Random.Range(0f, 1f));
		}
	}
}
