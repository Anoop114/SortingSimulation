using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;
using System;

public class SortingManager : MonoBehaviour
{
    public GameObject warning;
    public GameObject[] Btns;
    public Button back;
    public TMP_Dropdown algoSelect;
    public HorizontalLayoutGroup initialArray;
    public HorizontalLayoutGroup graphData;
    public int algoCount = 0;
    void Start()
    {
        algoSelect.onValueChanged.AddListener(delegate 
        {
            algoCount = algoSelect.value;
        });
    }
    public void SortCall(int call)
    {
        if(algoCount == 0)
        {
            StartCoroutine(WarningSign());
            return;
        }
        if (algoCount == 1)
        {
            gameObject.GetComponent<Bubble>().BubbleSort(call);
            back.onClick.Invoke();
        }
        foreach (var b in Btns)
        {
            b.SetActive(true);
        }
    }

    private IEnumerator WarningSign()
    {
        //1
        warning.SetActive(true);
        yield return new WaitForSeconds(.2f);
        warning.SetActive(false);
        
        //2
        warning.SetActive(true);
        yield return new WaitForSeconds(.2f);
        warning.SetActive(false);
        
        //2
        warning.SetActive(true);
        yield return new WaitForSeconds(.2f);
        warning.SetActive(false);
    }
}
