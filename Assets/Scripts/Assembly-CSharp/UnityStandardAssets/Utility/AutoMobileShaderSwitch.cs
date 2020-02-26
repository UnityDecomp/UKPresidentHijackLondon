using System;
using System.Collections.Generic;
using UnityEngine;

namespace UnityStandardAssets.Utility
{
	// Token: 0x020001B2 RID: 434
	public class AutoMobileShaderSwitch : MonoBehaviour
	{
		// Token: 0x06000BC5 RID: 3013 RVA: 0x0004A300 File Offset: 0x00048700
		private void OnEnable()
		{
			Renderer[] array = UnityEngine.Object.FindObjectsOfType<Renderer>();
			Debug.Log(array.Length + " renderers");
			List<Material> list = new List<Material>();
			List<Material> list2 = new List<Material>();
			int num = 0;
			int num2 = 0;
			foreach (AutoMobileShaderSwitch.ReplacementDefinition replacementDefinition in this.m_ReplacementList.items)
			{
				foreach (Renderer renderer in array)
				{
					Material[] array3 = null;
					for (int k = 0; k < renderer.sharedMaterials.Length; k++)
					{
						Material material = renderer.sharedMaterials[k];
						if (material.shader == replacementDefinition.original)
						{
							if (array3 == null)
							{
								array3 = renderer.materials;
							}
							if (!list.Contains(material))
							{
								list.Add(material);
								Material material2 = UnityEngine.Object.Instantiate<Material>(material);
								material2.shader = replacementDefinition.replacement;
								list2.Add(material2);
								num++;
							}
							Debug.Log(string.Concat(new object[]
							{
								"replacing ",
								renderer.gameObject.name,
								" renderer ",
								k,
								" with ",
								list2[list.IndexOf(material)].name
							}));
							array3[k] = list2[list.IndexOf(material)];
							num2++;
						}
					}
					if (array3 != null)
					{
						renderer.materials = array3;
					}
				}
			}
			Debug.Log(num2 + " material instances replaced");
			Debug.Log(num + " materials replaced");
			for (int l = 0; l < list.Count; l++)
			{
				Debug.Log(string.Concat(new string[]
				{
					list[l].name,
					" (",
					list[l].shader.name,
					") replaced with ",
					list2[l].name,
					" (",
					list2[l].shader.name,
					")"
				}));
			}
		}

		// Token: 0x04000BFA RID: 3066
		[SerializeField]
		private AutoMobileShaderSwitch.ReplacementList m_ReplacementList;

		// Token: 0x020001B3 RID: 435
		[Serializable]
		public class ReplacementDefinition
		{
			// Token: 0x04000BFB RID: 3067
			public Shader original;

			// Token: 0x04000BFC RID: 3068
			public Shader replacement;
		}

		// Token: 0x020001B4 RID: 436
		[Serializable]
		public class ReplacementList
		{
			// Token: 0x04000BFD RID: 3069
			public AutoMobileShaderSwitch.ReplacementDefinition[] items = new AutoMobileShaderSwitch.ReplacementDefinition[0];
		}
	}
}
