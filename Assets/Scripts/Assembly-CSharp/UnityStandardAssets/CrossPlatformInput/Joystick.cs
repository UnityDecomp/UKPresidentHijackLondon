using System;
using UnityEngine;
using UnityEngine.EventSystems;

namespace UnityStandardAssets.CrossPlatformInput
{
	// Token: 0x0200015E RID: 350
	public class Joystick : MonoBehaviour, IPointerDownHandler, IPointerUpHandler, IDragHandler, IEventSystemHandler
	{
		// Token: 0x06000AA1 RID: 2721 RVA: 0x0003F362 File Offset: 0x0003D762
		private void OnEnable()
		{
			this.CreateVirtualAxes();
		}

		// Token: 0x06000AA2 RID: 2722 RVA: 0x0003F36A File Offset: 0x0003D76A
		private void Start()
		{
			this.m_StartPos = base.transform.position;
		}

		// Token: 0x06000AA3 RID: 2723 RVA: 0x0003F380 File Offset: 0x0003D780
		private void UpdateVirtualAxes(Vector3 value)
		{
			Vector3 a = this.m_StartPos - value;
			a.y = -a.y;
			a /= (float)this.MovementRange;
			if (this.m_UseX)
			{
				this.m_HorizontalVirtualAxis.Update(-a.x);
			}
			if (this.m_UseY)
			{
				this.m_VerticalVirtualAxis.Update(a.y);
			}
		}

		// Token: 0x06000AA4 RID: 2724 RVA: 0x0003F3F4 File Offset: 0x0003D7F4
		private void CreateVirtualAxes()
		{
			this.m_UseX = (this.axesToUse == Joystick.AxisOption.Both || this.axesToUse == Joystick.AxisOption.OnlyHorizontal);
			this.m_UseY = (this.axesToUse == Joystick.AxisOption.Both || this.axesToUse == Joystick.AxisOption.OnlyVertical);
			if (this.m_UseX)
			{
				this.m_HorizontalVirtualAxis = new CrossPlatformInputManager.VirtualAxis(this.horizontalAxisName);
				CrossPlatformInputManager.RegisterVirtualAxis(this.m_HorizontalVirtualAxis);
			}
			if (this.m_UseY)
			{
				this.m_VerticalVirtualAxis = new CrossPlatformInputManager.VirtualAxis(this.verticalAxisName);
				CrossPlatformInputManager.RegisterVirtualAxis(this.m_VerticalVirtualAxis);
			}
		}

		// Token: 0x06000AA5 RID: 2725 RVA: 0x0003F48C File Offset: 0x0003D88C
		public void OnDrag(PointerEventData data)
		{
			Vector3 zero = Vector3.zero;
			if (this.m_UseX)
			{
				int num = (int)(data.position.x - this.m_StartPos.x);
				num = Mathf.Clamp(num, -this.MovementRange, this.MovementRange);
				zero.x = (float)num;
			}
			if (this.m_UseY)
			{
				int num2 = (int)(data.position.y - this.m_StartPos.y);
				num2 = Mathf.Clamp(num2, -this.MovementRange, this.MovementRange);
				zero.y = (float)num2;
			}
			base.transform.position = new Vector3(this.m_StartPos.x + zero.x, this.m_StartPos.y + zero.y, this.m_StartPos.z + zero.z);
			this.UpdateVirtualAxes(base.transform.position);
		}

		// Token: 0x06000AA6 RID: 2726 RVA: 0x0003F582 File Offset: 0x0003D982
		public void OnPointerUp(PointerEventData data)
		{
			base.transform.position = this.m_StartPos;
			this.UpdateVirtualAxes(this.m_StartPos);
		}

		// Token: 0x06000AA7 RID: 2727 RVA: 0x0003F5A1 File Offset: 0x0003D9A1
		public void OnPointerDown(PointerEventData data)
		{
		}

		// Token: 0x06000AA8 RID: 2728 RVA: 0x0003F5A3 File Offset: 0x0003D9A3
		private void OnDisable()
		{
			if (this.m_UseX)
			{
				this.m_HorizontalVirtualAxis.Remove();
			}
			if (this.m_UseY)
			{
				this.m_VerticalVirtualAxis.Remove();
			}
		}

		// Token: 0x04000998 RID: 2456
		public int MovementRange = 100;

		// Token: 0x04000999 RID: 2457
		public Joystick.AxisOption axesToUse;

		// Token: 0x0400099A RID: 2458
		public string horizontalAxisName = "Horizontal";

		// Token: 0x0400099B RID: 2459
		public string verticalAxisName = "Vertical";

		// Token: 0x0400099C RID: 2460
		private Vector3 m_StartPos;

		// Token: 0x0400099D RID: 2461
		private bool m_UseX;

		// Token: 0x0400099E RID: 2462
		private bool m_UseY;

		// Token: 0x0400099F RID: 2463
		private CrossPlatformInputManager.VirtualAxis m_HorizontalVirtualAxis;

		// Token: 0x040009A0 RID: 2464
		private CrossPlatformInputManager.VirtualAxis m_VerticalVirtualAxis;

		// Token: 0x0200015F RID: 351
		public enum AxisOption
		{
			// Token: 0x040009A2 RID: 2466
			Both,
			// Token: 0x040009A3 RID: 2467
			OnlyHorizontal,
			// Token: 0x040009A4 RID: 2468
			OnlyVertical
		}
	}
}
