using System;
using UnityEngine;

// Token: 0x020001D5 RID: 469
public class ARPGcameraC : MonoBehaviour
{
	// Token: 0x06000C30 RID: 3120 RVA: 0x0004D248 File Offset: 0x0004B648
	private void Start()
	{
		if (!this.target)
		{
			this.target = GameObject.FindWithTag("Player").transform;
		}
		Vector3 eulerAngles = base.transform.eulerAngles;
		this.x = eulerAngles.y;
		this.y = eulerAngles.x;
		if (base.GetComponent<Rigidbody>())
		{
			base.GetComponent<Rigidbody>().freezeRotation = true;
		}
	}

	// Token: 0x06000C31 RID: 3121 RVA: 0x0004D2BC File Offset: 0x0004B6BC
	private void LateUpdate()
	{
		if (!this.target)
		{
			return;
		}
		if (!this.targetBody)
		{
			this.targetBody = this.target;
		}
		if (Time.timeScale == 0f)
		{
			return;
		}
		this.x += CFInput.GetAxis("Mouse X") * this.xSpeed * 0.02f;
		this.y -= CFInput.GetAxis("Mouse Y") * this.ySpeed * 0.02f;
		this.distance -= CFInput.GetAxis("Mouse ScrollWheel") * Time.deltaTime * this.zoomRate * Mathf.Abs(this.distance);
		this.distance = Mathf.Clamp(this.distance, this.minDistance, this.maxDistance);
		this.y = ARPGcameraC.ClampAngle(this.y, this.yMinLimit, this.yMaxLimit);
		Quaternion rotation = Quaternion.Euler(0f, this.x, 0f);
		base.transform.rotation = rotation;
		this.aim = Quaternion.Euler(0f - this.aimAngle, this.x, 0f);
		if (CFInput.GetButton("Fire1") || CFInput.GetButton("Fire2") || CFInput.GetAxis("Horizontal") != 0f || CFInput.GetAxis("Vertical") != 0f || this.lockOn)
		{
			this.targetBody.transform.rotation = Quaternion.Euler(0f, this.x, 0f);
		}
		Vector3 position = this.target.position - (rotation * Vector3.forward * this.distance + new Vector3(this.offsetX, -this.targetHeight, this.offsetZ));
		base.transform.position = position;
		Vector3 vector = this.target.transform.position - new Vector3(0f, -this.targetHeight, 0f);
		if (Physics.Linecast(vector, base.transform.position, out this.hit) && this.hit.transform.tag == "Wall")
		{
			float d = Vector3.Distance(vector, this.hit.point) - 0.28f;
			position = this.target.position - (rotation * Vector3.forward * d + new Vector3(0f, -this.targetHeight, 0f));
			base.transform.position = position;
		}
	}

	// Token: 0x06000C32 RID: 3122 RVA: 0x0004D58A File Offset: 0x0004B98A
	private static float ClampAngle(float angle, float min, float max)
	{
		if (angle < -360f)
		{
			angle += 360f;
		}
		if (angle > 360f)
		{
			angle -= 360f;
		}
		return Mathf.Clamp(angle, min, max);
	}

	// Token: 0x04000C94 RID: 3220
	public Transform target;

	// Token: 0x04000C95 RID: 3221
	public Transform targetBody;

	// Token: 0x04000C96 RID: 3222
	public float targetHeight = 1.2f;

	// Token: 0x04000C97 RID: 3223
	public float distance = 4f;

	// Token: 0x04000C98 RID: 3224
	public float maxDistance = 6f;

	// Token: 0x04000C99 RID: 3225
	public float minDistance = 1f;

	// Token: 0x04000C9A RID: 3226
	public float xSpeed = 250f;

	// Token: 0x04000C9B RID: 3227
	public float ySpeed = 120f;

	// Token: 0x04000C9C RID: 3228
	public float yMinLimit = -10f;

	// Token: 0x04000C9D RID: 3229
	public float yMaxLimit = 70f;

	// Token: 0x04000C9E RID: 3230
	public float zoomRate = 80f;

	// Token: 0x04000C9F RID: 3231
	public float rotationDampening = 3f;

	// Token: 0x04000CA0 RID: 3232
	private float x = 20f;

	// Token: 0x04000CA1 RID: 3233
	private float y;

	// Token: 0x04000CA2 RID: 3234
	public Quaternion aim;

	// Token: 0x04000CA3 RID: 3235
	public float aimAngle = 8f;

	// Token: 0x04000CA4 RID: 3236
	public float offsetX;

	// Token: 0x04000CA5 RID: 3237
	public float offsetZ;

	// Token: 0x04000CA6 RID: 3238
	private bool setPosition = true;

	// Token: 0x04000CA7 RID: 3239
	public bool lockOn;

	// Token: 0x04000CA8 RID: 3240
	private RaycastHit hit;
}
