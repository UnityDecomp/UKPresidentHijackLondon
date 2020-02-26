using System;
using UnityEngine;

namespace GoogleMobileAds.Common
{
	// Token: 0x0200002C RID: 44
	internal class Utils
	{
		// Token: 0x06000252 RID: 594 RVA: 0x0000847C File Offset: 0x0000687C
		public static Texture2D GetTexture2DFromByteArray(byte[] img)
		{
			Texture2D texture2D = new Texture2D(1, 1);
			if (!texture2D.LoadImage(img))
			{
				throw new InvalidOperationException("Could not load custom native template\n                        image asset as texture");
			}
			return texture2D;
		}
	}
}
