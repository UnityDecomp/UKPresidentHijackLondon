using System;
using UnityEngine;

// Token: 0x020000A5 RID: 165
public class DemonController : MonoBehaviour
{
	// Token: 0x060004C2 RID: 1218 RVA: 0x000258E0 File Offset: 0x00023CE0
	private void OnEnable()
	{
		EasyTouch.On_TouchDown += this.On_TouchDown;
		EasyTouch.On_TouchUp += this.On_TouchUp;
		EasyTouch.On_TouchStart += this.On_TouchStart;
	}

	// Token: 0x060004C3 RID: 1219 RVA: 0x00025915 File Offset: 0x00023D15
	private void OnDisable()
	{
		this.UnsubscribeEvent();
	}

	// Token: 0x060004C4 RID: 1220 RVA: 0x0002591D File Offset: 0x00023D1D
	private void OnDestroy()
	{
		this.UnsubscribeEvent();
	}

	// Token: 0x060004C5 RID: 1221 RVA: 0x00025925 File Offset: 0x00023D25
	private void UnsubscribeEvent()
	{
		EasyTouch.On_TouchDown -= this.On_TouchDown;
		EasyTouch.On_TouchUp -= this.On_TouchUp;
		EasyTouch.On_TouchStart -= this.On_TouchStart;
	}

	// Token: 0x060004C6 RID: 1222 RVA: 0x0002595A File Offset: 0x00023D5A
	private void Start()
	{
		this.demon = GameObject.Find("demon").gameObject;
		this.controller = this.demon.GetComponent<CharacterController>();
	}

	// Token: 0x060004C7 RID: 1223 RVA: 0x00025984 File Offset: 0x00023D84
	private void Update()
	{
		if (EasyTouch.GetTouchCount() == 0)
		{
			this.demon.GetComponent<Animation>().CrossFade("idle");
		}
		if (!this.controller.isGrounded)
		{
			this.demon.GetComponent<Animation>().CrossFade("jump");
			this.moveDirection.y = this.moveDirection.y - 5f * Time.deltaTime;
		}
		this.controller.Move(this.moveDirection * Time.deltaTime);
		this.moveDirection = new Vector3(0f, this.moveDirection.y, 0f);
	}

	// Token: 0x060004C8 RID: 1224 RVA: 0x00025A30 File Offset: 0x00023E30
	private void On_TouchDown(Gesture gesture)
	{
		GameObject currentPickedObject = EasyTouch.GetCurrentPickedObject(gesture.fingerIndex);
		if (currentPickedObject != null)
		{
			if (currentPickedObject.name == "Right")
			{
				this.demon.transform.localEulerAngles = new Vector3(0f, 90f, 0f);
				this.moveDirection.x = 0.7f;
				this.demon.GetComponent<Animation>().CrossFade("walk");
			}
			else if (currentPickedObject.name == "Left")
			{
				this.demon.transform.localEulerAngles = new Vector3(0f, -90f, 0f);
				this.moveDirection.x = -0.7f;
				this.demon.GetComponent<Animation>().CrossFade("walk");
			}
		}
	}

	// Token: 0x060004C9 RID: 1225 RVA: 0x00025B16 File Offset: 0x00023F16
	private void On_TouchUp(Gesture gesture)
	{
		this.moveDirection = new Vector3(0f, this.moveDirection.y, 0f);
	}

	// Token: 0x060004CA RID: 1226 RVA: 0x00025B38 File Offset: 0x00023F38
	private void On_TouchStart(Gesture gesture)
	{
		if (gesture.pickObject != null && this.controller.isGrounded && gesture.pickObject.name == "Up")
		{
			this.moveDirection.y = 3f;
		}
	}

	// Token: 0x040004D9 RID: 1241
	private GameObject demon;

	// Token: 0x040004DA RID: 1242
	private CharacterController controller;

	// Token: 0x040004DB RID: 1243
	private Vector3 moveDirection;
}
