using System;

namespace admob
{
	// Token: 0x0200000A RID: 10
	internal interface IAdmobListener
	{
		// Token: 0x06000031 RID: 49
		void onAdmobEvent(string adtype, string eventName, string paramString);
	}
}
