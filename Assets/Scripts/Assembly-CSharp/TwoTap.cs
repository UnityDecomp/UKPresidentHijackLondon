using System;
using UnityEngine;

// Token: 0x020000BE RID: 190
public class TwoTap : MonoBehaviour
{
	// Token: 0x06000570 RID: 1392 RVA: 0x00028492 File Offset: 0x00026892
	private void OnEnable()
	{
		EasyTouch.On_SimpleTap2Fingers += this.On_SimpleTap2Fingers;
	}

	// Token: 0x06000571 RID: 1393 RVA: 0x000284A5 File Offset: 0x000268A5
	private void OnDisable()
	{
		this.UnsubscribeEvent();
	}

	// Token: 0x06000572 RID: 1394 RVA: 0x000284AD File Offset: 0x000268AD
	private void OnDestroy()
	{
		this.UnsubscribeEvent();
	}

	// Token: 0x06000573 RID: 1395 RVA: 0x000284B5 File Offset: 0x000268B5
	private void UnsubscribeEvent()
	{
		EasyTouch.On_SimpleTap2Fingers -= this.On_SimpleTap2Fingers;
	}

	// Token: 0x06000574 RID: 1396 RVA: 0x000284C8 File Offset: 0x000268C8
	private void On_SimpleTap2Fingers(Gesture gesture)
	{
		if (gesture.pickObject == base.gameObject)
		{
			base.gameObject.GetComponent<Renderer>().material.color = new Color(UnityEngine.Random.Range(0f, 1f), UnityEngine.Random.Range(0f, 1f), UnityEngine.Random.Range(0f, 1f));
		}
	}
}
