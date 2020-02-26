using System;
using System.Collections;
using UnityEngine;

namespace UnityStandardAssets.Utility
{
	// Token: 0x020001BE RID: 446
	[Serializable]
	public class FOVKick
	{
		// Token: 0x06000BE2 RID: 3042 RVA: 0x0004AE80 File Offset: 0x00049280
		public void Setup(Camera camera)
		{
			this.CheckStatus(camera);
			this.Camera = camera;
			this.originalFov = camera.fieldOfView;
		}

		// Token: 0x06000BE3 RID: 3043 RVA: 0x0004AE9C File Offset: 0x0004929C
		private void CheckStatus(Camera camera)
		{
			if (camera == null)
			{
				throw new Exception("FOVKick camera is null, please supply the camera to the constructor");
			}
			if (this.IncreaseCurve == null)
			{
				throw new Exception("FOVKick Increase curve is null, please define the curve for the field of view kicks");
			}
		}

		// Token: 0x06000BE4 RID: 3044 RVA: 0x0004AECB File Offset: 0x000492CB
		public void ChangeCamera(Camera camera)
		{
			this.Camera = camera;
		}

		// Token: 0x06000BE5 RID: 3045 RVA: 0x0004AED4 File Offset: 0x000492D4
		public IEnumerator FOVKickUp()
		{
			float t = Mathf.Abs((this.Camera.fieldOfView - this.originalFov) / this.FOVIncrease);
			while (t < this.TimeToIncrease)
			{
				this.Camera.fieldOfView = this.originalFov + this.IncreaseCurve.Evaluate(t / this.TimeToIncrease) * this.FOVIncrease;
				t += Time.deltaTime;
				yield return new WaitForEndOfFrame();
			}
			yield break;
		}

		// Token: 0x06000BE6 RID: 3046 RVA: 0x0004AEF0 File Offset: 0x000492F0
		public IEnumerator FOVKickDown()
		{
			float t = Mathf.Abs((this.Camera.fieldOfView - this.originalFov) / this.FOVIncrease);
			while (t > 0f)
			{
				this.Camera.fieldOfView = this.originalFov + this.IncreaseCurve.Evaluate(t / this.TimeToDecrease) * this.FOVIncrease;
				t -= Time.deltaTime;
				yield return new WaitForEndOfFrame();
			}
			this.Camera.fieldOfView = this.originalFov;
			yield break;
		}

		// Token: 0x04000C26 RID: 3110
		public Camera Camera;

		// Token: 0x04000C27 RID: 3111
		[HideInInspector]
		public float originalFov;

		// Token: 0x04000C28 RID: 3112
		public float FOVIncrease = 3f;

		// Token: 0x04000C29 RID: 3113
		public float TimeToIncrease = 1f;

		// Token: 0x04000C2A RID: 3114
		public float TimeToDecrease = 1f;

		// Token: 0x04000C2B RID: 3115
		public AnimationCurve IncreaseCurve;
	}
}
