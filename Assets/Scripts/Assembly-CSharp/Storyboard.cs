using System;
using System.Collections;
using UnityEngine;

// Token: 0x0200020F RID: 527
public class Storyboard : MonoBehaviour
{
	// Token: 0x06000D9A RID: 3482 RVA: 0x00056D05 File Offset: 0x00055105
	private void Start()
	{
	}

	// Token: 0x06000D9B RID: 3483 RVA: 0x00056D08 File Offset: 0x00055108
	private void Update()
	{
		if (this.allow)
		{
			if (this.scenePlay)
			{
				this.sceneFunction();
			}
			this.player.GetComponent<CharacterController>().Move(Vector3.forward * 2f * Time.deltaTime);
			this.mate.GetComponent<CharacterController>().Move(Vector3.forward * 2f * Time.deltaTime);
		}
	}

	// Token: 0x06000D9C RID: 3484 RVA: 0x00056D88 File Offset: 0x00055188
	private void sceneFunction()
	{
		if (this.Camera1.transform.position != this.allScenes[this.scene].positions[this.point].transform.position)
		{
			this.Camera1.transform.LookAt(this.player.transform.position);
			this.Camera1.transform.position = Vector3.MoveTowards(this.Camera1.transform.position, this.allScenes[this.scene].positions[this.point].transform.position, this.allScenes[this.scene].camSpeed);
		}
		else
		{
			this.point++;
		}
		if (this.point > this.allScenes[this.scene].positions.Length - 1)
		{
			this.scenePlay = false;
			this.point = 0;
			base.StartCoroutine(this.wait());
		}
	}

	// Token: 0x06000D9D RID: 3485 RVA: 0x00056E9C File Offset: 0x0005529C
	private IEnumerator wait()
	{
		yield return new WaitForSeconds(2f);
		this.scene++;
		this.scenePlay = true;
		this.sceneChange();
		yield break;
	}

	// Token: 0x06000D9E RID: 3486 RVA: 0x00056EB7 File Offset: 0x000552B7
	private void sceneChange()
	{
		this.Camera1.transform.position = this.allScenes[this.scene].positions[0].transform.position;
		this.readyScenes();
	}

	// Token: 0x06000D9F RID: 3487 RVA: 0x00056EF0 File Offset: 0x000552F0
	private void readyScenes()
	{
		if (this.scene == 1)
		{
			this.player.transform.position = this.playerPosition[0].transform.position;
			this.player.transform.rotation = Quaternion.Euler(new Vector3(this.playerPosition[0].transform.eulerAngles.x, this.playerPosition[0].transform.eulerAngles.y, this.playerPosition[0].transform.eulerAngles.z));
			this.mate.transform.position = this.matePosition[0].transform.position;
			this.mate.transform.rotation = Quaternion.Euler(new Vector3(this.matePosition[0].transform.eulerAngles.x, this.matePosition[0].transform.eulerAngles.y, this.matePosition[0].transform.eulerAngles.z));
		}
	}

	// Token: 0x04000E4E RID: 3662
	public GameObject player;

	// Token: 0x04000E4F RID: 3663
	public GameObject mate;

	// Token: 0x04000E50 RID: 3664
	public GameObject Camera1;

	// Token: 0x04000E51 RID: 3665
	public GameObject Camera2;

	// Token: 0x04000E52 RID: 3666
	public float cameraSpeed = 0.5f;

	// Token: 0x04000E53 RID: 3667
	public Storyboard.Scene[] allScenes = new Storyboard.Scene[1];

	// Token: 0x04000E54 RID: 3668
	private int scene;

	// Token: 0x04000E55 RID: 3669
	private int point;

	// Token: 0x04000E56 RID: 3670
	private bool allow = true;

	// Token: 0x04000E57 RID: 3671
	private bool scenePlay = true;

	// Token: 0x04000E58 RID: 3672
	public GameObject[] playerPosition;

	// Token: 0x04000E59 RID: 3673
	public GameObject[] matePosition;

	// Token: 0x02000210 RID: 528
	[Serializable]
	public class Scene
	{
		// Token: 0x04000E5A RID: 3674
		public string name;

		// Token: 0x04000E5B RID: 3675
		public GameObject[] positions;

		// Token: 0x04000E5C RID: 3676
		public float camSpeed;
	}
}
