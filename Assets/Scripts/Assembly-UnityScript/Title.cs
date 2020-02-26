using System;
using UnityEngine;

// Token: 0x020000A4 RID: 164
[Serializable]
public class Title : MonoBehaviour
{
	// Token: 0x06000239 RID: 569 RVA: 0x0001C024 File Offset: 0x0001A224
	public Title()
	{
		this.goToScene = "Field1";
		this.spawnPointName = "PlayerSpawnPoint";
		this.characterUiSize = new Vector2((float)400, (float)460);
		this.charName = "Richea";
		this.maxChar = 1;
	}

	// Token: 0x0600023A RID: 570 RVA: 0x0001C078 File Offset: 0x0001A278
	public virtual void Start()
	{
		Screen.lockCursor = false;
		this.charData = (CharacterData)this.characterDatabase.GetComponent(typeof(CharacterData));
		this.maxChar = this.charData.player.Length;
		if (!this.modelPosition)
		{
			this.modelPosition = this.transform;
		}
	}

	// Token: 0x0600023B RID: 571 RVA: 0x0001C0E0 File Offset: 0x0001A2E0
	public virtual void OnGUI()
	{
		if (this.page == 0)
		{
			if (GUI.Button(new Rect((float)(Screen.width - 420), (float)160, (float)280, (float)100), "Start Game"))
			{
				this.page = 2;
			}
			if (GUI.Button(new Rect((float)(Screen.width - 420), (float)280, (float)280, (float)100), "Load Game"))
			{
				this.page = 3;
			}
			if (GUI.Button(new Rect((float)(Screen.width - 420), (float)400, (float)280, (float)100), "How to Play"))
			{
				this.page = 1;
			}
		}
		if (this.page == 1)
		{
			GUI.Box(new Rect((float)(Screen.width / 2 - 250), (float)115, (float)400, (float)400), this.tip);
			if (GUI.Button(new Rect((float)(Screen.width - 280), (float)(Screen.height - 150), (float)250, (float)90), "Back"))
			{
				this.page = 0;
			}
		}
		if (this.page == 2)
		{
			GUI.Box(new Rect((float)(Screen.width / 2 - 250), (float)170, (float)500, (float)400), "Select your slot");
			if (GUI.Button(new Rect((float)(Screen.width / 2 + 185), (float)175, (float)30, (float)30), "X"))
			{
				this.page = 0;
			}
			if (PlayerPrefs.GetInt("PreviousSave0") > 0)
			{
				if (GUI.Button(new Rect((float)(Screen.width / 2 - 200), (float)205, (float)400, (float)100), PlayerPrefs.GetString("Name0") + "\n" + "Level " + PlayerPrefs.GetInt("PlayerLevel0").ToString()))
				{
					this.saveSlot = 0;
					this.page = 4;
				}
			}
			else if (GUI.Button(new Rect((float)(Screen.width / 2 - 200), (float)205, (float)400, (float)100), "- Empty Slot -"))
			{
				this.saveSlot = 0;
				this.page = 5;
				this.SwitchModel();
			}
			if (PlayerPrefs.GetInt("PreviousSave1") > 0)
			{
				if (GUI.Button(new Rect((float)(Screen.width / 2 - 200), (float)315, (float)400, (float)100), PlayerPrefs.GetString("Name1") + "\n" + "Level " + PlayerPrefs.GetInt("PlayerLevel1").ToString()))
				{
					this.saveSlot = 1;
					this.page = 4;
				}
			}
			else if (GUI.Button(new Rect((float)(Screen.width / 2 - 200), (float)315, (float)400, (float)100), "- Empty Slot -"))
			{
				this.saveSlot = 1;
				this.page = 5;
				this.SwitchModel();
			}
			if (PlayerPrefs.GetInt("PreviousSave2") > 0)
			{
				if (GUI.Button(new Rect((float)(Screen.width / 2 - 200), (float)425, (float)400, (float)100), PlayerPrefs.GetString("Name2") + "\n" + "Level " + PlayerPrefs.GetInt("PlayerLevel2").ToString()))
				{
					this.saveSlot = 2;
					this.page = 4;
				}
			}
			else if (GUI.Button(new Rect((float)(Screen.width / 2 - 200), (float)425, (float)400, (float)100), "- Empty Slot -"))
			{
				this.saveSlot = 2;
				this.page = 5;
				this.SwitchModel();
			}
		}
		if (this.page == 3)
		{
			GUI.Box(new Rect((float)(Screen.width / 2 - 250), (float)170, (float)500, (float)400), "Menu");
			if (GUI.Button(new Rect((float)(Screen.width / 2 + 185), (float)175, (float)30, (float)30), "X"))
			{
				this.page = 0;
			}
			if (PlayerPrefs.GetInt("PreviousSave0") > 0)
			{
				if (GUI.Button(new Rect((float)(Screen.width / 2 - 200), (float)205, (float)400, (float)100), PlayerPrefs.GetString("Name0") + "\n" + "Level " + PlayerPrefs.GetInt("PlayerLevel0").ToString()))
				{
					this.saveSlot = 0;
					this.LoadData();
				}
			}
			else if (GUI.Button(new Rect((float)(Screen.width / 2 - 200), (float)205, (float)400, (float)100), "- Empty Slot -"))
			{
			}
			if (PlayerPrefs.GetInt("PreviousSave1") > 0)
			{
				if (GUI.Button(new Rect((float)(Screen.width / 2 - 200), (float)315, (float)400, (float)100), PlayerPrefs.GetString("Name1") + "\n" + "Level " + PlayerPrefs.GetInt("PlayerLevel1").ToString()))
				{
					this.saveSlot = 1;
					this.LoadData();
				}
			}
			else if (GUI.Button(new Rect((float)(Screen.width / 2 - 200), (float)315, (float)400, (float)100), "- Empty Slot -"))
			{
			}
			if (PlayerPrefs.GetInt("PreviousSave2") > 0)
			{
				if (GUI.Button(new Rect((float)(Screen.width / 2 - 200), (float)425, (float)400, (float)100), PlayerPrefs.GetString("Name2") + "\n" + "Level " + PlayerPrefs.GetInt("PlayerLevel2").ToString()))
				{
					this.saveSlot = 2;
					this.LoadData();
				}
			}
			else if (GUI.Button(new Rect((float)(Screen.width / 2 - 200), (float)425, (float)400, (float)100), "- Empty Slot -"))
			{
			}
		}
		if (this.page == 4)
		{
			GUI.Box(new Rect((float)(Screen.width / 2 - 150), (float)200, (float)300, (float)180), "Are you sure to overwrite this slot?");
			if (GUI.Button(new Rect((float)(Screen.width / 2 - 110), (float)260, (float)100, (float)40), "Yes"))
			{
				this.page = 5;
				this.SwitchModel();
			}
			if (GUI.Button(new Rect((float)(Screen.width / 2 + 20), (float)260, (float)100, (float)40), "No"))
			{
				this.page = 0;
			}
		}
		if (this.page == 5)
		{
			GUI.Box(new Rect((float)80, (float)100, (float)300, (float)360), "Enter Your Name");
			GUI.Label(new Rect((float)100, (float)200, (float)300, (float)40), this.charData.player[this.charSelect].description.textLine1);
			GUI.Label(new Rect((float)100, (float)230, (float)300, (float)40), this.charData.player[this.charSelect].description.textLine2);
			GUI.Label(new Rect((float)100, (float)260, (float)300, (float)40), this.charData.player[this.charSelect].description.textLine3);
			GUI.Label(new Rect((float)100, (float)290, (float)300, (float)40), this.charData.player[this.charSelect].description.textLine4);
			this.charName = GUI.TextField(new Rect((float)120, (float)140, (float)220, (float)40), this.charName, 25);
			if (GUI.Button(new Rect((float)180, (float)400, (float)100, (float)40), "Done"))
			{
				this.NewGame();
			}
			if (GUI.Button(new Rect((float)(Screen.width / 2 - 110), (float)380, (float)50, (float)150), "<") && this.charSelect > 0)
			{
				this.charSelect--;
				this.SwitchModel();
			}
			if (GUI.Button(new Rect((float)(Screen.width / 2 + 190), (float)380, (float)50, (float)150), ">") && this.charSelect < this.maxChar - 1)
			{
				this.charSelect++;
				this.SwitchModel();
			}
			if (this.charData.player[this.charSelect].guiDescription)
			{
				GUI.DrawTexture(new Rect((float)Screen.width - this.characterUiSize.x - (float)5, (float)40, this.characterUiSize.x, this.characterUiSize.y), this.charData.player[this.charSelect].guiDescription);
			}
		}
	}

	// Token: 0x0600023C RID: 572 RVA: 0x0001CA88 File Offset: 0x0001AC88
	public virtual void NewGame()
	{
		PlayerPrefs.SetInt("SaveSlot", this.saveSlot);
		PlayerPrefs.SetInt("Loadgame", 0);
		GameObject gameObject = UnityEngine.Object.Instantiate<GameObject>(this.charData.player[this.charSelect].playerPrefab, this.transform.position, this.transform.rotation);
		((Status)gameObject.GetComponent(typeof(Status))).spawnPointName = this.spawnPointName;
		((Status)gameObject.GetComponent(typeof(Status))).characterId = this.charSelect;
		((Status)gameObject.GetComponent(typeof(Status))).characterName = this.charName;
		MonoBehaviour.print(this.charName);
		Application.LoadLevel(this.goToScene);
	}

	// Token: 0x0600023D RID: 573 RVA: 0x0001CB5C File Offset: 0x0001AD5C
	public virtual void LoadData()
	{
		PlayerPrefs.SetInt("SaveSlot", this.saveSlot);
		PlayerPrefs.SetInt("Loadgame", 10);
		int @int = PlayerPrefs.GetInt("PlayerID" + this.saveSlot.ToString());
		GameObject gameObject = UnityEngine.Object.Instantiate<GameObject>(this.charData.player[@int].playerPrefab, this.transform.position, this.transform.rotation);
		((Status)gameObject.GetComponent(typeof(Status))).spawnPointName = this.spawnPointName;
		Application.LoadLevel(this.goToScene);
	}

	// Token: 0x0600023E RID: 574 RVA: 0x0001CBFC File Offset: 0x0001ADFC
	public virtual void SwitchModel()
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

	// Token: 0x0600023F RID: 575 RVA: 0x0001CC80 File Offset: 0x0001AE80
	public virtual void Main()
	{
	}

	// Token: 0x040003AA RID: 938
	public Texture2D tip;

	// Token: 0x040003AB RID: 939
	public string goToScene;

	// Token: 0x040003AC RID: 940
	public string spawnPointName;

	// Token: 0x040003AD RID: 941
	public GameObject characterDatabase;

	// Token: 0x040003AE RID: 942
	public Transform modelPosition;

	// Token: 0x040003AF RID: 943
	public Vector2 characterUiSize;

	// Token: 0x040003B0 RID: 944
	private int page;

	// Token: 0x040003B1 RID: 945
	private int saveSlot;

	// Token: 0x040003B2 RID: 946
	private string charName;

	// Token: 0x040003B3 RID: 947
	private int charSelect;

	// Token: 0x040003B4 RID: 948
	private int maxChar;

	// Token: 0x040003B5 RID: 949
	private CharacterData charData;

	// Token: 0x040003B6 RID: 950
	private GameObject showingModel;
}
