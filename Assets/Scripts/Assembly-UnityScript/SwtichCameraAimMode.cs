using System;
using UnityEngine;

// Token: 0x020000A2 RID: 162
[Serializable]
public class SwtichCameraAimMode : MonoBehaviour
{
	// Token: 0x06000230 RID: 560 RVA: 0x0001BE40 File Offset: 0x0001A040
	public SwtichCameraAimMode()
	{
		this.targetHeightNormal = 1.6f;
		this.targetHeightRayCast = 1.2f;
	}

	// Token: 0x06000231 RID: 561 RVA: 0x0001BE60 File Offset: 0x0001A060
	public virtual void Update()
	{
		if (Input.GetKeyDown("p"))
		{
			this.SwitchMode();
		}
	}

	// Token: 0x06000232 RID: 562 RVA: 0x0001BE78 File Offset: 0x0001A078
	public virtual void SwitchMode()
	{
		AttackTrigger attackTrigger = (AttackTrigger)this.GetComponent(typeof(AttackTrigger));
		if (attackTrigger.aimingType == AimType.Normal)
		{
			attackTrigger.aimingType = AimType.Raycast;
			if (attackTrigger.cameraZoomPoint)
			{
				((ARPGcamera)attackTrigger.Maincam.GetComponent(typeof(ARPGcamera))).target = attackTrigger.cameraZoomPoint;
			}
			((ARPGcamera)attackTrigger.Maincam.GetComponent(typeof(ARPGcamera))).targetHeight = this.targetHeightRayCast;
			((ARPGcamera)attackTrigger.Maincam.GetComponent(typeof(ARPGcamera))).lockOn = true;
		}
		else
		{
			attackTrigger.aimingType = AimType.Normal;
			((ARPGcamera)attackTrigger.Maincam.GetComponent(typeof(ARPGcamera))).target = this.transform;
			((ARPGcamera)attackTrigger.Maincam.GetComponent(typeof(ARPGcamera))).targetHeight = this.targetHeightNormal;
			((ARPGcamera)attackTrigger.Maincam.GetComponent(typeof(ARPGcamera))).lockOn = false;
		}
	}

	// Token: 0x06000233 RID: 563 RVA: 0x0001BFA0 File Offset: 0x0001A1A0
	public virtual void Main()
	{
	}

	// Token: 0x040003A6 RID: 934
	public float targetHeightNormal;

	// Token: 0x040003A7 RID: 935
	public float targetHeightRayCast;
}
