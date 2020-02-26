using System;
using UnityEngine;

namespace UnityStandardAssets.Utility
{
	// Token: 0x020001B7 RID: 439
	public class CameraRefocus
	{
		// Token: 0x06000BCC RID: 3020 RVA: 0x0004A61F File Offset: 0x00048A1F
		public CameraRefocus(Camera camera, Transform parent, Vector3 origCameraPos)
		{
			this.m_OrigCameraPos = origCameraPos;
			this.Camera = camera;
			this.Parent = parent;
		}

		// Token: 0x06000BCD RID: 3021 RVA: 0x0004A63C File Offset: 0x00048A3C
		public void ChangeCamera(Camera camera)
		{
			this.Camera = camera;
		}

		// Token: 0x06000BCE RID: 3022 RVA: 0x0004A645 File Offset: 0x00048A45
		public void ChangeParent(Transform parent)
		{
			this.Parent = parent;
		}

		// Token: 0x06000BCF RID: 3023 RVA: 0x0004A650 File Offset: 0x00048A50
		public void GetFocusPoint()
		{
			RaycastHit raycastHit;
			if (Physics.Raycast(this.Parent.transform.position + this.m_OrigCameraPos, this.Parent.transform.forward, out raycastHit, 100f))
			{
				this.Lookatpoint = raycastHit.point;
				this.m_Refocus = true;
				return;
			}
			this.m_Refocus = false;
		}

		// Token: 0x06000BD0 RID: 3024 RVA: 0x0004A6B5 File Offset: 0x00048AB5
		public void SetFocusPoint()
		{
			if (this.m_Refocus)
			{
				this.Camera.transform.LookAt(this.Lookatpoint);
			}
		}

		// Token: 0x04000C04 RID: 3076
		public Camera Camera;

		// Token: 0x04000C05 RID: 3077
		public Vector3 Lookatpoint;

		// Token: 0x04000C06 RID: 3078
		public Transform Parent;

		// Token: 0x04000C07 RID: 3079
		private Vector3 m_OrigCameraPos;

		// Token: 0x04000C08 RID: 3080
		private bool m_Refocus;
	}
}
