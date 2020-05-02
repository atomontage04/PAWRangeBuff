using UnityEngine;
using System.Collections.Generic;

namespace PAWRangeBuff
{
    [KSPAddon(KSPAddon.Startup.Instantly, true)]
    class Loader : LoadingSystem
    {
        public Loader()
        {
            List<LoadingSystem> loadersList = LoadingScreen.Instance.loaders;
            GameObject go = new GameObject();
            ConfigLoader configLoader = go.AddComponent<ConfigLoader>();
            loadersList.Add(configLoader);
        }

        public override bool IsReady()
        {
            return true;
        }
    }
}
