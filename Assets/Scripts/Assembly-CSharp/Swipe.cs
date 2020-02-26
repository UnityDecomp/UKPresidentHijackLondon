using System;
using UnityEngine;

// Token: 0x020000B3 RID: 179
public class Swipe : MonoBehaviour
{
	// Token: 0x06000519 RID: 1305 RVA: 0x0002718D File Offset: 0x0002558D
	private void OnEnable()
	{
		EasyTouch.On_SwipeStart += this.On_SwipeStart;
		EasyTouch.On_Swipe += this.On_Swipe;
		EasyTouch.On_SwipeEnd += this.On_SwipeEnd;
	}

	// Token: 0x0600051A RID: 1306 RVA: 0x000271C2 File Offset: 0x000255C2
	private void OnDisable()
	{
		this.UnsubscribeEvent();
	}

	// Token: 0x0600051B RID: 1307 RVA: 0x000271CA File Offset: 0x000255CA
	private void OnDestroy()
	{
		this.UnsubscribeEvent();
	}

	// Token: 0x0600051C RID: 1308 RVA: 0x000271D2 File Offset: 0x000255D2
	private void UnsubscribeEvent()
	{
		EasyTouch.On_SwipeStart -= this.On_SwipeStart;
		EasyTouch.On_Swipe -= this.On_Swipe;
		EasyTouch.On_SwipeEnd -= this.On_SwipeEnd;
	}

	// Token: 0x0600051D RID: 1309 RVA: 0x00027207 File Offset: 0x00025607
	private void Start()
	{
		this.textMesh = (GameObject.Find("LastSwipeText").transform.gameObject.GetComponent("TextMesh") as TextMesh);
	}

	// Token: 0x0600051E RID: 1310 RVA: 0x00027234 File Offset: 0x00025634
	private void On_SwipeStart(Gesture gesture)
	{
		if (gesture.fingerIndex == 0 && this.trail == null)
		{
			Vector3 touchToWordlPoint = gesture.GetTouchToWordlPoint(5f);
			this.trail = (UnityEngine.Object.Instantiate(Resources.Load("Trail"), touchToWordlPoint, Quaternion.identity) as GameObject);
		}
	}

	// Token: 0x0600051F RID: 1311 RVA: 0x0002728C File Offset: 0x0002568C
	private void On_Swipe(Gesture gesture)
	{
		if (this.trail != null)
		{
			Vector3 touchToWordlPoint = gesture.GetTouchToWordlPoint(5f);
			this.trail.transform.position = touchToWordlPoint;
		}
	}

	// Token: 0x06000520 RID: 1312 RVA: 0x000272C8 File Offset: 0x000256C8
	private void On_SwipeEnd(Gesture gesture)
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
		}
	}

	// Token: 0x040004E8 RID: 1256
	private TextMesh textMesh;

	// Token: 0x040004E9 RID: 1257
	private GameObject trail;
}
