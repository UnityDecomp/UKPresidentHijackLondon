using System;
using UnityEngine;

// Token: 0x02000200 RID: 512
public class QuestProgress : MonoBehaviour
{
	// Token: 0x06000D5D RID: 3421 RVA: 0x00055C27 File Offset: 0x00054027
	private void Start()
	{
		Time.timeScale = 1f;
	}

	// Token: 0x06000D5E RID: 3422 RVA: 0x00055C33 File Offset: 0x00054033
	public double getTime()
	{
		return this.time;
	}

	// Token: 0x06000D5F RID: 3423 RVA: 0x00055C3B File Offset: 0x0005403B
	private void Update()
	{
	}

	// Token: 0x06000D60 RID: 3424 RVA: 0x00055C40 File Offset: 0x00054040
	public void StartCelebration()
	{
		MonoBehaviour.print("idhr rot cam ha");
		MonoBehaviour.print(string.Empty + this.RotCam.name);
		this.celebrate = true;
		this.RotCam.gameObject.SetActive(true);
		this.questManager.GetComponent<dogsactive>().getActiveCamera().SetActive(false);
		this.questManager.Hero.transform.GetChild(10).gameObject.SetActive(true);
		this.questManager.Hero1.transform.GetChild(8).gameObject.SetActive(true);
	}

	// Token: 0x06000D61 RID: 3425 RVA: 0x00055CE4 File Offset: 0x000540E4
	public void StopCelebration()
	{
		MonoBehaviour.print("idhr cam off ha");
		this.celebrate = false;
		this.questManager.GetComponent<dogsactive>().getActiveCamera().SetActive(true);
		this.questManager.Hero.transform.GetChild(10).gameObject.SetActive(false);
		this.questManager.Hero1.transform.GetChild(8).gameObject.SetActive(false);
		this.RotCam.gameObject.SetActive(false);
	}

	// Token: 0x04000E00 RID: 3584
	public Camera RotCam;

	// Token: 0x04000E01 RID: 3585
	public GameObject rotationPoint;

	// Token: 0x04000E02 RID: 3586
	public QuestManager questManager;

	// Token: 0x04000E03 RID: 3587
	private int questId;

	// Token: 0x04000E04 RID: 3588
	private int questRecord = -1;

	// Token: 0x04000E05 RID: 3589
	private double time = 100.0;

	// Token: 0x04000E06 RID: 3590
	private bool celebrate;
}
