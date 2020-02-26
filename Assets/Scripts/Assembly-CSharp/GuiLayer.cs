using System;
using UnityEngine;

// Token: 0x020000A9 RID: 169
public class GuiLayer : MonoBehaviour
{
	// Token: 0x060004DD RID: 1245 RVA: 0x000260A8 File Offset: 0x000244A8
	private void OnGUI()
	{
		GUI.matrix = Matrix4x4.Scale(new Vector3((float)Screen.width / 1024f, (float)Screen.height / 768f, 1f));
		GUI.Box(new Rect(0f, -4f, 1024f, 30f), string.Empty);
		GUILayout.Label("Multi layers example", new GUILayoutOption[0]);
		if (GUI.Button(new Rect(412f, 700f, 200f, 50f), "Main menu"))
		{
			Application.LoadLevel("StartMenu");
		}
	}
}
