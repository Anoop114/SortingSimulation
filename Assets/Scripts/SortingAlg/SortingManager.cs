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
    public void SortCall(int order)
    {
        // not any algo selected
        if(algoCount == 0)
        {
            StartCoroutine(WarningSign());
        }

        // bubble short
        if (algoCount == 1)
        {
            //Bubble short function call.
            gameObject.GetComponent<Bubble>().BubbleSort(order);//order => ASC/DEC
            
            //Call Back Button Auto Click
            back.onClick.Invoke();
        }

        // after Shorting Active the Buttons Of shorting.
        foreach (var b in Btns)
        {
            b.SetActive(true);
        }
    }


    /// <summary>
    /// Display the Warning Sign if not any Algol selected.
    /// </summary>
    /// <returns></returns>
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
