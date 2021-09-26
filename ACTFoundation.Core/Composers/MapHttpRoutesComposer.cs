using System.Web.Http;
using Umbraco.Core;
using Umbraco.Core.Composing;

namespace ACTFoundation.Core.Composers
{
    [RuntimeLevel(MinLevel = RuntimeLevel.Run)]
    public class MapHttpRoutesComposer : ComponentComposer<MapHttpRoutesComponent>
    {
        // nothing needed to be done here!
    }

    public class MapHttpRoutesComponent : IComponent
    {
        public MapHttpRoutesComponent()
        {
            GlobalConfiguration.Configuration.MapHttpAttributeRoutes();
        }
        // initialize: runs once when Umbraco starts
        public void Initialize()
        {
        }

        public void Terminate()
        {
        }
    }
}