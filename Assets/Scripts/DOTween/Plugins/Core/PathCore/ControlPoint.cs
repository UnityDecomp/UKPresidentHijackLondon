using System;
using UnityEngine;

namespace DG.Tweening.Plugins.Core.PathCore
{
	// Token: 0x0200003E RID: 62
	[Serializable]
	public struct ControlPoint
	{
		// Token: 0x06000212 RID: 530 RVA: 0x0000C0D0 File Offset: 0x0000A2D0
		public ControlPoint(Vector3 a, Vector3 b)
		{
			this.a = a;
			this.b = b;
		}

		// Token: 0x06000213 RID: 531 RVA: 0x0000C0E0 File Offset: 0x0000A2E0
		public static ControlPoint operator +(ControlPoint cp, Vector3 v)
		{
			return new ControlPoint(cp.a + v, cp.b + v);
		}

		// Token: 0x040000FB RID: 251
		public Vector3 a;

		// Token: 0x040000FC RID: 252
		public Vector3 b;
	}
}
