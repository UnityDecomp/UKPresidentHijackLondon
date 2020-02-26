using System;

// Token: 0x02000152 RID: 338
public class Sfx
{
	// Token: 0x04000978 RID: 2424
	public static string[] sfxFiles = new string[]
	{
		"bonus",
		"sfx_click",
		"Idle",
		"coins_sound"
	};

	// Token: 0x02000153 RID: 339
	public enum Type
	{
		// Token: 0x0400097A RID: 2426
		sfx_click_character,
		// Token: 0x0400097B RID: 2427
		sfx_click,
		// Token: 0x0400097C RID: 2428
		sfx_idle,
		// Token: 0x0400097D RID: 2429
		sfx_coin
	}
}
