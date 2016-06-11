define([
   "dojo",
   "dojo/_base/declare",
   "dojo/dom-construct",
   "dojo/on",
   "dojo/_base/lang",
   "dojo/query",
   "dojo/dom-attr",
   "dojo/when",
   "dojo/_base/array",


   "dojox/charting/Chart",
   "dojox/charting/axis2d/Default",
   "dojox/charting/plot2d/Lines",
   "dojox/charting/plot2d/Pie",
   "dojox/charting/Chart2D",
   "dojox/charting/action2d/Magnify",
   "dojox/charting/action2d/MoveSlice",
   "dojox/charting/action2d/Shake",
   "dojox/charting/action2d/Tooltip",
   "dojox/charting/action2d/MouseZoomAndPan",
   "dojox/charting/action2d/MouseIndicator",

   "dojox/charting/widget/SelectableLegend",
   "dojox/charting/themes/Dollar",
   "dojox/charting/themes/Electric",
   "dojox/charting/themes/Julie",
   "dojox/charting/themes/PurpleRain",
   "dojox/charting/themes/Renkoo",

   "dijit/_Widget",
   "dijit/_TemplatedMixin",

   "epi/dependency",
   "epi/routes",
   "epi-cms/contentediting/StandardToolbar",

    "app/editors/ChartWidget"
], function (
   dojo,
   declare,
   domConstruct,
   on,
   lang,
   query,
   domAttr,
   when,
   array,

   Chart,
   Default,
   Lines,
   Pie,
   Chart2D,
   Magnify,
   MoveSlice,
   Shake,
   Tooltip,
   MouseZoomAndPan,
   MouseIndicator,

   SelectableLegend,
   Dollar,
   Electric,
   Julie,
   PurpleRain,
   Renkoo,

   Widget,
   TemplatedMixin,

   dependency,
   routes,
   StandardToolbar,
   ChartWidget
) {
    return declare("app.editors.chartpreview",
    [
        Widget, TemplatedMixin
    ],
    {
        templateString: '<div data-dojo-attach-point="toolbarArea" /><div data-dojo-attach-point="chartsContainer" class="charts-container" />',
        chartsContainer: null,
        toolbar: null,
        currentContentId: null,

        postCreate: function () {
            this.toolbar = new StandardToolbar();
            this.toolbar.placeAt(this.toolbarArea, "first");

            //this.chartsContainer = dojo.byId("chartsContainer");

            var registry = dependency.resolve("epi.storeregistry");
            this.contentStore = registry.get("epi.cms.content.light");

            var contextService = epi.dependency.resolve("epi.shell.ContextService");
            var currentContext = contextService.currentContext;
            var res = currentContext.id.split("_");

            this.currentContentId = res[0];

            var chartWidget = new ChartWidget({
                currentPageId: 8,
                chartId: this.currentContentId
            }).placeAt(this.chartsContainer);
        },

        updateView: function(data, context, additionalParams) {
            // summary:
            //    Sets up the view by loading the URL of the inner iframe.
            if (data && data.skipUpdateView) {
                return;
            }

            this.toolbar.update({
                currentContext: context,
                viewConfigurations: {
                    availableViews: data.availableViews,
                    viewName: data.viewName
                }
            });
        }
    });
});