using System;
using System.Collections;
using SWS;
using UnityEngine;
using UnityEngine.AI;

// Token: 0x020000F7 RID: 247
public class EventReceiver : MonoBehaviour
{
	// Token: 0x060006EC RID: 1772 RVA: 0x0002D63D File Offset: 0x0002BA3D
	public void MyMethod()
	{
	}

	// Token: 0x060006ED RID: 1773 RVA: 0x0002D63F File Offset: 0x0002BA3F
	public void PrintText(string text)
	{
		Debug.Log(text);
	}

	// Token: 0x060006EE RID: 1774 RVA: 0x0002D648 File Offset: 0x0002BA48
	public void RotateSprite(float newRot)
	{
		Vector3 eulerAngles = base.transform.eulerAngles;
		eulerAngles.y = newRot;
		base.transform.eulerAngles = eulerAngles;
	}

	// Token: 0x060006EF RID: 1775 RVA: 0x0002D675 File Offset: 0x0002BA75
	public void SetDestination(UnityEngine.Object target)
	{
		base.StartCoroutine(this.SetDestinationRoutine(target));
	}

	// Token: 0x060006F0 RID: 1776 RVA: 0x0002D688 File Offset: 0x0002BA88
	private IEnumerator SetDestinationRoutine(UnityEngine.Object target)
	{
		NavMeshAgent agent = base.GetComponent<NavMeshAgent>();
		navMove myMove = base.GetComponent<navMove>();
		GameObject tar = (GameObject)target;
		myMove.ChangeSpeed(4f);
		agent.SetDestination(tar.transform.position);
		while (agent.pathPending)
		{
			yield return null;
		}
		float remain = agent.remainingDistance;
		while (remain == float.PositiveInfinity || remain - agent.stoppingDistance > 1.401298E-45f || agent.pathStatus != NavMeshPathStatus.PathComplete)
		{
			remain = agent.remainingDistance;
			yield return null;
		}
		yield return new WaitForSeconds(4f);
		myMove.ChangeSpeed(1.5f);
		myMove.moveToPath = true;
		myMove.StartMove();
		yield break;
	}

	// Token: 0x060006F1 RID: 1777 RVA: 0x0002D6AA File Offset: 0x0002BAAA
	public void ActivateForTime(UnityEngine.Object target)
	{
		base.StartCoroutine(this.ActivateForTimeRoutine(target));
	}

	// Token: 0x060006F2 RID: 1778 RVA: 0x0002D6BC File Offset: 0x0002BABC
	private IEnumerator ActivateForTimeRoutine(UnityEngine.Object target)
	{
		GameObject tar = (GameObject)target;
		tar.SetActive(true);
		yield return new WaitForSeconds(6f);
		tar.SetActive(false);
		yield break;
	}
}
