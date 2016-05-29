using EPiServer.Shell;
using EPiServer.Shell.ViewComposition;

namespace Site.Business.Widgets
{
    [Component(PlugInAreas = PlugInArea.Assets, 
        Title = "Charts viewer",
        Categories = "cms",
        WidgetType = "app.editors.chartsviewer")]
    public class ChartsViewerComponent
    {

    }
}