using System;
using UnityEngine;
using UnityEngine.UI;

// Token: 0x02000216 RID: 534
public class Tutorials : MonoBehaviour
{
	// Token: 0x06000DBB RID: 3515 RVA: 0x00057D10 File Offset: 0x00056110
	public void tutorialOk()
	{
		PlayerPrefs.SetInt("Tutorial", 0);
		if (this.progress > this.tutorialPanel.transform.childCount - 1)
		{
			base.GetComponent<QuestManager>().setQuestID(PlayerPrefs.GetInt("Quest"));
			this.tutorialPanel.gameObject.SetActive(false);
			return;
		}
		this.tutorialPanel.gameObject.SetActive(true);
		this.tutorialPanel.transform.GetChild(this.progress).gameObject.SetActive(true);
		if (this.progress > 0)
		{
			this.tutorialPanel.transform.GetChild(this.progress - 1).gameObject.SetActive(false);
		}
		this.progress++;
	}

	// Token: 0x04000E79 RID: 3705
	public Image tutorialPanel;

	// Token: 0x04000E7A RID: 3706
	[HideInInspector]
	public int progress;
}
