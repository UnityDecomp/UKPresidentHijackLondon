using System;
using UnityEngine;
using UnityEngine.Events;
using UnityEngine.EventSystems;

// Token: 0x02000143 RID: 323
public class HoldButtonScript : MonoBehaviour, IEventSystemHandler
{
	// Token: 0x06000A10 RID: 2576 RVA: 0x0003DB32 File Offset: 0x0003BF32
	public void Hold(BaseEventData eventData)
	{
		this._bButtonHeld = true;
	}

	// Token: 0x06000A11 RID: 2577 RVA: 0x0003DB3B File Offset: 0x0003BF3B
	public void Release(BaseEventData eventData)
	{
		this._bButtonHeld = false;
	}

	// Token: 0x06000A12 RID: 2578 RVA: 0x0003DB44 File Offset: 0x0003BF44
	public void Update()
	{
		if (this._bButtonHeld)
		{
			this.OnHold.Invoke();
		}
	}

	// Token: 0x06000A13 RID: 2579 RVA: 0x0003DB5C File Offset: 0x0003BF5C
	private void OnDisable()
	{
		this._bButtonHeld = false;
	}

	// Token: 0x04000940 RID: 2368
	public UnityEvent OnHold;

	// Token: 0x04000941 RID: 2369
	private bool _bButtonHeld;
}
