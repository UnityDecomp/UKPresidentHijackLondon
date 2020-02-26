using System;
using UnityEngine;
using UnityEngine.EventSystems;
using UnityEngine.UI;

namespace UnityStandardAssets.CrossPlatformInput
{
	// Token: 0x02000167 RID: 359
	[RequireComponent(typeof(Image))]
	public class TouchPad : MonoBehaviour, IPointerDownHandler, IPointerUpHandler, IEventSystemHandler
	{
		// Token: 0x06000ACE RID: 2766 RVA: 0x0003FD55 File Offset: 0x0003E155
		private void OnEnable()
		{
			this.CreateVirtualAxes();
		}

		// Token: 0x06000ACF RID: 2767 RVA: 0x0003FD5D File Offset: 0x0003E15D
		private void Start()
		{
			this.m_Image = base.GetComponent<Image>();
			this.m_Center = this.m_Image.transform.position;
		}

		// Token: 0x06000AD0 RID: 2768 RVA: 0x0003FD84 File Offset: 0x0003E184
		private void CreateVirtualAxes()
		{
			this.m_UseX = (this.axesToUse == TouchPad.AxisOption.Both || this.axesToUse == TouchPad.AxisOption.OnlyHorizontal);
			this.m_UseY = (this.axesToUse == TouchPad.AxisOption.Both || this.axesToUse == TouchPad.AxisOption.OnlyVertical);
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

		// Token: 0x06000AD1 RID: 2769 RVA: 0x0003FE1C File Offset: 0x0003E21C
		private void UpdateVirtualAxes(Vector3 value)
		{
			value = value.normalized;
			if (this.m_UseX)
			{
				this.m_HorizontalVirtualAxis.Update(value.x);
			}
			if (this.m_UseY)
			{
				this.m_VerticalVirtualAxis.Update(value.y);
			}
		}

		// Token: 0x06000AD2 RID: 2770 RVA: 0x0003FE6C File Offset: 0x0003E26C
		public void OnPointerDown(PointerEventData data)
		{
			this.m_Dragging = true;
			this.m_Id = data.pointerId;
			if (this.controlStyle != TouchPad.ControlStyle.Absolute)
			{
				this.m_Center = data.position;
			}
		}

		// Token: 0x06000AD3 RID: 2771 RVA: 0x0003FEA0 File Offset: 0x0003E2A0
		private void Update()
		{
			if (!this.m_Dragging)
			{
				return;
			}
			if (Input.touchCount >= this.m_Id + 1 && this.m_Id != -1)
			{
				if (this.controlStyle == TouchPad.ControlStyle.Swipe)
				{
					this.m_Center = this.m_PreviousTouchPos;
					this.m_PreviousTouchPos = Input.touches[this.m_Id].position;
				}
				Vector2 vector = new Vector2(Input.touches[this.m_Id].position.x - this.m_Center.x, Input.touches[this.m_Id].position.y - this.m_Center.y);
				Vector2 normalized = vector.normalized;
				normalized.x *= this.Xsensitivity;
				normalized.y *= this.Ysensitivity;
				this.UpdateVirtualAxes(new Vector3(normalized.x, normalized.y, 0f));
			}
		}

		// Token: 0x06000AD4 RID: 2772 RVA: 0x0003FFB6 File Offset: 0x0003E3B6
		public void OnPointerUp(PointerEventData data)
		{
			this.m_Dragging = false;
			this.m_Id = -1;
			this.UpdateVirtualAxes(Vector3.zero);
		}

		// Token: 0x06000AD5 RID: 2773 RVA: 0x0003FFD1 File Offset: 0x0003E3D1
		private void OnDisable()
		{
			if (CrossPlatformInputManager.AxisExists(this.horizontalAxisName))
			{
				CrossPlatformInputManager.UnRegisterVirtualAxis(this.horizontalAxisName);
			}
			if (CrossPlatformInputManager.AxisExists(this.verticalAxisName))
			{
				CrossPlatformInputManager.UnRegisterVirtualAxis(this.verticalAxisName);
			}
		}

		// Token: 0x040009B4 RID: 2484
		public TouchPad.AxisOption axesToUse;

		// Token: 0x040009B5 RID: 2485
		public TouchPad.ControlStyle controlStyle;

		// Token: 0x040009B6 RID: 2486
		public string horizontalAxisName = "Horizontal";

		// Token: 0x040009B7 RID: 2487
		public string verticalAxisName = "Vertical";

		// Token: 0x040009B8 RID: 2488
		public float Xsensitivity = 1f;

		// Token: 0x040009B9 RID: 2489
		public float Ysensitivity = 1f;

		// Token: 0x040009BA RID: 2490
		private Vector3 m_StartPos;

		// Token: 0x040009BB RID: 2491
		private Vector2 m_PreviousDelta;

		// Token: 0x040009BC RID: 2492
		private Vector3 m_JoytickOutput;

		// Token: 0x040009BD RID: 2493
		private bool m_UseX;

		// Token: 0x040009BE RID: 2494
		private bool m_UseY;

		// Token: 0x040009BF RID: 2495
		private CrossPlatformInputManager.VirtualAxis m_HorizontalVirtualAxis;

		// Token: 0x040009C0 RID: 2496
		private CrossPlatformInputManager.VirtualAxis m_VerticalVirtualAxis;

		// Token: 0x040009C1 RID: 2497
		private bool m_Dragging;

		// Token: 0x040009C2 RID: 2498
		private int m_Id = -1;

		// Token: 0x040009C3 RID: 2499
		private Vector2 m_PreviousTouchPos;

		// Token: 0x040009C4 RID: 2500
		private Vector3 m_Center;

		// Token: 0x040009C5 RID: 2501
		private Image m_Image;

		// Token: 0x02000168 RID: 360
		public enum AxisOption
		{
			// Token: 0x040009C7 RID: 2503
			Both,
			// Token: 0x040009C8 RID: 2504
			OnlyHorizontal,
			// Token: 0x040009C9 RID: 2505
			OnlyVertical
		}

		// Token: 0x02000169 RID: 361
		public enum ControlStyle
		{
			// Token: 0x040009CB RID: 2507
			Absolute,
			// Token: 0x040009CC RID: 2508
			Relative,
			// Token: 0x040009CD RID: 2509
			Swipe
		}
	}
}
