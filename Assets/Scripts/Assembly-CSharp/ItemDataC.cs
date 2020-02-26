using System;
using UnityEngine;

// Token: 0x0200006E RID: 110
public class ItemDataC : MonoBehaviour
{
	// Token: 0x040002F3 RID: 755
	public ItemDataC.Usable[] usableItem = new ItemDataC.Usable[3];

	// Token: 0x040002F4 RID: 756
	public ItemDataC.Equip[] equipment = new ItemDataC.Equip[3];

	// Token: 0x0200006F RID: 111
	[Serializable]
	public class Usable
	{
		// Token: 0x040002F5 RID: 757
		public string itemName = string.Empty;

		// Token: 0x040002F6 RID: 758
		public Texture2D icon;

		// Token: 0x040002F7 RID: 759
		public GameObject model;

		// Token: 0x040002F8 RID: 760
		public string description = string.Empty;

		// Token: 0x040002F9 RID: 761
		public int price = 10;

		// Token: 0x040002FA RID: 762
		public int hpRecover;

		// Token: 0x040002FB RID: 763
		public int mpRecover;

		// Token: 0x040002FC RID: 764
		public int atkPlus;

		// Token: 0x040002FD RID: 765
		public int defPlus;

		// Token: 0x040002FE RID: 766
		public int matkPlus;

		// Token: 0x040002FF RID: 767
		public int mdefPlus;

		// Token: 0x04000300 RID: 768
		public bool unusable;
	}

	// Token: 0x02000070 RID: 112
	[Serializable]
	public class Equip
	{
		// Token: 0x04000301 RID: 769
		public string itemName = string.Empty;

		// Token: 0x04000302 RID: 770
		public Texture2D icon;

		// Token: 0x04000303 RID: 771
		public GameObject model;

		// Token: 0x04000304 RID: 772
		public bool assignAllWeapon = true;

		// Token: 0x04000305 RID: 773
		public string description = string.Empty;

		// Token: 0x04000306 RID: 774
		public int price = 10;

		// Token: 0x04000307 RID: 775
		public int weaponType;

		// Token: 0x04000308 RID: 776
		public int attack = 5;

		// Token: 0x04000309 RID: 777
		public int defense;

		// Token: 0x0400030A RID: 778
		public int magicAttack;

		// Token: 0x0400030B RID: 779
		public int magicDefense;

		// Token: 0x0400030C RID: 780
		public ItemDataC.Equip.EqType EquipmentType;

		// Token: 0x0400030D RID: 781
		public GameObject attackPrefab;

		// Token: 0x0400030E RID: 782
		public AnimationClip[] attackCombo = new AnimationClip[3];

		// Token: 0x0400030F RID: 783
		public AnimationClip idleAnimation;

		// Token: 0x04000310 RID: 784
		public AnimationClip runAnimation;

		// Token: 0x04000311 RID: 785
		public AnimationClip rightAnimation;

		// Token: 0x04000312 RID: 786
		public AnimationClip leftAnimation;

		// Token: 0x04000313 RID: 787
		public AnimationClip backAnimation;

		// Token: 0x04000314 RID: 788
		public AnimationClip jumpAnimation;

		// Token: 0x04000315 RID: 789
		public ItemDataC.Equip.whileAtk whileAttack;

		// Token: 0x04000316 RID: 790
		public float attackSpeed = 0.18f;

		// Token: 0x04000317 RID: 791
		public float attackDelay = 0.12f;

		// Token: 0x02000071 RID: 113
		public enum EqType
		{
			// Token: 0x04000319 RID: 793
			Weapon,
			// Token: 0x0400031A RID: 794
			Armor
		}

		// Token: 0x02000072 RID: 114
		public enum whileAtk
		{
			// Token: 0x0400031C RID: 796
			MeleeFwd,
			// Token: 0x0400031D RID: 797
			Immobile,
			// Token: 0x0400031E RID: 798
			WalkFree
		}
	}
}
