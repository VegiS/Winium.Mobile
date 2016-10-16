namespace Winium.StoreApps.InnerServer.Web.Commands
{
    using System.Collections.Generic;
    using System.Linq;

    using Winium.StoreApps.InnerServer.Web;

    internal abstract class WebCommandAdapterHandler : WebCommandHandler
    {

        protected abstract Response Execute(CommandEnvironment enviroment, Dictionary<string, object> parameters);

        protected override string DoImpl()
        {
            var rv = this.Execute(this.Context, this.Parameters.ToDictionary(x => x.Key, x => x.Value as object));

            return this.JsonResponse(rv.Status, rv.Value);
        }
    }
}
