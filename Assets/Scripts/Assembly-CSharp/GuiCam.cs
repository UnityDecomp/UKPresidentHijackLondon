using System;
using UnityEngine;

// Token: 0x020000A4 RID: 164
public class GuiCam : MonoBehaviour
{
	// Token: 0x060004C0 RID: 1216 RVA: 0x00025800 File Offset: 0x00023C00
	private void OnGUI()
	{
		GUI.matrix = Matrix4x4.Scale(new Vector3((float)Screen.width / 1024f, (float)Screen.height / 768f, 1f));
		GUI.Box(new Rect(0f, -4f, 1024f, 30f), string.Empty);
		GUILayout.Label("Free camera ctrl or alt key to simulate the second finger", new GUILayoutOption[0]);
		GUILayout.Space(15f);
		GUILayout.Label("1 finger => Look around", new GUILayoutOption[0]);
		GUILayout.Label("2 fingers => Move forward", new GUILayoutOption[0]);
		GUILayout.Label("3 fingers => Move backward", new GUILayoutOption[0]);
		if (GUI.Button(new Rect(412f, 700f, 200f, 50f), "Main menu"))
		{
			Application.LoadLevel("StartMenu");
		}
	}
}
