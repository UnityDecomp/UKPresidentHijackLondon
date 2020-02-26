using System;
using System.Collections;
using UnityEngine;

namespace UnityStandardAssets.Utility
{
	// Token: 0x020001C2 RID: 450
	public class ParticleSystemDestroyer : MonoBehaviour
	{
		// Token: 0x06000BF2 RID: 3058 RVA: 0x0004B5FC File Offset: 0x000499FC
		private IEnumerator Start()
		{
			ParticleSystem[] systems = base.GetComponentsInChildren<ParticleSystem>();
			foreach (ParticleSystem particleSystem in systems)
			{
				this.m_MaxLifetime = Mathf.Max(particleSystem.startLifetime, this.m_MaxLifetime);
			}
			float stopTime = Time.time + UnityEngine.Random.Range(this.minDuration, this.maxDuration);
			while (Time.time < stopTime || this.m_EarlyStop)
			{
				yield return null;
			}
			Debug.Log("stopping " + base.name);
			foreach (ParticleSystem particleSystem2 in systems)
			{
				particleSystem2.emission.enabled = false;
			}
			base.BroadcastMessage("Extinguish", SendMessageOptions.DontRequireReceiver);
			yield return new WaitForSeconds(this.m_MaxLifetime);
			UnityEngine.Object.Destroy(base.gameObject);
			yield break;
		}

		// Token: 0x06000BF3 RID: 3059 RVA: 0x0004B617 File Offset: 0x00049A17
		public void Stop()
		{
			this.m_EarlyStop = true;
		}

		// Token: 0x04000C39 RID: 3129
		public float minDuration = 8f;

		// Token: 0x04000C3A RID: 3130
		public float maxDuration = 10f;

		// Token: 0x04000C3B RID: 3131
		private float m_MaxLifetime;

		// Token: 0x04000C3C RID: 3132
		private bool m_EarlyStop;
	}
}
