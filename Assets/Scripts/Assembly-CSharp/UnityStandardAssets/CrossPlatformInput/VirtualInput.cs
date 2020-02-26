using System;
using System.Collections.Generic;
using UnityEngine;

namespace UnityStandardAssets.CrossPlatformInput
{
	// Token: 0x0200016A RID: 362
	public abstract class VirtualInput
	{
		// Token: 0x17000058 RID: 88
		// (get) Token: 0x06000AD7 RID: 2775 RVA: 0x0003F6BD File Offset: 0x0003DABD
		// (set) Token: 0x06000AD8 RID: 2776 RVA: 0x0003F6C5 File Offset: 0x0003DAC5
		public Vector3 virtualMousePosition { get; private set; }

		// Token: 0x06000AD9 RID: 2777 RVA: 0x0003F6CE File Offset: 0x0003DACE
		public bool AxisExists(string name)
		{
			return this.m_VirtualAxes.ContainsKey(name);
		}

		// Token: 0x06000ADA RID: 2778 RVA: 0x0003F6DC File Offset: 0x0003DADC
		public bool ButtonExists(string name)
		{
			return this.m_VirtualButtons.ContainsKey(name);
		}

		// Token: 0x06000ADB RID: 2779 RVA: 0x0003F6EC File Offset: 0x0003DAEC
		public void RegisterVirtualAxis(CrossPlatformInputManager.VirtualAxis axis)
		{
			if (this.m_VirtualAxes.ContainsKey(axis.name))
			{
				Debug.LogError("There is already a virtual axis named " + axis.name + " registered.");
			}
			else
			{
				this.m_VirtualAxes.Add(axis.name, axis);
				if (!axis.matchWithInputManager)
				{
					this.m_AlwaysUseVirtual.Add(axis.name);
				}
			}
		}

		// Token: 0x06000ADC RID: 2780 RVA: 0x0003F75C File Offset: 0x0003DB5C
		public void RegisterVirtualButton(CrossPlatformInputManager.VirtualButton button)
		{
			if (this.m_VirtualButtons.ContainsKey(button.name))
			{
				Debug.LogError("There is already a virtual button named " + button.name + " registered.");
			}
			else
			{
				this.m_VirtualButtons.Add(button.name, button);
				if (!button.matchWithInputManager)
				{
					this.m_AlwaysUseVirtual.Add(button.name);
				}
			}
		}

		// Token: 0x06000ADD RID: 2781 RVA: 0x0003F7CC File Offset: 0x0003DBCC
		public void UnRegisterVirtualAxis(string name)
		{
			if (this.m_VirtualAxes.ContainsKey(name))
			{
				this.m_VirtualAxes.Remove(name);
			}
		}

		// Token: 0x06000ADE RID: 2782 RVA: 0x0003F7EC File Offset: 0x0003DBEC
		public void UnRegisterVirtualButton(string name)
		{
			if (this.m_VirtualButtons.ContainsKey(name))
			{
				this.m_VirtualButtons.Remove(name);
			}
		}

		// Token: 0x06000ADF RID: 2783 RVA: 0x0003F80C File Offset: 0x0003DC0C
		public CrossPlatformInputManager.VirtualAxis VirtualAxisReference(string name)
		{
			return (!this.m_VirtualAxes.ContainsKey(name)) ? null : this.m_VirtualAxes[name];
		}

		// Token: 0x06000AE0 RID: 2784 RVA: 0x0003F834 File Offset: 0x0003DC34
		public void SetVirtualMousePositionX(float f)
		{
			this.virtualMousePosition = new Vector3(f, this.virtualMousePosition.y, this.virtualMousePosition.z);
		}

		// Token: 0x06000AE1 RID: 2785 RVA: 0x0003F86C File Offset: 0x0003DC6C
		public void SetVirtualMousePositionY(float f)
		{
			this.virtualMousePosition = new Vector3(this.virtualMousePosition.x, f, this.virtualMousePosition.z);
		}

		// Token: 0x06000AE2 RID: 2786 RVA: 0x0003F8A4 File Offset: 0x0003DCA4
		public void SetVirtualMousePositionZ(float f)
		{
			this.virtualMousePosition = new Vector3(this.virtualMousePosition.x, this.virtualMousePosition.y, f);
		}

		// Token: 0x06000AE3 RID: 2787
		public abstract float GetAxis(string name, bool raw);

		// Token: 0x06000AE4 RID: 2788
		public abstract bool GetButton(string name);

		// Token: 0x06000AE5 RID: 2789
		public abstract bool GetButtonDown(string name);

		// Token: 0x06000AE6 RID: 2790
		public abstract bool GetButtonUp(string name);

		// Token: 0x06000AE7 RID: 2791
		public abstract void SetButtonDown(string name);

		// Token: 0x06000AE8 RID: 2792
		public abstract void SetButtonUp(string name);

		// Token: 0x06000AE9 RID: 2793
		public abstract void SetAxisPositive(string name);

		// Token: 0x06000AEA RID: 2794
		public abstract void SetAxisNegative(string name);

		// Token: 0x06000AEB RID: 2795
		public abstract void SetAxisZero(string name);

		// Token: 0x06000AEC RID: 2796
		public abstract void SetAxis(string name, float value);

		// Token: 0x06000AED RID: 2797
		public abstract Vector3 MousePosition();

		// Token: 0x040009CF RID: 2511
		protected Dictionary<string, CrossPlatformInputManager.VirtualAxis> m_VirtualAxes = new Dictionary<string, CrossPlatformInputManager.VirtualAxis>();

		// Token: 0x040009D0 RID: 2512
		protected Dictionary<string, CrossPlatformInputManager.VirtualButton> m_VirtualButtons = new Dictionary<string, CrossPlatformInputManager.VirtualButton>();

		// Token: 0x040009D1 RID: 2513
		protected List<string> m_AlwaysUseVirtual = new List<string>();
	}
}
