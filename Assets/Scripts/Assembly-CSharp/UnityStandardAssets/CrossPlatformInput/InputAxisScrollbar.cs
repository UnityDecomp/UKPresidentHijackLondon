using System;
using UnityEngine;

namespace UnityStandardAssets.CrossPlatformInput
{
	// Token: 0x0200015D RID: 349
	public class InputAxisScrollbar : MonoBehaviour
	{
		// Token: 0x06000A9E RID: 2718 RVA: 0x0003F320 File Offset: 0x0003D720
		private void Update()
		{
		}

		// Token: 0x06000A9F RID: 2719 RVA: 0x0003F322 File Offset: 0x0003D722
		public void HandleInput(float value)
		{
			CrossPlatformInputManager.SetAxis(this.axis, value * 2f - 1f);
		}

		// Token: 0x04000997 RID: 2455
		public string axis;
	}
}
