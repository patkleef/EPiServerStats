define([
    // dojo
   "dojo",
   "dojo/_base/declare",

   // dijit
   "dijit/_Widget",
   "dijit/_TemplatedMixin",

   // epi
   "epi/dependency",
   "epi/routes",
   "epi-cms/contentediting/StandardToolbar",

    "app/editors/ChartWidget",
    "dojo/text!./templates/chartpreviewtemplate.html",
    "xstyle/css!./templates/charts-style.css"
], function (
    // dojo
   dojo,
   declare,

   // dijit
   Widget,
   TemplatedMixin,

   // epi
   dependency,
   routes,
   StandardToolbar,
   ChartWidget,
   template
) {
    return declare("app.editors.chartpreview", [Widget, TemplatedMixin], {
        // summary:
        //      Chart preview widget
        // description:
        //      Widget for the chart preview for the current selected chart
        // tags:
        //      public

        templateString: template,
        chartsContainer: null,
        toolbar: null,
        currentContentId: null,

        postCreate: function () {
            // summary:
            //      Create layout for the widget
            // tags:
            //      public

            this.toolbar = new StandardToolbar();
            this.toolbar.placeAt(this.toolbarArea, "first");4

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
            //      Called by the menu item
            // tags:
            //      public
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