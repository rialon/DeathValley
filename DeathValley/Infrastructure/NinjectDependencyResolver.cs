using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using DeathValley.Models.Abstract;
using DeathValley.Models;

using Ninject;

namespace DeathValley.Infrastructure {

    public class NinjectDependencyResolver : IDependencyResolver {
        private IKernel _kernel;


        public NinjectDependencyResolver(IKernel kernel) {
            this._kernel = kernel;
            this._AddBinings();
        }

        public object GetService(Type serviceType) {
            return this._kernel.TryGet(serviceType);
        }

        public IEnumerable<object> GetServices(Type serviceType) {
            return this._kernel.GetAll(serviceType);
        }

        private void _AddBinings() {
            this._kernel.Bind<IChartProcessor>().To<ParabolicChartProcessor>();
        }
    }
}