using System;
using UnityEngine;

namespace UnityStandardAssets.CrossPlatformInput
{
	// Token: 0x02000163 RID: 355
	public class TiltInput : MonoBehaviour
	{
		// Token: 0x06000AC9 RID: 2761 RVA: 0x0003FB92 File Offset: 0x0003DF92
		private void OnEnable()
		{
			if (this.mapping.type == TiltInput.AxisMapping.MappingType.NamedAxis)
			{
				this.m_SteerAxis = new CrossPlatformInputManager.VirtualAxis(this.mapping.axisName);
				CrossPlatformInputManager.RegisterVirtualAxis(this.m_SteerAxis);
			}
		}

		// Token: 0x06000ACA RID: 2762 RVA: 0x0003FBC8 File Offset: 0x0003DFC8
		private void Update()
		{
			float value = 0f;
			if (Input.acceleration != Vector3.zero)
			{
				TiltInput.AxisOptions axisOptions = this.tiltAroundAxis;
				if (axisOptions != TiltInput.AxisOptions.ForwardAxis)
				{
					if (axisOptions == TiltInput.AxisOptions.SidewaysAxis)
					{
						value = Mathf.Atan2(Input.acceleration.z, -Input.acceleration.y) * 57.29578f + this.centreAngleOffset;
					}
				}
				else
				{
					value = Mathf.Atan2(Input.acceleration.x, -Input.acceleration.y) * 57.29578f + this.centreAngleOffset;
				}
			}
			float num = Mathf.InverseLerp(-this.fullTiltAngle, this.fullTiltAngle, value) * 2f - 1f;
			switch (this.mapping.type)
			{
			case TiltInput.AxisMapping.MappingType.NamedAxis:
				this.m_SteerAxis.Update(num);
				break;
			case TiltInput.AxisMapping.MappingType.MousePositionX:
				CrossPlatformInputManager.SetVirtualMousePositionX(num * (float)Screen.width);
				break;
			case TiltInput.AxisMapping.MappingType.MousePositionY:
				CrossPlatformInputManager.SetVirtualMousePositionY(num * (float)Screen.width);
				break;
			case TiltInput.AxisMapping.MappingType.MousePositionZ:
				CrossPlatformInputManager.SetVirtualMousePositionZ(num * (float)Screen.width);
				break;
			}
		}

		// Token: 0x06000ACB RID: 2763 RVA: 0x0003FD05 File Offset: 0x0003E105
		private void OnDisable()
		{
			this.m_SteerAxis.Remove();
		}

		// Token: 0x040009A5 RID: 2469
		public TiltInput.AxisMapping mapping;

		// Token: 0x040009A6 RID: 2470
		public TiltInput.AxisOptions tiltAroundAxis;

		// Token: 0x040009A7 RID: 2471
		public float fullTiltAngle = 25f;

		// Token: 0x040009A8 RID: 2472
		public float centreAngleOffset;

		// Token: 0x040009A9 RID: 2473
		private CrossPlatformInputManager.VirtualAxis m_SteerAxis;

		// Token: 0x02000164 RID: 356
		public enum AxisOptions
		{
			// Token: 0x040009AB RID: 2475
			ForwardAxis,
			// Token: 0x040009AC RID: 2476
			SidewaysAxis
		}

		// Token: 0x02000165 RID: 357
		[Serializable]
		public class AxisMapping
		{
			// Token: 0x040009AD RID: 2477
			public TiltInput.AxisMapping.MappingType type;

			// Token: 0x040009AE RID: 2478
			public string axisName;

			// Token: 0x02000166 RID: 358
			public enum MappingType
			{
				// Token: 0x040009B0 RID: 2480
				NamedAxis,
				// Token: 0x040009B1 RID: 2481
				MousePositionX,
				// Token: 0x040009B2 RID: 2482
				MousePositionY,
				// Token: 0x040009B3 RID: 2483
				MousePositionZ
			}
		}
	}
}
