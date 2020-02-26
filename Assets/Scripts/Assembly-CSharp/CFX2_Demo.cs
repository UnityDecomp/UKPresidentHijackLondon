using System;
using System.Collections;
using System.Text.RegularExpressions;
using UnityEngine;

// Token: 0x02000111 RID: 273
public class CFX2_Demo : MonoBehaviour
{
	// Token: 0x0600075C RID: 1884 RVA: 0x00031044 File Offset: 0x0002F444
	private void OnMouseDown()
	{
		RaycastHit raycastHit = default(RaycastHit);
		if (base.GetComponent<Collider>().Raycast(Camera.main.ScreenPointToRay(Input.mousePosition), out raycastHit, 9999f))
		{
			GameObject gameObject = this.spawnParticle();
			gameObject.transform.position = raycastHit.point + gameObject.transform.position;
		}
	}

	// Token: 0x0600075D RID: 1885 RVA: 0x000310A8 File Offset: 0x0002F4A8
	private GameObject spawnParticle()
	{
		GameObject gameObject = UnityEngine.Object.Instantiate<GameObject>(this.ParticleExamples[this.exampleIndex]);
		gameObject.transform.position = new Vector3(0f, gameObject.transform.position.y, 0f);
		gameObject.SetActive(true);
		for (int i = 0; i < gameObject.transform.childCount; i++)
		{
			gameObject.transform.GetChild(i).gameObject.SetActive(true);
		}
		return gameObject;
	}

	// Token: 0x0600075E RID: 1886 RVA: 0x00031130 File Offset: 0x0002F530
	private void OnGUI()
	{
		GUILayout.BeginArea(new Rect(5f, 20f, (float)(Screen.width - 10), 60f));
		GUILayout.BeginHorizontal(new GUILayoutOption[0]);
		GUILayout.Label("Effect", new GUILayoutOption[0]);
		if (GUILayout.Button("<", new GUILayoutOption[0]))
		{
			this.prevParticle();
		}
		GUILayout.Label(this.ParticleExamples[this.exampleIndex].name, new GUILayoutOption[]
		{
			GUILayout.Width(210f)
		});
		if (GUILayout.Button(">", new GUILayoutOption[0]))
		{
			this.nextParticle();
		}
		GUILayout.Label("Click on the ground to spawn selected particles", new GUILayoutOption[]
		{
			GUILayout.Width(150f)
		});
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
		if (GUILayout.Button((!base.GetComponent<Renderer>().enabled) ? "Show Ground" : "Hide Ground", new GUILayoutOption[]
		{
			GUILayout.Width(90f)
		}))
		{
			base.GetComponent<Renderer>().enabled = !base.GetComponent<Renderer>().enabled;
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
	}

	// Token: 0x0600075F RID: 1887 RVA: 0x000313A4 File Offset: 0x0002F7A4
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

	// Token: 0x06000760 RID: 1888 RVA: 0x000313BF File Offset: 0x0002F7BF
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
	}

	// Token: 0x06000761 RID: 1889 RVA: 0x000313F0 File Offset: 0x0002F7F0
	private void prevParticle()
	{
		this.exampleIndex--;
		if (this.exampleIndex < 0)
		{
			this.exampleIndex = this.ParticleExamples.Length - 1;
		}
		if (this.ParticleExamples[this.exampleIndex].name.Contains("Splash") || this.ParticleExamples[this.exampleIndex].name.Contains("Skim"))
		{
			base.GetComponent<Renderer>().material = this.waterMat;
		}
		else
		{
			base.GetComponent<Renderer>().material = this.groundMat;
		}
	}

	// Token: 0x06000762 RID: 1890 RVA: 0x00031490 File Offset: 0x0002F890
	private void nextParticle()
	{
		this.exampleIndex++;
		if (this.exampleIndex >= this.ParticleExamples.Length)
		{
			this.exampleIndex = 0;
		}
		if (this.ParticleExamples[this.exampleIndex].name.Contains("Splash") || this.ParticleExamples[this.exampleIndex].name.Contains("Skim"))
		{
			base.GetComponent<Renderer>().material = this.waterMat;
		}
		else
		{
			base.GetComponent<Renderer>().material = this.groundMat;
		}
	}

	// Token: 0x0400066E RID: 1646
	public bool orderedSpawns = true;

	// Token: 0x0400066F RID: 1647
	public float step = 1f;

	// Token: 0x04000670 RID: 1648
	public float range = 5f;

	// Token: 0x04000671 RID: 1649
	private float order = -5f;

	// Token: 0x04000672 RID: 1650
	public Material groundMat;

	// Token: 0x04000673 RID: 1651
	public Material waterMat;

	// Token: 0x04000674 RID: 1652
	public GameObject[] ParticleExamples;

	// Token: 0x04000675 RID: 1653
	private int exampleIndex;

	// Token: 0x04000676 RID: 1654
	private string randomSpawnsDelay = "0.5";

	// Token: 0x04000677 RID: 1655
	private bool randomSpawns;

	// Token: 0x04000678 RID: 1656
	private bool slowMo;
}
