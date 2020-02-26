using System;
using UnityEngine;

// Token: 0x02000145 RID: 325
public class Intro : MonoBehaviour
{
	// Token: 0x06000A18 RID: 2584 RVA: 0x0003DC40 File Offset: 0x0003C040
	private void Awake()
	{
		Screen.sleepTimeout = -1;
		GoTo.LoadMainMenu();
	}
}
