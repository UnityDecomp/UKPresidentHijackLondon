using System;

namespace UnityEngine.Advertisements.Optional
{
	// Token: 0x0200002D RID: 45
	public class ShowOptionsExtended : ShowOptions
	{
		// Token: 0x17000010 RID: 16
		// (get) Token: 0x0600014C RID: 332 RVA: 0x00004C9D File Offset: 0x00002E9D
		// (set) Token: 0x0600014D RID: 333 RVA: 0x00004CA5 File Offset: 0x00002EA5
		[Obsolete("Please use gamerSid on ShowOptions instead of ShowOptionsExtended")]
		public new string gamerSid { get; set; }
	}
}
