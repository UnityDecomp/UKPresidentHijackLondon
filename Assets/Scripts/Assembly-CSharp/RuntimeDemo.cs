using System;
using DG.Tweening;
using SWS;
using UnityEngine;
using UnityEngine.Events;

// Token: 0x020000FB RID: 251
public class RuntimeDemo : MonoBehaviour
{
	// Token: 0x060006FE RID: 1790 RVA: 0x0002DF74 File Offset: 0x0002C374
	private void OnGUI()
	{
		this.DrawExample1();
		this.DrawExample2();
		this.DrawExample3();
		this.DrawExample4();
		this.DrawExample5();
		this.DrawExample6();
	}

	// Token: 0x060006FF RID: 1791 RVA: 0x0002DF9C File Offset: 0x0002C39C
	private void DrawExample1()
	{
		GUI.Label(new Rect(10f, 10f, 20f, 20f), "1:");
		string name = "Walker (Path1)";
		string text = "Path1 (Instantiation)";
		Vector3 position = new Vector3(-25f, 0f, 10f);
		if (!this.example1.done && GUI.Button(new Rect(30f, 10f, 100f, 20f), "Instantiate"))
		{
			GameObject gameObject = UnityEngine.Object.Instantiate<GameObject>(this.example1.walkerPrefab, position, Quaternion.identity);
			gameObject.name = name;
			GameObject gameObject2 = UnityEngine.Object.Instantiate<GameObject>(this.example1.pathPrefab, position, Quaternion.identity);
			gameObject2.name = text;
			WaypointManager.AddPath(gameObject2);
			gameObject.GetComponent<splineMove>().SetPath(WaypointManager.Paths[text]);
			this.example1.done = true;
		}
		if (this.example1.done && GUI.Button(new Rect(30f, 10f, 100f, 20f), "Destroy"))
		{
			UnityEngine.Object.Destroy(GameObject.Find(name));
			UnityEngine.Object.Destroy(GameObject.Find(text));
			WaypointManager.Paths.Remove(text);
			this.example1.done = false;
		}
	}

	// Token: 0x06000700 RID: 1792 RVA: 0x0002E0F4 File Offset: 0x0002C4F4
	private void DrawExample2()
	{
		GUI.Label(new Rect(10f, 30f, 20f, 20f), "2:");
		if (GUI.Button(new Rect(30f, 30f, 100f, 20f), "Switch Path"))
		{
			string name = this.example2.moveRef.pathContainer.name;
			this.example2.moveRef.moveToPath = true;
			if (name == this.example2.pathName1)
			{
				this.example2.moveRef.SetPath(WaypointManager.Paths[this.example2.pathName2]);
			}
			else
			{
				this.example2.moveRef.SetPath(WaypointManager.Paths[this.example2.pathName1]);
			}
		}
	}

	// Token: 0x06000701 RID: 1793 RVA: 0x0002E1D8 File Offset: 0x0002C5D8
	private void DrawExample3()
	{
		GUI.Label(new Rect(10f, 50f, 20f, 20f), "3:");
		if (this.example3.moveRef.tween == null && GUI.Button(new Rect(30f, 50f, 100f, 20f), "Start"))
		{
			this.example3.moveRef.StartMove();
		}
		if (this.example3.moveRef.tween != null && GUI.Button(new Rect(30f, 50f, 100f, 20f), "Stop"))
		{
			this.example3.moveRef.Stop();
		}
		if (this.example3.moveRef.tween != null && GUI.Button(new Rect(30f, 70f, 100f, 20f), "Reset"))
		{
			this.example3.moveRef.ResetToStart();
		}
	}

	// Token: 0x06000702 RID: 1794 RVA: 0x0002E2F0 File Offset: 0x0002C6F0
	private void DrawExample4()
	{
		GUI.Label(new Rect(10f, 90f, 20f, 20f), "4:");
		if (this.example4.moveRef.tween != null && this.example4.moveRef.tween.IsPlaying() && GUI.Button(new Rect(30f, 90f, 100f, 20f), "Pause"))
		{
			this.example4.moveRef.Pause(0f);
		}
		if (this.example4.moveRef.tween != null && !this.example4.moveRef.tween.IsPlaying() && GUI.Button(new Rect(30f, 90f, 100f, 20f), "Resume"))
		{
			this.example4.moveRef.Resume();
		}
	}

	// Token: 0x06000703 RID: 1795 RVA: 0x0002E3F4 File Offset: 0x0002C7F4
	private void DrawExample5()
	{
		GUI.Label(new Rect(10f, 110f, 20f, 20f), "5:");
		if (GUI.Button(new Rect(30f, 110f, 100f, 20f), "Change Speed"))
		{
			float speed = this.example5.moveRef.speed;
			float num = 1.5f;
			if (speed == num)
			{
				num = 4f;
			}
			this.example5.moveRef.ChangeSpeed(num);
		}
	}

	// Token: 0x06000704 RID: 1796 RVA: 0x0002E484 File Offset: 0x0002C884
	private void DrawExample6()
	{
		GUI.Label(new Rect(10f, 130f, 20f, 20f), "6:");
		if (!this.example6.done && GUI.Button(new Rect(30f, 130f, 100f, 20f), "Add Event"))
		{
			EventReceiver receiver = this.example6.moveRef.GetComponent<EventReceiver>();
			UnityEvent unityEvent = this.example6.moveRef.events[1];
			unityEvent.RemoveAllListeners();
			unityEvent.AddListener(delegate()
			{
				receiver.ActivateForTime(this.example6.target);
			});
			this.example6.done = true;
		}
	}

	// Token: 0x040005FF RID: 1535
	public RuntimeDemo.ExampleClass1 example1;

	// Token: 0x04000600 RID: 1536
	public RuntimeDemo.ExampleClass2 example2;

	// Token: 0x04000601 RID: 1537
	public RuntimeDemo.ExampleClass3 example3;

	// Token: 0x04000602 RID: 1538
	public RuntimeDemo.ExampleClass4 example4;

	// Token: 0x04000603 RID: 1539
	public RuntimeDemo.ExampleClass5 example5;

	// Token: 0x04000604 RID: 1540
	public RuntimeDemo.ExampleClass6 example6;

	// Token: 0x020000FC RID: 252
	[Serializable]
	public class ExampleClass1
	{
		// Token: 0x04000605 RID: 1541
		public GameObject walkerPrefab;

		// Token: 0x04000606 RID: 1542
		public GameObject pathPrefab;

		// Token: 0x04000607 RID: 1543
		public bool done;
	}

	// Token: 0x020000FD RID: 253
	[Serializable]
	public class ExampleClass2
	{
		// Token: 0x04000608 RID: 1544
		public splineMove moveRef;

		// Token: 0x04000609 RID: 1545
		public string pathName1;

		// Token: 0x0400060A RID: 1546
		public string pathName2;
	}

	// Token: 0x020000FE RID: 254
	[Serializable]
	public class ExampleClass3
	{
		// Token: 0x0400060B RID: 1547
		public splineMove moveRef;
	}

	// Token: 0x020000FF RID: 255
	[Serializable]
	public class ExampleClass4
	{
		// Token: 0x0400060C RID: 1548
		public splineMove moveRef;
	}

	// Token: 0x02000100 RID: 256
	[Serializable]
	public class ExampleClass5
	{
		// Token: 0x0400060D RID: 1549
		public splineMove moveRef;
	}

	// Token: 0x02000101 RID: 257
	[Serializable]
	public class ExampleClass6
	{
		// Token: 0x0400060E RID: 1550
		public splineMove moveRef;

		// Token: 0x0400060F RID: 1551
		public GameObject target;

		// Token: 0x04000610 RID: 1552
		public bool done;
	}
}
