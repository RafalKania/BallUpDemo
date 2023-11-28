//**************************************************
// SettingsData.cs
//
// Code Soldiers 2020
//
// Author: Rafał Kania
// Creation Date: 11 February 2020
//**************************************************

using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace CodeSoldiers
{
    [System.Serializable]
    public class SettingsData
    {
        public bool isSoundDisabled;

        public bool isAdvertisingDisabled;

        public SettingsData(bool soundDisabled, bool advertisingDisabled)
        {
            isSoundDisabled = soundDisabled;
            isAdvertisingDisabled = advertisingDisabled;
        }
    }
}
