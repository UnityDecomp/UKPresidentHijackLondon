using System;
using UnityEngine;

// Token: 0x020000A1 RID: 161
public class GUIFirstDirect : MonoBehaviour
{
	// Token: 0x060004AE RID: 1198 RVA: 0x00024F14 File Offset: 0x00023314
	private void Start()
	{
		this.joystick = GameObject.Find("Move_Turn_Joystick").GetComponent<EasyJoystick>();
	}

	// Token: 0x060004AF RID: 1199 RVA: 0x00024F2C File Offset: 0x0002332C
	private void OnGUI()
	{
		this.showProperties = GUI.Toggle(new Rect(5f, 5f, 320f, 20f), this.showProperties, "Show some properties for example for left joystick");
		if (this.showProperties)
		{
			GUI.Box(new Rect(5f, 25f, 260f, 200f), string.Empty);
			this.joystick.enableInertia = GUI.Toggle(new Rect(10f, 30f, 200f, 20f), this.joystick.enableInertia, "Activated inertia");
			if (this.joystick.enableInertia)
			{
				GUI.Label(new Rect(10f, 50f, 200f, 25f), "X inertia : " + this.joystick.inertia.x.ToString("F1"));
				this.joystick.inertia.x = GUI.HorizontalSlider(new Rect(130f, 55f, 125f, 20f), this.joystick.inertia.x, 0f, 200f);
				GUI.Label(new Rect(10f, 75f, 200f, 25f), "Y inertia : " + this.joystick.inertia.y.ToString("F1"));
				this.joystick.inertia.y = GUI.HorizontalSlider(new Rect(130f, 80f, 125f, 20f), this.joystick.inertia.y, 0f, 200f);
			}
			GUI.Label(new Rect(10f, 105f, 200f, 25f), "x axis speed : " + this.joystick.speed.x.ToString("F1"));
			this.joystick.speed.x = GUI.HorizontalSlider(new Rect(130f, 110f, 125f, 20f), this.joystick.speed.x, 0f, 200f);
			GUI.Label(new Rect(10f, 130f, 200f, 25f), "Y axis speed : " + this.joystick.speed.y.ToString("F1"));
			this.joystick.speed.y = GUI.HorizontalSlider(new Rect(130f, 135f, 125f, 20f), this.joystick.speed.y, 0f, 20f);
			this.joystick.inverseXAxis = GUI.Toggle(new Rect(10f, 160f, 200f, 20f), this.joystick.inverseXAxis, "Inverse X axis");
			this.joystick.inverseYAxis = GUI.Toggle(new Rect(10f, 185f, 200f, 20f), this.joystick.inverseYAxis, "Inverse Y axis");
		}
	}

	// Token: 0x040004D0 RID: 1232
	private bool showProperties = true;

	// Token: 0x040004D1 RID: 1233
	private EasyJoystick joystick;
}
