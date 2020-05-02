using KSPDev.ConfigUtils;

namespace PAWRangeBuff
{
    class ConfigLoader : LoadingSystem
    {
        public override bool IsReady()
        {
            return true;
        }

        public override void StartLoad()
        {
            ConfigAccessor.ReadFieldsInType(typeof(Config), instance: null);
        }
    }
}
