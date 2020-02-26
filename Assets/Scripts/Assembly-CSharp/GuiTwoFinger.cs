using System;
using UnityEngine;

// Token: 0x020000B7 RID: 183
public class GuiTwoFinger : MonoBehaviour
{
	// Token: 0x06000535 RID: 1333 RVA: 0x00027758 File Offset: 0x00025B58
	private void OnGUI()
	{
		GUI.matrix = Matrix4x4.Scale(new Vector3((float)Screen.width / 1024f, (float)Screen.height / 768f, 1f));
		GUI.Box(new Rect(0f, -4f, 1024f, 30f), string.Empty);
		GUILayout.Label("Examples with two fingers : ctrl or alt key to simulate the second finger", new GUILayoutOption[0]);
		if (GUI.Button(new Rect(412f, 700f, 200f, 50f), "Main menu"))
		{
			Application.LoadLevel("StartMenu");
		}
	}
}
