using System;
using System.Collections;

namespace ServiceAgent.Agent {
    /// <summary>
    /// Summary description for AgentState.
    /// </summary>
    public class AgentState {
        private Hashtable   _cache;
        private string      _description;
        private Agent       _owner;

        private const string DESCRIPTION_FRESH = "Fresh";

        public AgentState(Agent owner) {
            this._owner = owner;
            this._cache = new Hashtable();
            this._description = DESCRIPTION_FRESH;
        }

        protected void SetState(Hashtable cache, string description) {
            this._cache = cache;
            this._description = description;
        }

        public string Description {
            get {
                return this._description;
            }
        }

        public void Clear() {
            this._cache.Clear();
            this._description = DESCRIPTION_FRESH;
        }

        public Hashtable Cache {
            get {
                return this._cache;
            }
        }
    }
}
