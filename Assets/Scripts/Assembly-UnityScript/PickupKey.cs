using System;
using UnityEngine;

// Token: 0x02000045 RID: 69
[Serializable]
public class PickupKey : MonoBehaviour
{
	// Token: 0x060000D3 RID: 211 RVA: 0x0000A508 File Offset: 0x00008708
	public virtual void OnTriggerEnter(Collider other)
	{
		if (other.gameObject.tag == "Player")
		{
			((Gate)this.mainGate.GetComponent(typeof(Gate))).key = ((Gate)this.mainGate.GetComponent(typeof(Gate))).key + 1;
			UnityEngine.Object.Destroy(this.gameObject);
		}
	}

	// Token: 0x060000D4 RID: 212 RVA: 0x0000A57C File Offset: 0x0000877C
	public virtual void Main()
	{
	}

	// Token: 0x04000184 RID: 388
	public GameObject mainGate;
}
