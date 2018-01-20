using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TreeData : MonoBehaviour
{
    public string Name;
    public GameObject[] Trees;
    public float carbon
    {
        get
        {
            return parameters[CARBON];
        }
    }

    public float stormwater
    {
        get
        {
            return parameters[STORMWATER];
        }
    }
    public float Stormsavings
    {
        get
        {
            return parameters[STORMSAVINGS];
        }
    }
   
    public float[] Params
    {
        get
        {
            return parameters;
        }
    }

    [HideInInspector]
    public int index;
    [HideInInspector]
    public const int CARBON = 0;
    [HideInInspector]
    public const int STORMWATER = 1;
    [HideInInspector]
    public const int STORMSAVINGS = 2;

    [SerializeField]
    float[] parameters = new float[3];

    public void SetParameter(float[] p)
    {
        parameters = p;
    }
    
    public float GetParam(int index)
    {
        return parameters[index];
    }

    public GameObject GetRandomTree()
    {
        return Trees[Random.Range(0, Trees.Length)];
    }

}
