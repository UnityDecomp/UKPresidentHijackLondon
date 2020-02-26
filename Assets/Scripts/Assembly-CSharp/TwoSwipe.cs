using System;
using UnityEngine;

// Token: 0x020000BD RID: 189
public class TwoSwipe : MonoBehaviour
{
	// Token: 0x06000566 RID: 1382 RVA: 0x0002824C File Offset: 0x0002664C
	private void OnEnable()
	{
		EasyTouch.On_SwipeStart2Fingers += this.On_SwipeStart2Fingers;
		EasyTouch.On_Swipe2Fingers += this.On_Swipe2Fingers;
		EasyTouch.On_SwipeEnd2Fingers += this.On_SwipeEnd2Fingers;
		EasyTouch.On_Cancel2Fingers += this.On_Cancel2Fingers;
	}

	// Token: 0x06000567 RID: 1383 RVA: 0x0002829D File Offset: 0x0002669D
	private void OnDisable()
	{
		this.UnsubscribeEvent();
	}

	// Token: 0x06000568 RID: 1384 RVA: 0x000282A5 File Offset: 0x000266A5
	private void OnDestroy()
	{
		this.UnsubscribeEvent();
	}

	// Token: 0x06000569 RID: 1385 RVA: 0x000282B0 File Offset: 0x000266B0
	private void UnsubscribeEvent()
	{
		EasyTouch.On_SwipeStart2Fingers -= this.On_SwipeStart2Fingers;
		EasyTouch.On_Swipe2Fingers -= this.On_Swipe2Fingers;
		EasyTouch.On_SwipeEnd2Fingers -= this.On_SwipeEnd2Fingers;
		EasyTouch.On_Cancel2Fingers -= this.On_Cancel2Fingers;
	}

	// Token: 0x0600056A RID: 1386 RVA: 0x00028301 File Offset: 0x00026701
	private void Start()
	{
		this.textMesh = (GameObject.Find("LastSwipeText").transform.gameObject.GetComponent("TextMesh") as TextMesh);
	}

	// Token: 0x0600056B RID: 1387 RVA: 0x0002832C File Offset: 0x0002672C
	private void On_SwipeStart2Fingers(Gesture gesture)
	{
		if (this.trail == null)
		{
			Vector3 touchToWordlPoint = gesture.GetTouchToWordlPoint(5f);
			this.trail = (UnityEngine.Object.Instantiate(Resources.Load("Trail"), touchToWordlPoint, Quaternion.identity) as GameObject);
			EasyTouch.SetEnableTwist(false);
			EasyTouch.SetEnablePinch(false);
		}
	}

	// Token: 0x0600056C RID: 1388 RVA: 0x00028384 File Offset: 0x00026784
	private void On_Swipe2Fingers(Gesture gesture)
	{
		if (this.trail != null)
		{
			Vector3 touchToWordlPoint = gesture.GetTouchToWordlPoint(5f);
			this.trail.transform.position = touchToWordlPoint;
		}
	}

	// Token: 0x0600056D RID: 1389 RVA: 0x000283C0 File Offset: 0x000267C0
	private void On_SwipeEnd2Fingers(Gesture gesture)
	{
		if (this.trail != null)
		{
			UnityEngine.Object.Destroy(this.trail);
			float swipeOrDragAngle = gesture.GetSwipeOrDragAngle();
			this.textMesh.text = string.Concat(new object[]
			{
				"Last swipe : ",
				gesture.swipe.ToString(),
				" /  vector : ",
				gesture.swipeVector.normalized,
				" / angle : ",
				swipeOrDragAngle.ToString("f2")
			});
			EasyTouch.SetEnableTwist(true);
			EasyTouch.SetEnablePinch(true);
		}
	}

	// Token: 0x0600056E RID: 1390 RVA: 0x00028460 File Offset: 0x00026860
	private void On_Cancel2Fingers(Gesture gesture)
	{
		if (this.trail != null)
		{
			UnityEngine.Object.Destroy(this.trail);
			EasyTouch.SetEnableTwist(true);
			EasyTouch.SetEnablePinch(true);
		}
	}

	// Token: 0x040004F0 RID: 1264
	private TextMesh textMesh;

	// Token: 0x040004F1 RID: 1265
	private GameObject trail;
}
