using System;
using UnityEngine;
using UnityEngine.UI;

// Token: 0x0200009F RID: 159
public class CLManager : MonoBehaviour
{
	// Token: 0x060004A4 RID: 1188 RVA: 0x00024CCC File Offset: 0x000230CC
	private void Start()
	{
		this.level = PlayerPrefs.GetInt(this.levelKey);
		if (this.container.transform.GetChild(this.level).GetComponent<Animator>())
		{
			this.container.transform.GetChild(this.level).GetComponent<Animator>().enabled = true;
		}
		for (int i = 0; i < this.container.transform.childCount; i++)
		{
			if (i <= PlayerPrefs.GetInt("SavedQuest") && i < this.levelIcons.Length)
			{
				this.container.transform.GetChild(i).GetComponent<Image>().sprite = this.levelIcons[i];
			}
			if (i > PlayerPrefs.GetInt("SavedQuest"))
			{
				this.container.transform.GetChild(i).GetComponent<Image>().sprite = this.lockImage;
			}
		}
	}

	// Token: 0x060004A5 RID: 1189 RVA: 0x00024DC3 File Offset: 0x000231C3
	private void Update()
	{
		if (Input.GetKey(KeyCode.Escape))
		{
			Application.LoadLevel("MainMenu");
		}
	}

	// Token: 0x060004A6 RID: 1190 RVA: 0x00024DDC File Offset: 0x000231DC
	public void setLevel(int selectedLevel)
	{
		if (selectedLevel <= PlayerPrefs.GetInt("SavedQuest"))
		{
			PlayerPrefs.SetInt(this.levelKey, selectedLevel);
			if (selectedLevel == 0)
			{
				Application.LoadLevel("Story");
			}
			else if (selectedLevel == 2)
			{
				Application.LoadLevel("Story");
			}
			else if (selectedLevel == 4)
			{
				Application.LoadLevel("Story");
			}
			else
			{
				Application.LoadLevel("Loading");
			}
		}
		else
		{
			MonoBehaviour.print("Level locked");
		}
	}

	// Token: 0x040004CB RID: 1227
	public int level;

	// Token: 0x040004CC RID: 1228
	public string levelKey = "Quest";

	// Token: 0x040004CD RID: 1229
	public Sprite[] levelIcons;

	// Token: 0x040004CE RID: 1230
	public GameObject container;

	// Token: 0x040004CF RID: 1231
	public Sprite lockImage;
}
