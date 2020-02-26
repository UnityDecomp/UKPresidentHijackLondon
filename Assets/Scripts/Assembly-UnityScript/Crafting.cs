using System;
using UnityEngine;

// Token: 0x02000036 RID: 54
[Serializable]
public class Crafting : MonoBehaviour
{
	// Token: 0x0600009C RID: 156 RVA: 0x00007F50 File Offset: 0x00006150
	public Crafting()
	{
		this.craftingListId = new int[3];
		this.maxPage = 1;
		this.showError = string.Empty;
	}

	// Token: 0x0600009D RID: 157 RVA: 0x00007F84 File Offset: 0x00006184
	public virtual void Start()
	{
		if (!this.player)
		{
			this.player = GameObject.FindWithTag("Player");
		}
		this.itemdb = (ItemData)this.itemDatabase.GetComponent(typeof(ItemData));
		this.craftdb = (CraftingData)this.craftingDatabase.GetComponent(typeof(CraftingData));
		this.GetCraftingData();
	}

	// Token: 0x0600009E RID: 158 RVA: 0x00007FF8 File Offset: 0x000061F8
	public virtual void GetCraftingData()
	{
		this.craftingData = new CraftData[this.craftingListId.Length];
		for (int i = 0; i < this.craftingData.Length; i++)
		{
			this.craftingData[i] = this.craftdb.craftingData[this.craftingListId[i]];
		}
		this.maxPage = this.craftingData.Length / 9;
		if (this.craftingData.Length % 9 != 0)
		{
			this.maxPage++;
		}
	}

	// Token: 0x0600009F RID: 159 RVA: 0x00008088 File Offset: 0x00006288
	public virtual void Update()
	{
		if (Input.GetKeyDown("e") && this.enter)
		{
			this.OnOffMenu();
		}
	}

	// Token: 0x060000A0 RID: 160 RVA: 0x000080B8 File Offset: 0x000062B8
	public virtual void OnGUI()
	{
		GUI.skin = this.uiSkin;
		if (this.enter && this.uiPage == 0)
		{
			GUI.DrawTexture(new Rect((float)(Screen.width / 2 - 130), (float)(Screen.height - 120), (float)260, (float)80), this.button);
		}
		if (this.uiPage == 1)
		{
			GUI.Box(new Rect((float)(Screen.width / 2 - 215), (float)70, (float)430, (float)500), "Crafting Menu");
			if (GUI.Button(new Rect((float)(Screen.width / 2 + 175), (float)75, (float)33, (float)33), "X"))
			{
				this.OnOffMenu();
			}
			if (this.page + 0 < this.craftingData.Length && GUI.Button(new Rect((float)(Screen.width / 2 - 175), (float)95, (float)350, (float)40), this.craftingData[this.page + 0].itemName))
			{
				this.selection = this.page + 0;
				this.ShowItemQuantity();
				this.uiPage = 2;
			}
			if (this.page + 1 < this.craftingData.Length && GUI.Button(new Rect((float)(Screen.width / 2 - 175), (float)145, (float)350, (float)40), this.craftingData[this.page + 1].itemName))
			{
				this.selection = this.page + 1;
				this.ShowItemQuantity();
				this.uiPage = 2;
			}
			if (this.page + 2 < this.craftingData.Length && GUI.Button(new Rect((float)(Screen.width / 2 - 175), (float)195, (float)350, (float)40), this.craftingData[this.page + 2].itemName))
			{
				this.selection = this.page + 2;
				this.ShowItemQuantity();
				this.uiPage = 2;
			}
			if (this.page + 3 < this.craftingData.Length && GUI.Button(new Rect((float)(Screen.width / 2 - 175), (float)245, (float)350, (float)40), this.craftingData[this.page + 3].itemName))
			{
				this.selection = this.page + 3;
				this.ShowItemQuantity();
				this.uiPage = 2;
			}
			if (this.page + 4 < this.craftingData.Length && GUI.Button(new Rect((float)(Screen.width / 2 - 175), (float)295, (float)350, (float)40), this.craftingData[this.page + 4].itemName))
			{
				this.selection = this.page + 4;
				this.ShowItemQuantity();
				this.uiPage = 2;
			}
			if (this.page + 5 < this.craftingData.Length && GUI.Button(new Rect((float)(Screen.width / 2 - 175), (float)345, (float)350, (float)40), this.craftingData[this.page + 5].itemName))
			{
				this.selection = this.page + 5;
				this.ShowItemQuantity();
				this.uiPage = 2;
			}
			if (this.page + 6 < this.craftingData.Length && GUI.Button(new Rect((float)(Screen.width / 2 - 175), (float)395, (float)350, (float)40), this.craftingData[this.page + 6].itemName))
			{
				this.selection = this.page + 6;
				this.ShowItemQuantity();
				this.uiPage = 2;
			}
			if (this.page + 7 < this.craftingData.Length && GUI.Button(new Rect((float)(Screen.width / 2 - 175), (float)445, (float)350, (float)40), this.craftingData[this.page + 7].itemName))
			{
				this.selection = this.page + 7;
				this.ShowItemQuantity();
				this.uiPage = 2;
			}
			if (this.page + 8 < this.craftingData.Length && GUI.Button(new Rect((float)(Screen.width / 2 - 175), (float)495, (float)350, (float)40), this.craftingData[this.page + 8].itemName))
			{
				this.selection = this.page + 8;
				this.ShowItemQuantity();
				this.uiPage = 2;
			}
		}
		if (this.uiPage == 2)
		{
			GUI.Box(new Rect((float)(Screen.width / 2 - 200), (float)70, (float)400, (float)300), this.craftingData[this.selection].itemName);
			if (GUI.Button(new Rect((float)(Screen.width / 2 + 155), (float)75, (float)40, (float)40), "X"))
			{
				this.showError = string.Empty;
				this.uiPage = 1;
			}
			GUI.Label(new Rect((float)(Screen.width / 2 - 50), (float)330, (float)200, (float)100), this.showError);
			string text = null;
			if (this.craftingData[this.selection].ingredient[0].itemType == ItType.Usable)
			{
				text = this.itemdb.usableItem[this.craftingData[this.selection].ingredient[0].itemId].itemName;
			}
			else if (this.craftingData[this.selection].ingredient[0].itemType == ItType.Equipment)
			{
				text = this.itemdb.equipment[this.craftingData[this.selection].ingredient[0].itemId].itemName;
			}
			GUI.Label(new Rect((float)(Screen.width / 2 - 180), (float)150, (float)500, (float)100), text);
			GUI.Label(new Rect((float)(Screen.width / 2 + 10), (float)150, (float)500, (float)100), this.craftingData[this.selection].ingredient[0].quantity.ToString());
			GUI.Label(new Rect((float)(Screen.width / 2 + 40), (float)150, (float)500, (float)100), "(" + this.itemQty1 + ")");
			if (this.craftingData[this.selection].ingredient.Length >= 2)
			{
				string text2 = null;
				if (this.craftingData[this.selection].ingredient[1].itemType == ItType.Usable)
				{
					text2 = this.itemdb.usableItem[this.craftingData[this.selection].ingredient[1].itemId].itemName;
				}
				else if (this.craftingData[this.selection].ingredient[1].itemType == ItType.Equipment)
				{
					text2 = this.itemdb.equipment[this.craftingData[this.selection].ingredient[1].itemId].itemName;
				}
				GUI.Label(new Rect((float)(Screen.width / 2 - 180), (float)170, (float)500, (float)100), text2);
				GUI.Label(new Rect((float)(Screen.width / 2 + 10), (float)170, (float)500, (float)100), this.craftingData[this.selection].ingredient[1].quantity.ToString());
				GUI.Label(new Rect((float)(Screen.width / 2 + 40), (float)170, (float)500, (float)100), "(" + this.itemQty2 + ")");
			}
			if (this.craftingData[this.selection].ingredient.Length >= 3)
			{
				string text3 = null;
				if (this.craftingData[this.selection].ingredient[2].itemType == ItType.Usable)
				{
					text3 = this.itemdb.usableItem[this.craftingData[this.selection].ingredient[2].itemId].itemName;
				}
				else if (this.craftingData[this.selection].ingredient[2].itemType == ItType.Equipment)
				{
					text3 = this.itemdb.equipment[this.craftingData[this.selection].ingredient[2].itemId].itemName;
				}
				GUI.Label(new Rect((float)(Screen.width / 2 - 180), (float)190, (float)500, (float)100), text3);
				GUI.Label(new Rect((float)(Screen.width / 2 + 10), (float)190, (float)500, (float)100), this.craftingData[this.selection].ingredient[2].quantity.ToString());
				GUI.Label(new Rect((float)(Screen.width / 2 + 40), (float)190, (float)500, (float)100), "(" + this.itemQty3 + ")");
			}
			if (this.craftingData[this.selection].ingredient.Length >= 4)
			{
				string text4 = null;
				if (this.craftingData[this.selection].ingredient[3].itemType == ItType.Usable)
				{
					text4 = this.itemdb.usableItem[this.craftingData[this.selection].ingredient[3].itemId].itemName;
				}
				else if (this.craftingData[this.selection].ingredient[3].itemType == ItType.Equipment)
				{
					text4 = this.itemdb.equipment[this.craftingData[this.selection].ingredient[3].itemId].itemName;
				}
				GUI.Label(new Rect((float)(Screen.width / 2 - 180), (float)210, (float)500, (float)100), text4);
				GUI.Label(new Rect((float)(Screen.width / 2 + 10), (float)210, (float)500, (float)100), this.craftingData[this.selection].ingredient[3].quantity.ToString());
				GUI.Label(new Rect((float)(Screen.width / 2 + 40), (float)210, (float)500, (float)100), "(" + this.itemQty4 + ")");
			}
			if (this.craftingData[this.selection].ingredient.Length >= 5)
			{
				string text5 = null;
				if (this.craftingData[this.selection].ingredient[4].itemType == ItType.Usable)
				{
					text5 = this.itemdb.usableItem[this.craftingData[this.selection].ingredient[4].itemId].itemName;
				}
				else if (this.craftingData[this.selection].ingredient[4].itemType == ItType.Equipment)
				{
					text5 = this.itemdb.equipment[this.craftingData[this.selection].ingredient[4].itemId].itemName;
				}
				GUI.Label(new Rect((float)(Screen.width / 2 - 180), (float)230, (float)500, (float)100), text5);
				GUI.Label(new Rect((float)(Screen.width / 2 + 10), (float)230, (float)500, (float)100), this.craftingData[this.selection].ingredient[4].quantity.ToString());
				GUI.Label(new Rect((float)(Screen.width / 2 + 40), (float)230, (float)500, (float)100), "(" + this.itemQty5 + ")");
			}
			if (GUI.Button(new Rect((float)(Screen.width / 2 - 60), (float)270, (float)120, (float)50), "Craft"))
			{
				bool flag = this.CheckIngredients();
				if (flag)
				{
					this.AddandRemoveItem();
				}
				this.ShowItemQuantity();
			}
		}
	}

	// Token: 0x060000A1 RID: 161 RVA: 0x00008D54 File Offset: 0x00006F54
	public virtual void ShowItemQuantity()
	{
		if (this.craftingData[this.selection].ingredient[0].itemType == ItType.Usable)
		{
			int num = ((Inventory)this.player.GetComponent(typeof(Inventory))).FindItemSlot(this.craftingData[this.selection].ingredient[0].itemId);
			if (num <= ((Inventory)this.player.GetComponent(typeof(Inventory))).itemSlot.Length)
			{
				this.itemQty1 = ((Inventory)this.player.GetComponent(typeof(Inventory))).itemQuantity[num];
			}
			else
			{
				this.itemQty1 = 0;
			}
		}
		else if (this.craftingData[this.selection].ingredient[0].itemType == ItType.Equipment)
		{
			int num = ((Inventory)this.player.GetComponent(typeof(Inventory))).FindEquipmentSlot(this.craftingData[this.selection].ingredient[0].itemId);
			if (num <= ((Inventory)this.player.GetComponent(typeof(Inventory))).equipment.Length)
			{
				this.itemQty1 = 1;
			}
			else
			{
				this.itemQty1 = 0;
			}
		}
		if (this.craftingData[this.selection].ingredient.Length >= 2)
		{
			if (this.craftingData[this.selection].ingredient[1].itemType == ItType.Usable)
			{
				int num = ((Inventory)this.player.GetComponent(typeof(Inventory))).FindItemSlot(this.craftingData[this.selection].ingredient[1].itemId);
				if (num <= ((Inventory)this.player.GetComponent(typeof(Inventory))).itemSlot.Length)
				{
					this.itemQty2 = ((Inventory)this.player.GetComponent(typeof(Inventory))).itemQuantity[num];
				}
				else
				{
					this.itemQty2 = 0;
				}
			}
			else if (this.craftingData[this.selection].ingredient[1].itemType == ItType.Equipment)
			{
				int num = ((Inventory)this.player.GetComponent(typeof(Inventory))).FindEquipmentSlot(this.craftingData[this.selection].ingredient[1].itemId);
				if (num <= ((Inventory)this.player.GetComponent(typeof(Inventory))).equipment.Length)
				{
					this.itemQty2 = 1;
				}
				else
				{
					this.itemQty2 = 0;
				}
			}
		}
		if (this.craftingData[this.selection].ingredient.Length >= 3)
		{
			if (this.craftingData[this.selection].ingredient[2].itemType == ItType.Usable)
			{
				int num = ((Inventory)this.player.GetComponent(typeof(Inventory))).FindItemSlot(this.craftingData[this.selection].ingredient[2].itemId);
				if (num <= ((Inventory)this.player.GetComponent(typeof(Inventory))).itemSlot.Length)
				{
					this.itemQty3 = ((Inventory)this.player.GetComponent(typeof(Inventory))).itemQuantity[num];
				}
				else
				{
					this.itemQty3 = 0;
				}
			}
			else if (this.craftingData[this.selection].ingredient[2].itemType == ItType.Equipment)
			{
				int num = ((Inventory)this.player.GetComponent(typeof(Inventory))).FindEquipmentSlot(this.craftingData[this.selection].ingredient[2].itemId);
				if (num <= ((Inventory)this.player.GetComponent(typeof(Inventory))).equipment.Length)
				{
					this.itemQty3 = 1;
				}
				else
				{
					this.itemQty3 = 0;
				}
			}
		}
		if (this.craftingData[this.selection].ingredient.Length >= 4)
		{
			if (this.craftingData[this.selection].ingredient[3].itemType == ItType.Usable)
			{
				int num = ((Inventory)this.player.GetComponent(typeof(Inventory))).FindItemSlot(this.craftingData[this.selection].ingredient[3].itemId);
				if (num <= ((Inventory)this.player.GetComponent(typeof(Inventory))).itemSlot.Length)
				{
					this.itemQty4 = ((Inventory)this.player.GetComponent(typeof(Inventory))).itemQuantity[num];
				}
				else
				{
					this.itemQty4 = 0;
				}
			}
			else if (this.craftingData[this.selection].ingredient[3].itemType == ItType.Equipment)
			{
				int num = ((Inventory)this.player.GetComponent(typeof(Inventory))).FindEquipmentSlot(this.craftingData[this.selection].ingredient[3].itemId);
				if (num <= ((Inventory)this.player.GetComponent(typeof(Inventory))).equipment.Length)
				{
					this.itemQty4 = 1;
				}
				else
				{
					this.itemQty4 = 0;
				}
			}
		}
		if (this.craftingData[this.selection].ingredient.Length >= 5)
		{
			if (this.craftingData[this.selection].ingredient[4].itemType == ItType.Usable)
			{
				int num = ((Inventory)this.player.GetComponent(typeof(Inventory))).FindItemSlot(this.craftingData[this.selection].ingredient[4].itemId);
				if (num <= ((Inventory)this.player.GetComponent(typeof(Inventory))).itemSlot.Length)
				{
					this.itemQty5 = ((Inventory)this.player.GetComponent(typeof(Inventory))).itemQuantity[num];
				}
				else
				{
					this.itemQty5 = 0;
				}
			}
			else if (this.craftingData[this.selection].ingredient[4].itemType == ItType.Equipment)
			{
				int num = ((Inventory)this.player.GetComponent(typeof(Inventory))).FindEquipmentSlot(this.craftingData[this.selection].ingredient[4].itemId);
				if (num <= ((Inventory)this.player.GetComponent(typeof(Inventory))).equipment.Length)
				{
					this.itemQty5 = 1;
				}
				else
				{
					this.itemQty5 = 0;
				}
			}
		}
	}

	// Token: 0x060000A2 RID: 162 RVA: 0x00009460 File Offset: 0x00007660
	public virtual bool CheckIngredients()
	{
		for (int i = 0; i < this.craftingData[this.selection].ingredient.Length; i++)
		{
			if (!((Inventory)this.player.GetComponent(typeof(Inventory))).CheckItem(this.craftingData[this.selection].ingredient[i].itemId, (int)this.craftingData[this.selection].ingredient[i].itemType, this.craftingData[this.selection].ingredient[i].quantity))
			{
				this.showError = "Not enought items";
				return false;
			}
		}
		return true;
	}

	// Token: 0x060000A3 RID: 163 RVA: 0x00009518 File Offset: 0x00007718
	public virtual void AddandRemoveItem()
	{
		bool flag = default(bool);
		if (this.craftingData[this.selection].gotItem.itemType == ItType.Usable)
		{
			flag = ((Inventory)this.player.GetComponent(typeof(Inventory))).AddItem(this.craftingData[this.selection].gotItem.itemId, this.craftingData[this.selection].gotItem.quantity);
		}
		else if (this.craftingData[this.selection].gotItem.itemType == ItType.Equipment)
		{
			flag = ((Inventory)this.player.GetComponent(typeof(Inventory))).AddEquipment(this.craftingData[this.selection].gotItem.itemId);
		}
		if (!flag)
		{
			for (int i = 0; i < this.craftingData[this.selection].ingredient.Length; i++)
			{
				if (this.craftingData[this.selection].ingredient[i].itemType == ItType.Usable)
				{
					((Inventory)this.player.GetComponent(typeof(Inventory))).RemoveItem(this.craftingData[this.selection].ingredient[i].itemId, this.craftingData[this.selection].ingredient[i].quantity);
				}
				else if (this.craftingData[this.selection].ingredient[i].itemType == ItType.Equipment)
				{
					((Inventory)this.player.GetComponent(typeof(Inventory))).RemoveEquipment(this.craftingData[this.selection].ingredient[i].itemId);
				}
			}
			this.showError = "You Got " + this.craftingData[this.selection].itemName;
		}
		else
		{
			this.showError = "Inventory Full";
		}
	}

	// Token: 0x060000A4 RID: 164 RVA: 0x00009718 File Offset: 0x00007918
	public virtual void OnOffMenu()
	{
		if (this.uiPage == 0 && Time.timeScale != (float)0)
		{
			if (!this.player)
			{
				this.player = GameObject.FindWithTag("Player");
			}
			this.uiPage = 1;
			Time.timeScale = (float)0;
			this.showError = string.Empty;
			Screen.lockCursor = false;
		}
		else if (this.uiPage >= 1)
		{
			this.uiPage = 0;
			Time.timeScale = 1f;
			Screen.lockCursor = true;
		}
	}

	// Token: 0x060000A5 RID: 165 RVA: 0x000097A4 File Offset: 0x000079A4
	public virtual void OnTriggerEnter(Collider other)
	{
		if (other.gameObject.tag == "Player")
		{
			Inventory exists = (Inventory)other.GetComponent(typeof(Inventory));
			if (exists)
			{
				this.player = other.gameObject;
				this.enter = true;
			}
		}
	}

	// Token: 0x060000A6 RID: 166 RVA: 0x00009800 File Offset: 0x00007A00
	public virtual void OnTriggerExit(Collider other)
	{
		if (other.gameObject == this.player)
		{
			this.enter = false;
		}
	}

	// Token: 0x060000A7 RID: 167 RVA: 0x00009820 File Offset: 0x00007A20
	public virtual void Main()
	{
	}

	// Token: 0x04000134 RID: 308
	public int[] craftingListId;

	// Token: 0x04000135 RID: 309
	private CraftData[] craftingData;

	// Token: 0x04000136 RID: 310
	public GameObject itemDatabase;

	// Token: 0x04000137 RID: 311
	public GameObject craftingDatabase;

	// Token: 0x04000138 RID: 312
	private GameObject player;

	// Token: 0x04000139 RID: 313
	public GUISkin uiSkin;

	// Token: 0x0400013A RID: 314
	public Texture2D button;

	// Token: 0x0400013B RID: 315
	private ItemData itemdb;

	// Token: 0x0400013C RID: 316
	private CraftingData craftdb;

	// Token: 0x0400013D RID: 317
	private int uiPage;

	// Token: 0x0400013E RID: 318
	private int page;

	// Token: 0x0400013F RID: 319
	private int maxPage;

	// Token: 0x04000140 RID: 320
	private int selection;

	// Token: 0x04000141 RID: 321
	private string showError;

	// Token: 0x04000142 RID: 322
	private bool enter;

	// Token: 0x04000143 RID: 323
	private int itemQty1;

	// Token: 0x04000144 RID: 324
	private int itemQty2;

	// Token: 0x04000145 RID: 325
	private int itemQty3;

	// Token: 0x04000146 RID: 326
	private int itemQty4;

	// Token: 0x04000147 RID: 327
	private int itemQty5;
}
