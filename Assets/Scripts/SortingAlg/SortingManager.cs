using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;
using System;

public class SortingManager : MonoBehaviour
{
    public GameObject warning;
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
        }
        if(algoCount == 1 && call == 0)//Asc
        {
            gameObject.GetComponent<Bubble>().BubbleSort();
            initialArray.reverseArrangement = true;
            graphData.reverseArrangement = true;
            back.onClick.Invoke();
        }
        if(algoCount == 1 && call == 1)//dec
        {
            gameObject.GetComponent<Bubble>().BubbleSort();
            initialArray.reverseArrangement = false;
            graphData.reverseArrangement = false;
            back.onClick.Invoke();
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
