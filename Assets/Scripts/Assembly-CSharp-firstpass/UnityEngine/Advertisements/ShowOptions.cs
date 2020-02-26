using System;

namespace UnityEngine.Advertisements
{
	// Token: 0x02000032 RID: 50
	public class ShowOptions
	{
		// Token: 0x17000012 RID: 18
		// (get) Token: 0x060001A2 RID: 418 RVA: 0x00004C62 File Offset: 0x00002E62
		// (set) Token: 0x060001A3 RID: 419 RVA: 0x00004C6A File Offset: 0x00002E6A
		[Obsolete("ShowOptions.pause is no longer supported and does nothing, video ads will always pause the game")]
		public bool pause { get; set; }

		// Token: 0x17000013 RID: 19
		// (get) Token: 0x060001A4 RID: 420 RVA: 0x00004C73 File Offset: 0x00002E73
		// (set) Token: 0x060001A5 RID: 421 RVA: 0x00004C7B File Offset: 0x00002E7B
		public Action<ShowResult> resultCallback { get; set; }

		// Token: 0x17000014 RID: 20
		// (get) Token: 0x060001A6 RID: 422 RVA: 0x00004C84 File Offset: 0x00002E84
		// (set) Token: 0x060001A7 RID: 423 RVA: 0x00004C8C File Offset: 0x00002E8C
		public string gamerSid { get; set; }
	}
}
