using System;
using UnityEngine;

// Token: 0x02000082 RID: 130
[AddComponentMenu("Action-RPG Kit/Shop")]
[Serializable]
public class Shop : MonoBehaviour
{
	// Token: 0x060001BC RID: 444 RVA: 0x00015274 File Offset: 0x00013474
	public Shop()
	{
		this.itemShopSlot = new int[8];
		this.equipmentShopSlot = new int[8];
		this.buyErrorLog = "Not Enough Cash";
		this.num = 1;
		this.text = "1";
	}

	// Token: 0x060001BD RID: 445 RVA: 0x000152B4 File Offset: 0x000134B4
	public virtual void Update()
	{
		if (Input.GetKeyDown("e") && this.enter)
		{
			this.OpenShop();
		}
	}

	// Token: 0x060001BE RID: 446 RVA: 0x000152E4 File Offset: 0x000134E4
	public virtual void OpenShop()
	{
		this.shopMain = true;
		this.OnOffMenu();
	}

	// Token: 0x060001BF RID: 447 RVA: 0x000152F4 File Offset: 0x000134F4
	public virtual void ShopBuy(int id, int slot, int price, int quan)
	{
		ItemData itemData = (ItemData)this.database.GetComponent(typeof(ItemData));
		if (((Inventory)this.player.GetComponent(typeof(Inventory))).cash < price)
		{
			MonoBehaviour.print(price);
			this.buyErrorLog = "Not Enough Cash";
			this.buyerror = true;
		}
		else
		{
			if (this.shopItem)
			{
				bool flag = ((Inventory)this.player.GetComponent(typeof(Inventory))).AddItem(id, quan);
				if (flag)
				{
					this.buyErrorLog = "Inventory Full";
					this.buyerror = true;
					return;
				}
			}
			else
			{
				bool flag = ((Inventory)this.player.GetComponent(typeof(Inventory))).AddEquipment(id);
				if (flag)
				{
					this.buyErrorLog = "Inventory Full";
					this.buyerror = true;
					return;
				}
			}
			((Inventory)this.player.GetComponent(typeof(Inventory))).cash = ((Inventory)this.player.GetComponent(typeof(Inventory))).cash - price;
		}
	}

	// Token: 0x060001C0 RID: 448 RVA: 0x00015434 File Offset: 0x00013634
	public virtual void ShopSell(int id, int slot, int price, int quan)
	{
		ItemData itemData = (ItemData)this.database.GetComponent(typeof(ItemData));
		if (this.itemInven)
		{
			if (quan >= ((Inventory)this.player.GetComponent(typeof(Inventory))).itemQuantity[slot])
			{
				quan = ((Inventory)this.player.GetComponent(typeof(Inventory))).itemQuantity[slot];
			}
			((Inventory)this.player.GetComponent(typeof(Inventory))).itemQuantity[slot] = ((Inventory)this.player.GetComponent(typeof(Inventory))).itemQuantity[slot] - quan;
			if (((Inventory)this.player.GetComponent(typeof(Inventory))).itemQuantity[slot] <= 0)
			{
				((Inventory)this.player.GetComponent(typeof(Inventory))).itemSlot[slot] = 0;
				((Inventory)this.player.GetComponent(typeof(Inventory))).itemQuantity[slot] = 0;
				((Inventory)this.player.GetComponent(typeof(Inventory))).AutoSortItem();
			}
			((Inventory)this.player.GetComponent(typeof(Inventory))).cash = ((Inventory)this.player.GetComponent(typeof(Inventory))).cash + price * quan;
		}
		else
		{
			((Inventory)this.player.GetComponent(typeof(Inventory))).equipment[slot] = 0;
			((Inventory)this.player.GetComponent(typeof(Inventory))).AutoSortEquipment();
			((Inventory)this.player.GetComponent(typeof(Inventory))).cash = ((Inventory)this.player.GetComponent(typeof(Inventory))).cash + price * quan;
		}
	}

	// Token: 0x060001C1 RID: 449 RVA: 0x00015660 File Offset: 0x00013860
	public virtual void OnGUI()
	{
		if (this.player)
		{
			ItemData itemData = (ItemData)this.database.GetComponent(typeof(ItemData));
			int[] itemQuantity = ((Inventory)this.player.GetComponent(typeof(Inventory))).itemQuantity;
			int cash = ((Inventory)this.player.GetComponent(typeof(Inventory))).cash;
			int[] itemSlot = ((Inventory)this.player.GetComponent(typeof(Inventory))).itemSlot;
			int[] equipment = ((Inventory)this.player.GetComponent(typeof(Inventory))).equipment;
			GUI.skin = this.skin1;
			if (this.enter && !this.menu)
			{
				GUI.DrawTexture(new Rect((float)(Screen.width / 2 - 130), (float)(Screen.height - 120), (float)260, (float)80), this.button);
			}
			if (this.menu && this.shopMain)
			{
				GUI.Box(new Rect((float)(Screen.width / 2 - 140), (float)180, (float)280, (float)120), string.Empty);
				if (GUI.Button(new Rect((float)(Screen.width / 2 - 100), (float)245, (float)80, (float)30), "Buy"))
				{
					this.shopItem = true;
					this.shopMain = false;
				}
				if (GUI.Button(new Rect((float)(Screen.width / 2 + 35), (float)245, (float)80, (float)30), "Sell"))
				{
					this.itemInven = true;
					this.shopMain = false;
				}
				if (GUI.Button(new Rect((float)(Screen.width / 2 + 90), (float)200, (float)30, (float)30), "X"))
				{
					this.OnOffMenu();
				}
			}
			if (this.menu && this.itemInven && !this.sellwindow)
			{
				GUI.Box(new Rect((float)260, (float)140, (float)280, (float)385), "Items");
				if (GUI.Button(new Rect((float)490, (float)142, (float)30, (float)30), "X"))
				{
					this.OnOffMenu();
				}
				if (GUI.Button(new Rect((float)290, (float)255, (float)50, (float)50), new GUIContent(itemData.usableItem[itemSlot[0]].icon, itemData.usableItem[itemSlot[0]].itemName + "\n" + "\n" + itemData.usableItem[itemSlot[0]].description)))
				{
					this.select = 0;
					this.sellwindow = true;
				}
				if (itemQuantity[0] > 0)
				{
					GUI.Label(new Rect((float)330, (float)290, (float)20, (float)20), itemQuantity[0].ToString());
				}
				if (GUI.Button(new Rect((float)350, (float)255, (float)50, (float)50), new GUIContent(itemData.usableItem[itemSlot[1]].icon, itemData.usableItem[itemSlot[1]].itemName + "\n" + "\n" + itemData.usableItem[itemSlot[1]].description)))
				{
					this.select = 1;
					this.sellwindow = true;
				}
				if (itemQuantity[1] > 0)
				{
					GUI.Label(new Rect((float)390, (float)290, (float)20, (float)20), itemQuantity[1].ToString());
				}
				if (GUI.Button(new Rect((float)410, (float)255, (float)50, (float)50), new GUIContent(itemData.usableItem[itemSlot[2]].icon, itemData.usableItem[itemSlot[2]].itemName + "\n" + "\n" + itemData.usableItem[itemSlot[2]].description)))
				{
					this.select = 2;
					this.sellwindow = true;
				}
				if (itemQuantity[2] > 0)
				{
					GUI.Label(new Rect((float)450, (float)290, (float)20, (float)20), itemQuantity[2].ToString());
				}
				if (GUI.Button(new Rect((float)470, (float)255, (float)50, (float)50), new GUIContent(itemData.usableItem[itemSlot[3]].icon, itemData.usableItem[itemSlot[3]].itemName + "\n" + "\n" + itemData.usableItem[itemSlot[3]].description)))
				{
					this.select = 3;
					this.sellwindow = true;
				}
				if (itemQuantity[3] > 0)
				{
					GUI.Label(new Rect((float)510, (float)290, (float)20, (float)20), itemQuantity[3].ToString());
				}
				if (GUI.Button(new Rect((float)290, (float)315, (float)50, (float)50), new GUIContent(itemData.usableItem[itemSlot[4]].icon, itemData.usableItem[itemSlot[4]].itemName + "\n" + "\n" + itemData.usableItem[itemSlot[4]].description)))
				{
					this.select = 4;
					this.sellwindow = true;
				}
				if (itemQuantity[4] > 0)
				{
					GUI.Label(new Rect((float)330, (float)350, (float)20, (float)20), itemQuantity[4].ToString());
				}
				if (GUI.Button(new Rect((float)350, (float)315, (float)50, (float)50), new GUIContent(itemData.usableItem[itemSlot[5]].icon, itemData.usableItem[itemSlot[5]].itemName + "\n" + "\n" + itemData.usableItem[itemSlot[5]].description)))
				{
					this.select = 5;
					this.sellwindow = true;
				}
				if (itemQuantity[5] > 0)
				{
					GUI.Label(new Rect((float)390, (float)350, (float)20, (float)20), itemQuantity[5].ToString());
				}
				if (GUI.Button(new Rect((float)410, (float)315, (float)50, (float)50), new GUIContent(itemData.usableItem[itemSlot[6]].icon, itemData.usableItem[itemSlot[6]].itemName + "\n" + "\n" + itemData.usableItem[itemSlot[6]].description)))
				{
					this.select = 6;
					this.sellwindow = true;
				}
				if (itemQuantity[6] > 0)
				{
					GUI.Label(new Rect((float)450, (float)350, (float)20, (float)20), itemQuantity[6].ToString());
				}
				if (GUI.Button(new Rect((float)470, (float)315, (float)50, (float)50), new GUIContent(itemData.usableItem[itemSlot[7]].icon, itemData.usableItem[itemSlot[7]].itemName + "\n" + "\n" + itemData.usableItem[itemSlot[7]].description)))
				{
					this.select = 7;
					this.sellwindow = true;
				}
				if (itemQuantity[7] > 0)
				{
					GUI.Label(new Rect((float)510, (float)350, (float)20, (float)20), itemQuantity[7].ToString());
				}
				if (GUI.Button(new Rect((float)290, (float)375, (float)50, (float)50), new GUIContent(itemData.usableItem[itemSlot[8]].icon, itemData.usableItem[itemSlot[8]].itemName + "\n" + "\n" + itemData.usableItem[itemSlot[8]].description)))
				{
					this.select = 8;
					this.sellwindow = true;
				}
				if (itemQuantity[8] > 0)
				{
					GUI.Label(new Rect((float)330, (float)410, (float)20, (float)20), itemQuantity[8].ToString());
				}
				if (GUI.Button(new Rect((float)350, (float)375, (float)50, (float)50), new GUIContent(itemData.usableItem[itemSlot[9]].icon, itemData.usableItem[itemSlot[9]].itemName + "\n" + "\n" + itemData.usableItem[itemSlot[9]].description)))
				{
					this.select = 9;
					this.sellwindow = true;
				}
				if (itemQuantity[9] > 0)
				{
					GUI.Label(new Rect((float)390, (float)410, (float)20, (float)20), itemQuantity[9].ToString());
				}
				if (GUI.Button(new Rect((float)410, (float)375, (float)50, (float)50), new GUIContent(itemData.usableItem[itemSlot[10]].icon, itemData.usableItem[itemSlot[10]].itemName + "\n" + "\n" + itemData.usableItem[itemSlot[10]].description)))
				{
					this.select = 10;
					this.sellwindow = true;
				}
				if (itemQuantity[10] > 0)
				{
					GUI.Label(new Rect((float)450, (float)410, (float)20, (float)20), itemQuantity[10].ToString());
				}
				if (GUI.Button(new Rect((float)470, (float)375, (float)50, (float)50), new GUIContent(itemData.usableItem[itemSlot[11]].icon, itemData.usableItem[itemSlot[11]].itemName + "\n" + "\n" + itemData.usableItem[itemSlot[11]].description)))
				{
					this.select = 11;
					this.sellwindow = true;
				}
				if (itemQuantity[11] > 0)
				{
					GUI.Label(new Rect((float)510, (float)410, (float)20, (float)20), itemQuantity[11].ToString());
				}
				if (GUI.Button(new Rect((float)290, (float)435, (float)50, (float)50), new GUIContent(itemData.usableItem[itemSlot[12]].icon, itemData.usableItem[itemSlot[12]].itemName + "\n" + "\n" + itemData.usableItem[itemSlot[12]].description)))
				{
					this.select = 12;
					this.sellwindow = true;
				}
				if (itemQuantity[12] > 0)
				{
					GUI.Label(new Rect((float)330, (float)470, (float)20, (float)20), itemQuantity[12].ToString());
				}
				if (GUI.Button(new Rect((float)350, (float)435, (float)50, (float)50), new GUIContent(itemData.usableItem[itemSlot[13]].icon, itemData.usableItem[itemSlot[13]].itemName + "\n" + "\n" + itemData.usableItem[itemSlot[13]].description)))
				{
					this.select = 13;
					this.sellwindow = true;
				}
				if (itemQuantity[13] > 0)
				{
					GUI.Label(new Rect((float)390, (float)470, (float)20, (float)20), itemQuantity[13].ToString());
				}
				if (GUI.Button(new Rect((float)410, (float)435, (float)50, (float)50), new GUIContent(itemData.usableItem[itemSlot[14]].icon, itemData.usableItem[itemSlot[14]].itemName + "\n" + "\n" + itemData.usableItem[itemSlot[14]].description)))
				{
					this.select = 14;
					this.sellwindow = true;
				}
				if (itemQuantity[14] > 0)
				{
					GUI.Label(new Rect((float)450, (float)470, (float)20, (float)20), itemQuantity[14].ToString());
				}
				if (GUI.Button(new Rect((float)470, (float)435, (float)50, (float)50), new GUIContent(itemData.usableItem[itemSlot[15]].icon, itemData.usableItem[itemSlot[15]].itemName + "\n" + "\n" + itemData.usableItem[itemSlot[15]].description)))
				{
					this.select = 15;
					this.sellwindow = true;
				}
				if (itemQuantity[15] > 0)
				{
					GUI.Label(new Rect((float)510, (float)470, (float)20, (float)20), itemQuantity[15].ToString());
				}
				GUI.Box(new Rect((float)280, (float)170, (float)240, (float)60), GUI.tooltip);
				GUI.Label(new Rect((float)280, (float)495, (float)150, (float)50), "$ " + cash.ToString());
				if (GUI.Button(new Rect((float)210, (float)245, (float)50, (float)100), "Item"))
				{
				}
				if (GUI.Button(new Rect((float)210, (float)365, (float)50, (float)100), "Equip"))
				{
					this.equipInven = true;
					this.itemInven = false;
				}
			}
			if (this.menu && this.equipInven && !this.sellwindow)
			{
				GUI.Box(new Rect((float)260, (float)140, (float)280, (float)385), "Equipment");
				if (GUI.Button(new Rect((float)490, (float)142, (float)30, (float)30), "X"))
				{
					this.OnOffMenu();
				}
				if (GUI.Button(new Rect((float)210, (float)245, (float)50, (float)100), "Item"))
				{
					this.itemInven = true;
					this.equipInven = false;
				}
				if (GUI.Button(new Rect((float)210, (float)365, (float)50, (float)100), "Equip"))
				{
				}
				GUI.Label(new Rect((float)280, (float)495, (float)150, (float)50), "$ " + cash.ToString());
				if (GUI.Button(new Rect((float)290, (float)375, (float)50, (float)50), new GUIContent(itemData.equipment[equipment[0]].icon, itemData.equipment[equipment[0]].itemName + "\n" + "\n" + itemData.equipment[equipment[0]].description)))
				{
					this.select = 0;
					this.sellwindow = true;
				}
				if (GUI.Button(new Rect((float)350, (float)375, (float)50, (float)50), new GUIContent(itemData.equipment[equipment[1]].icon, itemData.equipment[equipment[1]].itemName + "\n" + "\n" + itemData.equipment[equipment[1]].description)))
				{
					this.select = 1;
					this.sellwindow = true;
				}
				if (GUI.Button(new Rect((float)410, (float)375, (float)50, (float)50), new GUIContent(itemData.equipment[equipment[2]].icon, itemData.equipment[equipment[2]].itemName + "\n" + "\n" + itemData.equipment[equipment[2]].description)))
				{
					this.select = 2;
					this.sellwindow = true;
				}
				if (GUI.Button(new Rect((float)470, (float)375, (float)50, (float)50), new GUIContent(itemData.equipment[equipment[3]].icon, itemData.equipment[equipment[3]].itemName + "\n" + "\n" + itemData.equipment[equipment[3]].description)))
				{
					this.select = 3;
					this.sellwindow = true;
				}
				if (GUI.Button(new Rect((float)290, (float)435, (float)50, (float)50), new GUIContent(itemData.equipment[equipment[4]].icon, itemData.equipment[equipment[4]].itemName + "\n" + "\n" + itemData.equipment[equipment[4]].description)))
				{
					this.select = 4;
					this.sellwindow = true;
				}
				if (GUI.Button(new Rect((float)350, (float)435, (float)50, (float)50), new GUIContent(itemData.equipment[equipment[5]].icon, itemData.equipment[equipment[5]].itemName + "\n" + "\n" + itemData.equipment[equipment[5]].description)))
				{
					this.select = 5;
					this.sellwindow = true;
				}
				if (GUI.Button(new Rect((float)410, (float)435, (float)50, (float)50), new GUIContent(itemData.equipment[equipment[6]].icon, itemData.equipment[equipment[6]].itemName + "\n" + "\n" + itemData.equipment[equipment[6]].description)))
				{
					this.select = 6;
					this.sellwindow = true;
				}
				if (GUI.Button(new Rect((float)470, (float)435, (float)50, (float)50), new GUIContent(itemData.equipment[equipment[7]].icon, itemData.equipment[equipment[7]].itemName + "\n" + "\n" + itemData.equipment[equipment[7]].description)))
				{
					this.select = 7;
					this.sellwindow = true;
				}
				GUI.Box(new Rect((float)280, (float)170, (float)240, (float)60), GUI.tooltip);
			}
			if (this.sellwindow)
			{
				if (this.itemInven)
				{
					if (itemSlot[this.select] == 0)
					{
						this.sellwindow = false;
					}
					GUI.Box(new Rect((float)(Screen.width / 2 - 140), (float)230, (float)280, (float)120), "Price " + itemData.usableItem[itemSlot[this.select]].price / 2);
					this.text = GUI.TextField(new Rect((float)(Screen.width / 2 + 5), (float)250, (float)50, (float)20), this.num.ToString(), 2);
					GUI.Label(new Rect((float)(Screen.width / 2 - 65), (float)250, (float)60, (float)20), "Quantity");
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
					GUI.Box(new Rect((float)(Screen.width / 2 - 140), (float)230, (float)280, (float)120), "Price " + itemData.equipment[equipment[this.select]].price / 2);
				}
				if (GUI.Button(new Rect((float)(Screen.width / 2 - 100), (float)285, (float)80, (float)30), "Sell"))
				{
					if (this.itemInven)
					{
						if (this.num > 0)
						{
							this.ShopSell(itemSlot[this.select], this.select, itemData.usableItem[itemSlot[this.select]].price / 2, this.num);
							this.sellwindow = false;
						}
					}
					else
					{
						this.ShopSell(equipment[this.select], this.select, itemData.equipment[equipment[this.select]].price / 2, 1);
						this.sellwindow = false;
					}
				}
				if (GUI.Button(new Rect((float)(Screen.width / 2 + 35), (float)285, (float)80, (float)30), "Cancel"))
				{
					this.sellwindow = false;
				}
			}
			if (this.menu && this.shopItem && !this.buywindow && !this.buyerror)
			{
				GUI.Box(new Rect((float)260, (float)140, (float)280, (float)285), "Shop");
				GUI.Label(new Rect((float)280, (float)395, (float)150, (float)50), "$ " + cash.ToString());
				if (GUI.Button(new Rect((float)490, (float)142, (float)30, (float)30), "X"))
				{
					this.OnOffMenu();
				}
				if (GUI.Button(new Rect((float)290, (float)255, (float)50, (float)50), new GUIContent(itemData.usableItem[this.itemShopSlot[0]].icon, itemData.usableItem[this.itemShopSlot[0]].itemName + "\n" + "\n" + itemData.usableItem[this.itemShopSlot[0]].description)))
				{
					this.select = 0;
					this.buywindow = true;
				}
				if (GUI.Button(new Rect((float)350, (float)255, (float)50, (float)50), new GUIContent(itemData.usableItem[this.itemShopSlot[1]].icon, itemData.usableItem[this.itemShopSlot[1]].itemName + "\n" + "\n" + itemData.usableItem[this.itemShopSlot[1]].description)))
				{
					this.select = 1;
					this.buywindow = true;
				}
				if (GUI.Button(new Rect((float)410, (float)255, (float)50, (float)50), new GUIContent(itemData.usableItem[this.itemShopSlot[2]].icon, itemData.usableItem[this.itemShopSlot[2]].itemName + "\n" + "\n" + itemData.usableItem[this.itemShopSlot[2]].description)))
				{
					this.select = 2;
					this.buywindow = true;
				}
				if (GUI.Button(new Rect((float)470, (float)255, (float)50, (float)50), new GUIContent(itemData.usableItem[this.itemShopSlot[3]].icon, itemData.usableItem[this.itemShopSlot[3]].itemName + "\n" + "\n" + itemData.usableItem[this.itemShopSlot[3]].description)))
				{
					this.select = 3;
					this.buywindow = true;
				}
				if (GUI.Button(new Rect((float)290, (float)315, (float)50, (float)50), new GUIContent(itemData.usableItem[this.itemShopSlot[4]].icon, itemData.usableItem[this.itemShopSlot[4]].itemName + "\n" + "\n" + itemData.usableItem[this.itemShopSlot[4]].description)))
				{
					this.select = 4;
					this.buywindow = true;
				}
				if (GUI.Button(new Rect((float)350, (float)315, (float)50, (float)50), new GUIContent(itemData.usableItem[this.itemShopSlot[5]].icon, itemData.usableItem[this.itemShopSlot[5]].itemName + "\n" + "\n" + itemData.usableItem[this.itemShopSlot[5]].description)))
				{
					this.select = 5;
					this.buywindow = true;
				}
				if (GUI.Button(new Rect((float)410, (float)315, (float)50, (float)50), new GUIContent(itemData.usableItem[this.itemShopSlot[6]].icon, itemData.usableItem[this.itemShopSlot[6]].itemName + "\n" + "\n" + itemData.usableItem[this.itemShopSlot[6]].description)))
				{
					this.select = 6;
					this.buywindow = true;
				}
				if (GUI.Button(new Rect((float)470, (float)315, (float)50, (float)50), new GUIContent(itemData.usableItem[this.itemShopSlot[7]].icon, itemData.usableItem[this.itemShopSlot[7]].itemName + "\n" + "\n" + itemData.usableItem[this.itemShopSlot[7]].description)))
				{
					this.select = 7;
					this.buywindow = true;
				}
				GUI.Box(new Rect((float)280, (float)170, (float)240, (float)60), GUI.tooltip);
				if (GUI.Button(new Rect((float)210, (float)245, (float)50, (float)75), "Item"))
				{
				}
				if (GUI.Button(new Rect((float)210, (float)320, (float)50, (float)75), "Equip"))
				{
					this.shopEquip = true;
					this.shopItem = false;
				}
			}
			if (this.menu && this.shopEquip && !this.buywindow && !this.buyerror)
			{
				GUI.Box(new Rect((float)260, (float)140, (float)280, (float)285), "Shop");
				GUI.Label(new Rect((float)280, (float)395, (float)150, (float)50), "$ " + cash.ToString());
				if (GUI.Button(new Rect((float)490, (float)142, (float)30, (float)30), "X"))
				{
					this.OnOffMenu();
				}
				if (GUI.Button(new Rect((float)290, (float)255, (float)50, (float)50), new GUIContent(itemData.equipment[this.equipmentShopSlot[0]].icon, itemData.equipment[this.equipmentShopSlot[0]].itemName + "\n" + "\n" + itemData.equipment[this.equipmentShopSlot[0]].description)))
				{
					this.select = 0;
					this.buywindow = true;
				}
				if (GUI.Button(new Rect((float)350, (float)255, (float)50, (float)50), new GUIContent(itemData.equipment[this.equipmentShopSlot[1]].icon, itemData.equipment[this.equipmentShopSlot[1]].itemName + "\n" + "\n" + itemData.equipment[this.equipmentShopSlot[1]].description)))
				{
					this.select = 1;
					this.buywindow = true;
				}
				if (GUI.Button(new Rect((float)410, (float)255, (float)50, (float)50), new GUIContent(itemData.equipment[this.equipmentShopSlot[2]].icon, itemData.equipment[this.equipmentShopSlot[2]].itemName + "\n" + "\n" + itemData.equipment[this.equipmentShopSlot[2]].description)))
				{
					this.select = 2;
					this.buywindow = true;
				}
				if (GUI.Button(new Rect((float)470, (float)255, (float)50, (float)50), new GUIContent(itemData.equipment[this.equipmentShopSlot[3]].icon, itemData.equipment[this.equipmentShopSlot[3]].itemName + "\n" + "\n" + itemData.equipment[this.equipmentShopSlot[3]].description)))
				{
					this.select = 3;
					this.buywindow = true;
				}
				if (GUI.Button(new Rect((float)290, (float)315, (float)50, (float)50), new GUIContent(itemData.equipment[this.equipmentShopSlot[4]].icon, itemData.equipment[this.equipmentShopSlot[4]].itemName + "\n" + "\n" + itemData.equipment[this.equipmentShopSlot[4]].description)))
				{
					this.select = 4;
					this.buywindow = true;
				}
				if (GUI.Button(new Rect((float)350, (float)315, (float)50, (float)50), new GUIContent(itemData.equipment[this.equipmentShopSlot[5]].icon, itemData.equipment[this.equipmentShopSlot[5]].itemName + "\n" + "\n" + itemData.equipment[this.equipmentShopSlot[5]].description)))
				{
					this.select = 5;
					this.buywindow = true;
				}
				if (GUI.Button(new Rect((float)410, (float)315, (float)50, (float)50), new GUIContent(itemData.equipment[this.equipmentShopSlot[6]].icon, itemData.equipment[this.equipmentShopSlot[6]].itemName + "\n" + "\n" + itemData.equipment[this.equipmentShopSlot[6]].description)))
				{
					this.select = 6;
					this.buywindow = true;
				}
				if (GUI.Button(new Rect((float)470, (float)315, (float)50, (float)50), new GUIContent(itemData.equipment[this.equipmentShopSlot[7]].icon, itemData.equipment[this.equipmentShopSlot[7]].itemName + "\n" + "\n" + itemData.equipment[this.equipmentShopSlot[7]].description)))
				{
					this.select = 7;
					this.buywindow = true;
				}
				GUI.Box(new Rect((float)280, (float)170, (float)240, (float)60), GUI.tooltip);
				if (GUI.Button(new Rect((float)210, (float)245, (float)50, (float)75), "Item"))
				{
					this.shopItem = true;
					this.shopEquip = false;
				}
				if (GUI.Button(new Rect((float)210, (float)320, (float)50, (float)75), "Equip"))
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
					GUI.Box(new Rect((float)(Screen.width / 2 - 140), (float)230, (float)280, (float)120), "Price " + itemData.usableItem[this.itemShopSlot[this.select]].price);
					this.text = GUI.TextField(new Rect((float)(Screen.width / 2 + 5), (float)250, (float)50, (float)20), this.num.ToString(), 2);
					GUI.Label(new Rect((float)(Screen.width / 2 - 65), (float)250, (float)60, (float)20), "Quantity");
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
					if (this.equipmentShopSlot[this.select] == 0)
					{
						this.buywindow = false;
					}
					GUI.Box(new Rect((float)(Screen.width / 2 - 140), (float)230, (float)280, (float)120), "Price " + itemData.equipment[this.equipmentShopSlot[this.select]].price);
				}
				if (GUI.Button(new Rect((float)(Screen.width / 2 - 100), (float)285, (float)80, (float)30), "Buy"))
				{
					if (this.shopItem)
					{
						if (this.num > 0)
						{
							this.ShopBuy(this.itemShopSlot[this.select], this.select, itemData.usableItem[this.itemShopSlot[this.select]].price * this.num, this.num);
							this.buywindow = false;
						}
					}
					else
					{
						this.ShopBuy(this.equipmentShopSlot[this.select], this.select, itemData.equipment[this.equipmentShopSlot[this.select]].price, 1);
						this.buywindow = false;
					}
				}
				if (GUI.Button(new Rect((float)(Screen.width / 2 + 35), (float)285, (float)80, (float)30), "Cancel"))
				{
					this.buywindow = false;
				}
			}
			if (this.buyerror)
			{
				GUI.Box(new Rect((float)(Screen.width / 2 - 140), (float)230, (float)280, (float)120), this.buyErrorLog);
				if (GUI.Button(new Rect((float)(Screen.width / 2 - 40), (float)285, (float)80, (float)30), "OK"))
				{
					this.buyerror = false;
				}
			}
		}
	}

	// Token: 0x060001C2 RID: 450 RVA: 0x00017980 File Offset: 0x00015B80
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

	// Token: 0x060001C3 RID: 451 RVA: 0x000179DC File Offset: 0x00015BDC
	public virtual void OnTriggerExit(Collider other)
	{
		if (other.gameObject == this.player)
		{
			this.enter = false;
		}
	}

	// Token: 0x060001C4 RID: 452 RVA: 0x000179FC File Offset: 0x00015BFC
	public virtual void OnOffMenu()
	{
		if (!this.menu && Time.timeScale != (float)0)
		{
			this.menu = true;
			this.itemInven = false;
			this.shopItem = false;
			this.shopEquip = false;
			this.equipInven = false;
			this.sellwindow = false;
			this.buywindow = false;
			this.buyerror = false;
			Time.timeScale = (float)0;
			Screen.lockCursor = false;
		}
		else if (this.menu)
		{
			this.menu = false;
			Time.timeScale = 1f;
			Screen.lockCursor = true;
		}
	}

	// Token: 0x060001C5 RID: 453 RVA: 0x00017A8C File Offset: 0x00015C8C
	public virtual void Main()
	{
	}

	// Token: 0x040002DF RID: 735
	public int[] itemShopSlot;

	// Token: 0x040002E0 RID: 736
	public int[] equipmentShopSlot;

	// Token: 0x040002E1 RID: 737
	public Texture2D button;

	// Token: 0x040002E2 RID: 738
	public GameObject database;

	// Token: 0x040002E3 RID: 739
	private GameObject player;

	// Token: 0x040002E4 RID: 740
	private bool menu;

	// Token: 0x040002E5 RID: 741
	private bool shopMain;

	// Token: 0x040002E6 RID: 742
	private bool shopItem;

	// Token: 0x040002E7 RID: 743
	private bool shopEquip;

	// Token: 0x040002E8 RID: 744
	private bool itemInven;

	// Token: 0x040002E9 RID: 745
	private bool equipInven;

	// Token: 0x040002EA RID: 746
	private bool sellwindow;

	// Token: 0x040002EB RID: 747
	private bool buywindow;

	// Token: 0x040002EC RID: 748
	private bool buyerror;

	// Token: 0x040002ED RID: 749
	private string buyErrorLog;

	// Token: 0x040002EE RID: 750
	private bool enter;

	// Token: 0x040002EF RID: 751
	private int select;

	// Token: 0x040002F0 RID: 752
	private int num;

	// Token: 0x040002F1 RID: 753
	private string text;

	// Token: 0x040002F2 RID: 754
	public GUISkin skin1;

	// Token: 0x040002F3 RID: 755
	public GUISkin inventorySkin;
}
