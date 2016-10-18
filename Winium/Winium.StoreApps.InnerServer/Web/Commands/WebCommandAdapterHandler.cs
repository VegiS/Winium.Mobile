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
            var parameters = this.Parameters.ToDictionary(x => x.Key, x => x.Value as object);
            if (this.Parameters.ContainsKey("ID"))
            {
                parameters["ID"] = new Dictionary<string, string> { { "ELEMENT", this.Parameters["ID"].ToObject<string>() } };
            }
            var rv = this.Execute(this.Context, parameters);

            return this.JsonResponse(rv.Status, rv.Value);
        }
    }
}
