using System;
using System.Collections;
using UnityEngine;

// Token: 0x020001DC RID: 476
public class CollectionQuest : MonoBehaviour
{
	// Token: 0x06000C5E RID: 3166 RVA: 0x0004E4A0 File Offset: 0x0004C8A0
	private void Start()
	{
	}

	// Token: 0x06000C5F RID: 3167 RVA: 0x0004E4A2 File Offset: 0x0004C8A2
	private void Update()
	{
	}

	// Token: 0x06000C60 RID: 3168 RVA: 0x0004E4A4 File Offset: 0x0004C8A4
	public void gotOne(GameObject obj)
	{
		UnityEngine.Object.Destroy(obj);
		if (this.counter < this.positions.Length)
		{
			UnityEngine.Object.Instantiate<GameObject>(this.Meat, this.positions[this.counter].transform.position, Quaternion.identity);
			base.GetComponent<QuestManager>().setArrowDirection(this.positions[this.counter].transform);
			this.counter++;
		}
	}

	// Token: 0x06000C61 RID: 3169 RVA: 0x0004E51D File Offset: 0x0004C91D
	public void StartQuest()
	{
		base.StartCoroutine(this.starter());
	}

	// Token: 0x06000C62 RID: 3170 RVA: 0x0004E52C File Offset: 0x0004C92C
	private IEnumerator starter()
	{
		yield return new WaitForSeconds(1f);
		this.counter = 0;
		base.GetComponent<QuestManager>().setArrowDirection(this.positions[0].transform);
		UnityEngine.Object.Instantiate<GameObject>(this.Meat, this.positions[this.counter].transform.position, Quaternion.identity);
		this.counter++;
		yield break;
	}

	// Token: 0x06000C63 RID: 3171 RVA: 0x0004E547 File Offset: 0x0004C947
	public void removeOnTimeUp()
	{
	}

	// Token: 0x04000CCE RID: 3278
	public GameObject Meat;

	// Token: 0x04000CCF RID: 3279
	public Transform[] positions;

	// Token: 0x04000CD0 RID: 3280
	private int counter;
}
