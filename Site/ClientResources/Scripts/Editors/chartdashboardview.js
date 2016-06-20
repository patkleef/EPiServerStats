define([
    // dojo
    "dojo/_base/declare",
    "dojo/ready",
    "dojo/dom",
    "dojo/when",
    "dojo/_base/lang",
    "dojo/_base/array",
    "dojo/dnd/common",
    "dojo/dnd/Target",
    "dojo/dom-construct",
    "dojo/dom-attr",
    "dojo/on",
    "dojo/text!./templates/chartdashboardviewtemplate.html",

    // dijit
    "dijit/_TemplatedMixin",
    "dijit/_Widget",

    // epi
    "epi/dependency",
    "epi/routes",
    "epi-cms/contentediting/StandardToolbar",
    "app/editors/ChartWidget",

    "dojo/domReady!",
    "dojo/parser",
    "xstyle/css!./templates/charts-style.css"
], function (
    // dojo
    declare,
    ready,
    dom,
    when,
    lang,
    array,
    common,
    Target,
    domConstruct,
    domAttr,
    on,
    template,

    // dijit
    TemplatedMixin,
    Widget,

    // epi
    dependency,
    routes,
    StandardToolbar,
    ChartWidget,
    parser
    ) {

        return declare("app.editors.chartdashboard", [Widget, TemplatedMixin], {
        // summary:
        //      Dashboard widget for displaying charts
        // description:
        //      Displays all charts for the current page. Charts can be drag and drop on the dashboard
        // tags:
            //      public

            chartStore: null,
            contentStore: null,
            target: null,
            currentContentId: 1,
            templateString: template,
            toolbar: null,

            postCreate: function () {
                // summary:
                //      Create the layout for the dashboard
                // tags:
                //      protected

                this.toolbar = new StandardToolbar();
                this.toolbar.placeAt(this.toolbarArea, "first");

                ready(this,
                    function() {
                        this.target = new Target("chartlist",
                        {
                            horizontal: "true",
                            accept: ["site.business.charts.chartdata"],
                            creator: this.chartsContentCreator
                        });

                        on(this.target, 'DndDrop', lang.hitch(this, this.onDndDrop));

                        var registry = dependency.resolve("epi.storeregistry");
                        this.chartStore = registry.get("chartstore");
    
                        this.contentStore = registry.get("epi.cms.content.light");
    
                        var contextService = epi.dependency.resolve("epi.shell.ContextService");
                        var currentContext = contextService.currentContext;
                        var res = currentContext.id.split("_");
    
                        this.currentContentId = res[0];
    
                        this._initCharts();
                    });
            },

            updateView: function(data, context, additionalParams) {
                // summary:
                //      Called when menu item is clicked
                // tags:
                //      protected

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
            },

            _initCharts: function () {
                // summary:
                //      Called when the page is loaded. 
                //      Get saved chart from the chartStore
                // tags:
                //      private

                dojo.when(this.chartStore.query(
                    {
                        currentPageId: this.currentContentId
                    }),
                    lang.hitch(this,
                        function (value) {
                            if (value.length > 0) {
                                this.target.insertNodes(false, value);

                                for (var i in this.target.map) {
                                    var data = this.target.getItem(i).data;
                                    var divChart = dom.byId(i).childNodes[0];
                                    this.renderChart(divChart.id, data.id);
                                }
                                dojo.query(".remove-chart").connect("onclick", lang.hitch(this, this.removeChart));
                            }
                        }));
            },

            chartsContentCreator: function (item, hint) {
                // summary:
                //      Create the chart container in the Source object
                // tags:
                //      public

                var uniqueId = common.getUniqueId();

                var li = document.createElement("li");
                li.setAttribute("id", "li-" + uniqueId);

                var div = document.createElement("div");
                div.setAttribute("id", "chart-" + uniqueId);
                div.setAttribute("class", "chart");

                li.appendChild(div);

                var divRemove = document.createElement("div");
                divRemove.setAttribute("class", "epi-iconObjectTrash epi-icon--large remove-chart");

                li.appendChild(divRemove);

                return { node: li, data: item };
            },

            onDndDrop: function (source, nodes, copy, target) {
                // summary:
                //      Called when an item is dropped in the Source.
                //      Render a chart
                // tags:
                //      protected

                var chartId = Object.keys(target.selection)[0];
                var divChart = dom.byId(chartId).childNodes[0];

                var chartData = source.getItem(nodes[0].id);
                this.renderChart(divChart, chartData.data.contentLink);
                       
                var charts = [];
                for (var i in target.map) {
                    charts.push(target.getItem(i).data.contentLink);
                }
                this.chartStore.put({ currentPageId: this.currentContentId, charts: charts });

                dojo.query(".remove-chart").connect("onclick", lang.hitch(this, this.removeChart));
            },

            removeChart: function (evt, args) {
                // summary:
                //      Remove a chart from the dashboard
                // tags:
                //      protected

                var id = evt.currentTarget.parentElement.id;

                this.target.delItem(id);
                evt.currentTarget.parentElement.remove();

                var charts = [];
                for (var i in this.target.map) {
                    charts.push(this.target.getItem(i).data.id);
                }
                this.chartStore.put({ currentPageId: this.currentContentId, guids: charts });
            },

            renderChart: function (container, chartId) {
                // summary:
                //      Render chart method
                //      Create new chart widget an insert it in the HTML
                // tags:
                //      protected

                var chartWidget = new ChartWidget({
                    currentPageId: this.currentContentId,
                    chartId: chartId
                }).placeAt(container);
            }

        });
    }
);