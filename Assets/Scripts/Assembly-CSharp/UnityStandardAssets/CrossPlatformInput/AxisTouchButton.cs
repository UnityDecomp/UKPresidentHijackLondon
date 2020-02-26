using System;
using UnityEngine;
using UnityEngine.EventSystems;

namespace UnityStandardAssets.CrossPlatformInput
{
	// Token: 0x02000157 RID: 343
	public class AxisTouchButton : MonoBehaviour, IPointerDownHandler, IPointerUpHandler, IEventSystemHandler
	{
		// Token: 0x06000A61 RID: 2657 RVA: 0x0003EED0 File Offset: 0x0003D2D0
		private void OnEnable()
		{
			if (!CrossPlatformInputManager.AxisExists(this.axisName))
			{
				this.m_Axis = new CrossPlatformInputManager.VirtualAxis(this.axisName);
				CrossPlatformInputManager.RegisterVirtualAxis(this.m_Axis);
			}
			else
			{
				this.m_Axis = CrossPlatformInputManager.VirtualAxisReference(this.axisName);
			}
			this.FindPairedButton();
		}

		// Token: 0x06000A62 RID: 2658 RVA: 0x0003EF28 File Offset: 0x0003D328
		private void FindPairedButton()
		{
			AxisTouchButton[] array = UnityEngine.Object.FindObjectsOfType(typeof(AxisTouchButton)) as AxisTouchButton[];
			if (array != null)
			{
				for (int i = 0; i < array.Length; i++)
				{
					if (array[i].axisName == this.axisName && array[i] != this)
					{
						this.m_PairedWith = array[i];
					}
				}
			}
		}

		// Token: 0x06000A63 RID: 2659 RVA: 0x0003EF93 File Offset: 0x0003D393
		private void OnDisable()
		{
			this.m_Axis.Remove();
		}

		// Token: 0x06000A64 RID: 2660 RVA: 0x0003EFA0 File Offset: 0x0003D3A0
		public void OnPointerDown(PointerEventData data)
		{
			if (this.m_PairedWith == null)
			{
				this.FindPairedButton();
			}
			this.m_Axis.Update(Mathf.MoveTowards(this.m_Axis.GetValue, this.axisValue, this.responseSpeed * Time.deltaTime));
		}

		// Token: 0x06000A65 RID: 2661 RVA: 0x0003EFF1 File Offset: 0x0003D3F1
		public void OnPointerUp(PointerEventData data)
		{
			this.m_Axis.Update(Mathf.MoveTowards(this.m_Axis.GetValue, 0f, this.responseSpeed * Time.deltaTime));
		}

		// Token: 0x04000982 RID: 2434
		public string axisName = "Horizontal";

		// Token: 0x04000983 RID: 2435
		public float axisValue = 1f;

		// Token: 0x04000984 RID: 2436
		public float responseSpeed = 3f;

		// Token: 0x04000985 RID: 2437
		public float returnToCentreSpeed = 3f;

		// Token: 0x04000986 RID: 2438
		private AxisTouchButton m_PairedWith;

		// Token: 0x04000987 RID: 2439
		private CrossPlatformInputManager.VirtualAxis m_Axis;
	}
}
