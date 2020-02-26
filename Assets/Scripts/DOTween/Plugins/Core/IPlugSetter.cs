using System;
using DG.Tweening.Core;

namespace DG.Tweening.Plugins.Core
{
	// Token: 0x0200003A RID: 58
	public interface IPlugSetter<T1, out T2, TPlugin, out TPlugOptions>
	{
		// Token: 0x06000203 RID: 515
		DOGetter<T1> Getter();

		// Token: 0x06000204 RID: 516
		DOSetter<T1> Setter();

		// Token: 0x06000205 RID: 517
		T2 EndValue();

		// Token: 0x06000206 RID: 518
		TPlugOptions GetOptions();
	}
}
