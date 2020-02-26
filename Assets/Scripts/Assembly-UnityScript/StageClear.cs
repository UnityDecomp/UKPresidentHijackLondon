
using System;
using System.Collections;
using System.Collections.Generic;
using System.Runtime.CompilerServices;
using UnityEngine;

[Serializable]
public class StageClear : MonoBehaviour
{
    [Serializable]
    [CompilerGenerated]
    internal sealed class _0024Start_0024176 : GenericGenerator<WaitForSeconds>
    {
        internal StageClear _0024self__0024178;

        public _0024Start_0024176(StageClear self_)
        {
            _0024self__0024178 = self_;
        }

        public override IEnumerator<WaitForSeconds> GetEnumerator()
        {
            return new _0024Start_0024176(_0024self__0024178);
        }
    }

    public float delay;

    public float duration;

    private bool show;

    public string text;

    public GUIStyle textStyle;

    public StageClear()
    {
        delay = 2f;
        duration = 8f;
        text = "Text Here";
    }

    public IEnumerator Start()
    {
        return new _0024Start_0024176(this).GetEnumerator();
    }

    public void OnGUI()
    {
        if (show)
        {
            GUI.Label(new Rect(Screen.width / 2 - 250, Screen.height / 2 - 100, 500f, 200f), text, textStyle);
        }
    }

    public void Main()
    {
    }
}