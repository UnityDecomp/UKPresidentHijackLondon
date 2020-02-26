using System;
using UnityEngine;

// Token: 0x02000007 RID: 7
[Serializable]
public class AddSkill : MonoBehaviour
{
	// Token: 0x06000011 RID: 17 RVA: 0x000025AC File Offset: 0x000007AC
	public AddSkill()
	{
		this.skillID = 1;
		this.learnType = progressType.Trigger;
	}

	// Token: 0x06000012 RID: 18 RVA: 0x000025C4 File Offset: 0x000007C4
	public virtual void Start()
	{
		if (this.learnType == progressType.Auto)
		{
			GameObject gameObject = GameObject.FindWithTag("Player");
			((SkillWindow)gameObject.GetComponent(typeof(SkillWindow))).AddSkill(this.skillID);
			UnityEngine.Object.Destroy(this.gameObject);
		}
	}

	// Token: 0x06000013 RID: 19 RVA: 0x00002614 File Offset: 0x00000814
	public virtual void OnTriggerEnter(Collider other)
	{
		if (other.gameObject.tag == "Player" && this.learnType == progressType.Trigger)
		{
			((SkillWindow)other.GetComponent(typeof(SkillWindow))).AddSkill(this.skillID);
			UnityEngine.Object.Destroy(this.gameObject);
		}
	}

	// Token: 0x06000014 RID: 20 RVA: 0x00002674 File Offset: 0x00000874
	public virtual void Main()
	{
	}

	// Token: 0x04000019 RID: 25
	public int skillID;

	// Token: 0x0400001A RID: 26
	public progressType learnType;
}
