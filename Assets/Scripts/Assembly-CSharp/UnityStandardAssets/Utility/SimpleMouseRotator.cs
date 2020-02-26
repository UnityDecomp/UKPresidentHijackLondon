using System;
using UnityEngine;
using UnityStandardAssets.CrossPlatformInput;

namespace UnityStandardAssets.Utility
{
	// Token: 0x020001C6 RID: 454
	public class SimpleMouseRotator : MonoBehaviour
	{
		// Token: 0x06000BFC RID: 3068 RVA: 0x0004BA6D File Offset: 0x00049E6D
		private void Start()
		{
			this.m_OriginalRotation = base.transform.localRotation;
		}

		// Token: 0x06000BFD RID: 3069 RVA: 0x0004BA80 File Offset: 0x00049E80
		private void Update()
		{
			base.transform.localRotation = this.m_OriginalRotation;
			if (this.relative)
			{
				float num = CrossPlatformInputManager.GetAxis("Mouse X");
				float num2 = CrossPlatformInputManager.GetAxis("Mouse Y");
				if (this.m_TargetAngles.y > 180f)
				{
					this.m_TargetAngles.y = this.m_TargetAngles.y - 360f;
					this.m_FollowAngles.y = this.m_FollowAngles.y - 360f;
				}
				if (this.m_TargetAngles.x > 180f)
				{
					this.m_TargetAngles.x = this.m_TargetAngles.x - 360f;
					this.m_FollowAngles.x = this.m_FollowAngles.x - 360f;
				}
				if (this.m_TargetAngles.y < -180f)
				{
					this.m_TargetAngles.y = this.m_TargetAngles.y + 360f;
					this.m_FollowAngles.y = this.m_FollowAngles.y + 360f;
				}
				if (this.m_TargetAngles.x < -180f)
				{
					this.m_TargetAngles.x = this.m_TargetAngles.x + 360f;
					this.m_FollowAngles.x = this.m_FollowAngles.x + 360f;
				}
				if (this.autoZeroHorizontalOnMobile)
				{
					this.m_TargetAngles.y = Mathf.Lerp(-this.rotationRange.y * 0.5f, this.rotationRange.y * 0.5f, num * 0.5f + 0.5f);
				}
				else
				{
					this.m_TargetAngles.y = this.m_TargetAngles.y + num * this.rotationSpeed;
				}
				if (this.autoZeroVerticalOnMobile)
				{
					this.m_TargetAngles.x = Mathf.Lerp(-this.rotationRange.x * 0.5f, this.rotationRange.x * 0.5f, num2 * 0.5f + 0.5f);
				}
				else
				{
					this.m_TargetAngles.x = this.m_TargetAngles.x + num2 * this.rotationSpeed;
				}
				this.m_TargetAngles.y = Mathf.Clamp(this.m_TargetAngles.y, -this.rotationRange.y * 0.5f, this.rotationRange.y * 0.5f);
				this.m_TargetAngles.x = Mathf.Clamp(this.m_TargetAngles.x, -this.rotationRange.x * 0.5f, this.rotationRange.x * 0.5f);
			}
			else
			{
				float num = Input.mousePosition.x;
				float num2 = Input.mousePosition.y;
				this.m_TargetAngles.y = Mathf.Lerp(-this.rotationRange.y * 0.5f, this.rotationRange.y * 0.5f, num / (float)Screen.width);
				this.m_TargetAngles.x = Mathf.Lerp(-this.rotationRange.x * 0.5f, this.rotationRange.x * 0.5f, num2 / (float)Screen.height);
			}
			this.m_FollowAngles = Vector3.SmoothDamp(this.m_FollowAngles, this.m_TargetAngles, ref this.m_FollowVelocity, this.dampingTime);
			base.transform.localRotation = this.m_OriginalRotation * Quaternion.Euler(-this.m_FollowAngles.x, this.m_FollowAngles.y, 0f);
		}

		// Token: 0x04000C47 RID: 3143
		public Vector2 rotationRange = new Vector3(70f, 70f);

		// Token: 0x04000C48 RID: 3144
		public float rotationSpeed = 10f;

		// Token: 0x04000C49 RID: 3145
		public float dampingTime = 0.2f;

		// Token: 0x04000C4A RID: 3146
		public bool autoZeroVerticalOnMobile = true;

		// Token: 0x04000C4B RID: 3147
		public bool autoZeroHorizontalOnMobile;

		// Token: 0x04000C4C RID: 3148
		public bool relative = true;

		// Token: 0x04000C4D RID: 3149
		private Vector3 m_TargetAngles;

		// Token: 0x04000C4E RID: 3150
		private Vector3 m_FollowAngles;

		// Token: 0x04000C4F RID: 3151
		private Vector3 m_FollowVelocity;

		// Token: 0x04000C50 RID: 3152
		private Quaternion m_OriginalRotation;
	}
}
