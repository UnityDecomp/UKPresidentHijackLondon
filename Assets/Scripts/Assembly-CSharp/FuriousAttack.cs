using System;
using System.Collections;
using UnityEngine;
using UnityEngine.UI;

// Token: 0x020001E6 RID: 486
public class FuriousAttack : MonoBehaviour
{
	// Token: 0x06000C8D RID: 3213 RVA: 0x0004F2FB File Offset: 0x0004D6FB
	private void Start()
	{
		this.statusC = (UnityEngine.Object.FindObjectOfType(typeof(StatusC)) as StatusC);
		this.questM = (UnityEngine.Object.FindObjectOfType(typeof(QuestManager)) as QuestManager);
	}

	// Token: 0x06000C8E RID: 3214 RVA: 0x0004F334 File Offset: 0x0004D734
	private void Update()
	{
		if (this.startFollow)
		{
			for (int i = 0; i < 3; i++)
			{
				if (this.players[i].gameObject.activeSelf)
				{
					this.MainCam = this.Cams[i];
					this.player = this.players[i];
				}
			}
			this.ActionCamera = this.player.transform.Find("ActionCamera").gameObject;
			this.startFollow = false;
		}
		if (Input.GetMouseButtonDown(0) && this.enableAttack)
		{
			Ray ray = Camera.main.ScreenPointToRay(Input.mousePosition);
			RaycastHit raycastHit;
			if (Physics.Raycast(ray, out raycastHit) && raycastHit.collider.tag == "Enemy")
			{
				MonoBehaviour.print(raycastHit.collider.name);
				this.PreyObject = raycastHit.collider.gameObject;
				this.rotate = true;
				this.ActionCamera.SetActive(true);
				this.MainCam.SetActive(false);
				this.questM.hideGUI();
				this.disableTargets();
				this.AttackCompilation();
				this.enableAttack = false;
			}
		}
		if (this.rotate)
		{
			this.ActionCamera.transform.LookAt(this.mainModel.transform.position);
			this.ActionCamera.transform.RotateAround(this.mainModel.transform.position, Vector3.up, 70f * Time.deltaTime);
			this.MoveTowardsTarget(this.PreyObject);
		}
	}

	// Token: 0x06000C8F RID: 3215 RVA: 0x0004F4D0 File Offset: 0x0004D8D0
	private void disableTargets()
	{
		this.enableAttack = true;
		foreach (GameObject gameObject in this.Enemies)
		{
			GameObject gameObject2 = gameObject.transform.Find("target").gameObject;
			if (gameObject2)
			{
				gameObject2.gameObject.SetActive(false);
			}
		}
	}

	// Token: 0x06000C90 RID: 3216 RVA: 0x0004F534 File Offset: 0x0004D934
	public void showTargets()
	{
		this.Enemies = GameObject.FindGameObjectsWithTag("Enemy");
		Screen.lockCursor = false;
		foreach (GameObject gameObject in this.Enemies)
		{
			GameObject gameObject2 = gameObject.transform.Find("target").gameObject;
			if (gameObject2)
			{
				gameObject2.gameObject.SetActive(true);
			}
		}
		this.enableAttack = true;
	}

	// Token: 0x06000C91 RID: 3217 RVA: 0x0004F5AC File Offset: 0x0004D9AC
	private void MoveTowardsTarget(GameObject target)
	{
		CharacterController component = base.GetComponent<CharacterController>();
		Vector3 a = target.transform.position - base.transform.position;
		if (a.magnitude > 3f)
		{
			this.run = true;
			base.transform.LookAt(this.PreyObject.transform.position);
			a = a.normalized * 14f;
			component.Move(a * Time.deltaTime);
		}
		if (a.magnitude < 3f && this.run)
		{
			this.ActionCamera.GetComponent<Camera>().fieldOfView = 22f;
			this.mainModel.GetComponent<Animation>().Stop(this.running.name);
			this.mainModel.GetComponent<Animation>()[this.running.name].layer = 0;
			base.StartCoroutine(this.AttackCombo());
			this.run = false;
		}
	}

	// Token: 0x06000C92 RID: 3218 RVA: 0x0004F6B4 File Offset: 0x0004DAB4
	private IEnumerator AttackCombo()
	{
		this.mainModel.GetComponent<Animation>().Play(this.attack.name);
		yield return new WaitForSeconds(0.2f);
		this.mainModel.GetComponent<Animation>().Play(this.attack.name);
		yield return new WaitForSeconds(0.4f);
		this.cancelCompilation();
		if (this.PreyObject)
		{
			this.PreyObject.GetComponent<StatusC>().Death();
		}
		this.questM.showGUI();
		base.StartCoroutine(this.BiteImageStay());
		yield break;
	}

	// Token: 0x06000C93 RID: 3219 RVA: 0x0004F6D0 File Offset: 0x0004DAD0
	private IEnumerator BiteImageStay()
	{
		this.ActionCamera.SetActive(false);
		this.MainCam.SetActive(true);
		this.biteImage.gameObject.SetActive(true);
		yield return new WaitForSeconds(1f);
		this.biteImage.gameObject.SetActive(false);
		yield break;
	}

	// Token: 0x06000C94 RID: 3220 RVA: 0x0004F6EC File Offset: 0x0004DAEC
	private void cancelCompilation()
	{
		this.rotate = false;
		this.ActionCamera.gameObject.SetActive(false);
		this.mainModel.GetComponent<Animation>().Stop(this.running.name);
		this.mainModel.GetComponent<Animation>()[this.running.name].layer = 0;
		this.ActionCamera.GetComponent<Camera>().fieldOfView = 31f;
		Time.timeScale = 1f;
	}

	// Token: 0x06000C95 RID: 3221 RVA: 0x0004F76C File Offset: 0x0004DB6C
	private void AttackCompilation()
	{
		Time.timeScale = 0.5f;
		this.mainModel.GetComponent<Animation>()[this.running.name].layer = 20;
		this.mainModel.GetComponent<Animation>().Play(this.running.name);
		this.ActionCamera.gameObject.SetActive(true);
	}

	// Token: 0x04000CF5 RID: 3317
	public GameObject mainModel;

	// Token: 0x04000CF6 RID: 3318
	[HideInInspector]
	public GameObject[] Enemies;

	// Token: 0x04000CF7 RID: 3319
	private GameObject ActionCamera;

	// Token: 0x04000CF8 RID: 3320
	public GameObject[] Cams = new GameObject[3];

	// Token: 0x04000CF9 RID: 3321
	public GameObject[] players = new GameObject[3];

	// Token: 0x04000CFA RID: 3322
	[HideInInspector]
	public GameObject player;

	// Token: 0x04000CFB RID: 3323
	public AnimationClip running;

	// Token: 0x04000CFC RID: 3324
	public AnimationClip attack;

	// Token: 0x04000CFD RID: 3325
	[HideInInspector]
	public GameObject MainCam;

	// Token: 0x04000CFE RID: 3326
	public Image biteImage;

	// Token: 0x04000CFF RID: 3327
	private StatusC statusC;

	// Token: 0x04000D00 RID: 3328
	private GameObject PreyObject;

	// Token: 0x04000D01 RID: 3329
	private float speed = 10f;

	// Token: 0x04000D02 RID: 3330
	private bool enableAttack;

	// Token: 0x04000D03 RID: 3331
	private bool run = true;

	// Token: 0x04000D04 RID: 3332
	private bool rotate;

	// Token: 0x04000D05 RID: 3333
	private bool startFollow = true;

	// Token: 0x04000D06 RID: 3334
	private QuestManager questM;
}
