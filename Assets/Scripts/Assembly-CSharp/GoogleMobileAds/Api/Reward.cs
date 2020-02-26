using System;

namespace GoogleMobileAds.Api
{
	// Token: 0x02000022 RID: 34
	public class Reward : EventArgs
	{
		// Token: 0x17000026 RID: 38
		// (get) Token: 0x060001BA RID: 442 RVA: 0x000078FE File Offset: 0x00005CFE
		// (set) Token: 0x060001BB RID: 443 RVA: 0x00007906 File Offset: 0x00005D06
		public string Type { get; set; }

		// Token: 0x17000027 RID: 39
		// (get) Token: 0x060001BC RID: 444 RVA: 0x0000790F File Offset: 0x00005D0F
		// (set) Token: 0x060001BD RID: 445 RVA: 0x00007917 File Offset: 0x00005D17
		public double Amount { get; set; }
	}
}
