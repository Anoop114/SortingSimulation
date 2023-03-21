using System;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

namespace Anoop { 
    public class PopulateValueInCards : MonoBehaviour
    {
        [SerializeField] Button button;
        [SerializeField] TMP_Text dataInnerValue;
        [SerializeField] Slider dataSlider;
        bool isClicked;
        private void Start()
        {
            button.onClick.AddListener(delegate 
            {
                isClicked = !isClicked;
                if (isClicked)
                {
                    dataSlider.gameObject.SetActive(true);
                }
                else
                {
                    dataSlider.gameObject.SetActive(false);
                }
            });

            dataSlider.onValueChanged.AddListener(delegate
            {
                dataInnerValue.text = dataSlider.value.ToString("00");
            });
        }

        private void OnEnable()
        {
            ActionHelper.PopulateDataValues += DataValueUpdate;
        }
        private void OnDisable()
        {
            ActionHelper.PopulateDataValues -= DataValueUpdate;
        }
        private void DataValueUpdate(PopulateValueInCards script)
        {
            if (script.isClicked)
            {
                //dataSlider.gameObject.SetActive(true);
                
                int.TryParse(dataInnerValue.text, out int dataValue);
                dataSlider.value = dataValue;
            }
            else
            {
                isClicked = false;
            }
        }
    }
}