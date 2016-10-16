namespace Winium.StoreApps.InnerServer.Web.Commands
{
    internal class GetPageSourceCommandHandler : WebCommandHandler
    {
        protected override string DoImpl()
        {
            var environment = this.Context;

               const string Script = "return document.documentElement.outerHTML;";

                var result = this.EvaluateAtom(environment, this.Atom, Script, new object[] { }, environment.CreateFrameObject());
                return result;
            }
    }
}
