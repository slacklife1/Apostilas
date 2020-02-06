using System;

using ServiceAgent.Services;
using ServiceAgent.Entity;

namespace ServiceAgent.Agent {
    /// <summary>
    /// Summary description for CatalogAgent.
    /// </summary>
    public class CatalogAgent : Agent {
        public CatalogAgent() {
        }

        public ProductEntity GetProduct(string productId) {
            ICatalogService catalog = (ICatalogService)base.Service;

            return catalog.GetProduct(productId);
        }
    }
}
