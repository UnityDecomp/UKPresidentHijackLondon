using Boo.Lang;
using System;
using System.Collections;
using System.Collections.Generic;
using System.Runtime.CompilerServices;
using UnityEngine;

[Serializable]
public class RespawnMonster : MonoBehaviour
{
    [Serializable]
    [CompilerGenerated]
    internal sealed class _0024Start_0024209 : GenericGenerator<WaitForSeconds>
    {
        internal RespawnMonster _0024self__0024215;

        public _0024Start_0024209(RespawnMonster self_)
        {
            _0024self__0024215 = self_;
        }

        public override IEnumerator<WaitForSeconds> GetEnumerator()
        {
            return new _0024(_0024self__0024215);
        }
    }

    public Transform enemy;

    public string pointName;

    public float delay;

    public float randomPoint;

    public RespawnMonster()
    {
        pointName = "SpawnPoint";
        delay = 3f;
        randomPoint = 10f;
    }

    public override IEnumerator Start()
    {
        return new _0024Start_0024209(this).GetEnumerator();
    }

    public override void Main()
    {
    }
}