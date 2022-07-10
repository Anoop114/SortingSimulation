using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class GraphManager : MonoBehaviour
{
    public GameObject graphData;
    public GameObject graphPanal;
    public ArrDisplay arrayData;

    void Start()
    {
        CreateBar();
    }

    private void CreateBar()
    {
        int num = arrayData.num;
        for(int i = 0; i < num; i++)
        {
            GameObject tempbar = Instantiate(graphData);
            Slider tempBarSlider = tempbar.GetComponent<Slider>();
            tempBarSlider.minValue = arrayData.min;
            tempBarSlider.maxValue = arrayData.max;
            tempBarSlider.value = arrayData.arrData[i];
            
            Image sliderFill = tempbar.GetComponentInChildren<Image>();
            sliderFill.color = arrayData.arrColor[i];

            tempbar.transform.SetParent(graphPanal.transform);
            tempbar.SetActive(true);
        }
    }
    public void DestroyGraph()
    {
        int childs = graphPanal.transform.childCount;
        for (int i = childs - 1; i >= 0; i--)
        {
            Destroy(graphPanal.transform.GetChild(i).gameObject);
        }
        Start();
    }
}
