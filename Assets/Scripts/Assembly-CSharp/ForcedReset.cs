using System;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityStandardAssets.CrossPlatformInput;

// Token: 0x020001BD RID: 445
[RequireComponent(typeof(GUITexture))]
public class ForcedReset : MonoBehaviour
{
	// Token: 0x06000BE0 RID: 3040 RVA: 0x0004AE28 File Offset: 0x00049228
	private void Update()
	{
		if (CrossPlatformInputManager.GetButtonDown("ResetObject"))
		{
			SceneManager.LoadScene(SceneManager.GetSceneAt(0).name);
		}
	}
}
