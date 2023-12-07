using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DataManeger : MonoBehaviour
{

    public float[] times = null;

    public void Start()
    {
        for(int i=0; i<times.Length; i++)
        {
            Debug.Log(times[i]);
        }
    }


}
