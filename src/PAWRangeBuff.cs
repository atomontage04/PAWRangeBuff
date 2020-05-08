using System;
using UnityEngine;
using System.Collections.Generic;

namespace PAWRangeBuff
{
    [KSPAddon(KSPAddon.Startup.Flight, false)]
    public class PAWRangeBuff : MonoBehaviour
    {
        private static readonly float DEFAULT_UNFOCUSED_RANGE = 2.0f;

        public void OnEnable()
        {
            GameEvents.onVesselCreate.Add(this.onVesselCreated);
            GameEvents.onVesselLoaded.Add(this.onVesselLoaded);
        }

        public void OnDisable()
        {
            GameEvents.onVesselCreate.Remove(this.onVesselCreated);
            GameEvents.onVesselLoaded.Remove(this.onVesselLoaded);
        }

        private void onVesselLoaded(Vessel vessel)
        {
            this.buffPawRange(vessel);
        }

        private void onVesselCreated(Vessel vessel)
        {
            this.buffPawRange(vessel);
        }

        private void buffPawRange(Vessel vessel)
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
                        float unfocusedRangeFinal = this.getPawRangeBuff(kspevent.unfocusedRange, biggestAttachNode);
                        
                        Logger.log(
                            string.Format(
                                "Changing {0} to range of {1} (was {2}; size modifier: {3}, settings coef: {4})",
                                kspevent.name,
                                unfocusedRangeFinal,
                                kspevent.unfocusedRange,
                                biggestAttachNode,
                                Config.pawRangeCoef
                            )
                        );

                        kspevent.unfocusedRange = unfocusedRangeFinal;
                    }
                }
            }
        }

        private float getPawRangeBuff(float originalUnfocusedRange, float sizeModifier)
        {
            float defaultUnfocusedRangeWithSizeModifier = DEFAULT_UNFOCUSED_RANGE + sizeModifier;
            
            return Math.Max(defaultUnfocusedRangeWithSizeModifier, originalUnfocusedRange) * Config.pawRangeCoef;
        }
    }
}