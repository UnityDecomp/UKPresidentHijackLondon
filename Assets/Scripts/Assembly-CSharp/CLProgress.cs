using System;
using UnityEngine;

// Token: 0x020000A0 RID: 160
public class CLProgress : MonoBehaviour
{
	// Token: 0x060004A8 RID: 1192 RVA: 0x00024E67 File Offset: 0x00023267
	private void Start()
	{
	}

	// Token: 0x060004A9 RID: 1193 RVA: 0x00024E69 File Offset: 0x00023269
	private void Update()
	{
	}

	// Token: 0x060004AA RID: 1194 RVA: 0x00024E6C File Offset: 0x0002326C
	public void updateLevel(string key, int currentLevel)
	{
		currentLevel++;
		PlayerPrefs.SetInt(key, currentLevel);
		if (PlayerPrefs.GetInt(key) > PlayerPrefs.GetInt("SavedQuest"))
		{
			PlayerPrefs.SetInt("SavedQuest", PlayerPrefs.GetInt(key));
			MonoBehaviour.print("Proceed to level : " + currentLevel);
		}
	}

	// Token: 0x060004AB RID: 1195 RVA: 0x00024EBF File Offset: 0x000232BF
	public int getUpdatedLevel(string key, int currentLevel)
	{
		currentLevel++;
		PlayerPrefs.SetInt(key, currentLevel);
		if (PlayerPrefs.GetInt(key) > PlayerPrefs.GetInt("SavedQuest"))
		{
			PlayerPrefs.SetInt("SavedQuest", PlayerPrefs.GetInt(key));
		}
		return PlayerPrefs.GetInt(key);
	}

	// Token: 0x060004AC RID: 1196 RVA: 0x00024EF8 File Offset: 0x000232F8
	public void ResetData()
	{
		PlayerPrefs.SetInt("SavedQuest", 0);
	}
}
