
using System;
using System.Collections;
using System.Collections.Generic;
using System.Runtime.CompilerServices;
using UnityEngine;

[Serializable]
public class DamagePopup : MonoBehaviour
{
    [Serializable]
    [CompilerGenerated]
    internal sealed class _0024Start_0024172 : GenericGenerator<WaitForSeconds>
    {
        internal DamagePopup _0024self__0024175;

        public _0024Start_0024172(DamagePopup self_)
        {
            _0024self__0024175 = self_;
        }

        public override IEnumerator<WaitForSeconds> GetEnumerator()
        {
            return new _0024Start_0024172(_0024self__0024175);
        }
    }

    public Vector3 targetScreenPosition;

    public string damage;

    public GUIStyle fontStyle;

    public float duration;

    private int glide;

    public DamagePopup()
    {
        damage = string.Empty;
        duration = 0.5f;
        glide = 50;
    }

    public IEnumerator Start()
    {
        return new _0024Start_0024172(this).GetEnumerator();
    }

    public void OnGUI()
    {
        targetScreenPosition = Camera.main.WorldToScreenPoint(transform.position);
        targetScreenPosition.y = (float)Screen.height - targetScreenPosition.y - (float)glide;
        targetScreenPosition.x -= 6f;
        if (!(targetScreenPosition.z <= 0f))
        {
            GUI.Label(new Rect(targetScreenPosition.x, targetScreenPosition.y, 200f, 50f), damage, fontStyle);
        }
    }

    public void Main()
    {
    }
}