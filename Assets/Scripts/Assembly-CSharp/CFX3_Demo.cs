using System;
using System.Collections;
using System.Collections.Generic;
using System.Text.RegularExpressions;
using UnityEngine;

// Token: 0x02000113 RID: 275
public class CFX3_Demo : MonoBehaviour
{
	// Token: 0x06000767 RID: 1895 RVA: 0x00031808 File Offset: 0x0002FC08
	private void Awake()
	{
		List<GameObject> list = new List<GameObject>();
		int childCount = base.transform.childCount;
		for (int i = 0; i < childCount; i++)
		{
			GameObject gameObject = base.transform.GetChild(i).gameObject;
			list.Add(gameObject);
		}
		this.ParticleExamples = list.ToArray();
		base.StartCoroutine("CheckForDeletedParticles");
	}

	// Token: 0x06000768 RID: 1896 RVA: 0x0003186C File Offset: 0x0002FC6C
	private void Update()
	{
		if (Input.GetKeyDown(KeyCode.LeftArrow))
		{
			this.prevParticle();
		}
		else if (Input.GetKeyDown(KeyCode.RightArrow))
		{
			this.nextParticle();
		}
		else if (Input.GetKeyDown(KeyCode.Delete))
		{
			this.destroyParticles();
		}
		if (Input.GetMouseButtonDown(0) || Input.GetMouseButtonDown(1) || Input.GetMouseButtonDown(2))
		{
			RaycastHit raycastHit = default(RaycastHit);
			if (this.groundCollider.Raycast(Camera.main.ScreenPointToRay(Input.mousePosition), out raycastHit, 9999f))
			{
				GameObject gameObject = this.spawnParticle();
				gameObject.transform.position = raycastHit.point + gameObject.transform.position;
			}
		}
	}

	// Token: 0x06000769 RID: 1897 RVA: 0x00031938 File Offset: 0x0002FD38
	private void OnGUI()
	{
		GUILayout.BeginArea(new Rect(5f, 20f, (float)(Screen.width - 10), 60f));
		GUILayout.BeginHorizontal(new GUILayoutOption[0]);
		GUILayout.Label("Effect", new GUILayoutOption[]
		{
			GUILayout.Width(50f)
		});
		if (GUILayout.Button("<", new GUILayoutOption[]
		{
			GUILayout.Width(25f)
		}))
		{
			this.prevParticle();
		}
		GUILayout.Label(this.ParticleExamples[this.exampleIndex].name, new GUILayoutOption[]
		{
			GUILayout.Width(265f)
		});
		if (GUILayout.Button(">", new GUILayoutOption[]
		{
			GUILayout.Width(25f)
		}))
		{
			this.nextParticle();
		}
		GUILayout.Space(80f);
		if (GUILayout.Button((!CFX_Demo_RotateCamera.rotating) ? "Rotate Camera" : "Pause Camera", new GUILayoutOption[0]))
		{
			CFX_Demo_RotateCamera.rotating = !CFX_Demo_RotateCamera.rotating;
		}
		if (GUILayout.Button((!this.randomSpawns) ? "Start Random Spawns" : "Stop Random Spawns", new GUILayoutOption[]
		{
			GUILayout.Width(140f)
		}))
		{
			this.randomSpawns = !this.randomSpawns;
			if (this.randomSpawns)
			{
				base.StartCoroutine("RandomSpawnsCoroutine");
			}
			else
			{
				base.StopCoroutine("RandomSpawnsCoroutine");
			}
		}
		this.randomSpawnsDelay = GUILayout.TextField(this.randomSpawnsDelay, 10, new GUILayoutOption[]
		{
			GUILayout.Width(42f)
		});
		this.randomSpawnsDelay = Regex.Replace(this.randomSpawnsDelay, "[^0-9.]", string.Empty);
		if (GUILayout.Button((!this.groundRenderer.enabled) ? "Show Ground" : "Hide Ground", new GUILayoutOption[]
		{
			GUILayout.Width(90f)
		}))
		{
			this.groundRenderer.enabled = !this.groundRenderer.enabled;
		}
		if (GUILayout.Button((!this.slowMo) ? "Slow Motion" : "Normal Speed", new GUILayoutOption[]
		{
			GUILayout.Width(100f)
		}))
		{
			this.slowMo = !this.slowMo;
			if (this.slowMo)
			{
				Time.timeScale = 0.33f;
			}
			else
			{
				Time.timeScale = 1f;
			}
		}
		GUILayout.EndHorizontal();
		GUILayout.EndArea();
		GUILayout.BeginArea(new Rect(5f, 50f, (float)(Screen.width - 10), 60f));
		GUILayout.BeginHorizontal(new GUILayoutOption[0]);
		GUILayout.Label("Click on the ground to spawn selected particles", new GUILayoutOption[0]);
		GUILayout.FlexibleSpace();
		GUILayout.Label("Use the LEFT and RIGHT keys to switch effects; Press DEL to delete all effects on screen", new GUILayoutOption[0]);
		GUILayout.EndHorizontal();
		GUILayout.EndArea();
	}

	// Token: 0x0600076A RID: 1898 RVA: 0x00031C1C File Offset: 0x0003001C
	private GameObject spawnParticle()
	{
		GameObject gameObject = UnityEngine.Object.Instantiate<GameObject>(this.ParticleExamples[this.exampleIndex]);
		gameObject.transform.position = new Vector3(0f, gameObject.transform.position.y, 0f);
		gameObject.SetActive(true);
		for (int i = 0; i < gameObject.transform.childCount; i++)
		{
			gameObject.transform.GetChild(i).gameObject.SetActive(true);
		}
		ParticleSystem component = gameObject.GetComponent<ParticleSystem>();
		if (component != null && component.loop)
		{
			component.gameObject.AddComponent<CFX3_AutoStopLoopedEffect>();
			component.gameObject.AddComponent<CFX_AutoDestructShuriken>();
		}
		this.onScreenParticles.Add(gameObject);
		return gameObject;
	}

	// Token: 0x0600076B RID: 1899 RVA: 0x00031CE8 File Offset: 0x000300E8
	private IEnumerator CheckForDeletedParticles()
	{
		for (;;)
		{
			yield return new WaitForSeconds(5f);
			for (int i = this.onScreenParticles.Count - 1; i >= 0; i--)
			{
				if (this.onScreenParticles[i] == null)
				{
					this.onScreenParticles.RemoveAt(i);
				}
			}
		}
		yield break;
	}

	// Token: 0x0600076C RID: 1900 RVA: 0x00031D04 File Offset: 0x00030104
	private IEnumerator RandomSpawnsCoroutine()
	{
		for (;;)
		{
			GameObject particles = this.spawnParticle();
			if (this.orderedSpawns)
			{
				particles.transform.position = base.transform.position + new Vector3(this.order, particles.transform.position.y, 0f);
				this.order -= this.step;
				if (this.order < -this.range)
				{
					this.order = this.range;
				}
			}
			else
			{
				particles.transform.position = base.transform.position + new Vector3(UnityEngine.Random.Range(-this.range, this.range), 0f, UnityEngine.Random.Range(-this.range, this.range)) + new Vector3(0f, particles.transform.position.y, 0f);
			}
			yield return new WaitForSeconds(float.Parse(this.randomSpawnsDelay));
		}
		yield break;
	}

	// Token: 0x0600076D RID: 1901 RVA: 0x00031D1F File Offset: 0x0003011F
	private void prevParticle()
	{
		this.exampleIndex--;
		if (this.exampleIndex < 0)
		{
			this.exampleIndex = this.ParticleExamples.Length - 1;
		}
	}

	// Token: 0x0600076E RID: 1902 RVA: 0x00031D4B File Offset: 0x0003014B
	private void nextParticle()
	{
		this.exampleIndex++;
		if (this.exampleIndex >= this.ParticleExamples.Length)
		{
			this.exampleIndex = 0;
		}
	}

	// Token: 0x0600076F RID: 1903 RVA: 0x00031D78 File Offset: 0x00030178
	private void destroyParticles()
	{
		for (int i = this.onScreenParticles.Count - 1; i >= 0; i--)
		{
			if (this.onScreenParticles[i] != null)
			{
				UnityEngine.Object.Destroy(this.onScreenParticles[i]);
			}
			this.onScreenParticles.RemoveAt(i);
		}
	}

	// Token: 0x0400067B RID: 1659
	public bool orderedSpawns = true;

	// Token: 0x0400067C RID: 1660
	public float step = 1f;

	// Token: 0x0400067D RID: 1661
	public float range = 5f;

	// Token: 0x0400067E RID: 1662
	private float order = -5f;

	// Token: 0x0400067F RID: 1663
	public Renderer groundRenderer;

	// Token: 0x04000680 RID: 1664
	public Collider groundCollider;

	// Token: 0x04000681 RID: 1665
	private GameObject[] ParticleExamples;

	// Token: 0x04000682 RID: 1666
	private int exampleIndex;

	// Token: 0x04000683 RID: 1667
	private string randomSpawnsDelay = "0.5";

	// Token: 0x04000684 RID: 1668
	private bool randomSpawns;

	// Token: 0x04000685 RID: 1669
	private bool slowMo;

	// Token: 0x04000686 RID: 1670
	private List<GameObject> onScreenParticles = new List<GameObject>();
}
