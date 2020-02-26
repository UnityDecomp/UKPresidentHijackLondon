using System;
using UnityEngine;

namespace UnityStandardAssets.CrossPlatformInput.PlatformSpecific
{
	// Token: 0x02000162 RID: 354
	public class StandaloneInput : VirtualInput
	{
		// Token: 0x06000ABD RID: 2749 RVA: 0x0003FAFF File Offset: 0x0003DEFF
		public override float GetAxis(string name, bool raw)
		{
			return (!raw) ? Input.GetAxis(name) : Input.GetAxisRaw(name);
		}

		// Token: 0x06000ABE RID: 2750 RVA: 0x0003FB18 File Offset: 0x0003DF18
		public override bool GetButton(string name)
		{
			return Input.GetButton(name);
		}

		// Token: 0x06000ABF RID: 2751 RVA: 0x0003FB20 File Offset: 0x0003DF20
		public override bool GetButtonDown(string name)
		{
			return Input.GetButtonDown(name);
		}

		// Token: 0x06000AC0 RID: 2752 RVA: 0x0003FB28 File Offset: 0x0003DF28
		public override bool GetButtonUp(string name)
		{
			return Input.GetButtonUp(name);
		}

		// Token: 0x06000AC1 RID: 2753 RVA: 0x0003FB30 File Offset: 0x0003DF30
		public override void SetButtonDown(string name)
		{
			throw new Exception(" This is not possible to be called for standalone input. Please check your platform and code where this is called");
		}

		// Token: 0x06000AC2 RID: 2754 RVA: 0x0003FB3C File Offset: 0x0003DF3C
		public override void SetButtonUp(string name)
		{
			throw new Exception(" This is not possible to be called for standalone input. Please check your platform and code where this is called");
		}

		// Token: 0x06000AC3 RID: 2755 RVA: 0x0003FB48 File Offset: 0x0003DF48
		public override void SetAxisPositive(string name)
		{
			throw new Exception(" This is not possible to be called for standalone input. Please check your platform and code where this is called");
		}

		// Token: 0x06000AC4 RID: 2756 RVA: 0x0003FB54 File Offset: 0x0003DF54
		public override void SetAxisNegative(string name)
		{
			throw new Exception(" This is not possible to be called for standalone input. Please check your platform and code where this is called");
		}

		// Token: 0x06000AC5 RID: 2757 RVA: 0x0003FB60 File Offset: 0x0003DF60
		public override void SetAxisZero(string name)
		{
			throw new Exception(" This is not possible to be called for standalone input. Please check your platform and code where this is called");
		}

		// Token: 0x06000AC6 RID: 2758 RVA: 0x0003FB6C File Offset: 0x0003DF6C
		public override void SetAxis(string name, float value)
		{
			throw new Exception(" This is not possible to be called for standalone input. Please check your platform and code where this is called");
		}

		// Token: 0x06000AC7 RID: 2759 RVA: 0x0003FB78 File Offset: 0x0003DF78
		public override Vector3 MousePosition()
		{
			return Input.mousePosition;
		}
	}
}
