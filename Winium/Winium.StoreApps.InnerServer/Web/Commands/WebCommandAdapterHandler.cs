namespace Winium.StoreApps.InnerServer.Web.Commands
{
    using System;
    using System.Collections.Generic;
    using System.Linq;
    using System.Text;

    using Newtonsoft.Json;

    using Winium.StoreApps.Common;
    using Winium.StoreApps.InnerServer.Web;

    internal abstract class WebCommandAdapterHandler : WebCommandHandler
    {

        protected abstract string Execute(WebContext enviroment, Dictionary<string, object> parameters);

        public string CreateSuccessResponse(object responseValue = null)
        {
            return this.JsonResponse(ResponseStatus.Success, responseValue);
        }

        protected string CreateErroResponse(ResponseStatus errorCode, string errorMessage)
        {
            return this.JsonResponse(errorCode, errorMessage);
        }

        protected string CreateMissingParametersResponse(string missingParameters)
        {
            return this.JsonResponse(ResponseStatus.UnknownError, missingParameters);
        }

        protected static JsonResponse ResponseFromJson(string json)
        {
            var response = JsonConvert.DeserializeObject<JsonResponse>(json);

            return response;
        }

        protected string CreateResponse(JsonResponse response)
        {
            return this.JsonResponse(response.Status, response.Value);
        }

        protected override string DoImpl()
        {
            var rv = this.Execute(this.Context, this.Parameters.ToDictionary(x => x.Key, x => x.Value as object));
            return rv;
        }
    }
}
