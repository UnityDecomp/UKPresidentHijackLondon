using System;
using UnityEngine;


// Token: 0x02000054 RID: 84
[Serializable]
public class Inventory : MonoBehaviour
{
	// Token: 0x06000101 RID: 257 RVA: 0x0000BC10 File Offset: 0x00009E10
	public Inventory()
	{
		this.itemMenu = true;
		this.itemSlot = new int[16];
		this.itemQuantity = new int[16];
		this.equipment = new int[8];
		this.allowArmorUnequip = true;
		this.weapon = new GameObject[1];
		this.cash = 500;
		this.windowRect = new Rect((float)260, (float)140, (float)280, (float)385);
		this.hover = string.Empty;
	}

	// Token: 0x06000102 RID: 258 RVA: 0x0000BC9C File Offset: 0x00009E9C
	public virtual void Start()
	{
		if (!this.player)
		{
			this.player = this.gameObject;
		}
		ItemData itemData = (ItemData)this.database.GetComponent(typeof(ItemData));
		((Status)this.player.GetComponent(typeof(Status))).addAtk = 0;
		((Status)this.player.GetComponent(typeof(Status))).addDef = 0;
		((Status)this.player.GetComponent(typeof(Status))).addMatk = 0;
		((Status)this.player.GetComponent(typeof(Status))).addMdef = 0;
		((Status)this.player.GetComponent(typeof(Status))).weaponAtk = 0;
		((Status)this.player.GetComponent(typeof(Status))).weaponMatk = 0;
		((Status)this.player.GetComponent(typeof(Status))).weaponAtk = ((Status)this.player.GetComponent(typeof(Status))).weaponAtk + itemData.equipment[this.weaponEquip].attack;
		((Status)this.player.GetComponent(typeof(Status))).addDef = ((Status)this.player.GetComponent(typeof(Status))).addDef + itemData.equipment[this.weaponEquip].defense;
		((Status)this.player.GetComponent(typeof(Status))).weaponMatk = ((Status)this.player.GetComponent(typeof(Status))).weaponMatk + itemData.equipment[this.weaponEquip].magicAttack;
		((Status)this.player.GetComponent(typeof(Status))).addMdef = ((Status)this.player.GetComponent(typeof(Status))).addMdef + itemData.equipment[this.weaponEquip].magicDefense;
		((Status)this.player.GetComponent(typeof(Status))).weaponAtk = ((Status)this.player.GetComponent(typeof(Status))).weaponAtk + itemData.equipment[this.armorEquip].attack;
		((Status)this.player.GetComponent(typeof(Status))).addDef = ((Status)this.player.GetComponent(typeof(Status))).addDef + itemData.equipment[this.armorEquip].defense;
		((Status)this.player.GetComponent(typeof(Status))).weaponMatk = ((Status)this.player.GetComponent(typeof(Status))).weaponMatk + itemData.equipment[this.armorEquip].magicAttack;
		((Status)this.player.GetComponent(typeof(Status))).addMdef = ((Status)this.player.GetComponent(typeof(Status))).addMdef + itemData.equipment[this.armorEquip].magicDefense;
		((Status)this.player.GetComponent(typeof(Status))).CalculateStatus();
	}

	// Token: 0x06000103 RID: 259 RVA: 0x0000C048 File Offset: 0x0000A248
	public virtual void Update()
	{
		if (Input.GetKeyDown("i") || Input.GetKeyDown(KeyCode.Return) || Input.GetKeyDown(KeyCode.KeypadEnter))
		{
			this.OnOffMenu();
		}
	}

	// Token: 0x06000104 RID: 260 RVA: 0x0000C088 File Offset: 0x0000A288
	public virtual void UseItem(int id)
	{
		ItemData itemData = (ItemData)this.database.GetComponent(typeof(ItemData));
		((Status)this.player.GetComponent(typeof(Status))).Heal(itemData.usableItem[id].hpRecover, itemData.usableItem[id].mpRecover);
		((Status)this.player.GetComponent(typeof(Status))).atk = ((Status)this.player.GetComponent(typeof(Status))).atk + itemData.usableItem[id].atkPlus;
		((Status)this.player.GetComponent(typeof(Status))).def = ((Status)this.player.GetComponent(typeof(Status))).def + itemData.usableItem[id].defPlus;
		((Status)this.player.GetComponent(typeof(Status))).matk = ((Status)this.player.GetComponent(typeof(Status))).matk + itemData.usableItem[id].matkPlus;
		((Status)this.player.GetComponent(typeof(Status))).mdef = ((Status)this.player.GetComponent(typeof(Status))).mdef + itemData.usableItem[id].mdefPlus;
		this.AutoSortItem();
	}

	// Token: 0x06000105 RID: 261 RVA: 0x0000C220 File Offset: 0x0000A420
	public virtual void EquipItem(int id, int slot)
	{
		if (id != 0)
		{
			if (!this.player)
			{
				this.player = this.gameObject;
			}
			ItemData itemData = (ItemData)this.database.GetComponent(typeof(ItemData));
			int id2;
			if (itemData.equipment[id].EquipmentType == Equip.EqType.Weapon)
			{
				id2 = this.weaponEquip;
				this.weaponEquip = id;
				if (itemData.equipment[id].attackPrefab)
				{
					((AttackTrigger)this.player.GetComponent(typeof(AttackTrigger))).attackPrefab = itemData.equipment[id].attackPrefab.transform;
				}
				if (itemData.equipment[id].model && this.weapon != null)
				{
					int num = Extensions.get_length(this.weapon);
					int num2 = 0;
					if (num > 0 && itemData.equipment[id].assignAllWeapon)
					{
						while (num2 < num && this.weapon[num2])
						{
							this.weapon[num2].SetActive(true);
							GameObject gameObject = UnityEngine.Object.Instantiate<GameObject>(itemData.equipment[id].model, this.weapon[num2].transform.position, this.weapon[num2].transform.rotation);
							gameObject.transform.parent = this.weapon[num2].transform.parent;
							UnityEngine.Object.Destroy(this.weapon[num2].gameObject);
							this.weapon[num2] = gameObject;
							num2++;
						}
					}
					else if (num > 0)
					{
						while (num2 < num && this.weapon[num2])
						{
							if (num2 == 0)
							{
								this.weapon[num2].SetActive(true);
								GameObject gameObject = UnityEngine.Object.Instantiate<GameObject>(itemData.equipment[id].model, this.weapon[num2].transform.position, this.weapon[num2].transform.rotation);
								gameObject.transform.parent = this.weapon[num2].transform.parent;
								UnityEngine.Object.Destroy(this.weapon[num2].gameObject);
								this.weapon[num2] = gameObject;
							}
							else
							{
								this.weapon[num2].SetActive(false);
							}
							num2++;
						}
					}
				}
			}
			else
			{
				id2 = this.armorEquip;
				this.armorEquip = id;
			}
			if (slot <= this.equipment.Length)
			{
				this.equipment[slot] = 0;
			}
			this.AssignWeaponAnimation(id);
			((Status)this.player.GetComponent(typeof(Status))).addAtk = 0;
			((Status)this.player.GetComponent(typeof(Status))).addDef = 0;
			((Status)this.player.GetComponent(typeof(Status))).addMatk = 0;
			((Status)this.player.GetComponent(typeof(Status))).addMdef = 0;
			((Status)this.player.GetComponent(typeof(Status))).weaponAtk = 0;
			((Status)this.player.GetComponent(typeof(Status))).weaponMatk = 0;
			((Status)this.player.GetComponent(typeof(Status))).weaponAtk = ((Status)this.player.GetComponent(typeof(Status))).weaponAtk + itemData.equipment[this.weaponEquip].attack;
			((Status)this.player.GetComponent(typeof(Status))).addDef = ((Status)this.player.GetComponent(typeof(Status))).addDef + itemData.equipment[this.weaponEquip].defense;
			((Status)this.player.GetComponent(typeof(Status))).weaponMatk = ((Status)this.player.GetComponent(typeof(Status))).weaponMatk + itemData.equipment[this.weaponEquip].magicAttack;
			((Status)this.player.GetComponent(typeof(Status))).addMdef = ((Status)this.player.GetComponent(typeof(Status))).addMdef + itemData.equipment[this.weaponEquip].magicDefense;
			((Status)this.player.GetComponent(typeof(Status))).weaponAtk = ((Status)this.player.GetComponent(typeof(Status))).weaponAtk + itemData.equipment[this.armorEquip].attack;
			((Status)this.player.GetComponent(typeof(Status))).addDef = ((Status)this.player.GetComponent(typeof(Status))).addDef + itemData.equipment[this.armorEquip].defense;
			((Status)this.player.GetComponent(typeof(Status))).weaponMatk = ((Status)this.player.GetComponent(typeof(Status))).weaponMatk + itemData.equipment[this.armorEquip].magicAttack;
			((Status)this.player.GetComponent(typeof(Status))).addMdef = ((Status)this.player.GetComponent(typeof(Status))).addMdef + itemData.equipment[this.armorEquip].magicDefense;
			((Status)this.player.GetComponent(typeof(Status))).CalculateStatus();
			this.AutoSortEquipment();
			this.AddEquipment(id2);
		}
	}

	// Token: 0x06000106 RID: 262 RVA: 0x0000C838 File Offset: 0x0000AA38
	public virtual void RemoveWeaponMesh()
	{
		if (this.weapon != null)
		{
			int num = Extensions.get_length(this.weapon);
			int num2 = 0;
			if (num > 0)
			{
				while (num2 < num && this.weapon[num2])
				{
					this.weapon[num2].SetActive(false);
					num2++;
				}
			}
		}
	}

	// Token: 0x06000107 RID: 263 RVA: 0x0000C898 File Offset: 0x0000AA98
	public virtual void UnEquip(int id)
	{
		ItemData itemData = (ItemData)this.database.GetComponent(typeof(ItemData));
		if (!this.player)
		{
			this.player = this.gameObject;
		}
		bool flag;
		if (itemData.equipment[id].model && this.weapon != null)
		{
			flag = this.AddEquipment(this.weaponEquip);
		}
		else
		{
			flag = this.AddEquipment(this.armorEquip);
		}
		if (!flag)
		{
			if (itemData.equipment[id].model && this.weapon != null)
			{
				this.weaponEquip = 0;
				((AttackTrigger)this.player.GetComponent(typeof(AttackTrigger))).attackPrefab = this.fistPrefab.transform;
				if (this.weapon != null)
				{
					int num = Extensions.get_length(this.weapon);
					int num2 = 0;
					if (num > 0)
					{
						while (num2 < num && this.weapon[num2])
						{
							this.weapon[num2].SetActive(false);
							num2++;
						}
					}
				}
			}
			else
			{
				this.armorEquip = 0;
			}
			((Status)this.player.GetComponent(typeof(Status))).addAtk = 0;
			((Status)this.player.GetComponent(typeof(Status))).addDef = 0;
			((Status)this.player.GetComponent(typeof(Status))).addMatk = 0;
			((Status)this.player.GetComponent(typeof(Status))).addMdef = 0;
			((Status)this.player.GetComponent(typeof(Status))).weaponAtk = 0;
			((Status)this.player.GetComponent(typeof(Status))).weaponMatk = 0;
			((Status)this.player.GetComponent(typeof(Status))).weaponAtk = ((Status)this.player.GetComponent(typeof(Status))).weaponAtk + itemData.equipment[this.weaponEquip].attack;
			((Status)this.player.GetComponent(typeof(Status))).addDef = ((Status)this.player.GetComponent(typeof(Status))).addDef + itemData.equipment[this.weaponEquip].defense;
			((Status)this.player.GetComponent(typeof(Status))).weaponMatk = ((Status)this.player.GetComponent(typeof(Status))).weaponMatk + itemData.equipment[this.weaponEquip].magicAttack;
			((Status)this.player.GetComponent(typeof(Status))).addMdef = ((Status)this.player.GetComponent(typeof(Status))).addMdef + itemData.equipment[this.weaponEquip].magicDefense;
			((Status)this.player.GetComponent(typeof(Status))).weaponAtk = ((Status)this.player.GetComponent(typeof(Status))).weaponAtk + itemData.equipment[this.armorEquip].attack;
			((Status)this.player.GetComponent(typeof(Status))).addDef = ((Status)this.player.GetComponent(typeof(Status))).addDef + itemData.equipment[this.armorEquip].defense;
			((Status)this.player.GetComponent(typeof(Status))).weaponMatk = ((Status)this.player.GetComponent(typeof(Status))).weaponMatk + itemData.equipment[this.armorEquip].magicAttack;
			((Status)this.player.GetComponent(typeof(Status))).addMdef = ((Status)this.player.GetComponent(typeof(Status))).addMdef + itemData.equipment[this.armorEquip].magicDefense;
		}
	}

	// Token: 0x06000108 RID: 264 RVA: 0x0000CD20 File Offset: 0x0000AF20
	public virtual void OnGUI()
	{
		GUI.skin = this.skin;
		if (this.menu && this.itemMenu)
		{
			this.windowRect = GUI.Window(1, this.windowRect, new GUI.WindowFunction(this.ItemWindow), "Items");
		}
		if (this.menu && this.equipMenu)
		{
			this.windowRect = GUI.Window(1, this.windowRect, new GUI.WindowFunction(this.ItemWindow), "Equipment");
		}
		if (this.menu)
		{
			if (GUI.Button(new Rect(this.windowRect.x - (float)50, this.windowRect.y + (float)105, (float)50, (float)100), "Item"))
			{
				this.itemMenu = true;
				this.equipMenu = false;
			}
			if (GUI.Button(new Rect(this.windowRect.x - (float)50, this.windowRect.y + (float)225, (float)50, (float)100), "Equip"))
			{
				this.equipMenu = true;
				this.itemMenu = false;
			}
		}
	}

	// Token: 0x06000109 RID: 265 RVA: 0x0000CE48 File Offset: 0x0000B048
	public virtual void ItemWindow(int windowID)
	{
		ItemData itemData = (ItemData)this.database.GetComponent(typeof(ItemData));
		if (this.menu && this.itemMenu)
		{
			if (GUI.Button(new Rect((float)250, (float)2, (float)30, (float)30), "X"))
			{
				this.OnOffMenu();
			}
			if (GUI.Button(new Rect((float)30, (float)115, (float)50, (float)50), new GUIContent(itemData.usableItem[this.itemSlot[0]].icon, itemData.usableItem[this.itemSlot[0]].itemName + "\n" + "\n" + itemData.usableItem[this.itemSlot[0]].description)) && !itemData.usableItem[this.itemSlot[0]].unusable)
			{
				this.UseItem(this.itemSlot[0]);
				if (this.itemQuantity[0] > 0)
				{
					this.itemQuantity[0] = this.itemQuantity[0] - 1;
				}
				if (this.itemQuantity[0] <= 0)
				{
					this.itemSlot[0] = 0;
					this.itemQuantity[0] = 0;
					this.AutoSortItem();
				}
			}
			if (this.itemQuantity[0] > 0)
			{
				GUI.Label(new Rect((float)70, (float)150, (float)20, (float)20), this.itemQuantity[0].ToString());
			}
			if (GUI.Button(new Rect((float)90, (float)115, (float)50, (float)50), new GUIContent(itemData.usableItem[this.itemSlot[1]].icon, itemData.usableItem[this.itemSlot[1]].itemName + "\n" + "\n" + itemData.usableItem[this.itemSlot[1]].description)) && !itemData.usableItem[this.itemSlot[1]].unusable)
			{
				this.UseItem(this.itemSlot[1]);
				if (this.itemQuantity[1] > 0)
				{
					this.itemQuantity[1] = this.itemQuantity[1] - 1;
				}
				if (this.itemQuantity[1] <= 0)
				{
					this.itemSlot[1] = 0;
					this.itemQuantity[1] = 0;
					this.AutoSortItem();
				}
			}
			if (this.itemQuantity[1] > 0)
			{
				GUI.Label(new Rect((float)130, (float)150, (float)20, (float)20), this.itemQuantity[1].ToString());
			}
			if (GUI.Button(new Rect((float)150, (float)115, (float)50, (float)50), new GUIContent(itemData.usableItem[this.itemSlot[2]].icon, itemData.usableItem[this.itemSlot[2]].itemName + "\n" + "\n" + itemData.usableItem[this.itemSlot[2]].description)) && !itemData.usableItem[this.itemSlot[2]].unusable)
			{
				this.UseItem(this.itemSlot[2]);
				if (this.itemQuantity[2] > 0)
				{
					this.itemQuantity[2] = this.itemQuantity[2] - 1;
				}
				if (this.itemQuantity[2] <= 0)
				{
					this.itemSlot[2] = 0;
					this.itemQuantity[2] = 0;
					this.AutoSortItem();
				}
			}
			if (this.itemQuantity[2] > 0)
			{
				GUI.Label(new Rect((float)190, (float)150, (float)20, (float)20), this.itemQuantity[2].ToString());
			}
			if (GUI.Button(new Rect((float)210, (float)115, (float)50, (float)50), new GUIContent(itemData.usableItem[this.itemSlot[3]].icon, itemData.usableItem[this.itemSlot[3]].itemName + "\n" + "\n" + itemData.usableItem[this.itemSlot[3]].description)) && !itemData.usableItem[this.itemSlot[3]].unusable)
			{
				this.UseItem(this.itemSlot[3]);
				if (this.itemQuantity[3] > 0)
				{
					this.itemQuantity[3] = this.itemQuantity[3] - 1;
				}
				if (this.itemQuantity[3] <= 0)
				{
					this.itemSlot[3] = 0;
					this.itemQuantity[3] = 0;
					this.AutoSortItem();
				}
			}
			if (this.itemQuantity[3] > 0)
			{
				GUI.Label(new Rect((float)250, (float)150, (float)20, (float)20), this.itemQuantity[3].ToString());
			}
			if (GUI.Button(new Rect((float)30, (float)175, (float)50, (float)50), new GUIContent(itemData.usableItem[this.itemSlot[4]].icon, itemData.usableItem[this.itemSlot[4]].itemName + "\n" + "\n" + itemData.usableItem[this.itemSlot[4]].description)) && !itemData.usableItem[this.itemSlot[4]].unusable)
			{
				this.UseItem(this.itemSlot[4]);
				if (this.itemQuantity[4] > 0)
				{
					this.itemQuantity[4] = this.itemQuantity[4] - 1;
				}
				if (this.itemQuantity[4] <= 0)
				{
					this.itemSlot[4] = 0;
					this.itemQuantity[4] = 0;
					this.AutoSortItem();
				}
			}
			if (this.itemQuantity[4] > 0)
			{
				GUI.Label(new Rect((float)70, (float)210, (float)20, (float)20), this.itemQuantity[4].ToString());
			}
			if (GUI.Button(new Rect((float)90, (float)175, (float)50, (float)50), new GUIContent(itemData.usableItem[this.itemSlot[5]].icon, itemData.usableItem[this.itemSlot[5]].itemName + "\n" + "\n" + itemData.usableItem[this.itemSlot[5]].description)) && !itemData.usableItem[this.itemSlot[5]].unusable)
			{
				this.UseItem(this.itemSlot[5]);
				if (this.itemQuantity[5] > 0)
				{
					this.itemQuantity[5] = this.itemQuantity[5] - 1;
				}
				if (this.itemQuantity[5] <= 0)
				{
					this.itemSlot[5] = 0;
					this.itemQuantity[5] = 0;
					this.AutoSortItem();
				}
			}
			if (this.itemQuantity[5] > 0)
			{
				GUI.Label(new Rect((float)130, (float)210, (float)20, (float)20), this.itemQuantity[5].ToString());
			}
			if (GUI.Button(new Rect((float)150, (float)175, (float)50, (float)50), new GUIContent(itemData.usableItem[this.itemSlot[6]].icon, itemData.usableItem[this.itemSlot[6]].itemName + "\n" + "\n" + itemData.usableItem[this.itemSlot[6]].description)) && !itemData.usableItem[this.itemSlot[6]].unusable)
			{
				this.UseItem(this.itemSlot[6]);
				if (this.itemQuantity[6] > 0)
				{
					this.itemQuantity[6] = this.itemQuantity[6] - 1;
				}
				if (this.itemQuantity[6] <= 0)
				{
					this.itemSlot[6] = 0;
					this.itemQuantity[6] = 0;
					this.AutoSortItem();
				}
			}
			if (this.itemQuantity[6] > 0)
			{
				GUI.Label(new Rect((float)190, (float)210, (float)20, (float)20), this.itemQuantity[6].ToString());
			}
			if (GUI.Button(new Rect((float)210, (float)175, (float)50, (float)50), new GUIContent(itemData.usableItem[this.itemSlot[7]].icon, itemData.usableItem[this.itemSlot[7]].itemName + "\n" + "\n" + itemData.usableItem[this.itemSlot[7]].description)) && !itemData.usableItem[this.itemSlot[7]].unusable)
			{
				this.UseItem(this.itemSlot[7]);
				if (this.itemQuantity[7] > 0)
				{
					this.itemQuantity[7] = this.itemQuantity[7] - 1;
				}
				if (this.itemQuantity[7] <= 0)
				{
					this.itemSlot[7] = 0;
					this.itemQuantity[7] = 0;
					this.AutoSortItem();
				}
			}
			if (this.itemQuantity[7] > 0)
			{
				GUI.Label(new Rect((float)250, (float)210, (float)20, (float)20), this.itemQuantity[7].ToString());
			}
			if (GUI.Button(new Rect((float)30, (float)235, (float)50, (float)50), new GUIContent(itemData.usableItem[this.itemSlot[8]].icon, itemData.usableItem[this.itemSlot[8]].itemName + "\n" + "\n" + itemData.usableItem[this.itemSlot[8]].description)) && !itemData.usableItem[this.itemSlot[8]].unusable)
			{
				this.UseItem(this.itemSlot[8]);
				if (this.itemQuantity[8] > 0)
				{
					this.itemQuantity[8] = this.itemQuantity[8] - 1;
				}
				if (this.itemQuantity[8] <= 0)
				{
					this.itemSlot[8] = 0;
					this.itemQuantity[8] = 0;
					this.AutoSortItem();
				}
			}
			if (this.itemQuantity[8] > 0)
			{
				GUI.Label(new Rect((float)70, (float)270, (float)20, (float)20), this.itemQuantity[8].ToString());
			}
			if (GUI.Button(new Rect((float)90, (float)235, (float)50, (float)50), new GUIContent(itemData.usableItem[this.itemSlot[9]].icon, itemData.usableItem[this.itemSlot[9]].itemName + "\n" + "\n" + itemData.usableItem[this.itemSlot[9]].description)) && !itemData.usableItem[this.itemSlot[9]].unusable)
			{
				this.UseItem(this.itemSlot[9]);
				if (this.itemQuantity[9] > 0)
				{
					this.itemQuantity[9] = this.itemQuantity[9] - 1;
				}
				if (this.itemQuantity[9] <= 0)
				{
					this.itemSlot[9] = 0;
					this.itemQuantity[9] = 0;
					this.AutoSortItem();
				}
			}
			if (this.itemQuantity[9] > 0)
			{
				GUI.Label(new Rect((float)130, (float)270, (float)20, (float)20), this.itemQuantity[9].ToString());
			}
			if (GUI.Button(new Rect((float)150, (float)235, (float)50, (float)50), new GUIContent(itemData.usableItem[this.itemSlot[10]].icon, itemData.usableItem[this.itemSlot[10]].itemName + "\n" + "\n" + itemData.usableItem[this.itemSlot[10]].description)) && !itemData.usableItem[this.itemSlot[10]].unusable)
			{
				this.UseItem(this.itemSlot[10]);
				if (this.itemQuantity[10] > 0)
				{
					this.itemQuantity[10] = this.itemQuantity[10] - 1;
				}
				if (this.itemQuantity[10] <= 0)
				{
					this.itemSlot[10] = 0;
					this.itemQuantity[10] = 0;
					this.AutoSortItem();
				}
			}
			if (this.itemQuantity[10] > 0)
			{
				GUI.Label(new Rect((float)190, (float)270, (float)20, (float)20), this.itemQuantity[10].ToString());
			}
			if (GUI.Button(new Rect((float)210, (float)235, (float)50, (float)50), new GUIContent(itemData.usableItem[this.itemSlot[11]].icon, itemData.usableItem[this.itemSlot[11]].itemName + "\n" + "\n" + itemData.usableItem[this.itemSlot[11]].description)) && !itemData.usableItem[this.itemSlot[11]].unusable)
			{
				this.UseItem(this.itemSlot[11]);
				if (this.itemQuantity[11] > 0)
				{
					this.itemQuantity[11] = this.itemQuantity[11] - 1;
				}
				if (this.itemQuantity[11] <= 0)
				{
					this.itemSlot[11] = 0;
					this.itemQuantity[11] = 0;
					this.AutoSortItem();
				}
			}
			if (this.itemQuantity[11] > 0)
			{
				GUI.Label(new Rect((float)250, (float)270, (float)20, (float)20), this.itemQuantity[11].ToString());
			}
			if (GUI.Button(new Rect((float)30, (float)295, (float)50, (float)50), new GUIContent(itemData.usableItem[this.itemSlot[12]].icon, itemData.usableItem[this.itemSlot[12]].itemName + "\n" + "\n" + itemData.usableItem[this.itemSlot[12]].description)) && !itemData.usableItem[this.itemSlot[12]].unusable)
			{
				this.UseItem(this.itemSlot[12]);
				if (this.itemQuantity[12] > 0)
				{
					this.itemQuantity[12] = this.itemQuantity[12] - 1;
				}
				if (this.itemQuantity[12] <= 0)
				{
					this.itemSlot[12] = 0;
					this.itemQuantity[12] = 0;
					this.AutoSortItem();
				}
			}
			if (this.itemQuantity[12] > 0)
			{
				GUI.Label(new Rect((float)70, (float)330, (float)20, (float)20), this.itemQuantity[12].ToString());
			}
			if (GUI.Button(new Rect((float)90, (float)295, (float)50, (float)50), new GUIContent(itemData.usableItem[this.itemSlot[13]].icon, itemData.usableItem[this.itemSlot[13]].itemName + "\n" + "\n" + itemData.usableItem[this.itemSlot[13]].description)) && !itemData.usableItem[this.itemSlot[13]].unusable)
			{
				this.UseItem(this.itemSlot[13]);
				if (this.itemQuantity[13] > 0)
				{
					this.itemQuantity[13] = this.itemQuantity[13] - 1;
				}
				if (this.itemQuantity[13] <= 0)
				{
					this.itemSlot[13] = 0;
					this.itemQuantity[13] = 0;
					this.AutoSortItem();
				}
			}
			if (this.itemQuantity[13] > 0)
			{
				GUI.Label(new Rect((float)130, (float)330, (float)20, (float)20), this.itemQuantity[13].ToString());
			}
			if (GUI.Button(new Rect((float)150, (float)295, (float)50, (float)50), new GUIContent(itemData.usableItem[this.itemSlot[14]].icon, itemData.usableItem[this.itemSlot[14]].itemName + "\n" + "\n" + itemData.usableItem[this.itemSlot[14]].description)) && !itemData.usableItem[this.itemSlot[14]].unusable)
			{
				this.UseItem(this.itemSlot[14]);
				if (this.itemQuantity[14] > 0)
				{
					this.itemQuantity[14] = this.itemQuantity[14] - 1;
				}
				if (this.itemQuantity[14] <= 0)
				{
					this.itemSlot[14] = 0;
					this.itemQuantity[14] = 0;
					this.AutoSortItem();
				}
			}
			if (this.itemQuantity[14] > 0)
			{
				GUI.Label(new Rect((float)190, (float)330, (float)20, (float)20), this.itemQuantity[14].ToString());
			}
			if (GUI.Button(new Rect((float)210, (float)295, (float)50, (float)50), new GUIContent(itemData.usableItem[this.itemSlot[15]].icon, itemData.usableItem[this.itemSlot[15]].itemName + "\n" + "\n" + itemData.usableItem[this.itemSlot[15]].description)) && !itemData.usableItem[this.itemSlot[15]].unusable)
			{
				this.UseItem(this.itemSlot[15]);
				if (this.itemQuantity[15] > 0)
				{
					this.itemQuantity[15] = this.itemQuantity[15] - 1;
				}
				if (this.itemQuantity[15] <= 0)
				{
					this.itemSlot[15] = 0;
					this.itemQuantity[15] = 0;
					this.AutoSortItem();
				}
			}
			if (this.itemQuantity[15] > 0)
			{
				GUI.Label(new Rect((float)250, (float)330, (float)20, (float)20), this.itemQuantity[15].ToString());
			}
			GUI.Label(new Rect((float)20, (float)355, (float)150, (float)50), "$ " + this.cash.ToString());
			GUI.Box(new Rect((float)20, (float)30, (float)240, (float)60), GUI.tooltip);
		}
		if (this.menu && this.equipMenu)
		{
			if (GUI.Button(new Rect((float)250, (float)2, (float)30, (float)30), "X"))
			{
				this.OnOffMenu();
			}
			GUI.Label(new Rect((float)20, (float)130, (float)150, (float)50), "Weapon");
			if (GUI.Button(new Rect((float)100, (float)115, (float)50, (float)50), new GUIContent(itemData.equipment[this.weaponEquip].icon, itemData.equipment[this.weaponEquip].itemName + "\n" + "\n" + itemData.equipment[this.weaponEquip].description)))
			{
				if (!this.allowWeaponUnequip || this.weaponEquip == 0)
				{
					return;
				}
				this.UnEquip(this.weaponEquip);
			}
			GUI.Label(new Rect((float)20, (float)190, (float)150, (float)50), "Armor");
			if (GUI.Button(new Rect((float)100, (float)175, (float)50, (float)50), new GUIContent(itemData.equipment[this.armorEquip].icon, itemData.equipment[this.armorEquip].itemName + "\n" + "\n" + itemData.equipment[this.armorEquip].description)))
			{
				if (!this.allowArmorUnequip || this.armorEquip == 0)
				{
					return;
				}
				this.UnEquip(this.armorEquip);
			}
			if (GUI.Button(new Rect((float)30, (float)235, (float)50, (float)50), new GUIContent(itemData.equipment[this.equipment[0]].icon, itemData.equipment[this.equipment[0]].itemName + "\n" + "\n" + itemData.equipment[this.equipment[0]].description)))
			{
				this.EquipItem(this.equipment[0], 0);
			}
			if (GUI.Button(new Rect((float)90, (float)235, (float)50, (float)50), new GUIContent(itemData.equipment[this.equipment[1]].icon, itemData.equipment[this.equipment[1]].itemName + "\n" + "\n" + itemData.equipment[this.equipment[1]].description)))
			{
				this.EquipItem(this.equipment[1], 1);
			}
			if (GUI.Button(new Rect((float)150, (float)235, (float)50, (float)50), new GUIContent(itemData.equipment[this.equipment[2]].icon, itemData.equipment[this.equipment[2]].itemName + "\n" + "\n" + itemData.equipment[this.equipment[2]].description)))
			{
				this.EquipItem(this.equipment[2], 2);
			}
			if (GUI.Button(new Rect((float)210, (float)235, (float)50, (float)50), new GUIContent(itemData.equipment[this.equipment[3]].icon, itemData.equipment[this.equipment[3]].itemName + "\n" + "\n" + itemData.equipment[this.equipment[3]].description)))
			{
				this.EquipItem(this.equipment[3], 3);
			}
			if (GUI.Button(new Rect((float)30, (float)295, (float)50, (float)50), new GUIContent(itemData.equipment[this.equipment[4]].icon, itemData.equipment[this.equipment[4]].itemName + "\n" + "\n" + itemData.equipment[this.equipment[4]].description)))
			{
				this.EquipItem(this.equipment[4], 4);
			}
			if (GUI.Button(new Rect((float)90, (float)295, (float)50, (float)50), new GUIContent(itemData.equipment[this.equipment[5]].icon, itemData.equipment[this.equipment[5]].itemName + "\n" + "\n" + itemData.equipment[this.equipment[5]].description)))
			{
				this.EquipItem(this.equipment[5], 5);
			}
			if (GUI.Button(new Rect((float)150, (float)295, (float)50, (float)50), new GUIContent(itemData.equipment[this.equipment[6]].icon, itemData.equipment[this.equipment[6]].itemName + "\n" + "\n" + itemData.equipment[this.equipment[6]].description)))
			{
				this.EquipItem(this.equipment[6], 6);
			}
			if (GUI.Button(new Rect((float)210, (float)295, (float)50, (float)50), new GUIContent(itemData.equipment[this.equipment[7]].icon, itemData.equipment[this.equipment[7]].itemName + "\n" + "\n" + itemData.equipment[this.equipment[7]].description)))
			{
				this.EquipItem(this.equipment[7], 7);
			}
			GUI.Label(new Rect((float)20, (float)355, (float)150, (float)50), "$ " + this.cash.ToString());
			GUI.Box(new Rect((float)20, (float)30, (float)240, (float)60), GUI.tooltip);
		}
		GUI.DragWindow(new Rect((float)0, (float)0, (float)10000, (float)10000));
	}

	// Token: 0x0600010A RID: 266 RVA: 0x0000E7B4 File Offset: 0x0000C9B4
	public virtual bool AddItem(int id, int quan)
	{
		bool result = false;
		bool flag = false;
		int num = 0;
		while (num < this.itemSlot.Length && !flag)
		{
			if (this.itemSlot[num] == id)
			{
				this.itemQuantity[num] = this.itemQuantity[num] + quan;
				flag = true;
			}
			else if (this.itemSlot[num] == 0)
			{
				this.itemSlot[num] = id;
				this.itemQuantity[num] = quan;
				flag = true;
			}
			else
			{
				num++;
				if (num >= this.itemSlot.Length)
				{
					result = true;
					MonoBehaviour.print("Full");
				}
			}
		}
		return result;
	}

	// Token: 0x0600010B RID: 267 RVA: 0x0000E854 File Offset: 0x0000CA54
	public virtual bool AddEquipment(int id)
	{
		bool result = false;
		bool flag = false;
		int num = 0;
		while (num < this.equipment.Length && !flag)
		{
			if (this.equipment[num] == 0)
			{
				this.equipment[num] = id;
				flag = true;
			}
			else
			{
				num++;
				if (num >= this.equipment.Length)
				{
					result = true;
					MonoBehaviour.print("Full");
				}
			}
		}
		return result;
	}

	// Token: 0x0600010C RID: 268 RVA: 0x0000E8C4 File Offset: 0x0000CAC4
	public virtual void AutoSortItem()
	{
		int i = 0;
		bool flag = false;
		while (i < this.itemSlot.Length)
		{
			if (this.itemSlot[i] == 0)
			{
				int num = i + 1;
				while (num < this.itemSlot.Length && !flag)
				{
					if (this.itemSlot[num] > 0)
					{
						this.itemSlot[i] = this.itemSlot[num];
						this.itemQuantity[i] = this.itemQuantity[num];
						this.itemSlot[num] = 0;
						this.itemQuantity[num] = 0;
						flag = true;
					}
					else
					{
						num++;
					}
				}
				flag = false;
				i++;
			}
			else
			{
				i++;
			}
		}
	}

	// Token: 0x0600010D RID: 269 RVA: 0x0000E974 File Offset: 0x0000CB74
	public virtual void AutoSortEquipment()
	{
		int i = 0;
		bool flag = false;
		while (i < this.equipment.Length)
		{
			if (this.equipment[i] == 0)
			{
				int num = i + 1;
				while (num < this.equipment.Length && !flag)
				{
					if (this.equipment[num] > 0)
					{
						this.equipment[i] = this.equipment[num];
						this.equipment[num] = 0;
						flag = true;
					}
					else
					{
						num++;
					}
				}
				flag = false;
				i++;
			}
			else
			{
				i++;
			}
		}
	}

	// Token: 0x0600010E RID: 270 RVA: 0x0000EA0C File Offset: 0x0000CC0C
	public virtual void OnOffMenu()
	{
		if (!this.menu && Time.timeScale != (float)0)
		{
			this.menu = true;
			Time.timeScale = (float)0;
			Screen.lockCursor = false;
			this.ResetPosition();
		}
		else if (this.menu)
		{
			this.menu = false;
			Time.timeScale = 1f;
			Screen.lockCursor = true;
		}
	}

	// Token: 0x0600010F RID: 271 RVA: 0x0000EA74 File Offset: 0x0000CC74
	public virtual void AssignWeaponAnimation(int id)
	{
		ItemData itemData = (ItemData)this.database.GetComponent(typeof(ItemData));
		PlayerAnimation playerAnimation = (PlayerAnimation)this.player.GetComponent(typeof(PlayerAnimation));
		if (!playerAnimation)
		{
			this.AssignMecanimAnimation(id);
		}
		else
		{
			if (itemData.equipment[id].attackCombo != null && itemData.equipment[id].EquipmentType == Equip.EqType.Weapon)
			{
				int num = Extensions.get_length(itemData.equipment[id].attackCombo);
				((AttackTrigger)this.player.GetComponent(typeof(AttackTrigger))).attackCombo = new AnimationClip[num];
				int i = 0;
				if (num > 0)
				{
					while (i < num)
					{
						((AttackTrigger)this.player.GetComponent(typeof(AttackTrigger))).attackCombo[i] = itemData.equipment[id].attackCombo[i];
						((AttackTrigger)this.player.GetComponent(typeof(AttackTrigger))).mainModel.GetComponent<Animation>()[itemData.equipment[id].attackCombo[i].name].layer = 15;
						i++;
					}
				}
				((AttackTrigger)this.player.GetComponent(typeof(AttackTrigger))).whileAttack = (whileAtk)UnityBuiltins.parseInt((int)itemData.equipment[id].whileAttack);
				((AttackTrigger)this.player.GetComponent(typeof(AttackTrigger))).attackSpeed = itemData.equipment[id].attackSpeed;
				((AttackTrigger)this.player.GetComponent(typeof(AttackTrigger))).atkDelay1 = itemData.equipment[id].attackDelay;
			}
			if (itemData.equipment[id].idleAnimation)
			{
				((PlayerAnimation)this.player.GetComponent(typeof(PlayerAnimation))).idle = itemData.equipment[id].idleAnimation;
			}
			if (itemData.equipment[id].runAnimation)
			{
				playerAnimation.run = itemData.equipment[id].runAnimation;
			}
			if (itemData.equipment[id].rightAnimation)
			{
				playerAnimation.right = itemData.equipment[id].rightAnimation;
			}
			if (itemData.equipment[id].leftAnimation)
			{
				playerAnimation.left = itemData.equipment[id].leftAnimation;
			}
			if (itemData.equipment[id].backAnimation)
			{
				playerAnimation.back = itemData.equipment[id].backAnimation;
			}
			if (itemData.equipment[id].jumpAnimation)
			{
				((PlayerAnimation)this.player.GetComponent(typeof(PlayerAnimation))).jump = itemData.equipment[id].jumpAnimation;
			}
			playerAnimation.AnimationSpeedSet();
		}
	}

	// Token: 0x06000110 RID: 272 RVA: 0x0000ED78 File Offset: 0x0000CF78
	public virtual void ResetPosition()
	{
		if (this.windowRect.x >= (float)(Screen.width - 30) || this.windowRect.y >= (float)(Screen.height - 30) || this.windowRect.x <= (float)-70 || this.windowRect.y <= (float)-70)
		{
			this.windowRect = new Rect((float)260, (float)140, (float)280, (float)385);
		}
	}

	// Token: 0x06000111 RID: 273 RVA: 0x0000EE00 File Offset: 0x0000D000
	public virtual void AssignMecanimAnimation(int id)
	{
		ItemData itemData = (ItemData)this.database.GetComponent(typeof(ItemData));
		if (itemData.equipment[id].EquipmentType == Equip.EqType.Weapon)
		{
			((AttackTrigger)this.player.GetComponent(typeof(AttackTrigger))).whileAttack = (whileAtk)UnityBuiltins.parseInt((int)itemData.equipment[id].whileAttack);
			((AttackTrigger)this.player.GetComponent(typeof(AttackTrigger))).attackSpeed = itemData.equipment[id].attackSpeed;
			((AttackTrigger)this.player.GetComponent(typeof(AttackTrigger))).atkDelay1 = itemData.equipment[id].attackDelay;
			((PlayerMecanimAnimation)this.player.GetComponent(typeof(PlayerMecanimAnimation))).SetWeaponType(itemData.equipment[id].weaponType, itemData.equipment[id].idleAnimation.name);
			int num = Extensions.get_length(itemData.equipment[id].attackCombo);
			((AttackTrigger)this.player.GetComponent(typeof(AttackTrigger))).attackCombo = new AnimationClip[num];
			int i = 0;
			if (num > 0)
			{
				while (i < num)
				{
					((AttackTrigger)this.player.GetComponent(typeof(AttackTrigger))).attackCombo[i] = itemData.equipment[id].attackCombo[i];
					i++;
				}
			}
		}
	}

	// Token: 0x06000112 RID: 274 RVA: 0x0000EF84 File Offset: 0x0000D184
	public virtual bool CheckItem(int id, int type, int qty)
	{
		bool result = false;
		bool flag = false;
		int num = 0;
		if (type == 0)
		{
			while (num < this.itemSlot.Length && !flag)
			{
				if (this.itemSlot[num] == id)
				{
					if (this.itemQuantity[num] >= qty)
					{
						result = true;
					}
					flag = true;
				}
				else
				{
					num++;
				}
			}
		}
		if (type == 1)
		{
			while (num < this.equipment.Length && !flag)
			{
				if (this.equipment[num] == id)
				{
					result = true;
					flag = true;
				}
				else
				{
					num++;
				}
			}
		}
		return result;
	}

	// Token: 0x06000113 RID: 275 RVA: 0x0000F024 File Offset: 0x0000D224
	public virtual int FindItemSlot(int id)
	{
		bool flag = false;
		int num = 0;
		while (num < this.itemSlot.Length && !flag)
		{
			if (this.itemSlot[num] == id)
			{
				flag = true;
			}
			else
			{
				num++;
				if (num >= this.itemSlot.Length)
				{
					num = this.itemSlot.Length + 50;
					MonoBehaviour.print("No Item");
				}
			}
		}
		return num;
	}

	// Token: 0x06000114 RID: 276 RVA: 0x0000F098 File Offset: 0x0000D298
	public virtual int FindEquipmentSlot(int id)
	{
		bool flag = false;
		int num = 0;
		while (num < this.equipment.Length && !flag)
		{
			if (this.equipment[num] == id)
			{
				flag = true;
			}
			else
			{
				num++;
				if (num >= this.equipment.Length)
				{
					num = this.equipment.Length + 50;
					MonoBehaviour.print("No Item");
				}
			}
		}
		return num;
	}

	// Token: 0x06000115 RID: 277 RVA: 0x0000F10C File Offset: 0x0000D30C
	public virtual bool RemoveItem(int id, int amount)
	{
		bool result = false;
		int num = this.FindItemSlot(id);
		if (num < this.itemSlot.Length)
		{
			if (this.itemQuantity[num] > 0)
			{
				this.itemQuantity[num] = this.itemQuantity[num] - amount;
				result = true;
			}
			if (this.itemQuantity[num] <= 0)
			{
				this.itemSlot[num] = 0;
				this.itemQuantity[num] = 0;
				this.AutoSortItem();
			}
		}
		return result;
	}

	// Token: 0x06000116 RID: 278 RVA: 0x0000F180 File Offset: 0x0000D380
	public virtual bool RemoveEquipment(int id)
	{
		bool result = false;
		int num = this.FindEquipmentSlot(id);
		if (num < this.equipment.Length)
		{
			this.equipment[num] = 0;
			this.AutoSortEquipment();
			result = true;
		}
		return result;
	}

	// Token: 0x06000117 RID: 279 RVA: 0x0000F1BC File Offset: 0x0000D3BC
	public virtual void Main()
	{
	}

	// Token: 0x040001CB RID: 459
	private bool menu;

	// Token: 0x040001CC RID: 460
	private bool itemMenu;

	// Token: 0x040001CD RID: 461
	private bool equipMenu;

	// Token: 0x040001CE RID: 462
	public int[] itemSlot;

	// Token: 0x040001CF RID: 463
	public int[] itemQuantity;

	// Token: 0x040001D0 RID: 464
	public int[] equipment;

	// Token: 0x040001D1 RID: 465
	public int weaponEquip;

	// Token: 0x040001D2 RID: 466
	public bool allowWeaponUnequip;

	// Token: 0x040001D3 RID: 467
	public int armorEquip;

	// Token: 0x040001D4 RID: 468
	public bool allowArmorUnequip;

	// Token: 0x040001D5 RID: 469
	public GameObject[] weapon;

	// Token: 0x040001D6 RID: 470
	public GameObject player;

	// Token: 0x040001D7 RID: 471
	public GameObject database;

	// Token: 0x040001D8 RID: 472
	public GameObject fistPrefab;

	// Token: 0x040001D9 RID: 473
	public int cash;

	// Token: 0x040001DA RID: 474
	public GUISkin skin;

	// Token: 0x040001DB RID: 475
	public Rect windowRect;

	// Token: 0x040001DC RID: 476
	private string hover;
}
