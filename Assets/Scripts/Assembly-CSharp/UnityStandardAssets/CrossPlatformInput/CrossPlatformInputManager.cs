using System;
using UnityEngine;
using UnityStandardAssets.CrossPlatformInput.PlatformSpecific;

namespace UnityStandardAssets.CrossPlatformInput
{
	// Token: 0x02000159 RID: 345
	public static class CrossPlatformInputManager
	{
		// Token: 0x06000A6E RID: 2670 RVA: 0x0003F06C File Offset: 0x0003D46C
		static CrossPlatformInputManager()
		{
			CrossPlatformInputManager.activeInput = CrossPlatformInputManager.s_TouchInput;
		}

		// Token: 0x06000A6F RID: 2671 RVA: 0x0003F08C File Offset: 0x0003D48C
		public static void SwitchActiveInputMethod(CrossPlatformInputManager.ActiveInputMethod activeInputMethod)
		{
			if (activeInputMethod != CrossPlatformInputManager.ActiveInputMethod.Hardware)
			{
				if (activeInputMethod == CrossPlatformInputManager.ActiveInputMethod.Touch)
				{
					CrossPlatformInputManager.activeInput = CrossPlatformInputManager.s_TouchInput;
				}
			}
			else
			{
				CrossPlatformInputManager.activeInput = CrossPlatformInputManager.s_HardwareInput;
			}
		}

		// Token: 0x06000A70 RID: 2672 RVA: 0x0003F0BE File Offset: 0x0003D4BE
		public static bool AxisExists(string name)
		{
			return CrossPlatformInputManager.activeInput.AxisExists(name);
		}

		// Token: 0x06000A71 RID: 2673 RVA: 0x0003F0CB File Offset: 0x0003D4CB
		public static bool ButtonExists(string name)
		{
			return CrossPlatformInputManager.activeInput.ButtonExists(name);
		}

		// Token: 0x06000A72 RID: 2674 RVA: 0x0003F0D8 File Offset: 0x0003D4D8
		public static void RegisterVirtualAxis(CrossPlatformInputManager.VirtualAxis axis)
		{
			CrossPlatformInputManager.activeInput.RegisterVirtualAxis(axis);
		}

		// Token: 0x06000A73 RID: 2675 RVA: 0x0003F0E5 File Offset: 0x0003D4E5
		public static void RegisterVirtualButton(CrossPlatformInputManager.VirtualButton button)
		{
			CrossPlatformInputManager.activeInput.RegisterVirtualButton(button);
		}

		// Token: 0x06000A74 RID: 2676 RVA: 0x0003F0F2 File Offset: 0x0003D4F2
		public static void UnRegisterVirtualAxis(string name)
		{
			if (name == null)
			{
				throw new ArgumentNullException("name");
			}
			CrossPlatformInputManager.activeInput.UnRegisterVirtualAxis(name);
		}

		// Token: 0x06000A75 RID: 2677 RVA: 0x0003F110 File Offset: 0x0003D510
		public static void UnRegisterVirtualButton(string name)
		{
			CrossPlatformInputManager.activeInput.UnRegisterVirtualButton(name);
		}

		// Token: 0x06000A76 RID: 2678 RVA: 0x0003F11D File Offset: 0x0003D51D
		public static CrossPlatformInputManager.VirtualAxis VirtualAxisReference(string name)
		{
			return CrossPlatformInputManager.activeInput.VirtualAxisReference(name);
		}

		// Token: 0x06000A77 RID: 2679 RVA: 0x0003F12A File Offset: 0x0003D52A
		public static float GetAxis(string name)
		{
			return CrossPlatformInputManager.GetAxis(name, false);
		}

		// Token: 0x06000A78 RID: 2680 RVA: 0x0003F133 File Offset: 0x0003D533
		public static float GetAxisRaw(string name)
		{
			return CrossPlatformInputManager.GetAxis(name, true);
		}

		// Token: 0x06000A79 RID: 2681 RVA: 0x0003F13C File Offset: 0x0003D53C
		private static float GetAxis(string name, bool raw)
		{
			return CrossPlatformInputManager.activeInput.GetAxis(name, raw);
		}

		// Token: 0x06000A7A RID: 2682 RVA: 0x0003F14A File Offset: 0x0003D54A
		public static bool GetButton(string name)
		{
			return CrossPlatformInputManager.activeInput.GetButton(name);
		}

		// Token: 0x06000A7B RID: 2683 RVA: 0x0003F157 File Offset: 0x0003D557
		public static bool GetButtonDown(string name)
		{
			return CrossPlatformInputManager.activeInput.GetButtonDown(name);
		}

		// Token: 0x06000A7C RID: 2684 RVA: 0x0003F164 File Offset: 0x0003D564
		public static bool GetButtonUp(string name)
		{
			return CrossPlatformInputManager.activeInput.GetButtonUp(name);
		}

		// Token: 0x06000A7D RID: 2685 RVA: 0x0003F171 File Offset: 0x0003D571
		public static void SetButtonDown(string name)
		{
			CrossPlatformInputManager.activeInput.SetButtonDown(name);
		}

		// Token: 0x06000A7E RID: 2686 RVA: 0x0003F17E File Offset: 0x0003D57E
		public static void SetButtonUp(string name)
		{
			CrossPlatformInputManager.activeInput.SetButtonUp(name);
		}

		// Token: 0x06000A7F RID: 2687 RVA: 0x0003F18B File Offset: 0x0003D58B
		public static void SetAxisPositive(string name)
		{
			CrossPlatformInputManager.activeInput.SetAxisPositive(name);
		}

		// Token: 0x06000A80 RID: 2688 RVA: 0x0003F198 File Offset: 0x0003D598
		public static void SetAxisNegative(string name)
		{
			CrossPlatformInputManager.activeInput.SetAxisNegative(name);
		}

		// Token: 0x06000A81 RID: 2689 RVA: 0x0003F1A5 File Offset: 0x0003D5A5
		public static void SetAxisZero(string name)
		{
			CrossPlatformInputManager.activeInput.SetAxisZero(name);
		}

		// Token: 0x06000A82 RID: 2690 RVA: 0x0003F1B2 File Offset: 0x0003D5B2
		public static void SetAxis(string name, float value)
		{
			CrossPlatformInputManager.activeInput.SetAxis(name, value);
		}

		// Token: 0x1700004E RID: 78
		// (get) Token: 0x06000A83 RID: 2691 RVA: 0x0003F1C0 File Offset: 0x0003D5C0
		public static Vector3 mousePosition
		{
			get
			{
				return CrossPlatformInputManager.activeInput.MousePosition();
			}
		}

		// Token: 0x06000A84 RID: 2692 RVA: 0x0003F1CC File Offset: 0x0003D5CC
		public static void SetVirtualMousePositionX(float f)
		{
			CrossPlatformInputManager.activeInput.SetVirtualMousePositionX(f);
		}

		// Token: 0x06000A85 RID: 2693 RVA: 0x0003F1D9 File Offset: 0x0003D5D9
		public static void SetVirtualMousePositionY(float f)
		{
			CrossPlatformInputManager.activeInput.SetVirtualMousePositionY(f);
		}

		// Token: 0x06000A86 RID: 2694 RVA: 0x0003F1E6 File Offset: 0x0003D5E6
		public static void SetVirtualMousePositionZ(float f)
		{
			CrossPlatformInputManager.activeInput.SetVirtualMousePositionZ(f);
		}

		// Token: 0x04000989 RID: 2441
		private static VirtualInput activeInput;

		// Token: 0x0400098A RID: 2442
		private static VirtualInput s_TouchInput = new MobileInput();

		// Token: 0x0400098B RID: 2443
		private static VirtualInput s_HardwareInput = new StandaloneInput();

		// Token: 0x0200015A RID: 346
		public enum ActiveInputMethod
		{
			// Token: 0x0400098D RID: 2445
			Hardware,
			// Token: 0x0400098E RID: 2446
			Touch
		}

		// Token: 0x0200015B RID: 347
		public class VirtualAxis
		{
			// Token: 0x06000A87 RID: 2695 RVA: 0x0003F1F3 File Offset: 0x0003D5F3
			public VirtualAxis(string name) : this(name, true)
			{
			}

			// Token: 0x06000A88 RID: 2696 RVA: 0x0003F1FD File Offset: 0x0003D5FD
			public VirtualAxis(string name, bool matchToInputSettings)
			{
				this.name = name;
				this.matchWithInputManager = matchToInputSettings;
			}

			// Token: 0x1700004F RID: 79
			// (get) Token: 0x06000A89 RID: 2697 RVA: 0x0003F213 File Offset: 0x0003D613
			// (set) Token: 0x06000A8A RID: 2698 RVA: 0x0003F21B File Offset: 0x0003D61B
			public string name { get; private set; }

			// Token: 0x17000050 RID: 80
			// (get) Token: 0x06000A8B RID: 2699 RVA: 0x0003F224 File Offset: 0x0003D624
			// (set) Token: 0x06000A8C RID: 2700 RVA: 0x0003F22C File Offset: 0x0003D62C
			public bool matchWithInputManager { get; private set; }

			// Token: 0x06000A8D RID: 2701 RVA: 0x0003F235 File Offset: 0x0003D635
			public void Remove()
			{
				CrossPlatformInputManager.UnRegisterVirtualAxis(this.name);
			}

			// Token: 0x06000A8E RID: 2702 RVA: 0x0003F242 File Offset: 0x0003D642
			public void Update(float value)
			{
				this.m_Value = value;
			}

			// Token: 0x17000051 RID: 81
			// (get) Token: 0x06000A8F RID: 2703 RVA: 0x0003F24B File Offset: 0x0003D64B
			public float GetValue
			{
				get
				{
					return this.m_Value;
				}
			}

			// Token: 0x17000052 RID: 82
			// (get) Token: 0x06000A90 RID: 2704 RVA: 0x0003F253 File Offset: 0x0003D653
			public float GetValueRaw
			{
				get
				{
					return this.m_Value;
				}
			}

			// Token: 0x04000990 RID: 2448
			private float m_Value;
		}

		// Token: 0x0200015C RID: 348
		public class VirtualButton
		{
			// Token: 0x06000A91 RID: 2705 RVA: 0x0003F25B File Offset: 0x0003D65B
			public VirtualButton(string name) : this(name, true)
			{
			}

			// Token: 0x06000A92 RID: 2706 RVA: 0x0003F265 File Offset: 0x0003D665
			public VirtualButton(string name, bool matchToInputSettings)
			{
				this.name = name;
				this.matchWithInputManager = matchToInputSettings;
			}

			// Token: 0x17000053 RID: 83
			// (get) Token: 0x06000A93 RID: 2707 RVA: 0x0003F28B File Offset: 0x0003D68B
			// (set) Token: 0x06000A94 RID: 2708 RVA: 0x0003F293 File Offset: 0x0003D693
			public string name { get; private set; }

			// Token: 0x17000054 RID: 84
			// (get) Token: 0x06000A95 RID: 2709 RVA: 0x0003F29C File Offset: 0x0003D69C
			// (set) Token: 0x06000A96 RID: 2710 RVA: 0x0003F2A4 File Offset: 0x0003D6A4
			public bool matchWithInputManager { get; private set; }

			// Token: 0x06000A97 RID: 2711 RVA: 0x0003F2AD File Offset: 0x0003D6AD
			public void Pressed()
			{
				if (this.m_Pressed)
				{
					return;
				}
				this.m_Pressed = true;
				this.m_LastPressedFrame = Time.frameCount;
			}

			// Token: 0x06000A98 RID: 2712 RVA: 0x0003F2CD File Offset: 0x0003D6CD
			public void Released()
			{
				this.m_Pressed = false;
				this.m_ReleasedFrame = Time.frameCount;
			}

			// Token: 0x06000A99 RID: 2713 RVA: 0x0003F2E1 File Offset: 0x0003D6E1
			public void Remove()
			{
				CrossPlatformInputManager.UnRegisterVirtualButton(this.name);
			}

			// Token: 0x17000055 RID: 85
			// (get) Token: 0x06000A9A RID: 2714 RVA: 0x0003F2EE File Offset: 0x0003D6EE
			public bool GetButton
			{
				get
				{
					return this.m_Pressed;
				}
			}

			// Token: 0x17000056 RID: 86
			// (get) Token: 0x06000A9B RID: 2715 RVA: 0x0003F2F6 File Offset: 0x0003D6F6
			public bool GetButtonDown
			{
				get
				{
					return this.m_LastPressedFrame - Time.frameCount == -1;
				}
			}

			// Token: 0x17000057 RID: 87
			// (get) Token: 0x06000A9C RID: 2716 RVA: 0x0003F307 File Offset: 0x0003D707
			public bool GetButtonUp
			{
				get
				{
					return this.m_ReleasedFrame == Time.frameCount - 1;
				}
			}

			// Token: 0x04000994 RID: 2452
			private int m_LastPressedFrame = -5;

			// Token: 0x04000995 RID: 2453
			private int m_ReleasedFrame = -5;

			// Token: 0x04000996 RID: 2454
			private bool m_Pressed;
		}
	}
}
