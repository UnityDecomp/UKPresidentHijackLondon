using System;
using UnityEngine;

namespace UnityStandardAssets.Utility
{
	// Token: 0x020001B8 RID: 440
	[Serializable]
	public class CurveControlledBob
	{
		// Token: 0x06000BD2 RID: 3026 RVA: 0x0004A7A4 File Offset: 0x00048BA4
		public void Setup(Camera camera, float bobBaseInterval)
		{
			this.m_BobBaseInterval = bobBaseInterval;
			this.m_OriginalCameraPosition = camera.transform.localPosition;
			this.m_Time = this.Bobcurve[this.Bobcurve.length - 1].time;
		}

		// Token: 0x06000BD3 RID: 3027 RVA: 0x0004A7F0 File Offset: 0x00048BF0
		public Vector3 DoHeadBob(float speed)
		{
			float x = this.m_OriginalCameraPosition.x + this.Bobcurve.Evaluate(this.m_CyclePositionX) * this.HorizontalBobRange;
			float y = this.m_OriginalCameraPosition.y + this.Bobcurve.Evaluate(this.m_CyclePositionY) * this.VerticalBobRange;
			this.m_CyclePositionX += speed * Time.deltaTime / this.m_BobBaseInterval;
			this.m_CyclePositionY += speed * Time.deltaTime / this.m_BobBaseInterval * this.VerticaltoHorizontalRatio;
			if (this.m_CyclePositionX > this.m_Time)
			{
				this.m_CyclePositionX -= this.m_Time;
			}
			if (this.m_CyclePositionY > this.m_Time)
			{
				this.m_CyclePositionY -= this.m_Time;
			}
			return new Vector3(x, y, 0f);
		}

		// Token: 0x04000C09 RID: 3081
		public float HorizontalBobRange = 0.33f;

		// Token: 0x04000C0A RID: 3082
		public float VerticalBobRange = 0.33f;

		// Token: 0x04000C0B RID: 3083
		public AnimationCurve Bobcurve = new AnimationCurve(new Keyframe[]
		{
			new Keyframe(0f, 0f),
			new Keyframe(0.5f, 1f),
			new Keyframe(1f, 0f),
			new Keyframe(1.5f, -1f),
			new Keyframe(2f, 0f)
		});

		// Token: 0x04000C0C RID: 3084
		public float VerticaltoHorizontalRatio = 1f;

		// Token: 0x04000C0D RID: 3085
		private float m_CyclePositionX;

		// Token: 0x04000C0E RID: 3086
		private float m_CyclePositionY;

		// Token: 0x04000C0F RID: 3087
		private float m_BobBaseInterval;

		// Token: 0x04000C10 RID: 3088
		private Vector3 m_OriginalCameraPosition;

		// Token: 0x04000C11 RID: 3089
		private float m_Time;
	}
}
