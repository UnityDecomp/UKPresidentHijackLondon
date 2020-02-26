using System;
using UnityEngine;

// Token: 0x020001FE RID: 510
public class PurchaseManager : MonoBehaviour
{
	// Token: 0x06000D03 RID: 3331 RVA: 0x000519DC File Offset: 0x0004FDDC
	private void Start()
	{
	}

	// Token: 0x06000D04 RID: 3332 RVA: 0x000519E0 File Offset: 0x0004FDE0
	private void Update()
	{
		if (Input.GetKeyDown(KeyCode.J))
		{
			this.ResetItemDatabase();
		}
		if (Input.GetKeyDown(KeyCode.E))
		{
			int num = PlayerPrefs.GetInt("TotalScore");
			num += 500;
			PlayerPrefs.SetInt("TotalScore", num);
			base.GetComponent<gameplay>().score.text = PlayerPrefs.GetInt("TotalScore").ToString();
		}
	}

	// Token: 0x06000D05 RID: 3333 RVA: 0x00051A54 File Offset: 0x0004FE54
	public void InitializeItems(GameObject[] theItems)
	{
		this.items = new GameObject[theItems.Length];
		for (int i = 0; i < this.items.Length; i++)
		{
			this.items[i] = theItems[i];
		}
		this.FirstItemSetting();
		for (int j = 0; j < this.items.Length; j++)
		{
			if (!this.items[j].GetComponent<ItemEntity>())
			{
				MonoBehaviour.print("<color=red> Item : " + this.items[j].name + " not identified. Purchase execution stopped </color>");
				break;
			}
			this.SetStatus(this.items[j]);
		}
	}

	// Token: 0x06000D06 RID: 3334 RVA: 0x00051B04 File Offset: 0x0004FF04
	private void FirstItemSetting()
	{
		int itemID = this.items[0].GetComponent<ItemEntity>().itemID;
		string key = "Item" + itemID.ToString();
		PlayerPrefs.SetInt(key, 1);
	}

	// Token: 0x06000D07 RID: 3335 RVA: 0x00051B44 File Offset: 0x0004FF44
	private void SetStatus(GameObject item)
	{
		int itemID = item.GetComponent<ItemEntity>().itemID;
		string text = "Item" + itemID.ToString();
		if (PlayerPrefs.GetInt(text) == 1)
		{
			item.GetComponent<ItemEntity>().status = "YES";
			MonoBehaviour.print("is already Bought " + text);
		}
		else
		{
			PlayerPrefs.SetInt(text, 0);
			MonoBehaviour.print("Created new prefs for " + text);
			item.GetComponent<ItemEntity>().status = "NO";
		}
	}

	// Token: 0x06000D08 RID: 3336 RVA: 0x00051BCD File Offset: 0x0004FFCD
	public string GetItemStatus(GameObject item)
	{
		return item.GetComponent<ItemEntity>().status;
	}

	// Token: 0x06000D09 RID: 3337 RVA: 0x00051BDC File Offset: 0x0004FFDC
	public void UnlockItem(GameObject item)
	{
		if (item.GetComponent<ItemEntity>())
		{
			int itemID = item.GetComponent<ItemEntity>().itemID;
			string key = "Item" + itemID.ToString();
			item.GetComponent<ItemEntity>().status = "YES";
			PlayerPrefs.SetInt(key, 1);
		}
		else
		{
			MonoBehaviour.print("<color=red> Item : " + item.name + " not identified </color>");
		}
	}

	// Token: 0x06000D0A RID: 3338 RVA: 0x00051C54 File Offset: 0x00050054
	public bool PurchaseItem(GameObject item)
	{
		int num = PlayerPrefs.GetInt("TotalScore");
		if (num >= item.GetComponent<ItemEntity>().price)
		{
			num -= item.GetComponent<ItemEntity>().price;
			PlayerPrefs.SetInt("TotalScore", num);
			base.GetComponent<gameplay>().score.text = PlayerPrefs.GetInt("TotalScore").ToString();
			this.UnlockItem(item);
			return true;
		}
		return false;
	}

	// Token: 0x06000D0B RID: 3339 RVA: 0x00051CC8 File Offset: 0x000500C8
	private void ResetItemDatabase()
	{
		for (int i = 0; i < this.items.Length; i++)
		{
			int itemID = this.items[i].GetComponent<ItemEntity>().itemID;
			string text = "Item" + itemID.ToString();
			if (PlayerPrefs.GetInt(text) == 1)
			{
				PlayerPrefs.DeleteKey(text);
				this.items[i].GetComponent<ItemEntity>().status = "NO";
				MonoBehaviour.print(text + " is deleted");
			}
		}
		PlayerPrefs.SetInt("TotalScore", 0);
	}

	// Token: 0x04000D8B RID: 3467
	public GameObject[] items;
}
