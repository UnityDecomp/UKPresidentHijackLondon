using System;
using UnityEngine;

// Token: 0x020000B6 RID: 182
public class GuiStartMenu : MonoBehaviour
{
	// Token: 0x06000531 RID: 1329 RVA: 0x000275C8 File Offset: 0x000259C8
	private void OnEnable()
	{
		EasyTouch.On_SimpleTap += this.On_SimpleTap;
	}

	// Token: 0x06000532 RID: 1330 RVA: 0x000275DC File Offset: 0x000259DC
	private void OnGUI()
	{
		GUI.matrix = Matrix4x4.Scale(new Vector3((float)Screen.width / 1024f, (float)Screen.height / 768f, 1f));
		GUI.Box(new Rect(0f, -4f, 1024f, 70f), string.Empty);
	}

	// Token: 0x06000533 RID: 1331 RVA: 0x00027638 File Offset: 0x00025A38
	private void On_SimpleTap(Gesture gesture)
	{
		if (gesture.pickObject != null)
		{
			string name = gesture.pickObject.name;
			if (name == "OneFinger")
			{
				Application.LoadLevel("Onefinger");
			}
			else if (name == "TwoFinger")
			{
				Application.LoadLevel("TwoFinger");
			}
			else if (name == "MultipleFinger")
			{
				Application.LoadLevel("MultipleFingers");
			}
			else if (name == "MultiLayer")
			{
				Application.LoadLevel("MultiLayers");
			}
			else if (name == "GameController")
			{
				Application.LoadLevel("GameController");
			}
			else if (name == "FreeCamera")
			{
				Application.LoadLevel("FreeCam");
			}
			else if (name == "ImageManipulation")
			{
				Application.LoadLevel("ManipulationImage");
			}
			else if (name == "Exit")
			{
				Application.Quit();
			}
		}
	}
}
