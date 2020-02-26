using System;
using UnityEngine;
using UnityEngine.AI;
using UnityEngine.Events;

namespace SWS
{
	// Token: 0x020000F6 RID: 246
	public class EventCollisionTrigger : MonoBehaviour
	{
		// Token: 0x060006E8 RID: 1768 RVA: 0x0002D563 File Offset: 0x0002B963
		private void OnTriggerEnter(Collider other)
		{
			if (!this.onTrigger)
			{
				return;
			}
			this.myEvent.Invoke();
		}

		// Token: 0x060006E9 RID: 1769 RVA: 0x0002D57C File Offset: 0x0002B97C
		private void OnCollisionEnter(Collision other)
		{
			if (!this.onCollision)
			{
				return;
			}
			this.myEvent.Invoke();
		}

		// Token: 0x060006EA RID: 1770 RVA: 0x0002D598 File Offset: 0x0002B998
		public void ApplyForce(int power)
		{
			Vector3 position = base.transform.position;
			float num = 5f;
			Collider[] array = Physics.OverlapSphere(position, num);
			foreach (Collider collider in array)
			{
				navMove component = collider.GetComponent<navMove>();
				if (component != null)
				{
					component.Stop();
					collider.GetComponent<NavMeshAgent>().enabled = false;
					collider.isTrigger = false;
				}
				Rigidbody component2 = collider.GetComponent<Rigidbody>();
				if (component2 != null)
				{
					component2.AddExplosionForce((float)power, position, num, 100f);
				}
			}
		}

		// Token: 0x040005EB RID: 1515
		public bool onTrigger = true;

		// Token: 0x040005EC RID: 1516
		public bool onCollision = true;

		// Token: 0x040005ED RID: 1517
		public UnityEvent myEvent;
	}
}
