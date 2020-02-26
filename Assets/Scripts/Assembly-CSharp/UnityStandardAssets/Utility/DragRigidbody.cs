using System;
using System.Collections;
using UnityEngine;

namespace UnityStandardAssets.Utility
{
	// Token: 0x020001B9 RID: 441
	public class DragRigidbody : MonoBehaviour
	{
		// Token: 0x06000BD5 RID: 3029 RVA: 0x0004A8E0 File Offset: 0x00048CE0
		private void Update()
		{
			if (!Input.GetMouseButtonDown(0))
			{
				return;
			}
			Camera camera = this.FindCamera();
			RaycastHit raycastHit = default(RaycastHit);
			if (!Physics.Raycast(camera.ScreenPointToRay(Input.mousePosition).origin, camera.ScreenPointToRay(Input.mousePosition).direction, out raycastHit, 100f, -5))
			{
				return;
			}
			if (!raycastHit.rigidbody || raycastHit.rigidbody.isKinematic)
			{
				return;
			}
			if (!this.m_SpringJoint)
			{
				GameObject gameObject = new GameObject("Rigidbody dragger");
				Rigidbody rigidbody = gameObject.AddComponent<Rigidbody>();
				this.m_SpringJoint = gameObject.AddComponent<SpringJoint>();
				rigidbody.isKinematic = true;
			}
			this.m_SpringJoint.transform.position = raycastHit.point;
			this.m_SpringJoint.anchor = Vector3.zero;
			this.m_SpringJoint.spring = 50f;
			this.m_SpringJoint.damper = 5f;
			this.m_SpringJoint.maxDistance = 0.2f;
			this.m_SpringJoint.connectedBody = raycastHit.rigidbody;
			base.StartCoroutine("DragObject", raycastHit.distance);
		}

		// Token: 0x06000BD6 RID: 3030 RVA: 0x0004AA20 File Offset: 0x00048E20
		private IEnumerator DragObject(float distance)
		{
			float oldDrag = this.m_SpringJoint.connectedBody.drag;
			float oldAngularDrag = this.m_SpringJoint.connectedBody.angularDrag;
			this.m_SpringJoint.connectedBody.drag = 10f;
			this.m_SpringJoint.connectedBody.angularDrag = 5f;
			Camera mainCamera = this.FindCamera();
			while (Input.GetMouseButton(0))
			{
				Ray ray = mainCamera.ScreenPointToRay(Input.mousePosition);
				this.m_SpringJoint.transform.position = ray.GetPoint(distance);
				yield return null;
			}
			if (this.m_SpringJoint.connectedBody)
			{
				this.m_SpringJoint.connectedBody.drag = oldDrag;
				this.m_SpringJoint.connectedBody.angularDrag = oldAngularDrag;
				this.m_SpringJoint.connectedBody = null;
			}
			yield break;
		}

		// Token: 0x06000BD7 RID: 3031 RVA: 0x0004AA42 File Offset: 0x00048E42
		private Camera FindCamera()
		{
			if (base.GetComponent<Camera>())
			{
				return base.GetComponent<Camera>();
			}
			return Camera.main;
		}

		// Token: 0x04000C12 RID: 3090
		private const float k_Spring = 50f;

		// Token: 0x04000C13 RID: 3091
		private const float k_Damper = 5f;

		// Token: 0x04000C14 RID: 3092
		private const float k_Drag = 10f;

		// Token: 0x04000C15 RID: 3093
		private const float k_AngularDrag = 5f;

		// Token: 0x04000C16 RID: 3094
		private const float k_Distance = 0.2f;

		// Token: 0x04000C17 RID: 3095
		private const bool k_AttachToCenterOfMass = false;

		// Token: 0x04000C18 RID: 3096
		private SpringJoint m_SpringJoint;
	}
}
