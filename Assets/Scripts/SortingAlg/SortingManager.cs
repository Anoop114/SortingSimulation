using System.Collections;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

#region Script_Info
// Sorting Manager display errors and allow which shorting is going to select.
//Added on Shorting Game Object;
#endregion
public class SortingManager : MonoBehaviour
{
    [Header("Object References")]
    [Tooltip("Warning panel")]
    public GameObject warning;

    [Tooltip("result and Tutorial btns")]
    public GameObject[] Btns;

    [Header("UI References"),Tooltip("Back Btn")]
    public Button back;

    [Tooltip("Type of algorithm")]
    public TMP_Dropdown algoSelect;

    [Tooltip("Arrange array number")]
    public HorizontalLayoutGroup initialArray;

    [Tooltip("Arrange array barLine")]
    public HorizontalLayoutGroup graphData;

    [Tooltip("Selection of algorithm")]
    public int algoCount = 0;

    void Start()
    {
        algoSelect.onValueChanged.AddListener(delegate 
        {
            algoCount = algoSelect.value;
        });
    }

    //Button Function  Descending btn  &  Ascending btn use this methods.
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
