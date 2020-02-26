using System;
using UnityEngine;

// Token: 0x0200008B RID: 139
public class ShopC : MonoBehaviour
{
	// Token: 0x06000441 RID: 1089 RVA: 0x0001D63C File Offset: 0x0001BA3C
	private void Update()
	{
		if (Input.GetKeyDown("e") && this.enter)
		{
			this.OpenShop();
		}
	}

	// Token: 0x06000442 RID: 1090 RVA: 0x0001D65E File Offset: 0x0001BA5E
	public void OpenShop()
	{
		this.shopMain = true;
		this.OnOffMenu();
	}

	// Token: 0x06000443 RID: 1091 RVA: 0x0001D670 File Offset: 0x0001BA70
	private void ShopBuy(int id, int slot, int price, int quan)
	{
		if (this.player.GetComponent<InventoryC>().cash < price)
		{
			MonoBehaviour.print(price);
			this.buyErrorLog = "Not Enough Cash";
			this.buyerror = true;
			return;
		}
		if (this.shopItem)
		{
			this.full = this.player.GetComponent<InventoryC>().AddItem(id, quan);
			if (this.full)
			{
				this.buyErrorLog = "Inventory Full";
				this.buyerror = true;
				return;
			}
		}
		else
		{
			this.full = this.player.GetComponent<InventoryC>().AddEquipment(id);
			if (this.full)
			{
				this.buyErrorLog = "Inventory Full";
				this.buyerror = true;
				return;
			}
		}
		this.player.GetComponent<InventoryC>().cash -= price;
	}

	// Token: 0x06000444 RID: 1092 RVA: 0x0001D748 File Offset: 0x0001BB48
	private void ShopSell(int id, int slot, int price, int quan)
	{
		if (this.itemInven)
		{
			if (quan >= this.player.GetComponent<InventoryC>().itemQuantity[slot])
			{
				quan = this.player.GetComponent<InventoryC>().itemQuantity[slot];
			}
			this.player.GetComponent<InventoryC>().itemQuantity[slot] -= quan;
			if (this.player.GetComponent<InventoryC>().itemQuantity[slot] <= 0)
			{
				this.player.GetComponent<InventoryC>().itemSlot[slot] = 0;
				this.player.GetComponent<InventoryC>().itemQuantity[slot] = 0;
				this.player.GetComponent<InventoryC>().AutoSortItem();
			}
			this.player.GetComponent<InventoryC>().cash += price * quan;
		}
		else
		{
			this.player.GetComponent<InventoryC>().equipment[slot] = 0;
			this.player.GetComponent<InventoryC>().AutoSortEquipment();
			this.player.GetComponent<InventoryC>().cash += price * quan;
		}
	}

	// Token: 0x06000445 RID: 1093 RVA: 0x0001D858 File Offset: 0x0001BC58
	private void OnGUI()
	{
		if (!this.player)
		{
			return;
		}
		ItemDataC component = this.database.GetComponent<ItemDataC>();
		int[] itemQuantity = this.player.GetComponent<InventoryC>().itemQuantity;
		int cash = this.player.GetComponent<InventoryC>().cash;
		int[] itemSlot = this.player.GetComponent<InventoryC>().itemSlot;
		int[] equipment = this.player.GetComponent<InventoryC>().equipment;
		if (this.enter && !this.menu)
		{
			GUI.DrawTexture(new Rect((float)(Screen.width / 2 - 130), (float)(Screen.height - 120), 260f, 80f), this.button);
		}
		if (this.menu && this.shopMain)
		{
			GUI.Box(new Rect((float)(Screen.width / 2 - 140), 240f, 280f, 120f), "Shop");
			if (GUI.Button(new Rect((float)(Screen.width / 2 - 100), 305f, 80f, 30f), "Buy"))
			{
				this.shopItem = true;
				this.shopMain = false;
			}
			if (GUI.Button(new Rect((float)(Screen.width / 2 + 35), 305f, 80f, 30f), "Sell"))
			{
				this.itemInven = true;
				this.shopMain = false;
			}
			if (GUI.Button(new Rect((float)(Screen.width / 2 + 90), 245f, 30f, 30f), "X"))
			{
				this.OnOffMenu();
			}
		}
		if (this.menu && this.itemInven && !this.sellwindow)
		{
			GUI.Box(new Rect(260f, 140f, 280f, 385f), "Items");
			if (GUI.Button(new Rect(490f, 142f, 30f, 30f), "X"))
			{
				this.OnOffMenu();
			}
			if (GUI.Button(new Rect(290f, 255f, 50f, 50f), new GUIContent(component.usableItem[itemSlot[0]].icon, component.usableItem[itemSlot[0]].itemName + "\n\n" + component.usableItem[itemSlot[0]].description)))
			{
				this.select = 0;
				this.sellwindow = true;
			}
			if (itemQuantity[0] > 0)
			{
				GUI.Label(new Rect(330f, 290f, 20f, 20f), itemQuantity[0].ToString());
			}
			if (GUI.Button(new Rect(350f, 255f, 50f, 50f), new GUIContent(component.usableItem[itemSlot[1]].icon, component.usableItem[itemSlot[1]].itemName + "\n\n" + component.usableItem[itemSlot[1]].description)))
			{
				this.select = 1;
				this.sellwindow = true;
			}
			if (itemQuantity[1] > 0)
			{
				GUI.Label(new Rect(390f, 290f, 20f, 20f), itemQuantity[1].ToString());
			}
			if (GUI.Button(new Rect(410f, 255f, 50f, 50f), new GUIContent(component.usableItem[itemSlot[2]].icon, component.usableItem[itemSlot[2]].itemName + "\n\n" + component.usableItem[itemSlot[2]].description)))
			{
				this.select = 2;
				this.sellwindow = true;
			}
			if (itemQuantity[2] > 0)
			{
				GUI.Label(new Rect(450f, 290f, 20f, 20f), itemQuantity[2].ToString());
			}
			if (GUI.Button(new Rect(470f, 255f, 50f, 50f), new GUIContent(component.usableItem[itemSlot[3]].icon, component.usableItem[itemSlot[3]].itemName + "\n\n" + component.usableItem[itemSlot[3]].description)))
			{
				this.select = 3;
				this.sellwindow = true;
			}
			if (itemQuantity[3] > 0)
			{
				GUI.Label(new Rect(510f, 290f, 20f, 20f), itemQuantity[3].ToString());
			}
			if (GUI.Button(new Rect(290f, 315f, 50f, 50f), new GUIContent(component.usableItem[itemSlot[4]].icon, component.usableItem[itemSlot[4]].itemName + "\n\n" + component.usableItem[itemSlot[4]].description)))
			{
				this.select = 4;
				this.sellwindow = true;
			}
			if (itemQuantity[4] > 0)
			{
				GUI.Label(new Rect(330f, 350f, 20f, 20f), itemQuantity[4].ToString());
			}
			if (GUI.Button(new Rect(350f, 315f, 50f, 50f), new GUIContent(component.usableItem[itemSlot[5]].icon, component.usableItem[itemSlot[5]].itemName + "\n\n" + component.usableItem[itemSlot[5]].description)))
			{
				this.select = 5;
				this.sellwindow = true;
			}
			if (itemQuantity[5] > 0)
			{
				GUI.Label(new Rect(390f, 350f, 20f, 20f), itemQuantity[5].ToString());
			}
			if (GUI.Button(new Rect(410f, 315f, 50f, 50f), new GUIContent(component.usableItem[itemSlot[6]].icon, component.usableItem[itemSlot[6]].itemName + "\n\n" + component.usableItem[itemSlot[6]].description)))
			{
				this.select = 6;
				this.sellwindow = true;
			}
			if (itemQuantity[6] > 0)
			{
				GUI.Label(new Rect(450f, 350f, 20f, 20f), itemQuantity[6].ToString());
			}
			if (GUI.Button(new Rect(470f, 315f, 50f, 50f), new GUIContent(component.usableItem[itemSlot[7]].icon, component.usableItem[itemSlot[7]].itemName + "\n\n" + component.usableItem[itemSlot[7]].description)))
			{
				this.select = 7;
				this.sellwindow = true;
			}
			if (itemQuantity[7] > 0)
			{
				GUI.Label(new Rect(510f, 350f, 20f, 20f), itemQuantity[7].ToString());
			}
			if (GUI.Button(new Rect(290f, 375f, 50f, 50f), new GUIContent(component.usableItem[itemSlot[8]].icon, component.usableItem[itemSlot[8]].itemName + "\n\n" + component.usableItem[itemSlot[8]].description)))
			{
				this.select = 8;
				this.sellwindow = true;
			}
			if (itemQuantity[8] > 0)
			{
				GUI.Label(new Rect(330f, 410f, 20f, 20f), itemQuantity[8].ToString());
			}
			if (GUI.Button(new Rect(350f, 375f, 50f, 50f), new GUIContent(component.usableItem[itemSlot[9]].icon, component.usableItem[itemSlot[9]].itemName + "\n\n" + component.usableItem[itemSlot[9]].description)))
			{
				this.select = 9;
				this.sellwindow = true;
			}
			if (itemQuantity[9] > 0)
			{
				GUI.Label(new Rect(390f, 410f, 20f, 20f), itemQuantity[9].ToString());
			}
			if (GUI.Button(new Rect(410f, 375f, 50f, 50f), new GUIContent(component.usableItem[itemSlot[10]].icon, component.usableItem[itemSlot[10]].itemName + "\n\n" + component.usableItem[itemSlot[10]].description)))
			{
				this.select = 10;
				this.sellwindow = true;
			}
			if (itemQuantity[10] > 0)
			{
				GUI.Label(new Rect(450f, 410f, 20f, 20f), itemQuantity[10].ToString());
			}
			if (GUI.Button(new Rect(470f, 375f, 50f, 50f), new GUIContent(component.usableItem[itemSlot[11]].icon, component.usableItem[itemSlot[11]].itemName + "\n\n" + component.usableItem[itemSlot[11]].description)))
			{
				this.select = 11;
				this.sellwindow = true;
			}
			if (itemQuantity[11] > 0)
			{
				GUI.Label(new Rect(510f, 410f, 20f, 20f), itemQuantity[11].ToString());
			}
			if (GUI.Button(new Rect(290f, 435f, 50f, 50f), new GUIContent(component.usableItem[itemSlot[12]].icon, component.usableItem[itemSlot[12]].itemName + "\n\n" + component.usableItem[itemSlot[12]].description)))
			{
				this.select = 12;
				this.sellwindow = true;
			}
			if (itemQuantity[12] > 0)
			{
				GUI.Label(new Rect(330f, 470f, 20f, 20f), itemQuantity[12].ToString());
			}
			if (GUI.Button(new Rect(350f, 435f, 50f, 50f), new GUIContent(component.usableItem[itemSlot[13]].icon, component.usableItem[itemSlot[13]].itemName + "\n\n" + component.usableItem[itemSlot[13]].description)))
			{
				this.select = 13;
				this.sellwindow = true;
			}
			if (itemQuantity[13] > 0)
			{
				GUI.Label(new Rect(390f, 470f, 20f, 20f), itemQuantity[13].ToString());
			}
			if (GUI.Button(new Rect(410f, 435f, 50f, 50f), new GUIContent(component.usableItem[itemSlot[14]].icon, component.usableItem[itemSlot[14]].itemName + "\n\n" + component.usableItem[itemSlot[14]].description)))
			{
				this.select = 14;
				this.sellwindow = true;
			}
			if (itemQuantity[14] > 0)
			{
				GUI.Label(new Rect(450f, 470f, 20f, 20f), itemQuantity[14].ToString());
			}
			if (GUI.Button(new Rect(470f, 435f, 50f, 50f), new GUIContent(component.usableItem[itemSlot[15]].icon, component.usableItem[itemSlot[15]].itemName + "\n\n" + component.usableItem[itemSlot[15]].description)))
			{
				this.select = 15;
				this.sellwindow = true;
			}
			if (itemQuantity[15] > 0)
			{
				GUI.Label(new Rect(510f, 470f, 20f, 20f), itemQuantity[15].ToString());
			}
			GUI.Box(new Rect(280f, 170f, 240f, 60f), GUI.tooltip);
			GUI.Label(new Rect(280f, 495f, 150f, 50f), "$ " + cash.ToString());
			if (GUI.Button(new Rect(210f, 245f, 50f, 100f), "Item"))
			{
			}
			if (GUI.Button(new Rect(210f, 365f, 50f, 100f), "Equip"))
			{
				this.equipInven = true;
				this.itemInven = false;
			}
		}
		if (this.menu && this.equipInven && !this.sellwindow)
		{
			GUI.Box(new Rect(260f, 140f, 280f, 385f), "Equipment");
			if (GUI.Button(new Rect(490f, 142f, 30f, 30f), "X"))
			{
				this.OnOffMenu();
			}
			if (GUI.Button(new Rect(210f, 245f, 50f, 100f), "Item"))
			{
				this.itemInven = true;
				this.equipInven = false;
			}
			if (GUI.Button(new Rect(210f, 365f, 50f, 100f), "Equip"))
			{
			}
			GUI.Label(new Rect(280f, 495f, 150f, 50f), "$ " + cash.ToString());
			if (GUI.Button(new Rect(290f, 375f, 50f, 50f), new GUIContent(component.equipment[equipment[0]].icon, component.equipment[equipment[0]].itemName + "\n\n" + component.equipment[equipment[0]].description)))
			{
				this.select = 0;
				this.sellwindow = true;
			}
			if (GUI.Button(new Rect(350f, 375f, 50f, 50f), new GUIContent(component.equipment[equipment[1]].icon, component.equipment[equipment[1]].itemName + "\n\n" + component.equipment[equipment[1]].description)))
			{
				this.select = 1;
				this.sellwindow = true;
			}
			if (GUI.Button(new Rect(410f, 375f, 50f, 50f), new GUIContent(component.equipment[equipment[2]].icon, component.equipment[equipment[2]].itemName + "\n\n" + component.equipment[equipment[2]].description)))
			{
				this.select = 2;
				this.sellwindow = true;
			}
			if (GUI.Button(new Rect(470f, 375f, 50f, 50f), new GUIContent(component.equipment[equipment[3]].icon, component.equipment[equipment[3]].itemName + "\n\n" + component.equipment[equipment[3]].description)))
			{
				this.select = 3;
				this.sellwindow = true;
			}
			if (GUI.Button(new Rect(290f, 435f, 50f, 50f), new GUIContent(component.equipment[equipment[4]].icon, component.equipment[equipment[4]].itemName + "\n\n" + component.equipment[equipment[4]].description)))
			{
				this.select = 4;
				this.sellwindow = true;
			}
			if (GUI.Button(new Rect(350f, 435f, 50f, 50f), new GUIContent(component.equipment[equipment[5]].icon, component.equipment[equipment[5]].itemName + "\n\n" + component.equipment[equipment[5]].description)))
			{
				this.select = 5;
				this.sellwindow = true;
			}
			if (GUI.Button(new Rect(410f, 435f, 50f, 50f), new GUIContent(component.equipment[equipment[6]].icon, component.equipment[equipment[6]].itemName + "\n\n" + component.equipment[equipment[6]].description)))
			{
				this.select = 6;
				this.sellwindow = true;
			}
			if (GUI.Button(new Rect(470f, 435f, 50f, 50f), new GUIContent(component.equipment[equipment[7]].icon, component.equipment[equipment[7]].itemName + "\n\n" + component.equipment[equipment[7]].description)))
			{
				this.select = 7;
				this.sellwindow = true;
			}
			GUI.Box(new Rect(280f, 170f, 240f, 60f), GUI.tooltip);
		}
		if (this.sellwindow)
		{
			if (this.itemInven)
			{
				if (itemSlot[this.select] == 0)
				{
					this.sellwindow = false;
				}
				GUI.Box(new Rect((float)(Screen.width / 2 - 140), 230f, 280f, 120f), "Price " + component.usableItem[itemSlot[this.select]].price / 2);
				this.text = GUI.TextField(new Rect((float)(Screen.width / 2 + 5), 250f, 50f, 20f), this.num.ToString(), 2);
				GUI.Label(new Rect((float)(Screen.width / 2 - 65), 250f, 60f, 20f), "Quantity");
				int num = 0;
				if (int.TryParse(this.text, out num))
				{
					this.num = num;
				}
				else if (this.text == string.Empty)
				{
					this.num = 0;
				}
			}
			else
			{
				if (equipment[this.select] == 0)
				{
					this.sellwindow = false;
				}
				GUI.Box(new Rect((float)(Screen.width / 2 - 140), 230f, 280f, 120f), "Price " + component.equipment[equipment[this.select]].price / 2);
			}
			if (GUI.Button(new Rect((float)(Screen.width / 2 - 100), 285f, 80f, 30f), "Sell"))
			{
				if (this.itemInven)
				{
					if (this.num > 0)
					{
						this.ShopSell(itemSlot[this.select], this.select, component.usableItem[itemSlot[this.select]].price / 2, this.num);
						this.sellwindow = false;
					}
				}
				else
				{
					this.ShopSell(equipment[this.select], this.select, component.equipment[equipment[this.select]].price / 2, 1);
					this.sellwindow = false;
				}
			}
			if (GUI.Button(new Rect((float)(Screen.width / 2 + 35), 285f, 80f, 30f), "Cancel"))
			{
				this.sellwindow = false;
			}
		}
		if (this.menu && this.shopItem && !this.buywindow && !this.buyerror)
		{
			GUI.Box(new Rect(260f, 140f, 280f, 285f), "Shop");
			GUI.Label(new Rect(280f, 395f, 150f, 50f), "$ " + cash.ToString());
			if (GUI.Button(new Rect(490f, 142f, 30f, 30f), "X"))
			{
				this.OnOffMenu();
			}
			if (GUI.Button(new Rect(290f, 255f, 50f, 50f), new GUIContent(component.usableItem[this.itemShopSlot[0]].icon, component.usableItem[this.itemShopSlot[0]].itemName + "\n\n" + component.usableItem[this.itemShopSlot[0]].description)))
			{
				this.select = 0;
				this.buywindow = true;
			}
			if (GUI.Button(new Rect(350f, 255f, 50f, 50f), new GUIContent(component.usableItem[this.itemShopSlot[1]].icon, component.usableItem[this.itemShopSlot[1]].itemName + "\n\n" + component.usableItem[this.itemShopSlot[1]].description)))
			{
				this.select = 1;
				this.buywindow = true;
			}
			if (GUI.Button(new Rect(410f, 255f, 50f, 50f), new GUIContent(component.usableItem[this.itemShopSlot[2]].icon, component.usableItem[this.itemShopSlot[2]].itemName + "\n\n" + component.usableItem[this.itemShopSlot[2]].description)))
			{
				this.select = 2;
				this.buywindow = true;
			}
			if (GUI.Button(new Rect(470f, 255f, 50f, 50f), new GUIContent(component.usableItem[this.itemShopSlot[3]].icon, component.usableItem[this.itemShopSlot[3]].itemName + "\n\n" + component.usableItem[this.itemShopSlot[3]].description)))
			{
				this.select = 3;
				this.buywindow = true;
			}
			if (GUI.Button(new Rect(290f, 315f, 50f, 50f), new GUIContent(component.usableItem[this.itemShopSlot[4]].icon, component.usableItem[this.itemShopSlot[4]].itemName + "\n\n" + component.usableItem[this.itemShopSlot[4]].description)))
			{
				this.select = 4;
				this.buywindow = true;
			}
			if (GUI.Button(new Rect(350f, 315f, 50f, 50f), new GUIContent(component.usableItem[this.itemShopSlot[5]].icon, component.usableItem[this.itemShopSlot[5]].itemName + "\n\n" + component.usableItem[this.itemShopSlot[5]].description)))
			{
				this.select = 5;
				this.buywindow = true;
			}
			if (GUI.Button(new Rect(410f, 315f, 50f, 50f), new GUIContent(component.usableItem[this.itemShopSlot[6]].icon, component.usableItem[this.itemShopSlot[6]].itemName + "\n\n" + component.usableItem[this.itemShopSlot[6]].description)))
			{
				this.select = 6;
				this.buywindow = true;
			}
			if (GUI.Button(new Rect(470f, 315f, 50f, 50f), new GUIContent(component.usableItem[this.itemShopSlot[7]].icon, component.usableItem[this.itemShopSlot[7]].itemName + "\n\n" + component.usableItem[this.itemShopSlot[7]].description)))
			{
				this.select = 7;
				this.buywindow = true;
			}
			GUI.Box(new Rect(280f, 170f, 240f, 60f), GUI.tooltip);
			if (GUI.Button(new Rect(210f, 245f, 50f, 75f), "Item"))
			{
			}
			if (GUI.Button(new Rect(210f, 320f, 50f, 75f), "Equip"))
			{
				this.shopEquip = true;
				this.shopItem = false;
			}
		}
		if (this.menu && this.shopEquip && !this.buywindow && !this.buyerror)
		{
			GUI.Box(new Rect(260f, 140f, 280f, 285f), "Shop");
			GUI.Label(new Rect(280f, 395f, 150f, 50f), "$ " + cash.ToString());
			if (GUI.Button(new Rect(490f, 142f, 30f, 30f), "X"))
			{
				this.OnOffMenu();
			}
			if (GUI.Button(new Rect(290f, 255f, 50f, 50f), new GUIContent(component.equipment[this.equipmentShopSlot[0]].icon, component.equipment[this.equipmentShopSlot[0]].itemName + "\n\n" + component.equipment[this.equipmentShopSlot[0]].description)))
			{
				this.select = 0;
				this.buywindow = true;
			}
			if (GUI.Button(new Rect(350f, 255f, 50f, 50f), new GUIContent(component.equipment[this.equipmentShopSlot[1]].icon, component.equipment[this.equipmentShopSlot[1]].itemName + "\n\n" + component.equipment[this.equipmentShopSlot[1]].description)))
			{
				this.select = 1;
				this.buywindow = true;
			}
			if (GUI.Button(new Rect(410f, 255f, 50f, 50f), new GUIContent(component.equipment[this.equipmentShopSlot[2]].icon, component.equipment[this.equipmentShopSlot[2]].itemName + "\n\n" + component.equipment[this.equipmentShopSlot[2]].description)))
			{
				this.select = 2;
				this.buywindow = true;
			}
			if (GUI.Button(new Rect(470f, 255f, 50f, 50f), new GUIContent(component.equipment[this.equipmentShopSlot[3]].icon, component.equipment[this.equipmentShopSlot[3]].itemName + "\n\n" + component.equipment[this.equipmentShopSlot[3]].description)))
			{
				this.select = 3;
				this.buywindow = true;
			}
			if (GUI.Button(new Rect(290f, 315f, 50f, 50f), new GUIContent(component.equipment[this.equipmentShopSlot[4]].icon, component.equipment[this.equipmentShopSlot[4]].itemName + "\n\n" + component.equipment[this.equipmentShopSlot[4]].description)))
			{
				this.select = 4;
				this.buywindow = true;
			}
			if (GUI.Button(new Rect(350f, 315f, 50f, 50f), new GUIContent(component.equipment[this.equipmentShopSlot[5]].icon, component.equipment[this.equipmentShopSlot[5]].itemName + "\n\n" + component.equipment[this.equipmentShopSlot[5]].description)))
			{
				this.select = 5;
				this.buywindow = true;
			}
			if (GUI.Button(new Rect(410f, 315f, 50f, 50f), new GUIContent(component.equipment[this.equipmentShopSlot[6]].icon, component.equipment[this.equipmentShopSlot[6]].itemName + "\n\n" + component.equipment[this.equipmentShopSlot[6]].description)))
			{
				this.select = 6;
				this.buywindow = true;
			}
			if (GUI.Button(new Rect(470f, 315f, 50f, 50f), new GUIContent(component.equipment[this.equipmentShopSlot[7]].icon, component.equipment[this.equipmentShopSlot[7]].itemName + "\n\n" + component.equipment[this.equipmentShopSlot[7]].description)))
			{
				this.select = 7;
				this.buywindow = true;
			}
			GUI.Box(new Rect(280f, 170f, 240f, 60f), GUI.tooltip);
			if (GUI.Button(new Rect(210f, 245f, 50f, 75f), "Item"))
			{
				this.shopItem = true;
				this.shopEquip = false;
			}
			if (GUI.Button(new Rect(210f, 320f, 50f, 75f), "Equip"))
			{
			}
		}
		if (this.buywindow)
		{
			if (this.shopItem)
			{
				if (this.itemShopSlot[this.select] == 0)
				{
					this.buywindow = false;
				}
				GUI.Box(new Rect((float)(Screen.width / 2 - 140), 230f, 280f, 120f), "Price " + component.usableItem[this.itemShopSlot[this.select]].price);
				this.text = GUI.TextField(new Rect((float)(Screen.width / 2 + 5), 250f, 50f, 20f), this.num.ToString(), 2);
				GUI.Label(new Rect((float)(Screen.width / 2 - 65), 250f, 60f, 20f), "Quantity");
				int num2 = 0;
				if (int.TryParse(this.text, out num2))
				{
					this.num = num2;
				}
				else if (this.text == string.Empty)
				{
					this.num = 0;
				}
			}
			else
			{
				if (this.equipmentShopSlot[this.select] == 0)
				{
					this.buywindow = false;
				}
				GUI.Box(new Rect((float)(Screen.width / 2 - 140), 230f, 280f, 120f), "Price " + component.equipment[this.equipmentShopSlot[this.select]].price);
			}
			if (GUI.Button(new Rect((float)(Screen.width / 2 - 100), 285f, 80f, 30f), "Buy"))
			{
				if (this.shopItem)
				{
					if (this.num > 0)
					{
						this.ShopBuy(this.itemShopSlot[this.select], this.select, component.usableItem[this.itemShopSlot[this.select]].price * this.num, this.num);
						this.buywindow = false;
					}
				}
				else
				{
					this.ShopBuy(this.equipmentShopSlot[this.select], this.select, component.equipment[this.equipmentShopSlot[this.select]].price, 1);
					this.buywindow = false;
				}
			}
			if (GUI.Button(new Rect((float)(Screen.width / 2 + 35), 285f, 80f, 30f), "Cancel"))
			{
				this.buywindow = false;
			}
		}
		if (this.buyerror)
		{
			GUI.Box(new Rect((float)(Screen.width / 2 - 140), 230f, 280f, 120f), this.buyErrorLog);
			if (GUI.Button(new Rect((float)(Screen.width / 2 - 40), 285f, 80f, 30f), "OK"))
			{
				this.buyerror = false;
			}
		}
	}

	// Token: 0x06000446 RID: 1094 RVA: 0x0001F9DE File Offset: 0x0001DDDE
	private void OnTriggerEnter(Collider other)
	{
		if (other.gameObject.tag == "Player")
		{
			this.player = other.gameObject;
			this.enter = true;
		}
	}

	// Token: 0x06000447 RID: 1095 RVA: 0x0001FA0D File Offset: 0x0001DE0D
	private void OnTriggerExit(Collider other)
	{
		if (other.gameObject.tag == "Player")
		{
			this.enter = false;
		}
	}

	// Token: 0x06000448 RID: 1096 RVA: 0x0001FA30 File Offset: 0x0001DE30
	private void OnOffMenu()
	{
		if (!this.menu && Time.timeScale != 0f)
		{
			this.menu = true;
			this.itemInven = false;
			this.shopItem = false;
			this.shopEquip = false;
			this.equipInven = false;
			this.sellwindow = false;
			this.buywindow = false;
			this.buyerror = false;
			Screen.lockCursor = false;
			Time.timeScale = 0f;
		}
		else if (this.menu)
		{
			this.menu = false;
			Screen.lockCursor = true;
			Time.timeScale = 1f;
		}
	}

	// Token: 0x04000401 RID: 1025
	public int[] itemShopSlot = new int[8];

	// Token: 0x04000402 RID: 1026
	public int[] equipmentShopSlot = new int[8];

	// Token: 0x04000403 RID: 1027
	public Texture2D button;

	// Token: 0x04000404 RID: 1028
	public GameObject database;

	// Token: 0x04000405 RID: 1029
	private GameObject player;

	// Token: 0x04000406 RID: 1030
	private bool menu;

	// Token: 0x04000407 RID: 1031
	private bool shopMain;

	// Token: 0x04000408 RID: 1032
	private bool shopItem;

	// Token: 0x04000409 RID: 1033
	private bool shopEquip;

	// Token: 0x0400040A RID: 1034
	private bool itemInven;

	// Token: 0x0400040B RID: 1035
	private bool equipInven;

	// Token: 0x0400040C RID: 1036
	private bool sellwindow;

	// Token: 0x0400040D RID: 1037
	private bool buywindow;

	// Token: 0x0400040E RID: 1038
	private bool buyerror;

	// Token: 0x0400040F RID: 1039
	private string buyErrorLog = "Not Enough Cash";

	// Token: 0x04000410 RID: 1040
	private bool enter;

	// Token: 0x04000411 RID: 1041
	private int select;

	// Token: 0x04000412 RID: 1042
	private bool full;

	// Token: 0x04000413 RID: 1043
	private int num = 1;

	// Token: 0x04000414 RID: 1044
	private string text = "1";
}
