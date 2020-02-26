using System;
using System.Collections.Generic;

namespace GoogleMobileAds.Api.Mediation
{
	// Token: 0x0200001F RID: 31
	public abstract class MediationExtras
	{
		// Token: 0x17000023 RID: 35
		// (get) Token: 0x0600019B RID: 411 RVA: 0x0000747D File Offset: 0x0000587D
		// (set) Token: 0x0600019C RID: 412 RVA: 0x00007485 File Offset: 0x00005885
		public Dictionary<string, string> Extras { get; protected set; }

		// Token: 0x17000024 RID: 36
		// (get) Token: 0x0600019D RID: 413
		public abstract string AndroidMediationExtraBuilderClassName { get; }

		// Token: 0x17000025 RID: 37
		// (get) Token: 0x0600019E RID: 414
		public abstract string IOSMediationExtraBuilderClassName { get; }
	}
}
