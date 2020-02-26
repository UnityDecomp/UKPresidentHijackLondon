using System;
using System.Collections;
using System.Collections.Generic;
using System.Runtime.CompilerServices;
using Boo.Lang;
using UnityEngine;

// Token: 0x02000046 RID: 70
[Serializable]
public class StageClear : MonoBehaviour
{
	// Token: 0x060000D5 RID: 213 RVA: 0x0000A580 File Offset: 0x00008780
	public StageClear()
	{
		this.delay = 2f;
		this.duration = 8f;
		this.text = "Text Here";
	}

	// Token: 0x060000D6 RID: 214 RVA: 0x0000A5AC File Offset: 0x000087AC
	public virtual IEnumerator Start()
	{
		return new StageClear.$Start$176(this).GetEnumerator();
	}

	// Token: 0x060000D7 RID: 215 RVA: 0x0000A5BC File Offset: 0x000087BC
	public virtual void OnGUI()
	{
		if (this.show)
		{
			GUI.Label(new Rect((float)(Screen.width / 2 - 250), (float)(Screen.height / 2 - 100), (float)500, (float)200), this.text, this.textStyle);
		}
	}

	// Token: 0x060000D8 RID: 216 RVA: 0x0000A610 File Offset: 0x00008810
	public virtual void Main()
	{
	}

	// Token: 0x04000185 RID: 389
	public float delay;

	// Token: 0x04000186 RID: 390
	public float duration;

	// Token: 0x04000187 RID: 391
	private bool show;

	// Token: 0x04000188 RID: 392
	public string text;

	// Token: 0x04000189 RID: 393
	public GUIStyle textStyle;

	// Token: 0x02000047 RID: 71
	[CompilerGenerated]
	[Serializable]
	internal sealed class $Start$176 : GenericGenerator<WaitForSeconds>
	{
		// Token: 0x060000D9 RID: 217 RVA: 0x0000A614 File Offset: 0x00008814
		public $Start$176(StageClear self_)
		{
			this.$self_$178 = self_;
		}

		// Token: 0x060000DA RID: 218 RVA: 0x0000A624 File Offset: 0x00008824
		public override IEnumerator<WaitForSeconds> GetEnumerator()
		{
			return new StageClear.$Start$176.$(this.$self_$178);
		}

		// Token: 0x0400018A RID: 394
		internal StageClear $self_$178;
	}
}
