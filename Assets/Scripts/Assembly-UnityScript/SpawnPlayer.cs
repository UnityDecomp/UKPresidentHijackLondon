using System;
using UnityEngine;

// Token: 0x0200008C RID: 140
[Serializable]
public class SpawnPlayer : MonoBehaviour
{
	// Token: 0x060001EA RID: 490 RVA: 0x00019068 File Offset: 0x00017268
	public virtual void Start()
	{
		GameObject gameObject = GameObject.FindWithTag("Player");
		if (gameObject)
		{
			string spawnPointName = ((Status)gameObject.GetComponent(typeof(Status))).spawnPointName;
			GameObject gameObject2 = GameObject.Find(spawnPointName);
			if (gameObject2)
			{
				gameObject.transform.position = gameObject2.transform.position;
				gameObject.transform.rotation = gameObject2.transform.rotation;
			}
			GameObject gameObject3 = ((AttackTrigger)gameObject.GetComponent(typeof(AttackTrigger))).Maincam.gameObject;
			if (gameObject3)
			{
				GameObject[] array = GameObject.FindGameObjectsWithTag("MainCamera");
				int i = 0;
				GameObject[] array2 = array;
				int length = array2.Length;
				while (i < length)
				{
					if (array2[i] != gameObject3)
					{
						UnityEngine.Object.Destroy(array2[i].gameObject);
					}
					i++;
				}
			}
		}
		else
		{
			GameObject gameObject4 = UnityEngine.Object.Instantiate<GameObject>(this.player, this.transform.position, this.transform.rotation);
			this.mainCam = GameObject.FindWithTag("MainCamera").transform;
			ARPGcamera exists = (ARPGcamera)this.mainCam.GetComponent(typeof(ARPGcamera));
			if (this.mainCam && exists)
			{
				((ARPGcamera)this.mainCam.GetComponent(typeof(ARPGcamera))).target = gameObject4.transform;
			}
			Screen.lockCursor = true;
		}
	}

	// Token: 0x060001EB RID: 491 RVA: 0x00019204 File Offset: 0x00017404
	public virtual void Main()
	{
	}

	// Token: 0x0400032A RID: 810
	public GameObject player;

	// Token: 0x0400032B RID: 811
	private Transform mainCam;
}
