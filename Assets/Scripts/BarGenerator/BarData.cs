using TMPro;
using UnityEngine;

public class BarData : MonoBehaviour
{
    [SerializeField] private RectTransform bar;
    [SerializeField] private TMP_Text barVal;
    [SerializeField] private Color barColor;
    public BarData(RectTransform _bar, string _barVal, Color _barColor)
    {
        bar = _bar;
        barVal.text = _barVal;
        barColor = _barColor;
    }
    public BarData(){}
}
