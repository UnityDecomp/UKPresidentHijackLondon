using System;
using UnityEngine;

// Token: 0x020001DA RID: 474
public class CharacterSelection : MonoBehaviour
{
	// Token: 0x06000C51 RID: 3153 RVA: 0x0004E28C File Offset: 0x0004C68C
	private void Start()
	{
		if (PlayerPrefs.GetInt("Quest") < 3)
		{
			this.locked.SetActive(true);
		}
		else
		{
			this.locked.SetActive(false);
		}
		if (gameplay.startCrazyLevel)
		{
			this.gameplayCanvas.GetComponent<gameplay>().crazyLevelCanvas.SetActive(true);
			this.characterCanvas.SetActive(false);
		}
		for (int i = 0; i < this.mode1Models.Length; i++)
		{
			this.mode1Models[i].SetActive(false);
		}
		this.playAsCharacter1();
	}

	// Token: 0x06000C52 RID: 3154 RVA: 0x0004E320 File Offset: 0x0004C720
	public void playAsCharacter1()
	{
		CharacterSelection.characterID = 0;
		this.mode1Models[0].SetActive(true);
		for (int i = 0; i < this.mode1Models.Length; i++)
		{
			this.gameplayCanvas.GetComponent<gameplay>().bikes[i] = this.mode1Models[i];
		}
		this.openNextScene();
	}

	// Token: 0x06000C53 RID: 3155 RVA: 0x0004E37C File Offset: 0x0004C77C
	public void playAsCharacter2()
	{
		CharacterSelection.characterID = 1;
		this.mode2Models[0].SetActive(true);
		for (int i = 0; i < this.mode2Models.Length; i++)
		{
			this.gameplayCanvas.GetComponent<gameplay>().bikes[i] = this.mode2Models[i];
		}
		this.openNextScene();
	}

	// Token: 0x06000C54 RID: 3156 RVA: 0x0004E3D6 File Offset: 0x0004C7D6
	private void openNextScene()
	{
		this.characterCanvas.SetActive(false);
		this.gameplayCanvas.SetActive(true);
		this.gameplayCanvas.GetComponent<gameplay>().initialSetting();
	}

	// Token: 0x06000C55 RID: 3157 RVA: 0x0004E400 File Offset: 0x0004C800
	public void OnClickLock()
	{
		this.lockedPanel.SetActive(true);
	}

	// Token: 0x06000C56 RID: 3158 RVA: 0x0004E40E File Offset: 0x0004C80E
	public void CloseLockedPanel()
	{
		this.lockedPanel.SetActive(false);
	}

	// Token: 0x04000CC4 RID: 3268
	[HideInInspector]
	public static int characterID;

	// Token: 0x04000CC5 RID: 3269
	public GameObject gameplayCanvas;

	// Token: 0x04000CC6 RID: 3270
	public GameObject characterCanvas;

	// Token: 0x04000CC7 RID: 3271
	public GameObject lockedPanel;

	// Token: 0x04000CC8 RID: 3272
	public GameObject locked;

	// Token: 0x04000CC9 RID: 3273
	public GameObject[] mode1Models;

	// Token: 0x04000CCA RID: 3274
	public GameObject[] mode2Models;
}
