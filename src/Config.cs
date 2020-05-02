using KSPDev.ConfigUtils;
using UnityEngine;

namespace PAWRangeBuff
{
    [PersistentFieldsDatabase("PAWRangeBuff/Settings/PAWRangeBuff")]
    sealed class Config
    {
        [PersistentField("pawRangeCoef")]
        public static float pawRangeCoef = 1.0f;
    }
}
