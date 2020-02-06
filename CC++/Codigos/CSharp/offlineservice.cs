using System;

namespace ServiceAgent.Services {
    /// <summary>
    /// Summary description for OfflineService.
    /// </summary>
    public class OfflineService : ServiceBase {
        public OfflineService() {
            base.SetState(ServiceState.Offline);
        }
    }
}
