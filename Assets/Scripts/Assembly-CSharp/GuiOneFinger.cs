using System;
using UnityEngine;

// Token: 0x020000B1 RID: 177
public class GuiOneFinger : MonoBehaviour
{
	// Token: 0x0600050E RID: 1294 RVA: 0x00026F44 File Offset: 0x00025344
	private void OnGUI()
	{
		GUI.matrix = Matrix4x4.Scale(new Vector3((float)Screen.width / 1024f, (float)Screen.height / 768f, 1f));
		GUI.Box(new Rect(0f, -4f, 1024f, 30f), string.Empty);
		GUILayout.Label("Examples with one finger", new GUILayoutOption[0]);
		if (GUI.Button(new Rect(412f, 700f, 200f, 50f), "Main menu"))
		{
			Application.LoadLevel("StartMenu");
		}
	}
}
