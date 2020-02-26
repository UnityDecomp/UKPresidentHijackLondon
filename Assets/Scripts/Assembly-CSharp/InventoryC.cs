using System;
using UnityEngine;

// Token: 0x0200006D RID: 109
public class InventoryC : MonoBehaviour
{
	// Token: 0x060003A1 RID: 929 RVA: 0x00014034 File Offset: 0x00012434
	private void Start()
	{
		if (!this.player)
		{
			this.player = base.gameObject;
		}
		ItemDataC component = this.database.GetComponent<ItemDataC>();
		this.player.GetComponent<StatusC>().addAtk = 0;
		this.player.GetComponent<StatusC>().addDef = 0;
		this.player.GetComponent<StatusC>().addMatk = 0;
		this.player.GetComponent<StatusC>().addMdef = 0;
		this.player.GetComponent<StatusC>().weaponAtk = 0;
		this.player.GetComponent<StatusC>().weaponMatk = 0;
		this.player.GetComponent<StatusC>().weaponAtk += component.equipment[this.weaponEquip].attack;
		this.player.GetComponent<StatusC>().addDef += component.equipment[this.weaponEquip].defense;
		this.player.GetComponent<StatusC>().weaponMatk += component.equipment[this.weaponEquip].magicAttack;
		this.player.GetComponent<StatusC>().addMdef += component.equipment[this.weaponEquip].magicDefense;
		this.player.GetComponent<StatusC>().weaponAtk += component.equipment[this.armorEquip].attack;
		this.player.GetComponent<StatusC>().addDef += component.equipment[this.armorEquip].defense;
		this.player.GetComponent<StatusC>().weaponMatk += component.equipment[this.armorEquip].magicAttack;
		this.player.GetComponent<StatusC>().addMdef += component.equipment[this.armorEquip].magicDefense;
		this.player.GetComponent<StatusC>().CalculateStatus();
	}

	// Token: 0x060003A2 RID: 930 RVA: 0x00014227 File Offset: 0x00012627
	private void Update()
	{
		if (Input.GetKeyDown("i") || Input.GetKeyDown(KeyCode.Return) || Input.GetKeyDown(KeyCode.KeypadEnter))
		{
			this.OnOffMenu();
		}
	}

	// Token: 0x060003A3 RID: 931 RVA: 0x0001425C File Offset: 0x0001265C
	public void UseItem(int id)
	{
		ItemDataC component = this.database.GetComponent<ItemDataC>();
		this.player.GetComponent<StatusC>().Heal(component.usableItem[id].hpRecover, component.usableItem[id].mpRecover);
		this.player.GetComponent<StatusC>().atk += component.usableItem[id].atkPlus;
		this.player.GetComponent<StatusC>().def += component.usableItem[id].defPlus;
		this.player.GetComponent<StatusC>().matk += component.usableItem[id].matkPlus;
		this.player.GetComponent<StatusC>().mdef += component.usableItem[id].mdefPlus;
		this.AutoSortItem();
	}

	// Token: 0x060003A4 RID: 932 RVA: 0x00014338 File Offset: 0x00012738
	public void EquipItem(int id, int slot)
	{
		GameObject gameObject = new GameObject();
		if (id == 0)
		{
			return;
		}
		if (!this.player)
		{
			this.player = base.gameObject;
		}
		ItemDataC component = this.database.GetComponent<ItemDataC>();
		int id2;
		if (component.equipment[id].EquipmentType == ItemDataC.Equip.EqType.Weapon)
		{
			id2 = this.weaponEquip;
			this.weaponEquip = id;
			if (component.equipment[id].attackPrefab)
			{
				this.player.GetComponent<AttackTriggerC>().attackPrefab = component.equipment[id].attackPrefab.transform;
			}
			if (component.equipment[id].model && this.weapon.Length > 0 && this.weapon[0] != null)
			{
				int num = this.weapon.Length;
				int num2 = 0;
				if (num > 0 && component.equipment[id].assignAllWeapon)
				{
					while (num2 < num && this.weapon[num2])
					{
						this.weapon[num2].SetActive(true);
						gameObject = UnityEngine.Object.Instantiate<GameObject>(component.equipment[id].model, this.weapon[num2].transform.position, this.weapon[num2].transform.rotation);
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
							gameObject = UnityEngine.Object.Instantiate<GameObject>(component.equipment[id].model, this.weapon[num2].transform.position, this.weapon[num2].transform.rotation);
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
		this.player.GetComponent<StatusC>().addAtk = 0;
		this.player.GetComponent<StatusC>().addDef = 0;
		this.player.GetComponent<StatusC>().addMatk = 0;
		this.player.GetComponent<StatusC>().addMdef = 0;
		this.player.GetComponent<StatusC>().weaponAtk = 0;
		this.player.GetComponent<StatusC>().weaponMatk = 0;
		this.player.GetComponent<StatusC>().weaponAtk += component.equipment[this.weaponEquip].attack;
		this.player.GetComponent<StatusC>().addDef += component.equipment[this.weaponEquip].defense;
		this.player.GetComponent<StatusC>().weaponMatk += component.equipment[this.weaponEquip].magicAttack;
		this.player.GetComponent<StatusC>().addMdef += component.equipment[this.weaponEquip].magicDefense;
		this.player.GetComponent<StatusC>().weaponAtk += component.equipment[this.armorEquip].attack;
		this.player.GetComponent<StatusC>().addDef += component.equipment[this.armorEquip].defense;
		this.player.GetComponent<StatusC>().weaponMatk += component.equipment[this.armorEquip].magicAttack;
		this.player.GetComponent<StatusC>().addMdef += component.equipment[this.armorEquip].magicDefense;
		this.player.GetComponent<StatusC>().CalculateStatus();
		this.AutoSortEquipment();
		this.AddEquipment(id2);
	}

	// Token: 0x060003A5 RID: 933 RVA: 0x000147A8 File Offset: 0x00012BA8
	public void RemoveWeaponMesh()
	{
		if (this.weapon.Length > 0 && this.weapon[0] != null)
		{
			int num = this.weapon.Length;
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

	// Token: 0x060003A6 RID: 934 RVA: 0x00014818 File Offset: 0x00012C18
	public void UnEquip(int id)
	{
		ItemDataC component = this.database.GetComponent<ItemDataC>();
		if (!this.player)
		{
			this.player = base.gameObject;
		}
		bool flag;
		if (component.equipment[id].model && this.weapon.Length > 0 && this.weapon[0] != null)
		{
			flag = this.AddEquipment(this.weaponEquip);
		}
		else
		{
			flag = this.AddEquipment(this.armorEquip);
		}
		if (!flag)
		{
			if (component.equipment[id].model && this.weapon.Length > 0 && this.weapon[0] != null)
			{
				this.weaponEquip = 0;
				this.player.GetComponent<AttackTriggerC>().attackPrefab = this.fistPrefab.transform;
				if (this.weapon.Length > 0 && this.weapon[0] != null)
				{
					int num = this.weapon.Length;
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
			this.player.GetComponent<StatusC>().addAtk = 0;
			this.player.GetComponent<StatusC>().addDef = 0;
			this.player.GetComponent<StatusC>().addMatk = 0;
			this.player.GetComponent<StatusC>().addMdef = 0;
			this.player.GetComponent<StatusC>().weaponAtk = 0;
			this.player.GetComponent<StatusC>().weaponMatk = 0;
			this.player.GetComponent<StatusC>().weaponAtk += component.equipment[this.weaponEquip].attack;
			this.player.GetComponent<StatusC>().addDef += component.equipment[this.weaponEquip].defense;
			this.player.GetComponent<StatusC>().weaponMatk += component.equipment[this.weaponEquip].magicAttack;
			this.player.GetComponent<StatusC>().addMdef += component.equipment[this.weaponEquip].magicDefense;
			this.player.GetComponent<StatusC>().weaponAtk += component.equipment[this.armorEquip].attack;
			this.player.GetComponent<StatusC>().addDef += component.equipment[this.armorEquip].defense;
			this.player.GetComponent<StatusC>().weaponMatk += component.equipment[this.armorEquip].magicAttack;
			this.player.GetComponent<StatusC>().addMdef += component.equipment[this.armorEquip].magicDefense;
		}
	}

	// Token: 0x060003A7 RID: 935 RVA: 0x00014B24 File Offset: 0x00012F24
	private void OnGUI()
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
			if (GUI.Button(new Rect(this.windowRect.x - 50f, this.windowRect.y + 105f, 50f, 100f), "Item"))
			{
				this.itemMenu = true;
				this.equipMenu = false;
			}
			if (GUI.Button(new Rect(this.windowRect.x - 50f, this.windowRect.y + 225f, 50f, 100f), "Equip"))
			{
				this.equipMenu = true;
				this.itemMenu = false;
			}
		}
	}

	// Token: 0x060003A8 RID: 936 RVA: 0x00014C58 File Offset: 0x00013058
	private void ItemWindow(int windowID)
	{
		ItemDataC component = this.database.GetComponent<ItemDataC>();
		if (this.menu && this.itemMenu)
		{
			if (GUI.Button(new Rect(250f, 2f, 30f, 30f), "X"))
			{
				this.OnOffMenu();
			}
			if (GUI.Button(new Rect(30f, 115f, 50f, 50f), new GUIContent(component.usableItem[this.itemSlot[0]].icon, component.usableItem[this.itemSlot[0]].itemName + "\n\n" + component.usableItem[this.itemSlot[0]].description)) && !component.usableItem[this.itemSlot[0]].unusable)
			{
				this.UseItem(this.itemSlot[0]);
				if (this.itemQuantity[0] > 0)
				{
					this.itemQuantity[0]--;
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
				GUI.Label(new Rect(70f, 150f, 20f, 20f), this.itemQuantity[0].ToString());
			}
			if (GUI.Button(new Rect(90f, 115f, 50f, 50f), new GUIContent(component.usableItem[this.itemSlot[1]].icon, component.usableItem[this.itemSlot[1]].itemName + "\n\n" + component.usableItem[this.itemSlot[1]].description)) && !component.usableItem[this.itemSlot[1]].unusable)
			{
				this.UseItem(this.itemSlot[1]);
				if (this.itemQuantity[1] > 0)
				{
					this.itemQuantity[1]--;
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
				GUI.Label(new Rect(130f, 150f, 20f, 20f), this.itemQuantity[1].ToString());
			}
			if (GUI.Button(new Rect(150f, 115f, 50f, 50f), new GUIContent(component.usableItem[this.itemSlot[2]].icon, component.usableItem[this.itemSlot[2]].itemName + "\n\n" + component.usableItem[this.itemSlot[2]].description)) && !component.usableItem[this.itemSlot[2]].unusable)
			{
				this.UseItem(this.itemSlot[2]);
				if (this.itemQuantity[2] > 0)
				{
					this.itemQuantity[2]--;
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
				GUI.Label(new Rect(190f, 150f, 20f, 20f), this.itemQuantity[2].ToString());
			}
			if (GUI.Button(new Rect(210f, 115f, 50f, 50f), new GUIContent(component.usableItem[this.itemSlot[3]].icon, component.usableItem[this.itemSlot[3]].itemName + "\n\n" + component.usableItem[this.itemSlot[3]].description)) && !component.usableItem[this.itemSlot[3]].unusable)
			{
				this.UseItem(this.itemSlot[3]);
				if (this.itemQuantity[3] > 0)
				{
					this.itemQuantity[3]--;
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
				GUI.Label(new Rect(250f, 150f, 20f, 20f), this.itemQuantity[3].ToString());
			}
			if (GUI.Button(new Rect(30f, 175f, 50f, 50f), new GUIContent(component.usableItem[this.itemSlot[4]].icon, component.usableItem[this.itemSlot[4]].itemName + "\n\n" + component.usableItem[this.itemSlot[4]].description)) && !component.usableItem[this.itemSlot[4]].unusable)
			{
				this.UseItem(this.itemSlot[4]);
				if (this.itemQuantity[4] > 0)
				{
					this.itemQuantity[4]--;
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
				GUI.Label(new Rect(70f, 210f, 20f, 20f), this.itemQuantity[4].ToString());
			}
			if (GUI.Button(new Rect(90f, 175f, 50f, 50f), new GUIContent(component.usableItem[this.itemSlot[5]].icon, component.usableItem[this.itemSlot[5]].itemName + "\n\n" + component.usableItem[this.itemSlot[5]].description)) && !component.usableItem[this.itemSlot[5]].unusable)
			{
				this.UseItem(this.itemSlot[5]);
				if (this.itemQuantity[5] > 0)
				{
					this.itemQuantity[5]--;
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
				GUI.Label(new Rect(130f, 210f, 20f, 20f), this.itemQuantity[5].ToString());
			}
			if (GUI.Button(new Rect(150f, 175f, 50f, 50f), new GUIContent(component.usableItem[this.itemSlot[6]].icon, component.usableItem[this.itemSlot[6]].itemName + "\n\n" + component.usableItem[this.itemSlot[6]].description)) && !component.usableItem[this.itemSlot[6]].unusable)
			{
				this.UseItem(this.itemSlot[6]);
				if (this.itemQuantity[6] > 0)
				{
					this.itemQuantity[6]--;
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
				GUI.Label(new Rect(190f, 210f, 20f, 20f), this.itemQuantity[6].ToString());
			}
			if (GUI.Button(new Rect(210f, 175f, 50f, 50f), new GUIContent(component.usableItem[this.itemSlot[7]].icon, component.usableItem[this.itemSlot[7]].itemName + "\n\n" + component.usableItem[this.itemSlot[7]].description)) && !component.usableItem[this.itemSlot[7]].unusable)
			{
				this.UseItem(this.itemSlot[7]);
				if (this.itemQuantity[7] > 0)
				{
					this.itemQuantity[7]--;
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
				GUI.Label(new Rect(250f, 210f, 20f, 20f), this.itemQuantity[7].ToString());
			}
			if (GUI.Button(new Rect(30f, 235f, 50f, 50f), new GUIContent(component.usableItem[this.itemSlot[8]].icon, component.usableItem[this.itemSlot[8]].itemName + "\n\n" + component.usableItem[this.itemSlot[8]].description)) && !component.usableItem[this.itemSlot[8]].unusable)
			{
				this.UseItem(this.itemSlot[8]);
				if (this.itemQuantity[8] > 0)
				{
					this.itemQuantity[8]--;
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
				GUI.Label(new Rect(70f, 270f, 20f, 20f), this.itemQuantity[8].ToString());
			}
			if (GUI.Button(new Rect(90f, 235f, 50f, 50f), new GUIContent(component.usableItem[this.itemSlot[9]].icon, component.usableItem[this.itemSlot[9]].itemName + "\n\n" + component.usableItem[this.itemSlot[9]].description)) && !component.usableItem[this.itemSlot[9]].unusable)
			{
				this.UseItem(this.itemSlot[9]);
				if (this.itemQuantity[9] > 0)
				{
					this.itemQuantity[9]--;
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
				GUI.Label(new Rect(130f, 270f, 20f, 20f), this.itemQuantity[9].ToString());
			}
			if (GUI.Button(new Rect(150f, 235f, 50f, 50f), new GUIContent(component.usableItem[this.itemSlot[10]].icon, component.usableItem[this.itemSlot[10]].itemName + "\n\n" + component.usableItem[this.itemSlot[10]].description)) && !component.usableItem[this.itemSlot[10]].unusable)
			{
				this.UseItem(this.itemSlot[10]);
				if (this.itemQuantity[10] > 0)
				{
					this.itemQuantity[10]--;
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
				GUI.Label(new Rect(190f, 270f, 20f, 20f), this.itemQuantity[10].ToString());
			}
			if (GUI.Button(new Rect(210f, 235f, 50f, 50f), new GUIContent(component.usableItem[this.itemSlot[11]].icon, component.usableItem[this.itemSlot[11]].itemName + "\n\n" + component.usableItem[this.itemSlot[11]].description)) && !component.usableItem[this.itemSlot[11]].unusable)
			{
				this.UseItem(this.itemSlot[11]);
				if (this.itemQuantity[11] > 0)
				{
					this.itemQuantity[11]--;
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
				GUI.Label(new Rect(250f, 270f, 20f, 20f), this.itemQuantity[11].ToString());
			}
			if (GUI.Button(new Rect(30f, 295f, 50f, 50f), new GUIContent(component.usableItem[this.itemSlot[12]].icon, component.usableItem[this.itemSlot[12]].itemName + "\n\n" + component.usableItem[this.itemSlot[12]].description)) && !component.usableItem[this.itemSlot[12]].unusable)
			{
				this.UseItem(this.itemSlot[12]);
				if (this.itemQuantity[12] > 0)
				{
					this.itemQuantity[12]--;
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
				GUI.Label(new Rect(70f, 330f, 20f, 20f), this.itemQuantity[12].ToString());
			}
			if (GUI.Button(new Rect(90f, 295f, 50f, 50f), new GUIContent(component.usableItem[this.itemSlot[13]].icon, component.usableItem[this.itemSlot[13]].itemName + "\n\n" + component.usableItem[this.itemSlot[13]].description)) && !component.usableItem[this.itemSlot[13]].unusable)
			{
				this.UseItem(this.itemSlot[13]);
				if (this.itemQuantity[13] > 0)
				{
					this.itemQuantity[13]--;
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
				GUI.Label(new Rect(130f, 330f, 20f, 20f), this.itemQuantity[13].ToString());
			}
			if (GUI.Button(new Rect(150f, 295f, 50f, 50f), new GUIContent(component.usableItem[this.itemSlot[14]].icon, component.usableItem[this.itemSlot[14]].itemName + "\n\n" + component.usableItem[this.itemSlot[14]].description)) && !component.usableItem[this.itemSlot[14]].unusable)
			{
				this.UseItem(this.itemSlot[14]);
				if (this.itemQuantity[14] > 0)
				{
					this.itemQuantity[14]--;
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
				GUI.Label(new Rect(190f, 330f, 20f, 20f), this.itemQuantity[14].ToString());
			}
			if (GUI.Button(new Rect(210f, 295f, 50f, 50f), new GUIContent(component.usableItem[this.itemSlot[15]].icon, component.usableItem[this.itemSlot[15]].itemName + "\n\n" + component.usableItem[this.itemSlot[15]].description)) && !component.usableItem[this.itemSlot[15]].unusable)
			{
				this.UseItem(this.itemSlot[15]);
				if (this.itemQuantity[15] > 0)
				{
					this.itemQuantity[15]--;
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
				GUI.Label(new Rect(250f, 330f, 20f, 20f), this.itemQuantity[15].ToString());
			}
			GUI.Label(new Rect(20f, 355f, 150f, 50f), "$ " + this.cash.ToString());
			GUI.Box(new Rect(20f, 30f, 240f, 60f), GUI.tooltip);
		}
		if (this.menu && this.equipMenu)
		{
			if (GUI.Button(new Rect(250f, 2f, 30f, 30f), "X"))
			{
				this.OnOffMenu();
			}
			GUI.Label(new Rect(20f, 130f, 150f, 50f), "Weapon");
			if (GUI.Button(new Rect(100f, 115f, 50f, 50f), new GUIContent(component.equipment[this.weaponEquip].icon, component.equipment[this.weaponEquip].itemName + "\n\n" + component.equipment[this.weaponEquip].description)))
			{
				if (!this.allowWeaponUnequip || this.weaponEquip == 0)
				{
					return;
				}
				this.UnEquip(this.weaponEquip);
			}
			GUI.Label(new Rect(20f, 190f, 150f, 50f), "Armor");
			if (GUI.Button(new Rect(100f, 175f, 50f, 50f), new GUIContent(component.equipment[this.armorEquip].icon, component.equipment[this.armorEquip].itemName + "\n\n" + component.equipment[this.armorEquip].description)))
			{
				if (!this.allowArmorUnequip || this.armorEquip == 0)
				{
					return;
				}
				this.UnEquip(this.armorEquip);
			}
			if (GUI.Button(new Rect(30f, 235f, 50f, 50f), new GUIContent(component.equipment[this.equipment[0]].icon, component.equipment[this.equipment[0]].itemName + "\n\n" + component.equipment[this.equipment[0]].description)))
			{
				this.EquipItem(this.equipment[0], 0);
			}
			if (GUI.Button(new Rect(90f, 235f, 50f, 50f), new GUIContent(component.equipment[this.equipment[1]].icon, component.equipment[this.equipment[1]].itemName + "\n\n" + component.equipment[this.equipment[1]].description)))
			{
				this.EquipItem(this.equipment[1], 1);
			}
			if (GUI.Button(new Rect(150f, 235f, 50f, 50f), new GUIContent(component.equipment[this.equipment[2]].icon, component.equipment[this.equipment[2]].itemName + "\n\n" + component.equipment[this.equipment[2]].description)))
			{
				this.EquipItem(this.equipment[2], 2);
			}
			if (GUI.Button(new Rect(210f, 235f, 50f, 50f), new GUIContent(component.equipment[this.equipment[3]].icon, component.equipment[this.equipment[3]].itemName + "\n\n" + component.equipment[this.equipment[3]].description)))
			{
				this.EquipItem(this.equipment[3], 3);
			}
			if (GUI.Button(new Rect(30f, 295f, 50f, 50f), new GUIContent(component.equipment[this.equipment[4]].icon, component.equipment[this.equipment[4]].itemName + "\n\n" + component.equipment[this.equipment[4]].description)))
			{
				this.EquipItem(this.equipment[4], 4);
			}
			if (GUI.Button(new Rect(90f, 295f, 50f, 50f), new GUIContent(component.equipment[this.equipment[5]].icon, component.equipment[this.equipment[5]].itemName + "\n\n" + component.equipment[this.equipment[5]].description)))
			{
				this.EquipItem(this.equipment[5], 5);
			}
			if (GUI.Button(new Rect(150f, 295f, 50f, 50f), new GUIContent(component.equipment[this.equipment[6]].icon, component.equipment[this.equipment[6]].itemName + "\n\n" + component.equipment[this.equipment[6]].description)))
			{
				this.EquipItem(this.equipment[6], 6);
			}
			if (GUI.Button(new Rect(210f, 295f, 50f, 50f), new GUIContent(component.equipment[this.equipment[7]].icon, component.equipment[this.equipment[7]].itemName + "\n\n" + component.equipment[this.equipment[7]].description)))
			{
				this.EquipItem(this.equipment[7], 7);
			}
			GUI.Label(new Rect(20f, 355f, 150f, 50f), "$ " + this.cash.ToString());
			GUI.Box(new Rect(20f, 30f, 240f, 60f), GUI.tooltip);
		}
		GUI.DragWindow(new Rect(0f, 0f, 10000f, 10000f));
	}

	// Token: 0x060003A9 RID: 937 RVA: 0x00016538 File Offset: 0x00014938
	public bool AddItem(int id, int quan)
	{
		bool result = false;
		bool flag = false;
		int num = 0;
		while (num < this.itemSlot.Length && !flag)
		{
			if (this.itemSlot[num] == id)
			{
				this.itemQuantity[num] += quan;
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

	// Token: 0x060003AA RID: 938 RVA: 0x000165D0 File Offset: 0x000149D0
	public bool AddEquipment(int id)
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

	// Token: 0x060003AB RID: 939 RVA: 0x00016638 File Offset: 0x00014A38
	public void AutoSortItem()
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

	// Token: 0x060003AC RID: 940 RVA: 0x000166E4 File Offset: 0x00014AE4
	public void AutoSortEquipment()
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

	// Token: 0x060003AD RID: 941 RVA: 0x00016778 File Offset: 0x00014B78
	private void OnOffMenu()
	{
		if (!this.menu && Time.timeScale != 0f)
		{
			this.menu = true;
			Time.timeScale = 0f;
			this.ResetPosition();
		}
		else if (this.menu)
		{
			this.menu = false;
			Time.timeScale = 1f;
		}
	}

	// Token: 0x060003AE RID: 942 RVA: 0x000167D8 File Offset: 0x00014BD8
	private void AssignWeaponAnimation(int id)
	{
		ItemDataC component = this.database.GetComponent<ItemDataC>();
		PlayerAnimationC component2 = this.player.GetComponent<PlayerAnimationC>();
		if (!component2)
		{
			this.AssignMecanimAnimation(id);
			return;
		}
		if (component.equipment[id].attackCombo.Length > 0 && component.equipment[id].attackCombo[0] != null && component.equipment[id].EquipmentType == ItemDataC.Equip.EqType.Weapon)
		{
			int num = component.equipment[id].attackCombo.Length;
			this.player.GetComponent<AttackTriggerC>().attackCombo = new AnimationClip[num];
			int i = 0;
			if (num > 0)
			{
				while (i < num)
				{
					this.player.GetComponent<AttackTriggerC>().attackCombo[i] = component.equipment[id].attackCombo[i];
					this.player.GetComponent<AttackTriggerC>().mainModel.GetComponent<Animation>()[component.equipment[id].attackCombo[i].name].layer = 15;
					i++;
				}
			}
			int whileAttack = (int)component.equipment[id].whileAttack;
			this.player.GetComponent<AttackTriggerC>().WhileAttackSet(whileAttack);
			this.player.GetComponent<AttackTriggerC>().attackSpeed = component.equipment[id].attackSpeed;
			this.player.GetComponent<AttackTriggerC>().atkDelay1 = component.equipment[id].attackDelay;
		}
		if (component.equipment[id].idleAnimation)
		{
			this.player.GetComponent<PlayerAnimationC>().idle = component.equipment[id].idleAnimation;
		}
		if (component.equipment[id].runAnimation)
		{
			component2.run = component.equipment[id].runAnimation;
		}
		if (component.equipment[id].rightAnimation)
		{
			component2.right = component.equipment[id].rightAnimation;
		}
		if (component.equipment[id].leftAnimation)
		{
			component2.left = component.equipment[id].leftAnimation;
		}
		if (component.equipment[id].backAnimation)
		{
			component2.back = component.equipment[id].backAnimation;
		}
		if (component.equipment[id].jumpAnimation)
		{
			this.player.GetComponent<PlayerAnimationC>().jump = component.equipment[id].jumpAnimation;
		}
		component2.AnimationSpeedSet();
	}

	// Token: 0x060003AF RID: 943 RVA: 0x00016A58 File Offset: 0x00014E58
	private void ResetPosition()
	{
		if (this.windowRect.x >= (float)(Screen.width - 30) || this.windowRect.y >= (float)(Screen.height - 30) || this.windowRect.x <= -70f || this.windowRect.y <= -70f)
		{
			this.windowRect = new Rect(260f, 140f, 280f, 385f);
		}
	}

	// Token: 0x060003B0 RID: 944 RVA: 0x00016AE0 File Offset: 0x00014EE0
	private void AssignMecanimAnimation(int id)
	{
		ItemDataC component = this.database.GetComponent<ItemDataC>();
		if (component.equipment[id].EquipmentType == ItemDataC.Equip.EqType.Weapon)
		{
			int whileAttack = (int)component.equipment[id].whileAttack;
			this.player.GetComponent<AttackTriggerC>().WhileAttackSet(whileAttack);
			this.player.GetComponent<AttackTriggerC>().attackSpeed = component.equipment[id].attackSpeed;
			this.player.GetComponent<AttackTriggerC>().atkDelay1 = component.equipment[id].attackDelay;
			this.player.GetComponent<PlayerMecanimAnimationC>().SetWeaponType(component.equipment[id].weaponType, component.equipment[id].idleAnimation.name);
			int num = component.equipment[id].attackCombo.Length;
			this.player.GetComponent<AttackTriggerC>().attackCombo = new AnimationClip[num];
			int i = 0;
			if (num > 0)
			{
				while (i < num)
				{
					this.player.GetComponent<AttackTriggerC>().attackCombo[i] = component.equipment[id].attackCombo[i];
					i++;
				}
			}
		}
	}

	// Token: 0x060003B1 RID: 945 RVA: 0x00016BF4 File Offset: 0x00014FF4
	public bool CheckItem(int id, int type, int qty)
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

	// Token: 0x060003B2 RID: 946 RVA: 0x00016C8C File Offset: 0x0001508C
	public int FindItemSlot(int id)
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

	// Token: 0x060003B3 RID: 947 RVA: 0x00016CF4 File Offset: 0x000150F4
	public int FindEquipmentSlot(int id)
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

	// Token: 0x060003B4 RID: 948 RVA: 0x00016D5C File Offset: 0x0001515C
	public bool RemoveItem(int id, int amount)
	{
		bool result = false;
		int num = this.FindItemSlot(id);
		if (num < this.itemSlot.Length)
		{
			if (this.itemQuantity[num] > 0)
			{
				this.itemQuantity[num] -= amount;
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

	// Token: 0x060003B5 RID: 949 RVA: 0x00016DCC File Offset: 0x000151CC
	public bool RemoveEquipment(int id)
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

	// Token: 0x040002E2 RID: 738
	private bool menu;

	// Token: 0x040002E3 RID: 739
	private bool itemMenu = true;

	// Token: 0x040002E4 RID: 740
	private bool equipMenu;

	// Token: 0x040002E5 RID: 741
	public int[] itemSlot = new int[16];

	// Token: 0x040002E6 RID: 742
	public int[] itemQuantity = new int[16];

	// Token: 0x040002E7 RID: 743
	public int[] equipment = new int[8];

	// Token: 0x040002E8 RID: 744
	public int weaponEquip;

	// Token: 0x040002E9 RID: 745
	public bool allowWeaponUnequip;

	// Token: 0x040002EA RID: 746
	public int armorEquip;

	// Token: 0x040002EB RID: 747
	public bool allowArmorUnequip = true;

	// Token: 0x040002EC RID: 748
	public GameObject[] weapon = new GameObject[1];

	// Token: 0x040002ED RID: 749
	public GameObject player;

	// Token: 0x040002EE RID: 750
	public GameObject database;

	// Token: 0x040002EF RID: 751
	public GameObject fistPrefab;

	// Token: 0x040002F0 RID: 752
	public int cash = 500;

	// Token: 0x040002F1 RID: 753
	public GUISkin skin;

	// Token: 0x040002F2 RID: 754
	public Rect windowRect = new Rect(260f, 140f, 280f, 385f);
}
