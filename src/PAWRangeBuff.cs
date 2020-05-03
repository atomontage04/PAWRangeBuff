using System;
using UnityEngine;
using System.Collections.Generic;

namespace PAWRangeBuff
{
    [KSPAddon(KSPAddon.Startup.Flight, false)]
    public class PAWRangeBuff : MonoBehaviour
    {
        public PAWRangeBuff()
        {
            GameEvents.onVesselLoaded.Add(this.onVesselLoaded);
        }

        private void onVesselLoaded(Vessel vessel)
        {
            List<Part> parts = vessel.Parts;
            float biggestAttachNode = 0.0f;

            foreach (Part part in parts)
            {
                List<AttachNode> attachNodes = part.attachNodes;

                foreach (AttachNode attachNode in attachNodes)
                {
                    biggestAttachNode = Math.Max(biggestAttachNode, attachNode.size);
                }

                PartModuleList modules = part.Modules;

                foreach (PartModule module in modules)
                {
                    string moduleName = module.moduleName;
                    BaseEventList events = module.Events;

                    foreach (BaseEvent kspevent in events)
                    {
                        float unfocusedRangeBuffed = (kspevent.unfocusedRange + biggestAttachNode) * Config.pawRangeCoef;
                        kspevent.unfocusedRange = unfocusedRangeBuffed;
                        Logger.log(string.Format("Buffed {0} with range of {1}", kspevent.name, unfocusedRangeBuffed));
                    }
                }
            }
        }
    }
}