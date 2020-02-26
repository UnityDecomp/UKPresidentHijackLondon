using System;
using UnityEngine;

// Token: 0x020000F0 RID: 240
public class EasyTouchInput
{
	// Token: 0x060006AF RID: 1711 RVA: 0x0002C5D7 File Offset: 0x0002A9D7
	public int TouchCount()
	{
		return this.getTouchCount(true);
	}

	// Token: 0x060006B0 RID: 1712 RVA: 0x0002C5E0 File Offset: 0x0002A9E0
	private int getTouchCount(bool realTouch)
	{
		int result = 0;
		if (realTouch || EasyTouch.instance.enableRemote)
		{
			result = Input.touchCount;
		}
		else if (Input.GetMouseButton(0) || Input.GetMouseButtonUp(0))
		{
			result = 1;
			if (Input.GetKey(KeyCode.LeftAlt) || Input.GetKey(KeyCode.RightAlt) || Input.GetKey(KeyCode.LeftControl) || Input.GetKey(KeyCode.RightControl))
			{
				result = 2;
			}
			if (Input.GetKeyUp(KeyCode.LeftAlt) || Input.GetKeyUp(KeyCode.RightAlt) || Input.GetKeyUp(KeyCode.LeftControl) || Input.GetKeyUp(KeyCode.RightControl))
			{
				result = 2;
			}
		}
		return result;
	}

	// Token: 0x060006B1 RID: 1713 RVA: 0x0002C6A4 File Offset: 0x0002AAA4
	public Finger GetMouseTouch(int fingerIndex, Finger myFinger)
	{
		Finger finger;
		if (myFinger != null)
		{
			finger = myFinger;
		}
		else
		{
			finger = new Finger();
			finger.gesture = EasyTouch.GestureType.None;
		}
		if (fingerIndex == 1 && (Input.GetKeyUp(KeyCode.LeftAlt) || Input.GetKeyUp(KeyCode.RightAlt) || Input.GetKeyUp(KeyCode.LeftControl) || Input.GetKeyUp(KeyCode.RightControl)))
		{
			finger.fingerIndex = fingerIndex;
			finger.position = this.oldFinger2Position;
			finger.deltaPosition = finger.position - this.oldFinger2Position;
			finger.tapCount = this.tapCount[fingerIndex];
			finger.deltaTime = Time.time - this.deltaTime[fingerIndex];
			finger.phase = TouchPhase.Ended;
			return finger;
		}
		if (Input.GetMouseButton(0))
		{
			finger.fingerIndex = fingerIndex;
			finger.position = this.GetPointerPosition(fingerIndex);
			if ((double)(Time.time - this.tapeTime[fingerIndex]) > 0.5)
			{
				this.tapCount[fingerIndex] = 0;
			}
			if (Input.GetMouseButtonDown(0) || (fingerIndex == 1 && (Input.GetKeyDown(KeyCode.LeftAlt) || Input.GetKeyDown(KeyCode.RightAlt) || Input.GetKeyDown(KeyCode.LeftControl) || Input.GetKeyDown(KeyCode.RightControl))))
			{
				finger.position = this.GetPointerPosition(fingerIndex);
				finger.deltaPosition = Vector2.zero;
				this.tapCount[fingerIndex] = this.tapCount[fingerIndex] + 1;
				finger.tapCount = this.tapCount[fingerIndex];
				this.startActionTime[fingerIndex] = Time.time;
				this.deltaTime[fingerIndex] = this.startActionTime[fingerIndex];
				finger.deltaTime = 0f;
				finger.phase = TouchPhase.Began;
				if (fingerIndex == 1)
				{
					this.oldFinger2Position = finger.position;
				}
				else
				{
					this.oldMousePosition[fingerIndex] = finger.position;
				}
				if (this.tapCount[fingerIndex] == 1)
				{
					this.tapeTime[fingerIndex] = Time.time;
				}
				return finger;
			}
			finger.deltaPosition = finger.position - this.oldMousePosition[fingerIndex];
			finger.tapCount = this.tapCount[fingerIndex];
			finger.deltaTime = Time.time - this.deltaTime[fingerIndex];
			if (finger.deltaPosition.sqrMagnitude < 1f)
			{
				finger.phase = TouchPhase.Stationary;
			}
			else
			{
				finger.phase = TouchPhase.Moved;
			}
			this.oldMousePosition[fingerIndex] = finger.position;
			this.deltaTime[fingerIndex] = Time.time;
			return finger;
		}
		else
		{
			if (Input.GetMouseButtonUp(0))
			{
				finger.fingerIndex = fingerIndex;
				finger.position = this.GetPointerPosition(fingerIndex);
				finger.deltaPosition = finger.position - this.oldMousePosition[fingerIndex];
				finger.tapCount = this.tapCount[fingerIndex];
				finger.deltaTime = Time.time - this.deltaTime[fingerIndex];
				finger.phase = TouchPhase.Ended;
				this.oldMousePosition[fingerIndex] = finger.position;
				return finger;
			}
			return null;
		}
	}

	// Token: 0x060006B2 RID: 1714 RVA: 0x0002C9C0 File Offset: 0x0002ADC0
	public Vector2 GetSecondFingerPosition()
	{
		Vector2 result = new Vector2(-1f, -1f);
		if ((Input.GetKey(KeyCode.LeftAlt) || Input.GetKey(KeyCode.RightAlt)) && (Input.GetKey(KeyCode.LeftControl) || Input.GetKey(KeyCode.RightControl)))
		{
			if (!this.bComplex)
			{
				this.bComplex = true;
				this.deltaFingerPosition = Input.mousePosition - this.oldFinger2Position;
			}
			result = this.GetComplex2finger();
			return result;
		}
		if (Input.GetKey(KeyCode.LeftAlt) || Input.GetKey(KeyCode.RightAlt))
		{
			result = this.GetPinchTwist2Finger();
			this.bComplex = false;
			return result;
		}
		if (Input.GetKey(KeyCode.LeftControl) || Input.GetKey(KeyCode.RightControl))
		{
			result = this.GetComplex2finger();
			this.bComplex = false;
			return result;
		}
		return result;
	}

	// Token: 0x060006B3 RID: 1715 RVA: 0x0002CAB0 File Offset: 0x0002AEB0
	private Vector2 GetPointerPosition(int index)
	{
		if (index == 0)
		{
			return Input.mousePosition;
		}
		return this.GetSecondFingerPosition();
	}

	// Token: 0x060006B4 RID: 1716 RVA: 0x0002CAD8 File Offset: 0x0002AED8
	private Vector2 GetPinchTwist2Finger()
	{
		Vector2 result;
		if (this.complexCenter == Vector2.zero)
		{
			result.x = (float)Screen.width / 2f - (Input.mousePosition.x - (float)Screen.width / 2f);
			result.y = (float)Screen.height / 2f - (Input.mousePosition.y - (float)Screen.height / 2f);
		}
		else
		{
			result.x = this.complexCenter.x - (Input.mousePosition.x - this.complexCenter.x);
			result.y = this.complexCenter.y - (Input.mousePosition.y - this.complexCenter.y);
		}
		this.oldFinger2Position = result;
		return result;
	}

	// Token: 0x060006B5 RID: 1717 RVA: 0x0002CBBC File Offset: 0x0002AFBC
	private Vector2 GetComplex2finger()
	{
		Vector2 result;
		result.x = Input.mousePosition.x - this.deltaFingerPosition.x;
		result.y = Input.mousePosition.y - this.deltaFingerPosition.y;
		this.complexCenter = new Vector2((Input.mousePosition.x + result.x) / 2f, (Input.mousePosition.y + result.y) / 2f);
		this.oldFinger2Position = result;
		return result;
	}

	// Token: 0x040005C3 RID: 1475
	private Vector2[] oldMousePosition = new Vector2[2];

	// Token: 0x040005C4 RID: 1476
	private int[] tapCount = new int[2];

	// Token: 0x040005C5 RID: 1477
	private float[] startActionTime = new float[2];

	// Token: 0x040005C6 RID: 1478
	private float[] deltaTime = new float[2];

	// Token: 0x040005C7 RID: 1479
	private float[] tapeTime = new float[2];

	// Token: 0x040005C8 RID: 1480
	private bool bComplex;

	// Token: 0x040005C9 RID: 1481
	private Vector2 deltaFingerPosition;

	// Token: 0x040005CA RID: 1482
	private Vector2 oldFinger2Position;

	// Token: 0x040005CB RID: 1483
	private Vector2 complexCenter;
}
