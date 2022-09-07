using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Test : MonoBehaviour
{
    public GraphManager manager;
    public ArrDisplay arr;
    public bool isGenerate;

    // Update is called once per frame
    void Update()
    {
        if (isGenerate)
        {
            RandomGenerator();
        }
    }

    public void RandomGenerator()
    {
        isGenerate = false;
        arr.DestroyArr();
        manager.DestroyAndCareateGraph();
    }
}
