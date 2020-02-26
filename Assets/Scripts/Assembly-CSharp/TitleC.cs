using System;
using UnityEngine;

// Token: 0x02000099 RID: 153
public class TitleC : MonoBehaviour
{
	// Token: 0x0600048C RID: 1164 RVA: 0x00023204 File Offset: 0x00021604
	private void Start()
	{
		Screen.lockCursor = false;
		this.charData = this.characterDatabase.GetComponent<CharacterDataC>();
		this.maxChar = this.charData.player.Length;
		if (!this.modelPosition)
		{
			this.modelPosition = base.transform;
		}
	}

	// Token: 0x0600048D RID: 1165 RVA: 0x00023258 File Offset: 0x00021658
	private void OnGUI()
	{
		if (this.page == 0)
		{
			if (GUI.Button(new Rect((float)(Screen.width - 420), 160f, 280f, 100f), "Start Game"))
			{
				this.page = 2;
			}
			if (GUI.Button(new Rect((float)(Screen.width - 420), 280f, 280f, 100f), "Load Game"))
			{
				this.page = 3;
			}
			if (GUI.Button(new Rect((float)(Screen.width - 420), 400f, 280f, 100f), "How to Play"))
			{
				this.page = 1;
			}
		}
		if (this.page == 1)
		{
			GUI.Box(new Rect((float)(Screen.width / 2 - 250), 115f, 400f, 400f), this.tip);
			if (GUI.Button(new Rect((float)(Screen.width - 280), (float)(Screen.height - 150), 250f, 90f), "Back"))
			{
				this.page = 0;
			}
		}
		if (this.page == 2)
		{
			GUI.Box(new Rect((float)(Screen.width / 2 - 250), 170f, 500f, 400f), "Select your slot");
			if (GUI.Button(new Rect((float)(Screen.width / 2 + 185), 175f, 30f, 30f), "X"))
			{
				this.page = 0;
			}
			if (PlayerPrefs.GetInt("PreviousSave0") > 0)
			{
				if (GUI.Button(new Rect((float)(Screen.width / 2 - 200), 205f, 400f, 100f), PlayerPrefs.GetString("Name0") + "\nLevel " + PlayerPrefs.GetInt("PlayerLevel0").ToString()))
				{
					this.saveSlot = 0;
					this.page = 4;
				}
			}
			else if (GUI.Button(new Rect((float)(Screen.width / 2 - 200), 205f, 400f, 100f), "- Empty Slot -"))
			{
				this.saveSlot = 0;
				this.page = 5;
				this.SwitchModel();
			}
			if (PlayerPrefs.GetInt("PreviousSave1") > 0)
			{
				if (GUI.Button(new Rect((float)(Screen.width / 2 - 200), 315f, 400f, 100f), PlayerPrefs.GetString("Name1") + "\nLevel " + PlayerPrefs.GetInt("PlayerLevel1").ToString()))
				{
					this.saveSlot = 1;
					this.page = 4;
				}
			}
			else if (GUI.Button(new Rect((float)(Screen.width / 2 - 200), 315f, 400f, 100f), "- Empty Slot -"))
			{
				this.saveSlot = 1;
				this.page = 5;
				this.SwitchModel();
			}
			if (PlayerPrefs.GetInt("PreviousSave2") > 0)
			{
				if (GUI.Button(new Rect((float)(Screen.width / 2 - 200), 425f, 400f, 100f), PlayerPrefs.GetString("Name2") + "\nLevel " + PlayerPrefs.GetInt("PlayerLevel2").ToString()))
				{
					this.saveSlot = 2;
					this.page = 4;
				}
			}
			else if (GUI.Button(new Rect((float)(Screen.width / 2 - 200), 425f, 400f, 100f), "- Empty Slot -"))
			{
				this.saveSlot = 2;
				this.page = 5;
				this.SwitchModel();
			}
		}
		if (this.page == 3)
		{
			GUI.Box(new Rect((float)(Screen.width / 2 - 250), 170f, 500f, 400f), "Menu");
			if (GUI.Button(new Rect((float)(Screen.width / 2 + 185), 175f, 30f, 30f), "X"))
			{
				this.page = 0;
			}
			if (PlayerPrefs.GetInt("PreviousSave0") > 0)
			{
				if (GUI.Button(new Rect((float)(Screen.width / 2 - 200), 205f, 400f, 100f), PlayerPrefs.GetString("Name0") + "\nLevel " + PlayerPrefs.GetInt("PlayerLevel0").ToString()))
				{
					this.saveSlot = 0;
					this.LoadData();
				}
			}
			else if (GUI.Button(new Rect((float)(Screen.width / 2 - 200), 205f, 400f, 100f), "- Empty Slot -"))
			{
			}
			if (PlayerPrefs.GetInt("PreviousSave1") > 0)
			{
				if (GUI.Button(new Rect((float)(Screen.width / 2 - 200), 315f, 400f, 100f), PlayerPrefs.GetString("Name1") + "\nLevel " + PlayerPrefs.GetInt("PlayerLevel1").ToString()))
				{
					this.saveSlot = 1;
					this.LoadData();
				}
			}
			else if (GUI.Button(new Rect((float)(Screen.width / 2 - 200), 315f, 400f, 100f), "- Empty Slot -"))
			{
			}
			if (PlayerPrefs.GetInt("PreviousSave2") > 0)
			{
				if (GUI.Button(new Rect((float)(Screen.width / 2 - 200), 425f, 400f, 100f), PlayerPrefs.GetString("Name2") + "\nLevel " + PlayerPrefs.GetInt("PlayerLevel2").ToString()))
				{
					this.saveSlot = 2;
					this.LoadData();
				}
			}
			else if (GUI.Button(new Rect((float)(Screen.width / 2 - 200), 425f, 400f, 100f), "- Empty Slot -"))
			{
			}
		}
		if (this.page == 4)
		{
			GUI.Box(new Rect((float)(Screen.width / 2 - 150), 200f, 300f, 180f), "Are you sure to overwrite this slot?");
			if (GUI.Button(new Rect((float)(Screen.width / 2 - 110), 260f, 100f, 40f), "Yes"))
			{
				this.page = 5;
				this.SwitchModel();
			}
			if (GUI.Button(new Rect((float)(Screen.width / 2 + 20), 260f, 100f, 40f), "No"))
			{
				this.page = 0;
			}
		}
		if (this.page == 5)
		{
			GUI.Box(new Rect(80f, 100f, 300f, 360f), "Enter Your Name");
			GUI.Label(new Rect(100f, 200f, 300f, 40f), this.charData.player[this.charSelect].description.textLine1);
			GUI.Label(new Rect(100f, 230f, 300f, 40f), this.charData.player[this.charSelect].description.textLine2);
			GUI.Label(new Rect(100f, 260f, 300f, 40f), this.charData.player[this.charSelect].description.textLine3);
			GUI.Label(new Rect(100f, 290f, 300f, 40f), this.charData.player[this.charSelect].description.textLine4);
			this.charName = GUI.TextField(new Rect(120f, 140f, 220f, 40f), this.charName, 25);
			if (GUI.Button(new Rect(180f, 400f, 100f, 40f), "Done"))
			{
				this.NewGame();
			}
			if (GUI.Button(new Rect((float)(Screen.width / 2 - 110), 380f, 50f, 150f), "<") && this.charSelect > 0)
			{
				this.charSelect--;
				this.SwitchModel();
			}
			if (GUI.Button(new Rect((float)(Screen.width / 2 + 190), 380f, 50f, 150f), ">") && this.charSelect < this.maxChar - 1)
			{
				this.charSelect++;
				this.SwitchModel();
			}
			if (this.charData.player[this.charSelect].guiDescription)
			{
				GUI.DrawTexture(new Rect((float)Screen.width - this.characterUiSize.x - 5f, 40f, this.characterUiSize.x, this.characterUiSize.y), this.charData.player[this.charSelect].guiDescription);
			}
		}
	}

	// Token: 0x0600048E RID: 1166 RVA: 0x00023BE0 File Offset: 0x00021FE0
	private void NewGame()
	{
		PlayerPrefs.SetInt("SaveSlot", this.saveSlot);
		PlayerPrefs.SetInt("Loadgame", 0);
		GameObject gameObject = UnityEngine.Object.Instantiate<GameObject>(this.charData.player[this.charSelect].playerPrefab, base.transform.position, base.transform.rotation);
		gameObject.GetComponent<StatusC>().spawnPointName = this.spawnPointName;
		gameObject.GetComponent<StatusC>().characterId = this.charSelect;
		gameObject.GetComponent<StatusC>().characterName = this.charName;
		Application.LoadLevel(this.goToScene);
	}

	// Token: 0x0600048F RID: 1167 RVA: 0x00023C7C File Offset: 0x0002207C
	private void LoadData()
	{
		PlayerPrefs.SetInt("SaveSlot", this.saveSlot);
		PlayerPrefs.SetInt("Loadgame", 10);
		int @int = PlayerPrefs.GetInt("PlayerID" + this.saveSlot.ToString());
		GameObject gameObject = UnityEngine.Object.Instantiate<GameObject>(this.charData.player[@int].playerPrefab, base.transform.position, base.transform.rotation);
		gameObject.GetComponent<StatusC>().spawnPointName = this.spawnPointName;
		Application.LoadLevel(this.goToScene);
	}

	// Token: 0x06000490 RID: 1168 RVA: 0x00023D10 File Offset: 0x00022110
	private void SwitchModel()
	{
		if (this.showingModel)
		{
			UnityEngine.Object.Destroy(this.showingModel);
		}
		if (this.charData.player[this.charSelect].characterSelectModel)
		{
			this.showingModel = UnityEngine.Object.Instantiate<GameObject>(this.charData.player[this.charSelect].characterSelectModel, this.modelPosition.position, this.modelPosition.rotation);
		}
	}

	// Token: 0x0400048F RID: 1167
	public Texture2D tip;

	// Token: 0x04000490 RID: 1168
	public string goToScene = "Field1";

	// Token: 0x04000491 RID: 1169
	public string spawnPointName = "PlayerSpawnPointC";

	// Token: 0x04000492 RID: 1170
	public GameObject characterDatabase;

	// Token: 0x04000493 RID: 1171
	public Transform modelPosition;

	// Token: 0x04000494 RID: 1172
	public Vector2 characterUiSize = new Vector2(400f, 460f);

	// Token: 0x04000495 RID: 1173
	private int page;

	// Token: 0x04000496 RID: 1174
	private int saveSlot;

	// Token: 0x04000497 RID: 1175
	private string charName = "Richea";

	// Token: 0x04000498 RID: 1176
	private int charSelect;

	// Token: 0x04000499 RID: 1177
	private int maxChar = 1;

	// Token: 0x0400049A RID: 1178
	private CharacterDataC charData;

	// Token: 0x0400049B RID: 1179
	private GameObject showingModel;
}
