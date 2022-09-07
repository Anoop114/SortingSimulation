using UnityEngine;
using UnityEngine.UI;
#region ScriptInfo
// This script allow user to create the bar lines on the graph.
#endregion
public class GraphManager : MonoBehaviour
{
    [Header("Script References")] public ArrDisplay arrayData;

    [Header("GameObject references")]
    [Tooltip("Canvas Were the barLine is going to added.")]
    public GameObject graphData;
    [Tooltip("This is the panel where the graph data is going to display.")]
    public GameObject graphPanal;
    

    void Start()
    {
        //in start create the graph.
        CreateBar();
    }

    //Graph creation function.
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
    
    
    // Destroy the previous graph data and create the graph again.
    public void DestroyAndCareateGraph()
    {
        int childs = graphPanal.transform.childCount;
        for (int i = childs - 1; i >= 0; i--)
        {
            Destroy(graphPanal.transform.GetChild(i).gameObject);
        }
        CreateBar();
    }
}
