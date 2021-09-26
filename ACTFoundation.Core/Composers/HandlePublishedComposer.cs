using ACTFoundation.Core.Components;
using Umbraco.Core;
using Umbraco.Core.Composing;

namespace ACTFoundation.Core.Composers
{
    [RuntimeLevel(MinLevel = RuntimeLevel.Run)]
    public class HandlePublishedComposer : ComponentComposer<HandlePublishedComponent>
    {
        // leave empty!
    }
}