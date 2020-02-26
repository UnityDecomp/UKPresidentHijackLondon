using System;
using UnityEngine;

// Token: 0x020001D4 RID: 468
public class AreaSpawner : MonoBehaviour
{
	// Token: 0x06000C2C RID: 3116 RVA: 0x0004CFCA File Offset: 0x0004B3CA
	private void Start()
	{
		this.farmAnimals.SetActive(false);
		this.jungleAnimals.SetActive(false);
		this.hillAnimals.SetActive(false);
		this.waterAnimals.SetActive(false);
		this.jungle2Animals.SetActive(false);
	}

	// Token: 0x06000C2D RID: 3117 RVA: 0x0004D008 File Offset: 0x0004B408
	private void Update()
	{
	}

	// Token: 0x06000C2E RID: 3118 RVA: 0x0004D00C File Offset: 0x0004B40C
	private void OnTriggerEnter(Collider other)
	{
		string name = other.gameObject.name;
		if (name != null)
		{
			if (!(name == "Farm Collider"))
			{
				if (!(name == "Jungle Collider"))
				{
					if (!(name == "Jungle Collider2"))
					{
						if (!(name == "Hill Collider"))
						{
							if (name == "Water Collider")
							{
								this.waterAnimals.SetActive(true);
								this.farmAnimals.SetActive(false);
								this.jungleAnimals.SetActive(false);
								this.hillAnimals.SetActive(false);
								Debug.Log("spawn water animals");
							}
						}
						else
						{
							this.hillAnimals.SetActive(true);
							this.farmAnimals.SetActive(false);
							this.jungleAnimals.SetActive(false);
							this.waterAnimals.SetActive(false);
							Debug.Log("spawn Hill animals");
						}
					}
					else
					{
						this.jungleAnimals.SetActive(true);
						this.farmAnimals.SetActive(false);
						this.hillAnimals.SetActive(false);
						this.waterAnimals.SetActive(false);
					}
				}
				else
				{
					this.jungle2Animals.SetActive(true);
					this.farmAnimals.SetActive(false);
					this.hillAnimals.SetActive(false);
					this.waterAnimals.SetActive(false);
				}
			}
			else
			{
				this.farmAnimals.SetActive(true);
				this.jungleAnimals.SetActive(false);
				this.hillAnimals.SetActive(false);
				this.waterAnimals.SetActive(false);
				Debug.Log("spawn farm animals");
			}
		}
	}

	// Token: 0x04000C8F RID: 3215
	public GameObject farmAnimals;

	// Token: 0x04000C90 RID: 3216
	public GameObject jungleAnimals;

	// Token: 0x04000C91 RID: 3217
	public GameObject jungle2Animals;

	// Token: 0x04000C92 RID: 3218
	public GameObject hillAnimals;

	// Token: 0x04000C93 RID: 3219
	public GameObject waterAnimals;
}
