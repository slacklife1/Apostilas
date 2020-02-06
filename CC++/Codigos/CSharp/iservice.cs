using System;

namespace ServiceAgent.Services {
    public enum ServiceState {
        Offline = 0,
        Online = 1,
        Unknown = 2
    }

    /// <summary>
    /// Summary description for IService.
    /// </summary>
    public interface IService {
        ServiceState State {
            get;
        }
    }
}
