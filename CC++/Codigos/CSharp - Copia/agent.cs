using System;

using ServiceAgent.Services;

namespace ServiceAgent.Agent {
    /// <summary>
    /// Summary description for Agent.
    /// </summary>
    public abstract class Agent {
        private AgentState  _state;
        private IService    _service;
        
        public Agent() {
            this._state = new AgentState(this);
        }

        public ServiceState State {
            get {
                return this._service.State;
            }
        }

        public IService Service {
            get {
                return this._service;
            }
        }

        public void GoOffline() {
            this._service = new OfflineCatalogService();
        }

        public void GoOnline() {
            try {
                this._service = new OnlineCatalogService();
                this._state.Clear();
            }
            catch (Exception ex) {
                this.GoOffline();
                throw ex;
            }
        }
    }
}
