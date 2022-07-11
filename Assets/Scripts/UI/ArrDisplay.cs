using UnityEngine;
using UnityEngine.UI;
using TMPro;
using System;

public class ArrDisplay : MonoBehaviour
{
    public GameObject dataSet;
    public GameObject LayoutDataSet;

    [Range(0, 13)]public int num;

    [HideInInspector]public int min,max;
    
    [HideInInspector]public bool isRandom;
    
    [HideInInspector]public Color[] arrColor;
    [HideInInspector]public float[] arrData;
    [HideInInspector]public GameObject[] DataSets;
    // Start is called before the first frame update
    void Awake()
    {
        
        
        if (isRandom)
        {
            num = UnityEngine.Random.Range(1,13);
            arrColor = new Color[num];
            arrData = new float[num];
            DataSets = new GameObject[num];
            GenerateRamdomData();
        }
        else
        {
            arrColor = new Color[num];
            arrData = new float[num];
            DataSets = new GameObject[num];

        }
        CreateData();
        gameObject.GetComponent<GraphManager>().enabled = true;
    }

    private void GenerateRamdomData()
    {
        for(int i = 0; i < num; i++)
        {
            arrData[i] = UnityEngine.Random.Range(0, 50);
        }
    }

    private void CreateData()
    {
        for(int i = 0; i < num; i++)
        {
            GameObject tempData = Instantiate(dataSet);
            Image tempImage = tempData.GetComponent<Image>();
            tempImage.color = UnityEngine.Random.ColorHSV();
            arrColor[i] = tempImage.color;


            TMP_Text tempText = tempData.GetComponentInChildren<TMP_Text>();
            if (isRandom)
            {
                tempText.text = arrData[i].ToString("00");
            }
            else
            {
                arrData[i] = i;
                tempText.text = i.ToString("00");
            }
            //tempText.color = InvertColor(tempImage.color);
            tempData.transform.SetParent(LayoutDataSet.transform);
            DataSets[i] = tempData;
            tempData.SetActive(true);
            if (arrData[i] > max)
            {
                max = (int)arrData[i];
            }
            if (arrData[i] < min)
            {
                min = (int)arrData[i];
            }
        }
    }

    private Color InvertColor(Color color)
    {
        color.r = 1-color.r;
        color.g = 1-color.g;
        color.b = 1-color.b;
        return color;
    }

    public void DestroyArr() 
    {
        int childs = LayoutDataSet.transform.childCount;
        for (int i = childs-1; i >= 0; i--)
        {
            Destroy(LayoutDataSet.transform.GetChild(i).gameObject);
        }
        Array.Clear(arrData, 0, arrData.Length);
        Array.Clear(arrColor, 0, arrColor.Length);
        Array.Clear(DataSets,0, DataSets.Length);
        Awake();
    }
}

