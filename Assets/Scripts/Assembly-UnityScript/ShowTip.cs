using System;
using UnityEngine;

// Token: 0x02000084 RID: 132
[Serializable]
public class ShowTip : MonoBehaviour
{
	// Token: 0x060001CC RID: 460 RVA: 0x00017CB8 File Offset: 0x00015EB8
	public ShowTip()
	{
		this.show = true;
	}

	// Token: 0x060001CD RID: 461 RVA: 0x00017CC8 File Offset: 0x00015EC8
	public virtual void Update()
	{
		if (Input.GetKeyDown("h"))
		{
			if (this.show)
			{
				this.show = false;
			}
			else
			{
				this.show = true;
			}
		}
	}

	// Token: 0x060001CE RID: 462 RVA: 0x00017CF8 File Offset: 0x00015EF8
	public virtual void OnGUI()
	{
		if (this.show)
		{
			GUI.DrawTexture(new Rect((float)(Screen.width - 300), (float)235, (float)300, (float)255), this.tip);
		}
	}

	// Token: 0x060001CF RID: 463 RVA: 0x00017D34 File Offset: 0x00015F34
	public virtual void Main()
	{
	}

	// Token: 0x04000304 RID: 772
	public Texture2D tip;

	// Token: 0x04000305 RID: 773
	private bool show;
}
