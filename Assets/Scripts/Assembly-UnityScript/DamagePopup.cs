using System;
using System.Collections;
using System.Collections.Generic;
using System.Runtime.CompilerServices;
using Boo.Lang;
using UnityEngine;

// Token: 0x0200003B RID: 59
[Serializable]
public class DamagePopup : MonoBehaviour
{
	// Token: 0x060000AF RID: 175 RVA: 0x000098DC File Offset: 0x00007ADC
	public DamagePopup()
	{
		this.damage = string.Empty;
		this.duration = 0.5f;
		this.glide = 50;
	}

	// Token: 0x060000B0 RID: 176 RVA: 0x00009910 File Offset: 0x00007B10
	public virtual IEnumerator Start()
	{
		return new DamagePopup.$Start$172(this).GetEnumerator();
	}

	// Token: 0x060000B1 RID: 177 RVA: 0x00009920 File Offset: 0x00007B20
	public virtual void OnGUI()
	{
		this.targetScreenPosition = Camera.main.WorldToScreenPoint(this.transform.position);
		this.targetScreenPosition.y = (float)Screen.height - this.targetScreenPosition.y - (float)this.glide;
		this.targetScreenPosition.x = this.targetScreenPosition.x - (float)6;
		if (this.targetScreenPosition.z > (float)0)
		{
			GUI.Label(new Rect(this.targetScreenPosition.x, this.targetScreenPosition.y, (float)200, (float)50), this.damage, this.fontStyle);
		}
	}

	// Token: 0x060000B2 RID: 178 RVA: 0x000099D0 File Offset: 0x00007BD0
	public virtual void Main()
	{
	}

	// Token: 0x04000150 RID: 336
	public Vector3 targetScreenPosition;

	// Token: 0x04000151 RID: 337
	public string damage;

	// Token: 0x04000152 RID: 338
	public GUIStyle fontStyle;

	// Token: 0x04000153 RID: 339
	public float duration;

	// Token: 0x04000154 RID: 340
	private int glide;

	// Token: 0x0200003C RID: 60
	[CompilerGenerated]
	[Serializable]
	internal sealed class $Start$172 : GenericGenerator<WaitForSeconds>
	{
		// Token: 0x060000B3 RID: 179 RVA: 0x000099D4 File Offset: 0x00007BD4
		public $Start$172(DamagePopup self_)
		{
			this.$self_$175 = self_;
		}

		// Token: 0x060000B4 RID: 180 RVA: 0x000099E4 File Offset: 0x00007BE4
		public override IEnumerator<WaitForSeconds> GetEnumerator()
		{
			return new DamagePopup.$Start$172.$(this.$self_$175);
		}

		// Token: 0x04000155 RID: 341
		internal DamagePopup $self_$175;
	}
}
