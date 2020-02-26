using System;
using UnityEngine;

// Token: 0x02000019 RID: 25
[AddComponentMenu("Action-RPG Kit/ARPG Camera")]
[Serializable]
public class ARPGcamera : MonoBehaviour
{
	// Token: 0x06000045 RID: 69 RVA: 0x00004B58 File Offset: 0x00002D58
	public ARPGcamera()
	{
		this.targetHeight = 1.2f;
		this.distance = 4f;
		this.maxDistance = (float)6;
		this.minDistance = 1f;
		this.xSpeed = 250f;
		this.ySpeed = 120f;
		this.yMinLimit = (float)-10;
		this.yMaxLimit = (float)70;
		this.zoomRate = (float)80;
		this.rotationDampening = 3f;
		this.x = 20f;
		this.aimAngle = (float)8;
	}

	// Token: 0x06000046 RID: 70 RVA: 0x00004BE4 File Offset: 0x00002DE4
	public virtual void Start()
	{
		if (!this.target)
		{
			this.target = GameObject.FindWithTag("Player").transform;
		}
		Vector3 eulerAngles = this.transform.eulerAngles;
		this.x = eulerAngles.y;
		this.y = eulerAngles.x;
		if (this.GetComponent<Rigidbody>())
		{
			this.GetComponent<Rigidbody>().freezeRotation = true;
		}
		Screen.lockCursor = true;
	}

	// Token: 0x06000047 RID: 71 RVA: 0x00004C60 File Offset: 0x00002E60
	public virtual void LateUpdate()
	{
		if (this.target)
		{
			if (!this.targetBody)
			{
				this.targetBody = this.target;
			}
			if (Time.timeScale != (float)0)
			{
				this.x += Input.GetAxis("Mouse X") * this.xSpeed * 0.02f;
				this.y -= Input.GetAxis("Mouse Y") * this.ySpeed * 0.02f;
				this.distance -= Input.GetAxis("Mouse ScrollWheel") * Time.deltaTime * this.zoomRate * Mathf.Abs(this.distance);
				this.distance = Mathf.Clamp(this.distance, this.minDistance, this.maxDistance);
				this.y = ARPGcamera.ClampAngle(this.y, this.yMinLimit, this.yMaxLimit);
				Quaternion rotation = Quaternion.Euler(this.y, this.x, (float)0);
				this.transform.rotation = rotation;
				this.aim = Quaternion.Euler(this.y - this.aimAngle, this.x, (float)0);
				if (Input.GetButton("Fire1") || Input.GetButton("Fire2") || Input.GetAxis("Horizontal") != (float)0 || Input.GetAxis("Vertical") != (float)0 || this.lockOn)
				{
					this.targetBody.transform.rotation = Quaternion.Euler((float)0, this.x, (float)0);
				}
				Vector3 position = this.target.position - (rotation * Vector3.forward * this.distance + new Vector3((float)0, -this.targetHeight, (float)0));
				this.transform.position = position;
				RaycastHit raycastHit = default(RaycastHit);
				Vector3 vector = this.target.transform.position - new Vector3((float)0, -this.targetHeight, (float)0);
				if (Physics.Linecast(vector, this.transform.position, out raycastHit) && raycastHit.transform.tag == "Wall")
				{
					float d = Vector3.Distance(vector, raycastHit.point) - 0.28f;
					position = this.target.position - (rotation * Vector3.forward * d + new Vector3((float)0, -this.targetHeight, (float)0));
					this.transform.position = position;
				}
			}
		}
	}

	// Token: 0x06000048 RID: 72 RVA: 0x00004F10 File Offset: 0x00003110
	public static float ClampAngle(float angle, float min, float max)
	{
		if (angle < (float)-360)
		{
			angle += (float)360;
		}
		if (angle > (float)360)
		{
			angle -= (float)360;
		}
		return Mathf.Clamp(angle, min, max);
	}

	// Token: 0x06000049 RID: 73 RVA: 0x00004F5C File Offset: 0x0000315C
	public virtual void Main()
	{
	}

	// Token: 0x04000084 RID: 132
	public Transform target;

	// Token: 0x04000085 RID: 133
	public Transform targetBody;

	// Token: 0x04000086 RID: 134
	public float targetHeight;

	// Token: 0x04000087 RID: 135
	public float distance;

	// Token: 0x04000088 RID: 136
	public float maxDistance;

	// Token: 0x04000089 RID: 137
	public float minDistance;

	// Token: 0x0400008A RID: 138
	public float xSpeed;

	// Token: 0x0400008B RID: 139
	public float ySpeed;

	// Token: 0x0400008C RID: 140
	public float yMinLimit;

	// Token: 0x0400008D RID: 141
	public float yMaxLimit;

	// Token: 0x0400008E RID: 142
	public float zoomRate;

	// Token: 0x0400008F RID: 143
	public float rotationDampening;

	// Token: 0x04000090 RID: 144
	private float x;

	// Token: 0x04000091 RID: 145
	private float y;

	// Token: 0x04000092 RID: 146
	public Quaternion aim;

	// Token: 0x04000093 RID: 147
	public float aimAngle;

	// Token: 0x04000094 RID: 148
	public bool lockOn;
}
