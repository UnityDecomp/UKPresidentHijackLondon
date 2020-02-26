using System;
using UnityEngine;

// Token: 0x02000056 RID: 86
[Serializable]
public class Equip
{
	// Token: 0x06000119 RID: 281 RVA: 0x0000F1F4 File Offset: 0x0000D3F4
	public Equip()
	{
		this.itemName = string.Empty;
		this.assignAllWeapon = true;
		this.description = string.Empty;
		this.price = 10;
		this.attack = 5;
		this.EquipmentType = Equip.EqType.Weapon;
		this.attackCombo = new AnimationClip[3];
		this.whileAttack = Equip.whileAtk.MeleeFwd;
		this.attackSpeed = 0.18f;
		this.attackDelay = 0.12f;
	}

	// Token: 0x040001E9 RID: 489
	public string itemName;

	// Token: 0x040001EA RID: 490
	public Texture2D icon;

	// Token: 0x040001EB RID: 491
	public GameObject model;

	// Token: 0x040001EC RID: 492
	public bool assignAllWeapon;

	// Token: 0x040001ED RID: 493
	public string description;

	// Token: 0x040001EE RID: 494
	public int price;

	// Token: 0x040001EF RID: 495
	public int weaponType;

	// Token: 0x040001F0 RID: 496
	public int attack;

	// Token: 0x040001F1 RID: 497
	public int defense;

	// Token: 0x040001F2 RID: 498
	public int magicAttack;

	// Token: 0x040001F3 RID: 499
	public int magicDefense;

	// Token: 0x040001F4 RID: 500
	public Equip.EqType EquipmentType;

	// Token: 0x040001F5 RID: 501
	public GameObject attackPrefab;

	// Token: 0x040001F6 RID: 502
	public AnimationClip[] attackCombo;

	// Token: 0x040001F7 RID: 503
	public AnimationClip idleAnimation;

	// Token: 0x040001F8 RID: 504
	public AnimationClip runAnimation;

	// Token: 0x040001F9 RID: 505
	public AnimationClip rightAnimation;

	// Token: 0x040001FA RID: 506
	public AnimationClip leftAnimation;

	// Token: 0x040001FB RID: 507
	public AnimationClip backAnimation;

	// Token: 0x040001FC RID: 508
	public AnimationClip jumpAnimation;

	// Token: 0x040001FD RID: 509
	public Equip.whileAtk whileAttack;

	// Token: 0x040001FE RID: 510
	public float attackSpeed;

	// Token: 0x040001FF RID: 511
	public float attackDelay;

	// Token: 0x02000057 RID: 87
	[Serializable]
	public enum EqType
	{
		// Token: 0x04000201 RID: 513
		Weapon,
		// Token: 0x04000202 RID: 514
		Armor
	}

	// Token: 0x02000058 RID: 88
	[Serializable]
	public enum whileAtk
	{
		// Token: 0x04000204 RID: 516
		MeleeFwd,
		// Token: 0x04000205 RID: 517
		Immobile,
		// Token: 0x04000206 RID: 518
		WalkFree
	}
}
