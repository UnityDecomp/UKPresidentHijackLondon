using System;
using DG.Tweening.Core.Enums;

namespace DG.Tweening.Core
{
	// Token: 0x0200004A RID: 74
	public static class Extensions
	{
		// Token: 0x06000260 RID: 608 RVA: 0x0000D4A7 File Offset: 0x0000B6A7
		internal static T SetSpecialStartupMode<T>(this T t, SpecialStartupMode mode) where T : Tween
		{
			t.specialStartupMode = mode;
			return t;
		}

		// Token: 0x06000261 RID: 609 RVA: 0x0000D4B6 File Offset: 0x0000B6B6
		internal static TweenerCore<T1, T2, TPlugOptions> NoFrom<T1, T2, TPlugOptions>(this TweenerCore<T1, T2, TPlugOptions> t) where TPlugOptions : struct
		{
			t.isFromAllowed = false;
			return t;
		}

		// Token: 0x06000262 RID: 610 RVA: 0x0000D4C0 File Offset: 0x0000B6C0
		internal static TweenerCore<T1, T2, TPlugOptions> Blendable<T1, T2, TPlugOptions>(this TweenerCore<T1, T2, TPlugOptions> t) where TPlugOptions : struct
		{
			t.isBlendable = true;
			return t;
		}
	}
}
