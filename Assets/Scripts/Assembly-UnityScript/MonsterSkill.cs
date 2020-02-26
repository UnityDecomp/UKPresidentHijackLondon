
using System;
using System.Collections;
using System.Collections.Generic;
using System.Runtime.CompilerServices;
using UnityEngine;

[Serializable]
[RequireComponent(typeof(AIset))]
public class MonsterSkill : MonoBehaviour
{
    [Serializable]
    [CompilerGenerated]
    internal sealed class _0024Start_0024188
    {
        internal MonsterSkill _0024self__0024190;

        public _0024Start_0024188(MonsterSkill self_)
        {
            _0024self__0024190 = self_;
        }

        public  IEnumerator<WaitForSeconds> GetEnumerator()
        {
            return new _0024(_0024self__0024190);
        }
    }

    [Serializable]
    [CompilerGenerated]
    internal sealed class _0024UseSkill_0024191
    {
        internal MonsterSkill _0024self__0024196;

        public _0024UseSkill_0024191(MonsterSkill self_)
        {
            _0024self__0024196 = self_;
        }

        public IEnumerator<WaitForSeconds> GetEnumerator()
        {
            return new _0024(_0024self__0024196);
        }
    }

    public GameObject mainModel;

    public float skillDistance;

    public float delay;

    private bool begin;

    private bool onSkill;

    private float wait;

    public SkillSetting[] skillSet;

    public MonsterSkill()
    {
        skillDistance = 4.5f;
        delay = 2f;
        skillSet = new SkillSetting[1];
    }

    public  IEnumerator Start()
    {
        return new _0024Start_0024188(this).GetEnumerator();
    }

    public  void Update()
    {
        if (begin && !onSkill)
        {
            if (!(wait < delay))
            {
                StartCoroutine(UseSkill());
                wait = 0f;
            }
            else
            {
                wait += Time.deltaTime;
            }
        }
    }

    public  IEnumerator UseSkill()
    {
        return new _0024UseSkill_0024191(this).GetEnumerator();
    }

    public  void Main()
    {
    }
}