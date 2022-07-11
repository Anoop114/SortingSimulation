using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ResultManager : MonoBehaviour
{
    public GameObject ActualArray;
    public GameObject[] Steps;
    
    public void DeleteAllData()
    {
        //delete data first arr.
        int childs = ActualArray.transform.childCount;
        for (int i = childs - 1; i >= 1; i--)
        {
            Destroy(ActualArray.transform.GetChild(i).gameObject);
        }

        foreach (GameObject arrData in Steps)
        {
            childs = arrData.transform.childCount;
            for (int i = childs - 1; i >= 1; i--)
            {
                Destroy(arrData.transform.GetChild(i).gameObject);
            }
        }

    }
}
