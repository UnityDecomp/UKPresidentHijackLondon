using System;
using System.Collections;
using UnityEngine;
using UnityEngine.UI;

// Token: 0x02000211 RID: 529
public class StoryScene : MonoBehaviour
{
	// Token: 0x06000DA2 RID: 3490 RVA: 0x000570F4 File Offset: 0x000554F4
	private void Start()
	{
		for (int i = 0; i < this.SceneNum.Length; i++)
		{
			this.SceneNum[i].Actors.SetActive(false);
		}
		this.scene = 5;
		this.lastingScene = 10;
		if (PlayerPrefs.GetInt("Quest") == 0)
		{
			this.scene = 0;
			this.lastingScene = 2;
		}
		if (PlayerPrefs.GetInt("Quest") == 2)
		{
			this.scene = 3;
			this.lastingScene = 4;
		}
		if (PlayerPrefs.GetInt("Quest") == 4)
		{
			this.scene = 5;
			this.lastingScene = 6;
		}
		this.startScene();
	}

	// Token: 0x06000DA3 RID: 3491 RVA: 0x0005719C File Offset: 0x0005559C
	private void Update()
	{
		if (this.allow)
		{
			if (this.scene == 0)
			{
			}
			if (this.scene == 1)
			{
				GameObject gameObject = this.SceneNum[this.scene].Actors.transform.GetChild(0).gameObject;
				this.Camera.transform.LookAt(gameObject.transform);
			}
			if (this.scene == 2)
			{
				this.Camera.transform.Translate(Vector3.forward * Time.deltaTime);
			}
			if (this.scene == 3)
			{
			}
			if (this.scene == 4)
			{
			}
			if (this.scene == 5)
			{
				this.Camera.transform.Translate(Vector3.up * 0.2f * Time.deltaTime);
			}
			if (this.scene == 6)
			{
			}
			if (this.scene == 7)
			{
			}
			if (this.scene == 8)
			{
				for (int i = 0; i < 2; i++)
				{
					GameObject gameObject2 = this.SceneNum[this.scene].Actors.transform.GetChild(i).gameObject;
					gameObject2.GetComponent<CharacterController>().Move(Vector3.left * 2f * Time.deltaTime);
				}
			}
			if (this.scene == 9)
			{
			}
			if (this.scene == 10)
			{
			}
			if (this.scene == 11)
			{
				for (int j = 0; j < 1; j++)
				{
					GameObject gameObject3 = this.SceneNum[this.scene].Actors.transform.GetChild(j).gameObject;
					this.Camera.transform.LookAt(gameObject3.transform.position);
					this.Camera.transform.RotateAround(gameObject3.transform.position, Vector3.up, 0.6f);
				}
			}
		}
	}

	// Token: 0x06000DA4 RID: 3492 RVA: 0x0005739C File Offset: 0x0005579C
	private void startScene()
	{
		MonoBehaviour.print("Scene : " + this.scene);
		this.sceneSetting();
		this.SceneNum[this.scene].Actors.SetActive(true);
		this.Camera.transform.position = this.SceneNum[this.scene].camPosition.position;
		if (this.SceneNum[this.scene].lookPoint)
		{
			this.Camera.transform.LookAt(this.SceneNum[this.scene].lookPoint);
		}
		if (this.missionStatement() != string.Empty)
		{
			this.panel.GetComponentInChildren<Text>().text = string.Empty;
			base.StartCoroutine(this.nextText(this.SceneNum[this.scene].time));
		}
		base.StartCoroutine(this.waitForNext(this.SceneNum[this.scene].time));
	}

	// Token: 0x06000DA5 RID: 3493 RVA: 0x000574B0 File Offset: 0x000558B0
	private IEnumerator waitForNext(float delay)
	{
		this.allow = true;
		yield return new WaitForSeconds(delay);
		this.allow = false;
		this.scene++;
		if (this.scene <= this.lastingScene)
		{
			this.SceneNum[this.scene - 1].Actors.SetActive(false);
			this.startScene();
		}
		else
		{
			this.skipStory();
		}
		yield break;
	}

	// Token: 0x06000DA6 RID: 3494 RVA: 0x000574D4 File Offset: 0x000558D4
	private IEnumerator nextText(float delay)
	{
		string statment = this.missionStatement();
		for (int i = 0; i < statment.Length; i++)
		{
			yield return new WaitForSeconds(0.01f);
			Text componentInChildren = this.panel.GetComponentInChildren<Text>();
			componentInChildren.text += statment[i];
		}
		yield break;
	}

	// Token: 0x06000DA7 RID: 3495 RVA: 0x000574F0 File Offset: 0x000558F0
	private IEnumerator dayNightCycle()
	{
		for (int i = 0; i < 12; i++)
		{
			yield return new WaitForSeconds(0.1f);
			this.daylight.GetComponent<Light>().intensity -= 0.1f;
		}
		yield return new WaitForSeconds(2f);
		for (int j = 0; j < 12; j++)
		{
			yield return new WaitForSeconds(0.1f);
			this.daylight.GetComponent<Light>().intensity += 0.1f;
		}
		yield break;
	}

	// Token: 0x06000DA8 RID: 3496 RVA: 0x0005750B File Offset: 0x0005590B
	private void sceneSetting()
	{
		if (this.scene == 0)
		{
		}
	}

	// Token: 0x06000DA9 RID: 3497 RVA: 0x00057518 File Offset: 0x00055918
	private string missionStatement()
	{
		string result = string.Empty;
		switch (this.scene)
		{
		case 0:
			result = "President's Car Came into the Building ";
			break;
		case 1:
			result = "She is going to her office";
			break;
		case 2:
			result = "Special Force Officers are here to Protect Her  ";
			break;
		case 3:
			result = "President is In Meeting ";
			break;
		case 4:
			result = "Two Outsider Came to Meet Her";
			break;
		case 5:
			result = "The Hijeckers attack the President's Office ";
			break;
		case 6:
			result = "Office's Security get down. Hijacker takes Controll over the Office";
			break;
		case 7:
			result = "Somehow these two were able to reach the shore near a Jungle.";
			break;
		case 8:
			result = "You proved your bravery and escaped the city eliminating all threats";
			break;
		case 9:
			result = "You are a Hero and from now on 'The Alpha Ape'";
			break;
		}
		return result;
	}

	// Token: 0x06000DAA RID: 3498 RVA: 0x000575D4 File Offset: 0x000559D4
	public void skipStory()
	{
		MonoBehaviour.print("start mission");
		PlayerPrefs.SetString("Scene", "MainScene");
		Application.LoadLevel("Loading");
	}

	// Token: 0x06000DAB RID: 3499 RVA: 0x000575FC File Offset: 0x000559FC
	private IEnumerator LoadLoadingScene()
	{
		yield return new WaitForSeconds(4f);
		Application.LoadLevel("Loading");
		yield break;
	}

	// Token: 0x04000E5D RID: 3677
	public int QID;

	// Token: 0x04000E5E RID: 3678
	public GameObject Camera;

	// Token: 0x04000E5F RID: 3679
	public Image panel;

	// Token: 0x04000E60 RID: 3680
	public AudioClip[] sounds;

	// Token: 0x04000E61 RID: 3681
	public GameObject daylight;

	// Token: 0x04000E62 RID: 3682
	public GameObject underWaterLight;

	// Token: 0x04000E63 RID: 3683
	private int lastingScene;

	// Token: 0x04000E64 RID: 3684
	public StoryScene.Scenes[] SceneNum = new StoryScene.Scenes[1];

	// Token: 0x04000E65 RID: 3685
	private bool allow;

	// Token: 0x04000E66 RID: 3686
	private int scene;

	// Token: 0x02000212 RID: 530
	[Serializable]
	public class Scenes
	{
		// Token: 0x04000E67 RID: 3687
		public string scene;

		// Token: 0x04000E68 RID: 3688
		public GameObject Actors;

		// Token: 0x04000E69 RID: 3689
		public Transform camPosition;

		// Token: 0x04000E6A RID: 3690
		public Transform lookPoint;

		// Token: 0x04000E6B RID: 3691
		[Range(2f, 16f)]
		public float time;
	}
}
