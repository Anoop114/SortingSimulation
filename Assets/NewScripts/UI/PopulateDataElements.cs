using System;
using System.Collections;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

namespace Anoop
{
    public class PopulateDataElements : MonoBehaviour
    {
        [SerializeField] TMP_Text numberOfElements;
        [SerializeField] Slider numberOfElementsSlider;
        [SerializeField] GameObject[] elementCards;
        [SerializeField] GameObject randomGenerator;
        private void Start()
        {
            numberOfElementsSlider.onValueChanged.AddListener(delegate
            {
                UpdateDataNumberValue(numberOfElementsSlider.value);
            });
        }

        private void UpdateDataNumberValue(float value)
        {
            numberOfElements.text = value.ToString("00");
            int i = 0;
            foreach(var card in elementCards) 
            {
                if (i < value)
                {
                    card.SetActive(true);
                }
                else
                {
                    card.SetActive(false);
                }
                i++;
            }
            if (value != 0)
            {
                randomGenerator.SetActive(true);
            }
            else
            {
                randomGenerator.SetActive(false);

            }
        }


        private void OnEnable()
        {
            ActionHelper.PopulateDataCard += UpdateData;
        }
        private void OnDisable()
        {
            ActionHelper.PopulateDataCard -= UpdateData;
        }
        private void UpdateData()
        {
            numberOfElementsSlider.value = 0;
            numberOfElements.text = "00";
        }
    }
}