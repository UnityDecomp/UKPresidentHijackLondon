using System;
using System.Collections;
using UnityEngine;

// Token: 0x02000207 RID: 519
public class ResourceStatus : MonoBehaviour
{
	// Token: 0x06000D7E RID: 3454 RVA: 0x000564F7 File Offset: 0x000548F7
	private void Start()
	{
		if (this.resourceType == ResourceStatus.ResourceType.Tree && base.GetComponent<Rigidbody>())
		{
			base.GetComponent<Rigidbody>().useGravity = false;
		}
	}

	// Token: 0x06000D7F RID: 3455 RVA: 0x00056521 File Offset: 0x00054921
	private void Update()
	{
	}

	// Token: 0x06000D80 RID: 3456 RVA: 0x00056524 File Offset: 0x00054924
	private void OnTriggerEnter(Collider other)
	{
		if (other.gameObject.name == "Melee" || other.gameObject.name == "Melee(Clone)")
		{
			if (!this.allow)
			{
				return;
			}
			this.health--;
			if (this.health <= 0)
			{
				this.checkAndExecute();
				if (this.destroy)
				{
					base.StartCoroutine(this.delay());
				}
				else
				{
					UnityEngine.Object.Destroy(base.GetComponent<ResourceStatus>());
				}
			}
		}
	}

	// Token: 0x06000D81 RID: 3457 RVA: 0x000565BC File Offset: 0x000549BC
	private void checkAndExecute()
	{
		if (this.resourceType == ResourceStatus.ResourceType.Tree && base.GetComponent<Rigidbody>())
		{
			base.GetComponent<Rigidbody>().useGravity = true;
		}
		if (this.resourceType == ResourceStatus.ResourceType.Box)
		{
		}
		if (this.dropItem)
		{
			for (int i = 0; i < this.dropAmount; i++)
			{
				UnityEngine.Object.Instantiate<GameObject>(this.dropItem, new Vector3(base.transform.position.x, base.transform.position.y + 5f, base.transform.position.z), Quaternion.identity);
			}
		}
		this.allow = false;
		base.GetComponent<ResourceStatus>().enabled = false;
	}

	// Token: 0x06000D82 RID: 3458 RVA: 0x0005668C File Offset: 0x00054A8C
	private IEnumerator delay()
	{
		yield return new WaitForSeconds(this.destroyTime);
		UnityEngine.Object.Destroy(base.gameObject);
		yield break;
	}

	// Token: 0x04000E2D RID: 3629
	public int health = 4;

	// Token: 0x04000E2E RID: 3630
	public ResourceStatus.ResourceType resourceType;

	// Token: 0x04000E2F RID: 3631
	private bool allow = true;

	// Token: 0x04000E30 RID: 3632
	[Header("Item Drop")]
	public GameObject dropItem;

	// Token: 0x04000E31 RID: 3633
	public int dropAmount = 2;

	// Token: 0x04000E32 RID: 3634
	[Header("Destroy")]
	public bool destroy = true;

	// Token: 0x04000E33 RID: 3635
	public float destroyTime = 2f;

	// Token: 0x02000208 RID: 520
	public enum ResourceType
	{
		// Token: 0x04000E35 RID: 3637
		Box,
		// Token: 0x04000E36 RID: 3638
		Tree
	}
}
