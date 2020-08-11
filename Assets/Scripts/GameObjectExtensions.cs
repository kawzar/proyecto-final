using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using UnityEngine;

static public class GameObjectExtensions
{
    static public void Clear(this GameObject go)
    {
        for (int i = go.transform.childCount - 1; i >= 0; i--)
        {
            GameObject.Destroy(go.transform.GetChild(i).gameObject);
        }
    }
}
