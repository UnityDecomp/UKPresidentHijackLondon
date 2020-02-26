using System;
using System.Collections;
using UnityEngine;

// Token: 0x020000AC RID: 172
public class ObjectTouch : MonoBehaviour
{
	// Token: 0x060004E7 RID: 1255 RVA: 0x0002635C File Offset: 0x0002475C
	private void OnEnable()
	{
		EasyTouch.On_TouchStart += this.On_TouchStart;
		EasyTouch.On_SimpleTap += this.On_SimpleTap;
		EasyTouch.On_LongTap += this.On_LongTap;
		EasyTouch.On_DragStart += this.On_DragStart;
		EasyTouch.On_Drag += this.On_Drag;
		EasyTouch.On_DragEnd += this.On_DragEnd;
		EasyTouch.On_PinchIn += this.On_PinchIn;
		EasyTouch.On_PinchOut += this.On_PinchOut;
	}

	// Token: 0x060004E8 RID: 1256 RVA: 0x000263F1 File Offset: 0x000247F1
	private void OnDisable()
	{
		this.UnsubscribeEvent();
	}

	// Token: 0x060004E9 RID: 1257 RVA: 0x000263F9 File Offset: 0x000247F9
	private void OnDestroy()
	{
		this.UnsubscribeEvent();
	}

	// Token: 0x060004EA RID: 1258 RVA: 0x00026404 File Offset: 0x00024804
	private void UnsubscribeEvent()
	{
		EasyTouch.On_TouchStart -= this.On_TouchStart;
		EasyTouch.On_SimpleTap -= this.On_SimpleTap;
		EasyTouch.On_LongTap -= this.On_LongTap;
		EasyTouch.On_DragStart -= this.On_DragStart;
		EasyTouch.On_Drag -= this.On_Drag;
		EasyTouch.On_DragEnd -= this.On_DragEnd;
		EasyTouch.On_PinchIn -= this.On_PinchIn;
		EasyTouch.On_PinchOut -= this.On_PinchOut;
	}

	// Token: 0x060004EB RID: 1259 RVA: 0x00026499 File Offset: 0x00024899
	private void Start()
	{
		this.cam = Camera.main;
	}

	// Token: 0x060004EC RID: 1260 RVA: 0x000264A8 File Offset: 0x000248A8
	private void FixedUpdate()
	{
		Vector2 vector = this.cam.WorldToScreenPoint(base.GetComponent<Rigidbody>().position);
		if (vector.x > (float)Screen.width || vector.y < 0f || vector.y > (float)Screen.height)
		{
			UnityEngine.Object.Destroy(base.gameObject);
		}
		if (vector.x < base.transform.localScale.x / 2f)
		{
			base.GetComponent<Rigidbody>().AddForce(base.GetComponent<Rigidbody>().velocity * -100f);
		}
	}

	// Token: 0x060004ED RID: 1261 RVA: 0x00026556 File Offset: 0x00024956
	private void On_TouchStart(Gesture gesture)
	{
		if (gesture.pickObject == base.gameObject)
		{
			base.GetComponent<Rigidbody>().constraints = RigidbodyConstraints.FreezeAll;
		}
	}

	// Token: 0x060004EE RID: 1262 RVA: 0x0002657C File Offset: 0x0002497C
	private void On_SimpleTap(Gesture gesture)
	{
		if (gesture.pickObject == base.gameObject)
		{
			GameObject gameObject = null;
			base.GetComponent<Rigidbody>().constraints = RigidbodyConstraints.None;
			IEnumerator enumerator = base.transform.GetEnumerator();
			try
			{
				while (enumerator.MoveNext())
				{
					object obj = enumerator.Current;
					Transform transform = (Transform)obj;
					if (transform.name == "ring")
					{
						gameObject = transform.gameObject;
					}
				}
			}
			finally
			{
				IDisposable disposable;
				if ((disposable = (enumerator as IDisposable)) != null)
				{
					disposable.Dispose();
				}
			}
			if (gameObject == null)
			{
				GameObject gameObject2 = UnityEngine.Object.Instantiate(Resources.Load("Ring01"), base.transform.position, Quaternion.identity) as GameObject;
				gameObject2.transform.localScale = base.transform.localScale * 1.5f;
				gameObject2.AddComponent<SlowRotate>();
				gameObject2.GetComponent<Renderer>().material.SetColor("_TintColor", base.GetComponent<Renderer>().material.GetColor("_TintColor"));
				gameObject2.transform.parent = base.transform;
				gameObject2.name = "ring";
			}
			else
			{
				UnityEngine.Object.Destroy(gameObject);
			}
		}
	}

	// Token: 0x060004EF RID: 1263 RVA: 0x000266CC File Offset: 0x00024ACC
	private void On_LongTap(Gesture gesture)
	{
		if (gesture.pickObject == base.gameObject)
		{
			GameObject gameObject = null;
			base.GetComponent<Rigidbody>().constraints = RigidbodyConstraints.None;
			IEnumerator enumerator = base.transform.GetEnumerator();
			try
			{
				while (enumerator.MoveNext())
				{
					object obj = enumerator.Current;
					Transform transform = (Transform)obj;
					if (transform.name == "ring")
					{
						gameObject = transform.gameObject;
					}
				}
			}
			finally
			{
				IDisposable disposable;
				if ((disposable = (enumerator as IDisposable)) != null)
				{
					disposable.Dispose();
				}
			}
			if (gameObject != null)
			{
				gameObject.GetComponent<SlowRotate>().rotateSpeed *= 1.1f;
			}
		}
	}

	// Token: 0x060004F0 RID: 1264 RVA: 0x00026790 File Offset: 0x00024B90
	private void On_DragStart(Gesture gesture)
	{
		if (gesture.pickObject == base.gameObject)
		{
			Vector3 touchToWordlPoint = gesture.GetTouchToWordlPoint(8f);
			this.deltaPosition = touchToWordlPoint - base.GetComponent<Rigidbody>().position;
			base.GetComponent<Rigidbody>().constraints = RigidbodyConstraints.None;
		}
	}

	// Token: 0x060004F1 RID: 1265 RVA: 0x000267E4 File Offset: 0x00024BE4
	private void On_Drag(Gesture gesture)
	{
		if (gesture.pickObject == base.gameObject)
		{
			Vector3 touchToWordlPoint = gesture.GetTouchToWordlPoint(8f);
			base.GetComponent<Rigidbody>().position = touchToWordlPoint - this.deltaPosition;
		}
	}

	// Token: 0x060004F2 RID: 1266 RVA: 0x0002682C File Offset: 0x00024C2C
	private void On_DragEnd(Gesture gesture)
	{
		if (gesture.pickObject == base.gameObject)
		{
			base.GetComponent<Rigidbody>().AddForce(gesture.deltaPosition * gesture.swipeLength / 10f);
		}
	}

	// Token: 0x060004F3 RID: 1267 RVA: 0x0002687C File Offset: 0x00024C7C
	private void On_PinchIn(Gesture gesture)
	{
		if (gesture.pickObject == base.gameObject)
		{
			float num = Time.deltaTime * gesture.deltaPinch;
			Vector3 localScale = base.transform.localScale;
			base.transform.localScale = new Vector3(localScale.x - num, localScale.y - num, 1f);
		}
	}

	// Token: 0x060004F4 RID: 1268 RVA: 0x000268E0 File Offset: 0x00024CE0
	private void On_PinchOut(Gesture gesture)
	{
		if (gesture.pickObject == base.gameObject)
		{
			float num = Time.deltaTime * gesture.deltaPinch;
			Vector3 localScale = base.transform.localScale;
			base.transform.localScale = new Vector3(localScale.x + num, localScale.y + num, 1f);
		}
	}

	// Token: 0x040004E2 RID: 1250
	private Camera cam;

	// Token: 0x040004E3 RID: 1251
	private Vector3 deltaPosition;
}
