using System;
using UnityEngine;

// Token: 0x020000A3 RID: 163
public class FreeCam : MonoBehaviour
{
	// Token: 0x060004B8 RID: 1208 RVA: 0x00025685 File Offset: 0x00023A85
	private void OnEnable()
	{
		EasyTouch.On_TouchDown += this.On_TouchDown;
		EasyTouch.On_Swipe += this.On_Swipe;
	}

	// Token: 0x060004B9 RID: 1209 RVA: 0x000256A9 File Offset: 0x00023AA9
	private void OnDisable()
	{
		this.UnsubscribeEvent();
	}

	// Token: 0x060004BA RID: 1210 RVA: 0x000256B1 File Offset: 0x00023AB1
	private void OnDestroy()
	{
		this.UnsubscribeEvent();
	}

	// Token: 0x060004BB RID: 1211 RVA: 0x000256B9 File Offset: 0x00023AB9
	private void UnsubscribeEvent()
	{
		EasyTouch.On_TouchDown -= this.On_TouchDown;
		EasyTouch.On_Swipe -= this.On_Swipe;
	}

	// Token: 0x060004BC RID: 1212 RVA: 0x000256DD File Offset: 0x00023ADD
	private void Start()
	{
		this.cam = Camera.main;
	}

	// Token: 0x060004BD RID: 1213 RVA: 0x000256EC File Offset: 0x00023AEC
	private void On_TouchDown(Gesture gesture)
	{
		if (gesture.touchCount == 2)
		{
			this.cam.transform.Translate(new Vector3(0f, 0f, 1f) * Time.deltaTime);
		}
		if (gesture.touchCount == 3)
		{
			this.cam.transform.Translate(new Vector3(0f, 0f, -1f) * Time.deltaTime);
		}
	}

	// Token: 0x060004BE RID: 1214 RVA: 0x00025770 File Offset: 0x00023B70
	private void On_Swipe(Gesture gesture)
	{
		this.rotationX += gesture.deltaPosition.x;
		this.rotationY += gesture.deltaPosition.y;
		this.cam.transform.localRotation = Quaternion.AngleAxis(this.rotationX, Vector3.up);
		this.cam.transform.localRotation *= Quaternion.AngleAxis(this.rotationY, Vector3.left);
	}

	// Token: 0x040004D6 RID: 1238
	private float rotationX;

	// Token: 0x040004D7 RID: 1239
	private float rotationY;

	// Token: 0x040004D8 RID: 1240
	private Camera cam;
}
