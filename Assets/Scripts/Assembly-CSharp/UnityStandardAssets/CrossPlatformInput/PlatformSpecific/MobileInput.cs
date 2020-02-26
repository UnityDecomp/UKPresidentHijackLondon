using System;
using UnityEngine;

namespace UnityStandardAssets.CrossPlatformInput.PlatformSpecific
{
	// Token: 0x02000161 RID: 353
	public class MobileInput : VirtualInput
	{
		// Token: 0x06000AAF RID: 2735 RVA: 0x0003F8E1 File Offset: 0x0003DCE1
		private void AddButton(string name)
		{
			CrossPlatformInputManager.RegisterVirtualButton(new CrossPlatformInputManager.VirtualButton(name));
		}

		// Token: 0x06000AB0 RID: 2736 RVA: 0x0003F8EE File Offset: 0x0003DCEE
		private void AddAxes(string name)
		{
			CrossPlatformInputManager.RegisterVirtualAxis(new CrossPlatformInputManager.VirtualAxis(name));
		}

		// Token: 0x06000AB1 RID: 2737 RVA: 0x0003F8FB File Offset: 0x0003DCFB
		public override float GetAxis(string name, bool raw)
		{
			if (!this.m_VirtualAxes.ContainsKey(name))
			{
				this.AddAxes(name);
			}
			return this.m_VirtualAxes[name].GetValue;
		}

		// Token: 0x06000AB2 RID: 2738 RVA: 0x0003F926 File Offset: 0x0003DD26
		public override void SetButtonDown(string name)
		{
			if (!this.m_VirtualButtons.ContainsKey(name))
			{
				this.AddButton(name);
			}
			this.m_VirtualButtons[name].Pressed();
		}

		// Token: 0x06000AB3 RID: 2739 RVA: 0x0003F951 File Offset: 0x0003DD51
		public override void SetButtonUp(string name)
		{
			if (!this.m_VirtualButtons.ContainsKey(name))
			{
				this.AddButton(name);
			}
			this.m_VirtualButtons[name].Released();
		}

		// Token: 0x06000AB4 RID: 2740 RVA: 0x0003F97C File Offset: 0x0003DD7C
		public override void SetAxisPositive(string name)
		{
			if (!this.m_VirtualAxes.ContainsKey(name))
			{
				this.AddAxes(name);
			}
			this.m_VirtualAxes[name].Update(1f);
		}

		// Token: 0x06000AB5 RID: 2741 RVA: 0x0003F9AC File Offset: 0x0003DDAC
		public override void SetAxisNegative(string name)
		{
			if (!this.m_VirtualAxes.ContainsKey(name))
			{
				this.AddAxes(name);
			}
			this.m_VirtualAxes[name].Update(-1f);
		}

		// Token: 0x06000AB6 RID: 2742 RVA: 0x0003F9DC File Offset: 0x0003DDDC
		public override void SetAxisZero(string name)
		{
			if (!this.m_VirtualAxes.ContainsKey(name))
			{
				this.AddAxes(name);
			}
			this.m_VirtualAxes[name].Update(0f);
		}

		// Token: 0x06000AB7 RID: 2743 RVA: 0x0003FA0C File Offset: 0x0003DE0C
		public override void SetAxis(string name, float value)
		{
			if (!this.m_VirtualAxes.ContainsKey(name))
			{
				this.AddAxes(name);
			}
			this.m_VirtualAxes[name].Update(value);
		}

		// Token: 0x06000AB8 RID: 2744 RVA: 0x0003FA38 File Offset: 0x0003DE38
		public override bool GetButtonDown(string name)
		{
			if (this.m_VirtualButtons.ContainsKey(name))
			{
				return this.m_VirtualButtons[name].GetButtonDown;
			}
			this.AddButton(name);
			return this.m_VirtualButtons[name].GetButtonDown;
		}

		// Token: 0x06000AB9 RID: 2745 RVA: 0x0003FA75 File Offset: 0x0003DE75
		public override bool GetButtonUp(string name)
		{
			if (this.m_VirtualButtons.ContainsKey(name))
			{
				return this.m_VirtualButtons[name].GetButtonUp;
			}
			this.AddButton(name);
			return this.m_VirtualButtons[name].GetButtonUp;
		}

		// Token: 0x06000ABA RID: 2746 RVA: 0x0003FAB2 File Offset: 0x0003DEB2
		public override bool GetButton(string name)
		{
			if (this.m_VirtualButtons.ContainsKey(name))
			{
				return this.m_VirtualButtons[name].GetButton;
			}
			this.AddButton(name);
			return this.m_VirtualButtons[name].GetButton;
		}

		// Token: 0x06000ABB RID: 2747 RVA: 0x0003FAEF File Offset: 0x0003DEEF
		public override Vector3 MousePosition()
		{
			return base.virtualMousePosition;
		}
	}
}
