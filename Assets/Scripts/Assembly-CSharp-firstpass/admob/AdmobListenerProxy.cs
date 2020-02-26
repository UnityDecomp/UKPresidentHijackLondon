using System;
using UnityEngine;

namespace admob
{
	// Token: 0x02000007 RID: 7
	public class AdmobListenerProxy : AndroidJavaProxy
	{
		// Token: 0x06000028 RID: 40 RVA: 0x0000272F File Offset: 0x0000092F
		internal AdmobListenerProxy(IAdmobListener listener) : base("com.admob.plugin.IAdmobListener")
		{
			this.listener = listener;
		}

		// Token: 0x06000029 RID: 41 RVA: 0x00002743 File Offset: 0x00000943
		private void onAdmobEvent(string adtype, string eventName, string paramString)
		{
			if (this.listener != null)
			{
				this.listener.onAdmobEvent(adtype, eventName, paramString);
			}
		}

		// Token: 0x0600002A RID: 42 RVA: 0x0000275E File Offset: 0x0000095E
		private new string toString()
		{
			return "AdmobListenerProxy";
		}

		// Token: 0x04000012 RID: 18
		private IAdmobListener listener;
	}
}
