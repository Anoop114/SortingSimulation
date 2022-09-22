using UnityEngine;
using UnityEngine.UI;
using TMPro;
using System;


#region Script_Info
// Display all the array data and change randomly 
// Added on Manager Game Object;
#endregion
public class ArrDisplay : MonoBehaviour
{
    [Header("GameObject References")]
    [Tooltip("Prefab of number of data in arrays")]
    public GameObject dataSet;
    [Tooltip("The area where the data is going to display")]
    public GameObject LayoutDataSet;

    [Tooltip("Number of bar lines")]
    [Range(0, 15)]public int num;

    [Tooltip("Providing the min and max value for bar creation")]
    [HideInInspector]public int min,max;

    [Tooltip("Generate Random Data")]
    [HideInInspector]public bool isRandom;

    [Tooltip("Color of all number and bars")]
    [HideInInspector]public Color[] arrColor;

    [Tooltip("Array Data numbers")]
    [HideInInspector]public int[] arrData;
    [Tooltip("Array Data gameObject")]
    [HideInInspector]public GameObject[] DataSets;
    // Start is called before the first frame update
    void Awake()
    { 
        if (isRandom)
        {
            num = UnityEngine.Random.Range(1,16);
            arrColor = new Color[num];
            arrData = new int[num];
            DataSets = new GameObject[num];
            GenerateRamdomData();
        }
        else
        {
            arrColor = new Color[num];
            arrData = new int[num];
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
            tempData.transform.SetParent(LayoutDataSet.transform);
            DataSets[i] = tempData;
            
            if (arrData[i] > max)
            {
                max = (int)arrData[i];
            }
            if (arrData[i] < min)
            {
                min = (int)arrData[i];
            }
            
            tempData.SetActive(true);
        }
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

