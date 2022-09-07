using System;
using System.Collections;
using System.IO;
using UnityEditor;
using UnityEngine;
using UnityEngine.UI;

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
    public FrameCapture screenShot;
    public float timeCapture = 0;

    public void BubbleSort(int call)
    {
        StartCoroutine(SetResult(call));
    }

    private IEnumerator SetResult(int call)
    {
        //set result data
        int childCount = ArrayPanal.transform.childCount;
        for (int i = 0; i < childCount; i++)
        {
            GameObject child = Instantiate(ArrayPanal.transform.GetChild(i).gameObject);
            child.transform.SetParent(resultManager.ActualArray.transform);
        }
        yield return new WaitForEndOfFrame();
        if(call == 1)
        {
            StartCoroutine(SortingDEC());
        }
        if(call == 0) 
        {
            StartCoroutine(SortingASC());
        }
#if UNITY_EDITOR
        AssetDatabase.Refresh();
#endif
    }

    private IEnumerator SortingASC()
    {
        int numLength = arr.num;
        flag = true;
        for (int i = 0; i <= numLength - 2 && flag; i++)
        {
            flag = false;
            for (int j = 0; j <= numLength - 2; j++)
            {
                if (arr.arrData[j + 1] < arr.arrData[j])
                {
                    //change data
                    temp = (int)arr.arrData[j+1];
                    arr.arrData[j+1] = arr.arrData[j];
                    arr.arrData[j] = temp;

                    //change gameObjects
                    tempGameObject = arr.DataSets[j+1];
                    arr.DataSets[j+1] = arr.DataSets[j];
                    arr.DataSets[j] = tempGameObject;

                    //change actual positions
                    temp = ArrayPanal.transform.GetChild(j).GetSiblingIndex();
                    ArrayPanal.transform.GetChild(j+1).SetSiblingIndex(temp);


                    //change Bars
                    temp = BarPanal.transform.GetChild(j).GetSiblingIndex();
                    BarPanal.transform.GetChild(j+1).SetSiblingIndex(temp);

                    screenShot.CaptureScreenShot(i, j);
                    yield return new WaitForSeconds(timeCapture);
                    flag = true;
                }

            }
            //Set results
            int childCount = ArrayPanal.transform.childCount;
            for (int k = 0; k < childCount; k++)
            {
                GameObject child = Instantiate(ArrayPanal.transform.GetChild(k).gameObject);
                child.transform.SetParent(resultManager.Steps[i].transform);
                resultManager.Steps[i].SetActive(true);

            }
        }
        yield return new WaitForSeconds(1f);
        screenShot.DisplayTexture();
        print("capture complete");
        print(screenShot.textures.Count + " t");
        print(screenShot.frames.Count + " F");
    }

    private IEnumerator SortingDEC()
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

                    screenShot.CaptureScreenShot(i, j);
                    yield return new WaitForSeconds(timeCapture);
                    flag = true;
                }

            }
            //Set results
            int childCount = ArrayPanal.transform.childCount;
            for (int k = 0; k < childCount; k++)
            {
                GameObject child = Instantiate(ArrayPanal.transform.GetChild(k).gameObject);
                child.transform.SetParent(resultManager.Steps[i-1].transform);
                resultManager.Steps[i-1].SetActive(true);
            }
        }
        yield return new WaitForSeconds(1f);
        screenShot.DisplayTexture();
        print("capture complete");
        print(screenShot.textures.Count + " t");
        print(screenShot.frames.Count + " F");
    }
}
