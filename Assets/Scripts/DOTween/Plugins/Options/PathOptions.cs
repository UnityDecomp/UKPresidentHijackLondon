using System;
using UnityEngine;

namespace DG.Tweening.Plugins.Options
{
	// Token: 0x0200002F RID: 47
	public struct PathOptions
	{
		// Token: 0x040000CB RID: 203
		public PathMode mode;

		// Token: 0x040000CC RID: 204
		public OrientType orientType;

		// Token: 0x040000CD RID: 205
		public AxisConstraint lockPositionAxis;

		// Token: 0x040000CE RID: 206
		public AxisConstraint lockRotationAxis;

		// Token: 0x040000CF RID: 207
		public bool isClosedPath;

		// Token: 0x040000D0 RID: 208
		public Vector3 lookAtPosition;

		// Token: 0x040000D1 RID: 209
		public Transform lookAtTransform;

		// Token: 0x040000D2 RID: 210
		public float lookAhead;

		// Token: 0x040000D3 RID: 211
		public bool hasCustomForwardDirection;

		// Token: 0x040000D4 RID: 212
		public Quaternion forward;

		// Token: 0x040000D5 RID: 213
		public bool useLocalPosition;

		// Token: 0x040000D6 RID: 214
		public Transform parent;

		// Token: 0x040000D7 RID: 215
		internal Quaternion startupRot;

		// Token: 0x040000D8 RID: 216
		internal float startupZRot;
	}
}
