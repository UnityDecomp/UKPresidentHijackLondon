using System;
using UnityEngine;

namespace UnityStandardAssets.CrossPlatformInput
{
	// Token: 0x02000158 RID: 344
	public class ButtonHandler : MonoBehaviour
	{
		// Token: 0x06000A67 RID: 2663 RVA: 0x0003F027 File Offset: 0x0003D427
		private void OnEnable()
		{
		}

		// Token: 0x06000A68 RID: 2664 RVA: 0x0003F029 File Offset: 0x0003D429
		public void SetDownState()
		{
			CrossPlatformInputManager.SetButtonDown(this.Name);
		}

		// Token: 0x06000A69 RID: 2665 RVA: 0x0003F036 File Offset: 0x0003D436
		public void SetUpState()
		{
			CrossPlatformInputManager.SetButtonUp(this.Name);
		}

		// Token: 0x06000A6A RID: 2666 RVA: 0x0003F043 File Offset: 0x0003D443
		public void SetAxisPositiveState()
		{
			CrossPlatformInputManager.SetAxisPositive(this.Name);
		}

		// Token: 0x06000A6B RID: 2667 RVA: 0x0003F050 File Offset: 0x0003D450
		public void SetAxisNeutralState()
		{
			CrossPlatformInputManager.SetAxisZero(this.Name);
		}

		// Token: 0x06000A6C RID: 2668 RVA: 0x0003F05D File Offset: 0x0003D45D
		public void SetAxisNegativeState()
		{
			CrossPlatformInputManager.SetAxisNegative(this.Name);
		}

		// Token: 0x06000A6D RID: 2669 RVA: 0x0003F06A File Offset: 0x0003D46A
		public void Update()
		{
		}

		// Token: 0x04000988 RID: 2440
		public string Name;
	}
}
