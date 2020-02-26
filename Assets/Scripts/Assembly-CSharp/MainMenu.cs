using System;
using UnityEngine;

// Token: 0x02000147 RID: 327
public class MainMenu : MonoBehaviour
{
	// Token: 0x06000A1D RID: 2589 RVA: 0x0003DD85 File Offset: 0x0003C185
	private void Start()
	{
	}

	// Token: 0x06000A1E RID: 2590 RVA: 0x0003DD87 File Offset: 0x0003C187
	private void Update()
	{
		if (Input.GetKeyDown(KeyCode.Escape))
		{
			if (this.preCloseMenu.activeSelf)
			{
				this.preCloseMenu.SetActive(false);
			}
			else
			{
				this.preCloseMenu.SetActive(true);
			}
		}
	}

	// Token: 0x06000A1F RID: 2591 RVA: 0x0003DDC2 File Offset: 0x0003C1C2
	public void LoadShop()
	{
		GoTo.LoadShop();
	}

	// Token: 0x06000A20 RID: 2592 RVA: 0x0003DDC9 File Offset: 0x0003C1C9
	public void MoreGames()
	{
		Application.OpenURL("https://play.google.com/store/apps/developer?id=i6+Games");
	}

	// Token: 0x04000949 RID: 2377
	public GameObject preCloseMenu;
}
