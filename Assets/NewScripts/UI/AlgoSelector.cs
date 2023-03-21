using System;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

namespace Anoop
{
    public class AlgoSelector : MonoBehaviour
    {
        [SerializeField] TMP_Dropdown algoSelector;
        [SerializeField] GameObject elementGenerator;
        [SerializeField] SortingAlgorithms sortingAlgorithms;
        void Start()
        {
            PopulateDropDownWithEnum(algoSelector, sortingAlgorithms);

            algoSelector.onValueChanged.AddListener(delegate
            {
                UpdateAlogOnDropDownChange(algoSelector.value);
            });
        }

        private void UpdateAlogOnDropDownChange(int value)
        {
            elementGenerator.SetActive(true);
            sortingAlgorithms = (SortingAlgorithms)value;
            ActionHelper.PopulateDataCard?.Invoke();
        }

        private void PopulateDropDownWithEnum(TMP_Dropdown dropdown, Enum targetEnum)//You can populate any dropdown with any enum with t$$anonymous$$s method
        {
            Type enumType = targetEnum.GetType();//Type of enum(FormatPresetType in my example)
            List<TMP_Dropdown.OptionData> newOptions = new List<TMP_Dropdown.OptionData>();

            for (int i = 0; i < Enum.GetNames(enumType).Length; i++)//Populate new Options
            {
                newOptions.Add(new TMP_Dropdown.OptionData(Enum.GetName(enumType, i)));
            }

            dropdown.ClearOptions();//Clear old options
            dropdown.AddOptions(newOptions);//Add new options
        }
    }

    public enum SortingAlgorithms
    {
        none = 0,
        Selection = 1,
        Bubble = 2,
        Merge = 3
    }
}
