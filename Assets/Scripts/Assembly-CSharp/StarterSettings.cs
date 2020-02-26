using System;
using UnityEngine;

// Token: 0x0200020E RID: 526
public class StarterSettings : MonoBehaviour
{
	// Token: 0x06000D97 RID: 3479 RVA: 0x00056C7C File Offset: 0x0005507C
	private void Start()
	{
		for (int i = 0; i < 7; i++)
		{
			GameObject gameObject = this.FoodPoints.transform.GetChild(i).gameObject;
			UnityEngine.Object.Instantiate<GameObject>(this.Mushrooms[0], gameObject.transform.position, gameObject.transform.rotation);
		}
	}

	// Token: 0x06000D98 RID: 3480 RVA: 0x00056CD6 File Offset: 0x000550D6
	private void Update()
	{
	}

	// Token: 0x04000E4C RID: 3660
	public GameObject[] Mushrooms;

	// Token: 0x04000E4D RID: 3661
	public GameObject FoodPoints;
}
