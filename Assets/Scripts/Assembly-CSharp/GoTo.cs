using System;
using UnityEngine;

// Token: 0x02000141 RID: 321
public class GoTo : MonoBehaviour
{
	// Token: 0x06000A0A RID: 2570 RVA: 0x0003DAA7 File Offset: 0x0003BEA7
	public static void LoadMainMenu()
	{
		Application.LoadLevel("mainMenu");
	}

	// Token: 0x06000A0B RID: 2571 RVA: 0x0003DAB3 File Offset: 0x0003BEB3
	public static void LoadShop()
	{
		Application.LoadLevel("shopTable");
	}

	// Token: 0x06000A0C RID: 2572 RVA: 0x0003DABF File Offset: 0x0003BEBF
	public static void LoadGame()
	{
		Application.LoadLevel("game");
	}
}
