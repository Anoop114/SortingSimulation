using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

namespace Assets.Scripts
{
    public class GenerateBarData : MonoBehaviour
    {

        [SerializeField] private GameObject barData;
        [SerializeField] private List<BarData> dataBar;
        [SerializeField] private HorizontalLayoutGroup layout;
        void Start()
        {
            layout.enabled = true;
            for(int i = 0; i < 10; i++)
            {
                GameObject bar = GenerateBarVal();
                BarData tempBar = bar.GetComponent<BarData>();
                dataBar.Add(tempBar);   
            }
            Invoke(nameof(DisabelLayout), 2f);
        }

        private void DisabelLayout()
        {
            layout.enabled = false;
        }

        private GameObject GenerateBarVal()
        {
            return Instantiate(barData,transform);
        }

    }
}