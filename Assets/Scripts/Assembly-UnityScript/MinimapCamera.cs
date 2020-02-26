
using System;
using System.Collections;
using System.Collections.Generic;
using System.Runtime.CompilerServices;
using UnityEngine;

[Serializable]
public class MinimapCamera : MonoBehaviour
{
    [Serializable]
    [CompilerGenerated]
    internal sealed class _0024Start_0024185 : GenericGenerator<WaitForSeconds>
    {
        internal MinimapCamera _0024self__0024187;

        public _0024Start_0024185(MinimapCamera self_)
        {
            _0024self__0024187 = self_;
        }

        public override IEnumerator<WaitForSeconds> GetEnumerator()
        {
            return new _0024Start_0024185(_0024self__0024187);
        }
    }

    public Transform target;

    public float zoomMin;

    public float zoomMax;

    public MinimapCamera()
    {
        zoomMin = 20f;
        zoomMax = 70f;
    }

    public IEnumerator Start()
    {
        return new _0024Start_0024185(this).GetEnumerator();
    }

    public void Update()
    {
        if ((bool)target)
        {
            Transform transform = this.transform;
            Vector3 position = target.position;
            float x = position.x;
            Vector3 position2 = this.transform.position;
            float y = position2.y;
            Vector3 position3 = target.position;
            transform.position = new Vector3(x, y, position3.z);
            if (Input.GetKeyDown(KeyCode.KeypadPlus) && !(GetComponent<Camera>().orthographicSize < zoomMin))
            {
                GetComponent<Camera>().orthographic = true;
                GetComponent<Camera>().orthographicSize = GetComponent<Camera>().orthographicSize - 10f;
            }
            if (Input.GetKeyDown(KeyCode.KeypadMinus) && !(GetComponent<Camera>().orthographicSize > zoomMax))
            {
                GetComponent<Camera>().orthographic = true;
                GetComponent<Camera>().orthographicSize = GetComponent<Camera>().orthographicSize + 10f;
            }
        }
    }

    public void FindTarget()
    {
        if (!target)
        {
            Transform transform = GameObject.FindWithTag("Player").transform;
            if ((bool)transform)
            {
                target = transform;
            }
        }
    }

    public void Main()
    {
    }
}