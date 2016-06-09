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
   ChartWidget
) {
    return declare("app.editors.chartpreview", [
        Widget, TemplatedMixin
    ],
    {
        templateString: '<div id="chartsContainer" class="charts-container"></div>',
        chartsContainer: null,

        postCreate: function () {
            this.chartsContainer = dojo.byId("chartsContainer");

            var chartWidget = new ChartWidget({ currentPageId: this.params.currentPageId, chartId: this.params.chartId });

            //this.chartsContainer.addChild(chartWidget);
        }
    })
});