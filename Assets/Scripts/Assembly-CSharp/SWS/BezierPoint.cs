using System;
using UnityEngine;

namespace SWS
{
	// Token: 0x02000107 RID: 263
	[Serializable]
	public class BezierPoint
	{
		// Token: 0x04000626 RID: 1574
		public Transform wp;

		// Token: 0x04000627 RID: 1575
		public Transform[] cp = new Transform[2];
	}
}
