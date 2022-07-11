using System;
using System.Collections;
using UnityEngine;

public class Bubble : MonoBehaviour
{
    GameObject tempGameObject;
    int temp;
    bool flag = true;
    public bool isBubble;
    public ArrDisplay arr;
    public GameObject ArrayPanal;
    public GameObject BarPanal;
    public ResultManager resultManager;
    void Update()
    {
        if (isBubble)
        {
            isBubble = false;
            BubbleSort();
        }
    }

    public void BubbleSort()
    {
        StartCoroutine(SetResult());
        
    }

    private IEnumerator SetResult()
    {
        //set result data
        int childCount = ArrayPanal.transform.childCount;
        for (int i = 0; i < childCount; i++)
        {
            GameObject child = Instantiate(ArrayPanal.transform.GetChild(i).gameObject);
            child.transform.SetParent(resultManager.ActualArray.transform);
        }
        yield return new WaitForEndOfFrame();
        Sorting();
    }

    private void Sorting()
    {
        int numLength = arr.num;
        flag = true;
        for (int i = 1; (i <= (numLength - 1)) && flag; i++)
        {
            flag = false;
            for (int j = 0; j < (numLength - 1); j++)
            {
                if (arr.arrData[j + 1] > arr.arrData[j])
                {
                    //change data
                    temp = (int)arr.arrData[j];
                    arr.arrData[j] = arr.arrData[j + 1];
                    arr.arrData[j + 1] = temp;

                    //change gameObjects
                    tempGameObject = arr.DataSets[j];
                    arr.DataSets[j] = arr.DataSets[j + 1];
                    arr.DataSets[j + 1] = tempGameObject;

                    //change actual positions
                    temp = ArrayPanal.transform.GetChild(j + 1).GetSiblingIndex();
                    ArrayPanal.transform.GetChild(j).SetSiblingIndex(temp);


                    //change Bars
                    temp = BarPanal.transform.GetChild(j + 1).GetSiblingIndex();
                    BarPanal.transform.GetChild(j).SetSiblingIndex(temp);

                    flag = true;
                }
            }
        }
    }
}
