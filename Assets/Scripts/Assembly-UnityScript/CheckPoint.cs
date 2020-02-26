using System;
using UnityEngine;

// Token: 0x02000035 RID: 53
[Serializable]
public class CheckPoint : MonoBehaviour
{
	// Token: 0x06000099 RID: 153 RVA: 0x00007E84 File Offset: 0x00006084
	public virtual void OnTriggerEnter(Collider other)
	{
		if (other.gameObject.tag == "Player")
		{
			this.player = other.gameObject;
			this.SaveData();
		}
	}

	// Token: 0x0600009A RID: 154 RVA: 0x00007EC0 File Offset: 0x000060C0
	public virtual void SaveData()
	{
		PlayerPrefs.SetInt("PreviousSave", 10);
		PlayerPrefs.SetFloat("PlayerX", this.player.transform.position.x);
		PlayerPrefs.SetFloat("PlayerY", this.player.transform.position.y);
		PlayerPrefs.SetFloat("PlayerZ", this.player.transform.position.z);
		MonoBehaviour.print("Saved");
	}

	// Token: 0x0600009B RID: 155 RVA: 0x00007F4C File Offset: 0x0000614C
	public virtual void Main()
	{
	}

	// Token: 0x04000133 RID: 307
	private GameObject player;
}
