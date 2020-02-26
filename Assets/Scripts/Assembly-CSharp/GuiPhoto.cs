using System;
using UnityEngine;

// Token: 0x020000A7 RID: 167
public class GuiPhoto : MonoBehaviour
{
	// Token: 0x060004CE RID: 1230 RVA: 0x00025C4C File Offset: 0x0002404C
	private void OnGUI()
	{
		GUI.matrix = Matrix4x4.Scale(new Vector3((float)Screen.width / 1024f, (float)Screen.height / 768f, 1f));
		GUI.Box(new Rect(0f, -4f, 1024f, 30f), string.Empty);
		GUILayout.Label("Manipulation of an image : Twist, Pinch, Drag  with 1 or 2 fingers ctrl or alt key to simulate the second finger", new GUILayoutOption[0]);
		GUILayout.Space(15f);
		this.bTwist = GUILayout.Toggle(this.bTwist, "Enable Twist", new GUILayoutOption[0]);
		EasyTouch.SetEnableTwist(this.bTwist);
		GUILayout.Space(15f);
		this.bPinch = GUILayout.Toggle(this.bPinch, "Enable Pinch", new GUILayoutOption[0]);
		EasyTouch.SetEnablePinch(this.bPinch);
		if (GUI.Button(new Rect(412f, 700f, 200f, 50f), "Main menu"))
		{
			Application.LoadLevel("StartMenu");
		}
	}

	// Token: 0x040004DC RID: 1244
	private bool bTwist = true;

	// Token: 0x040004DD RID: 1245
	private bool bPinch = true;
}
