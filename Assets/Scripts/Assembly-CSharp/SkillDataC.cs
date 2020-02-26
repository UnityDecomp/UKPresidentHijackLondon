using System;
using UnityEngine;

// Token: 0x0200008D RID: 141
public class SkillDataC : MonoBehaviour
{
	// Token: 0x04000427 RID: 1063
	public SkillDataC.Skil[] skill = new SkillDataC.Skil[3];

	// Token: 0x0200008E RID: 142
	[Serializable]
	public class Skil
	{
		// Token: 0x04000428 RID: 1064
		public string skillName = string.Empty;

		// Token: 0x04000429 RID: 1065
		public Texture2D icon;

		// Token: 0x0400042A RID: 1066
		public Transform skillPrefab;

		// Token: 0x0400042B RID: 1067
		public AnimationClip skillAnimation;

		// Token: 0x0400042C RID: 1068
		public int manaCost = 10;

		// Token: 0x0400042D RID: 1069
		public string description = string.Empty;
	}
}
