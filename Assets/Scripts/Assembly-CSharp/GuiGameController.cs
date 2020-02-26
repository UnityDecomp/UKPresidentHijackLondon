using System;
using UnityEngine;

// Token: 0x020000A6 RID: 166
public class GuiGameController : MonoBehaviour
{
	// Token: 0x060004CC RID: 1228 RVA: 0x00025B98 File Offset: 0x00023F98
	private void OnGUI()
	{
		GUI.matrix = Matrix4x4.Scale(new Vector3((float)Screen.width / 1024f, (float)Screen.height / 768f, 1f));
		GUI.Box(new Rect(0f, -4f, 1024f, 30f), string.Empty);
		GUILayout.Label("Game Controller example", new GUILayoutOption[0]);
		if (GUI.Button(new Rect(412f, 30f, 200f, 50f), "Main menu"))
		{
			Application.LoadLevel("StartMenu");
		}
	}
}
