using System;
using UnityEngine;

// Token: 0x0200005B RID: 91
public class CraftingC : MonoBehaviour
{
	// Token: 0x06000368 RID: 872 RVA: 0x00010FE4 File Offset: 0x0000F3E4
	private void Start()
	{
		if (!this.player)
		{
			this.player = GameObject.FindWithTag("Player");
		}
		this.itemdb = this.itemDatabase.GetComponent<ItemDataC>();
		this.craftdb = this.craftingDatabase.GetComponent<CraftingDataC>();
		this.GetCraftingData();
	}

	// Token: 0x06000369 RID: 873 RVA: 0x0001103C File Offset: 0x0000F43C
	private void GetCraftingData()
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
		MonoBehaviour.print(this.maxPage);
	}

	// Token: 0x0600036A RID: 874 RVA: 0x000110D0 File Offset: 0x0000F4D0
	private void Update()
	{
		if (Input.GetKeyDown("e") && this.enter)
		{
			this.OnOffMenu();
		}
	}

	// Token: 0x0600036B RID: 875 RVA: 0x000110F4 File Offset: 0x0000F4F4
	private void OnGUI()
	{
		GUI.skin = this.uiSkin;
		if (this.enter && this.uiPage == 0)
		{
			GUI.DrawTexture(new Rect((float)(Screen.width / 2 - 130), (float)(Screen.height - 120), 260f, 80f), this.button);
		}
		if (this.uiPage == 1)
		{
			GUI.Box(new Rect((float)(Screen.width / 2 - 215), 70f, 430f, 500f), "Crafting Menu");
			if (GUI.Button(new Rect((float)(Screen.width / 2 + 175), 75f, 33f, 33f), "X"))
			{
				this.OnOffMenu();
			}
			if (this.page < this.craftingData.Length && GUI.Button(new Rect((float)(Screen.width / 2 - 175), 95f, 350f, 40f), this.craftingData[this.page].itemName))
			{
				this.selection = this.page;
				this.ShowItemQuantity();
				this.uiPage = 2;
			}
			if (this.page + 1 < this.craftingData.Length && GUI.Button(new Rect((float)(Screen.width / 2 - 175), 145f, 350f, 40f), this.craftingData[this.page + 1].itemName))
			{
				this.selection = this.page + 1;
				this.ShowItemQuantity();
				this.uiPage = 2;
			}
			if (this.page + 2 < this.craftingData.Length && GUI.Button(new Rect((float)(Screen.width / 2 - 175), 195f, 350f, 40f), this.craftingData[this.page + 2].itemName))
			{
				this.selection = this.page + 2;
				this.ShowItemQuantity();
				this.uiPage = 2;
			}
			if (this.page + 3 < this.craftingData.Length && GUI.Button(new Rect((float)(Screen.width / 2 - 175), 245f, 350f, 40f), this.craftingData[this.page + 3].itemName))
			{
				this.selection = this.page + 3;
				this.ShowItemQuantity();
				this.uiPage = 2;
			}
			if (this.page + 4 < this.craftingData.Length && GUI.Button(new Rect((float)(Screen.width / 2 - 175), 295f, 350f, 40f), this.craftingData[this.page + 4].itemName))
			{
				this.selection = this.page + 4;
				this.ShowItemQuantity();
				this.uiPage = 2;
			}
			if (this.page + 5 < this.craftingData.Length && GUI.Button(new Rect((float)(Screen.width / 2 - 175), 345f, 350f, 40f), this.craftingData[this.page + 5].itemName))
			{
				this.selection = this.page + 5;
				this.ShowItemQuantity();
				this.uiPage = 2;
			}
			if (this.page + 6 < this.craftingData.Length && GUI.Button(new Rect((float)(Screen.width / 2 - 175), 395f, 350f, 40f), this.craftingData[this.page + 6].itemName))
			{
				this.selection = this.page + 6;
				this.ShowItemQuantity();
				this.uiPage = 2;
			}
			if (this.page + 7 < this.craftingData.Length && GUI.Button(new Rect((float)(Screen.width / 2 - 175), 445f, 350f, 40f), this.craftingData[this.page + 7].itemName))
			{
				this.selection = this.page + 7;
				this.ShowItemQuantity();
				this.uiPage = 2;
			}
			if (this.page + 8 < this.craftingData.Length && GUI.Button(new Rect((float)(Screen.width / 2 - 175), 495f, 350f, 40f), this.craftingData[this.page + 8].itemName))
			{
				this.selection = this.page + 8;
				this.ShowItemQuantity();
				this.uiPage = 2;
			}
		}
		if (this.uiPage == 2)
		{
			GUI.Box(new Rect((float)(Screen.width / 2 - 200), 70f, 400f, 300f), this.craftingData[this.selection].itemName);
			if (GUI.Button(new Rect((float)(Screen.width / 2 + 155), 75f, 40f, 40f), "X"))
			{
				this.showError = string.Empty;
				this.uiPage = 1;
			}
			GUI.Label(new Rect((float)(Screen.width / 2 - 50), 330f, 200f, 100f), this.showError);
			string text = string.Empty;
			if (this.craftingData[this.selection].ingredient[0].itemType == ItType.Usable)
			{
				text = this.itemdb.usableItem[this.craftingData[this.selection].ingredient[0].itemId].itemName;
			}
			else if (this.craftingData[this.selection].ingredient[0].itemType == ItType.Equipment)
			{
				text = this.itemdb.equipment[this.craftingData[this.selection].ingredient[0].itemId].itemName;
			}
			GUI.Label(new Rect((float)(Screen.width / 2 - 180), 150f, 500f, 100f), text);
			GUI.Label(new Rect((float)(Screen.width / 2 + 10), 150f, 500f, 100f), this.craftingData[this.selection].ingredient[0].quantity.ToString());
			GUI.Label(new Rect((float)(Screen.width / 2 + 40), 150f, 500f, 100f), "(" + this.itemQty1 + ")");
			if (this.craftingData[this.selection].ingredient.Length >= 2)
			{
				string text2 = string.Empty;
				if (this.craftingData[this.selection].ingredient[1].itemType == ItType.Usable)
				{
					text2 = this.itemdb.usableItem[this.craftingData[this.selection].ingredient[1].itemId].itemName;
				}
				else if (this.craftingData[this.selection].ingredient[1].itemType == ItType.Equipment)
				{
					text2 = this.itemdb.equipment[this.craftingData[this.selection].ingredient[1].itemId].itemName;
				}
				GUI.Label(new Rect((float)(Screen.width / 2 - 180), 170f, 500f, 100f), text2);
				GUI.Label(new Rect((float)(Screen.width / 2 + 10), 170f, 500f, 100f), this.craftingData[this.selection].ingredient[1].quantity.ToString());
				GUI.Label(new Rect((float)(Screen.width / 2 + 40), 170f, 500f, 100f), "(" + this.itemQty2 + ")");
			}
			if (this.craftingData[this.selection].ingredient.Length >= 3)
			{
				string text3 = string.Empty;
				if (this.craftingData[this.selection].ingredient[2].itemType == ItType.Usable)
				{
					text3 = this.itemdb.usableItem[this.craftingData[this.selection].ingredient[2].itemId].itemName;
				}
				else if (this.craftingData[this.selection].ingredient[2].itemType == ItType.Equipment)
				{
					text3 = this.itemdb.equipment[this.craftingData[this.selection].ingredient[2].itemId].itemName;
				}
				GUI.Label(new Rect((float)(Screen.width / 2 - 180), 190f, 500f, 100f), text3);
				GUI.Label(new Rect((float)(Screen.width / 2 + 10), 190f, 500f, 100f), this.craftingData[this.selection].ingredient[2].quantity.ToString());
				GUI.Label(new Rect((float)(Screen.width / 2 + 40), 190f, 500f, 100f), "(" + this.itemQty3 + ")");
			}
			if (this.craftingData[this.selection].ingredient.Length >= 4)
			{
				string text4 = string.Empty;
				if (this.craftingData[this.selection].ingredient[3].itemType == ItType.Usable)
				{
					text4 = this.itemdb.usableItem[this.craftingData[this.selection].ingredient[3].itemId].itemName;
				}
				else if (this.craftingData[this.selection].ingredient[3].itemType == ItType.Equipment)
				{
					text4 = this.itemdb.equipment[this.craftingData[this.selection].ingredient[3].itemId].itemName;
				}
				GUI.Label(new Rect((float)(Screen.width / 2 - 180), 210f, 500f, 100f), text4);
				GUI.Label(new Rect((float)(Screen.width / 2 + 10), 210f, 500f, 100f), this.craftingData[this.selection].ingredient[3].quantity.ToString());
				GUI.Label(new Rect((float)(Screen.width / 2 + 40), 210f, 500f, 100f), "(" + this.itemQty4 + ")");
			}
			if (this.craftingData[this.selection].ingredient.Length >= 5)
			{
				string text5 = string.Empty;
				if (this.craftingData[this.selection].ingredient[4].itemType == ItType.Usable)
				{
					text5 = this.itemdb.usableItem[this.craftingData[this.selection].ingredient[4].itemId].itemName;
				}
				else if (this.craftingData[this.selection].ingredient[4].itemType == ItType.Equipment)
				{
					text5 = this.itemdb.equipment[this.craftingData[this.selection].ingredient[4].itemId].itemName;
				}
				GUI.Label(new Rect((float)(Screen.width / 2 - 180), 230f, 500f, 100f), text5);
				GUI.Label(new Rect((float)(Screen.width / 2 + 10), 230f, 500f, 100f), this.craftingData[this.selection].ingredient[4].quantity.ToString());
				GUI.Label(new Rect((float)(Screen.width / 2 + 40), 230f, 500f, 100f), "(" + this.itemQty5 + ")");
			}
			if (GUI.Button(new Rect((float)(Screen.width / 2 - 60), 270f, 120f, 50f), "Craft"))
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

	// Token: 0x0600036C RID: 876 RVA: 0x00011D90 File Offset: 0x00010190
	private void ShowItemQuantity()
	{
		if (this.craftingData[this.selection].ingredient[0].itemType == ItType.Usable)
		{
			int num = this.player.GetComponent<InventoryC>().FindItemSlot(this.craftingData[this.selection].ingredient[0].itemId);
			if (num <= this.player.GetComponent<InventoryC>().itemSlot.Length)
			{
				this.itemQty1 = this.player.GetComponent<InventoryC>().itemQuantity[num];
			}
			else
			{
				this.itemQty1 = 0;
			}
		}
		else if (this.craftingData[this.selection].ingredient[0].itemType == ItType.Equipment)
		{
			int num = this.player.GetComponent<InventoryC>().FindEquipmentSlot(this.craftingData[this.selection].ingredient[0].itemId);
			if (num <= this.player.GetComponent<InventoryC>().equipment.Length)
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
				int num = this.player.GetComponent<InventoryC>().FindItemSlot(this.craftingData[this.selection].ingredient[1].itemId);
				if (num <= this.player.GetComponent<InventoryC>().itemSlot.Length)
				{
					this.itemQty2 = this.player.GetComponent<InventoryC>().itemQuantity[num];
				}
				else
				{
					this.itemQty2 = 0;
				}
			}
			else if (this.craftingData[this.selection].ingredient[1].itemType == ItType.Equipment)
			{
				int num = this.player.GetComponent<InventoryC>().FindEquipmentSlot(this.craftingData[this.selection].ingredient[1].itemId);
				if (num <= this.player.GetComponent<InventoryC>().equipment.Length)
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
				int num = this.player.GetComponent<InventoryC>().FindItemSlot(this.craftingData[this.selection].ingredient[2].itemId);
				if (num <= this.player.GetComponent<InventoryC>().itemSlot.Length)
				{
					this.itemQty3 = this.player.GetComponent<InventoryC>().itemQuantity[num];
				}
				else
				{
					this.itemQty3 = 0;
				}
			}
			else if (this.craftingData[this.selection].ingredient[2].itemType == ItType.Equipment)
			{
				int num = this.player.GetComponent<InventoryC>().FindEquipmentSlot(this.craftingData[this.selection].ingredient[2].itemId);
				if (num <= this.player.GetComponent<InventoryC>().equipment.Length)
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
				int num = this.player.GetComponent<InventoryC>().FindItemSlot(this.craftingData[this.selection].ingredient[3].itemId);
				if (num <= this.player.GetComponent<InventoryC>().itemSlot.Length)
				{
					this.itemQty4 = this.player.GetComponent<InventoryC>().itemQuantity[num];
				}
				else
				{
					this.itemQty4 = 0;
				}
			}
			else if (this.craftingData[this.selection].ingredient[3].itemType == ItType.Equipment)
			{
				int num = this.player.GetComponent<InventoryC>().FindEquipmentSlot(this.craftingData[this.selection].ingredient[3].itemId);
				if (num <= this.player.GetComponent<InventoryC>().equipment.Length)
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
				int num = this.player.GetComponent<InventoryC>().FindItemSlot(this.craftingData[this.selection].ingredient[4].itemId);
				if (num <= this.player.GetComponent<InventoryC>().itemSlot.Length)
				{
					this.itemQty5 = this.player.GetComponent<InventoryC>().itemQuantity[num];
				}
				else
				{
					this.itemQty5 = 0;
				}
			}
			else if (this.craftingData[this.selection].ingredient[4].itemType == ItType.Equipment)
			{
				int num = this.player.GetComponent<InventoryC>().FindEquipmentSlot(this.craftingData[this.selection].ingredient[4].itemId);
				if (num <= this.player.GetComponent<InventoryC>().equipment.Length)
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

	// Token: 0x0600036D RID: 877 RVA: 0x000122F8 File Offset: 0x000106F8
	private bool CheckIngredients()
	{
		for (int i = 0; i < this.craftingData[this.selection].ingredient.Length; i++)
		{
			if (!this.player.GetComponent<InventoryC>().CheckItem(this.craftingData[this.selection].ingredient[i].itemId, (int)this.craftingData[this.selection].ingredient[i].itemType, this.craftingData[this.selection].ingredient[i].quantity))
			{
				this.showError = "Not enought items";
				return false;
			}
		}
		return true;
	}

	// Token: 0x0600036E RID: 878 RVA: 0x0001239C File Offset: 0x0001079C
	private void AddandRemoveItem()
	{
		bool flag = false;
		if (this.craftingData[this.selection].gotItem.itemType == ItType.Usable)
		{
			flag = this.player.GetComponent<InventoryC>().AddItem(this.craftingData[this.selection].gotItem.itemId, this.craftingData[this.selection].gotItem.quantity);
		}
		else if (this.craftingData[this.selection].gotItem.itemType == ItType.Equipment)
		{
			flag = this.player.GetComponent<InventoryC>().AddEquipment(this.craftingData[this.selection].gotItem.itemId);
		}
		if (!flag)
		{
			for (int i = 0; i < this.craftingData[this.selection].ingredient.Length; i++)
			{
				if (this.craftingData[this.selection].ingredient[i].itemType == ItType.Usable)
				{
					this.player.GetComponent<InventoryC>().RemoveItem(this.craftingData[this.selection].ingredient[i].itemId, this.craftingData[this.selection].ingredient[i].quantity);
				}
				else if (this.craftingData[this.selection].ingredient[i].itemType == ItType.Equipment)
				{
					this.player.GetComponent<InventoryC>().RemoveEquipment(this.craftingData[this.selection].ingredient[i].itemId);
				}
			}
			this.showError = "You Got " + this.craftingData[this.selection].itemName;
		}
		else
		{
			this.showError = "Inventory Full";
		}
	}

	// Token: 0x0600036F RID: 879 RVA: 0x0001255C File Offset: 0x0001095C
	private void OnOffMenu()
	{
		if (this.uiPage == 0 && Time.timeScale != 0f)
		{
			if (!this.player)
			{
				this.player = GameObject.FindWithTag("Player");
			}
			this.uiPage = 1;
			Time.timeScale = 0f;
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

	// Token: 0x06000370 RID: 880 RVA: 0x000125F0 File Offset: 0x000109F0
	private void OnTriggerEnter(Collider other)
	{
		if (other.gameObject.tag == "Player")
		{
			InventoryC component = other.GetComponent<InventoryC>();
			if (component)
			{
				this.player = other.gameObject;
				this.enter = true;
			}
		}
	}

	// Token: 0x06000371 RID: 881 RVA: 0x0001263C File Offset: 0x00010A3C
	private void OnTriggerExit(Collider other)
	{
		if (other.gameObject == this.player)
		{
			this.enter = false;
		}
	}

	// Token: 0x0400026A RID: 618
	public int[] craftingListId = new int[3];

	// Token: 0x0400026B RID: 619
	private CraftData[] craftingData;

	// Token: 0x0400026C RID: 620
	public GameObject itemDatabase;

	// Token: 0x0400026D RID: 621
	public GameObject craftingDatabase;

	// Token: 0x0400026E RID: 622
	private GameObject player;

	// Token: 0x0400026F RID: 623
	public GUISkin uiSkin;

	// Token: 0x04000270 RID: 624
	public Texture2D button;

	// Token: 0x04000271 RID: 625
	private ItemDataC itemdb;

	// Token: 0x04000272 RID: 626
	private CraftingDataC craftdb;

	// Token: 0x04000273 RID: 627
	private int uiPage;

	// Token: 0x04000274 RID: 628
	private int page;

	// Token: 0x04000275 RID: 629
	private int maxPage = 1;

	// Token: 0x04000276 RID: 630
	private int selection;

	// Token: 0x04000277 RID: 631
	private string showError = string.Empty;

	// Token: 0x04000278 RID: 632
	private bool enter;

	// Token: 0x04000279 RID: 633
	private int itemQty1;

	// Token: 0x0400027A RID: 634
	private int itemQty2;

	// Token: 0x0400027B RID: 635
	private int itemQty3;

	// Token: 0x0400027C RID: 636
	private int itemQty4;

	// Token: 0x0400027D RID: 637
	private int itemQty5;
}
