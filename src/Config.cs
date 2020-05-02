using KSPDev.ConfigUtils;
using System.Collections.Generic;
using UnityEngine;

namespace PAWRangeBuff
{
    [KSPAddon(KSPAddon.Startup.Instantly, false)]
    [PersistentFieldsDatabase("PAWRangeBuff/Settings/PAWRangeBuff")]
    sealed class Config : MonoBehaviour
    {
        [PersistentField("pawRangeCoef")]
        public static float pawRangeCoef = 0.0f;

        public void Awake()
        {
            List<LoadingSystem> loadersList = LoadingScreen.Instance.loaders;

            GameObject go = new GameObject();
            ConfigLoader configLoader = go.AddComponent<ConfigLoader>();
            loadersList.Add(configLoader);
        }
    }
}
