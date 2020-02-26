using System;
using System.Collections;
using UnityEngine;
using UnityEngine.SceneManagement;

// Token: 0x02000102 RID: 258
public class ShowcaseGUI : MonoBehaviour
{
	// Token: 0x0600070C RID: 1804 RVA: 0x0002E5AF File Offset: 0x0002C9AF
	private void Start()
	{
		if (ShowcaseGUI.instance)
		{
			UnityEngine.Object.Destroy(base.gameObject);
		}
		ShowcaseGUI.instance = this;
		UnityEngine.Object.DontDestroyOnLoad(base.gameObject);
		this.OnLevelWasLoaded(0);
	}

	// Token: 0x0600070D RID: 1805 RVA: 0x0002E5E4 File Offset: 0x0002C9E4
	private void OnLevelWasLoaded(int level)
	{
		GameObject gameObject = GameObject.Find("Floor_Tile");
		if (gameObject)
		{
			IEnumerator enumerator = gameObject.transform.GetEnumerator();
			try
			{
				while (enumerator.MoveNext())
				{
					object obj = enumerator.Current;
					Transform transform = (Transform)obj;
					transform.gameObject.SetActive(true);
				}
			}
			finally
			{
				IDisposable disposable;
				if ((disposable = (enumerator as IDisposable)) != null)
				{
					disposable.Dispose();
				}
			}
		}
	}

	// Token: 0x0600070E RID: 1806 RVA: 0x0002E664 File Offset: 0x0002CA64
	private void OnGUI()
	{
		int width = Screen.width;
		int num = 30;
		int num2 = 40;
		Rect rect = new Rect((float)(width - num * 2 - 70), 10f, (float)num, (float)num2);
		if (SceneManager.GetActiveScene().buildIndex > 0 && GUI.Button(rect, "<"))
		{
			SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex - 1);
		}
		else if (GUI.Button(new Rect(rect), "<"))
		{
			SceneManager.LoadScene(this.levels - 1);
		}
		GUI.Box(new Rect((float)(width - num - 70), 10f, 60f, (float)num2), string.Concat(new object[]
		{
			"Scene:\n",
			SceneManager.GetActiveScene().buildIndex + 1,
			" / ",
			this.levels
		}));
		Rect source = new Rect((float)(width - num - 10), 10f, (float)num, (float)num2);
		if (SceneManager.GetActiveScene().buildIndex < this.levels - 1 && GUI.Button(new Rect(source), ">"))
		{
			SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex + 1);
		}
		else if (GUI.Button(new Rect(source), ">"))
		{
			SceneManager.LoadScene(0);
		}
		GUI.Box(new Rect((float)(width - 130), 50f, 120f, 55f), "Example scenes\nmust be added\nto Build Settings.");
	}

	// Token: 0x04000611 RID: 1553
	private static ShowcaseGUI instance;

	// Token: 0x04000612 RID: 1554
	private int levels = 9;
}
