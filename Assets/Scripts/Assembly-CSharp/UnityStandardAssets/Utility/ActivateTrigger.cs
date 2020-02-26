using System;
using UnityEngine;

namespace UnityStandardAssets.Utility
{
	// Token: 0x020001B0 RID: 432
	public class ActivateTrigger : MonoBehaviour
	{
		// Token: 0x06000BC2 RID: 3010 RVA: 0x0004A194 File Offset: 0x00048594
		private void DoActivateTrigger()
		{
			this.triggerCount--;
			if (this.triggerCount == 0 || this.repeatTrigger)
			{
				UnityEngine.Object @object = this.target ?? base.gameObject;
				Behaviour behaviour = @object as Behaviour;
				GameObject gameObject = @object as GameObject;
				if (behaviour != null)
				{
					gameObject = behaviour.gameObject;
				}
				switch (this.action)
				{
				case ActivateTrigger.Mode.Trigger:
					if (gameObject != null)
					{
						gameObject.BroadcastMessage("DoActivateTrigger");
					}
					break;
				case ActivateTrigger.Mode.Replace:
					if (this.source != null && gameObject != null)
					{
						UnityEngine.Object.Instantiate<GameObject>(this.source, gameObject.transform.position, gameObject.transform.rotation);
						UnityEngine.Object.DestroyObject(gameObject);
					}
					break;
				case ActivateTrigger.Mode.Activate:
					if (gameObject != null)
					{
						gameObject.SetActive(true);
					}
					break;
				case ActivateTrigger.Mode.Enable:
					if (behaviour != null)
					{
						behaviour.enabled = true;
					}
					break;
				case ActivateTrigger.Mode.Animate:
					if (gameObject != null)
					{
						gameObject.GetComponent<Animation>().Play();
					}
					break;
				case ActivateTrigger.Mode.Deactivate:
					if (gameObject != null)
					{
						gameObject.SetActive(false);
					}
					break;
				}
			}
		}

		// Token: 0x06000BC3 RID: 3011 RVA: 0x0004A2EF File Offset: 0x000486EF
		private void OnTriggerEnter(Collider other)
		{
			this.DoActivateTrigger();
		}

		// Token: 0x04000BEE RID: 3054
		public ActivateTrigger.Mode action = ActivateTrigger.Mode.Activate;

		// Token: 0x04000BEF RID: 3055
		public UnityEngine.Object target;

		// Token: 0x04000BF0 RID: 3056
		public GameObject source;

		// Token: 0x04000BF1 RID: 3057
		public int triggerCount = 1;

		// Token: 0x04000BF2 RID: 3058
		public bool repeatTrigger;

		// Token: 0x020001B1 RID: 433
		public enum Mode
		{
			// Token: 0x04000BF4 RID: 3060
			Trigger,
			// Token: 0x04000BF5 RID: 3061
			Replace,
			// Token: 0x04000BF6 RID: 3062
			Activate,
			// Token: 0x04000BF7 RID: 3063
			Enable,
			// Token: 0x04000BF8 RID: 3064
			Animate,
			// Token: 0x04000BF9 RID: 3065
			Deactivate
		}
	}
}
