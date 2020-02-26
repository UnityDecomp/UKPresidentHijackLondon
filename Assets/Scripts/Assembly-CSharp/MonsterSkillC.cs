using System;
using System.Collections;
using UnityEngine;

// Token: 0x02000076 RID: 118
[RequireComponent(typeof(AIsetC))]
public class MonsterSkillC : MonoBehaviour
{
	// Token: 0x060003C3 RID: 963 RVA: 0x0001703F File Offset: 0x0001543F
	private void Start()
	{
		if (!this.mainModel)
		{
			this.mainModel = base.gameObject;
		}
		base.StartCoroutine("Begin");
	}

	// Token: 0x060003C4 RID: 964 RVA: 0x0001706C File Offset: 0x0001546C
	private IEnumerator Begin()
	{
		yield return new WaitForSeconds(1.5f);
		this.begin = true;
		yield break;
	}

	// Token: 0x060003C5 RID: 965 RVA: 0x00017088 File Offset: 0x00015488
	private void Update()
	{
		if (this.begin && !this.onSkill)
		{
			if (this.wait >= this.delay)
			{
				base.StartCoroutine("UseSkill");
				this.wait = 0f;
			}
			else
			{
				this.wait += Time.deltaTime;
			}
		}
	}

	// Token: 0x060003C6 RID: 966 RVA: 0x000170EC File Offset: 0x000154EC
	private IEnumerator UseSkill()
	{
		if (this.useSkill && !base.GetComponent<StatusC>().freeze)
		{
			AIsetC ai = base.GetComponent<AIsetC>();
			int c = 0;
			if (this.skillSet.Length > 1)
			{
				c = UnityEngine.Random.Range(0, this.skillSet.Length);
			}
			this.onSkill = true;
			if (this.skillSet[c].castEffect)
			{
				this.eff = UnityEngine.Object.Instantiate<GameObject>(this.skillSet[c].castEffect, this.mainModel.transform.position, this.mainModel.transform.rotation);
				this.eff.transform.parent = base.transform;
			}
			ai.ActivateSkill(this.skillSet[c].skillPrefab, this.skillSet[c].castTime, this.skillSet[c].delayTime, this.skillSet[c].skillAnimation.name, this.skillDistance);
			yield return new WaitForSeconds(this.skillSet[c].castTime);
			if (this.eff)
			{
				UnityEngine.Object.Destroy(this.eff);
			}
			yield return new WaitForSeconds(this.skillSet[c].delayTime);
			this.onSkill = false;
		}
		yield break;
	}

	// Token: 0x04000322 RID: 802
	public GameObject mainModel;

	// Token: 0x04000323 RID: 803
	public float skillDistance = 4.5f;

	// Token: 0x04000324 RID: 804
	public float delay = 2f;

	// Token: 0x04000325 RID: 805
	private bool begin;

	// Token: 0x04000326 RID: 806
	private bool onSkill;

	// Token: 0x04000327 RID: 807
	public bool useSkill;

	// Token: 0x04000328 RID: 808
	private float wait;

	// Token: 0x04000329 RID: 809
	private GameObject eff;

	// Token: 0x0400032A RID: 810
	public MonsterSkillC.SkillSetting[] skillSet = new MonsterSkillC.SkillSetting[1];

	// Token: 0x02000077 RID: 119
	[Serializable]
	public class SkillSetting
	{
		// Token: 0x0400032B RID: 811
		public string skillName;

		// Token: 0x0400032C RID: 812
		public Transform skillPrefab;

		// Token: 0x0400032D RID: 813
		public AnimationClip skillAnimation;

		// Token: 0x0400032E RID: 814
		public GameObject castEffect;

		// Token: 0x0400032F RID: 815
		public float castTime = 0.5f;

		// Token: 0x04000330 RID: 816
		public float delayTime = 1.5f;
	}
}
