using System;

namespace ServiceAgent.Entity {
    /// <summary>
    /// Summary description for EntityKey.
    /// </summary>
    public class EntityKey {
        private string _key;

        public EntityKey(string key) {
            this._key = key;
        }

        public override string ToString() {
            return this._key;
        }

    }
}
