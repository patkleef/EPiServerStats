define([
    "dojo/_base/declare",
    "dojo/ready",
    "dojo/dom",
    "dojo/when",
    "dojo/_base/lang",
    "dojo/_base/array",
    "dojo/dnd/common",
    "dojo/dnd/Source",
    "dojo/dnd/Target",
    "dojo/dom-construct",
    "dojo/dom-attr",
    "dojo/on",
    "dojo/text!./templates/chartcontentviewtemplate.html",

    "dijit/_TemplatedMixin",
    "dijit/_Widget",

    "dojox/charting/Chart",
    "dojox/charting/axis2d/Default",
    "dojox/charting/plot2d/Lines",
    "dojox/charting/plot2d/Pie",
    "dojox/charting/Chart2D",
    "dojox/charting/DataSeries",
    "dojox/charting/DataChart",

    "epi/dependency",
    "epi/routes",
    "dojo/topic",

    "dojo/domReady!",
    "dojo/parser"
], function(
    declare,
    ready,
    dom,
    when,
    lang,
    array,
    common,
    Source,
    Target,
    domConstruct,
    domAttr,
    on,

    template,
    TemplatedMixin,
    Widget,
    
    Chart,
    Default,
    Lines,
    Pie,
    Chart2D,
    DataSeries,
    DataChart,

    dependency,
    routes,
    topic,
    parser
    ) {
        return declare("app.editors.chartcontentview", [
            Widget, TemplatedMixin
        ],
        {
            statsStore: null,
            contentStore: null,
            target: null,
            currentContentId: 1,
            templateString: template,

            postCreate: function () {
                
                ready(this, function () {
                    this.target = new Target("chartlist", { horizontal: "true", accept: ["episerver.core.icontentdata"], creator: this.chartsContentCreator });

                    on(this.target, 'DndDrop', lang.hitch(this, this.onDndDrop));

                    var registry = dependency.resolve("epi.storeregistry");
                    this.statsStore = registry.get("app.chartstore");
                    if (this.statsStore == null)
                    {
                        registry.create("app.chartstore", routes.getRestPath({ moduleArea: "app", storeName: "chartstore" }));
                        this.statsStore = registry.get("app.chartstore");
                    }

                    this.contentStore = registry.get("epi.cms.content.light");

                    var contextService = epi.dependency.resolve("epi.shell.ContextService");
                    var currentContext = contextService.currentContext;
                    var res = currentContext.id.split("_");

                    this.currentContentId = res[0];

                    this.initCharts();                    
                });
            },

            initCharts: function() {
                dojo.when(this.statsStore.query(
                {
                    currentPageId: this.currentContentId
                }), lang.hitch(this, function (value) {
                        this.target.insertNodes(false, value);

                        for (var i in this.target.map) {

                            var data = this.target.getItem(i).data;
                            var divChart = dom.byId(i).childNodes[0];
                            this.renderChart(divChart.id, data);
                        }
                        dojo.query(".remove-chart").connect("onclick", lang.hitch(this, this.removeChart));
                    }));
            },

            chartsContentCreator: function (item, hint) {
                var uniqueId = common.getUniqueId();

                var li = document.createElement("li");
                li.setAttribute("id", "li-" + uniqueId);

                var div = document.createElement("div");
                div.setAttribute("id", "chart-" + uniqueId);
                div.setAttribute("class", "chart");

                li.appendChild(div);

                var divRemove = document.createElement("div");
                divRemove.setAttribute("class", "epi-iconTrash remove-chart");

                li.appendChild(divRemove);

                return { node: li, data: item };
            },

            onDndDrop: function (source, nodes, copy, target) {
                //var data = source.getItem(nodes[0].id)

                var chartId = Object.keys(target.selection)[0];                        
                var divChart = dom.byId(chartId).childNodes[0];

                this.renderChart(divChart, null);

                /*dojo.when(this.statsStore.query(
                {
                    currentPageId: this.currentContentId,
                    chartTypeId: data.data.id
                }), lang.hitch(this, function (value) {
                    this.renderChart(divChart.id, value);
                }));
                        
                var charts = [];
                for(var i in target.map){
                    charts.push(target.getItem(i).data.id);
                }
                this.statsStore.put({ currentPageId: this.currentContentId, guids: charts });*/
                dojo.query(".remove-chart").connect("onclick", lang.hitch(this, this.removeChart));
            },

            removeChart: function (evt, args) {
                var id = evt.currentTarget.parentElement.id;

                this.target.delItem(id);
                evt.currentTarget.parentElement.remove();

                var charts = [];
                for (var i in this.target.map) {
                    charts.push(this.target.getItem(i).data.id);
                }
                this.statsStore.put({ currentPageId: this.currentContentId, guids: charts });
            },

            renderChart: function (id, data) {
                var registry = dependency.resolve("epi.storeregistry");
                registry.create("app.chartstore1", routes.getRestPath({ moduleArea: "app", storeName: "chartstore1" }));
                var chartstore = registry.get("app.chartstore1");

                var lines = new dojox.charting.DataChart(id, {
                    displayRange: 7,
                    xaxis: { labels: ["0", "A", "B", "C", "D", "E", "F", "G", "H", "I", "J"] },
                    type: dojox.charting.plot2d.Lines
                });
                lines.setStore(chartstore, { symbol: "*" }, "historicPrice");

                var chart2 = new Chart(id);
                chart2.title = "testtest";
                chart2.titlePos = "bottom";
                chart2.titleGap = 25;
                chart2.titleFont = "20px Myriad,Helvetica,Tahoma,Arial,clean,sans-serif";
                chart2.titleFontColor = "#333";
                this.renderLineChart(chart2, null);

                switch (data.type) {
                    case "LineChart":
                        this.renderLineChart(chart2, data);
                        break;
                    case "PieChart":
                        this.renderPieChart(chart2, data);
                        break;
                    case "ColumnsChart":
                        this.renderColumnChart(chart2, data);
                        break;
                }               
            },

            renderLineChart(chart, data) {
                chart.addPlot("default", { type: "Lines" });
                chart.addAxis("y", { min: 1, max: 20, vertical: true, fixLower: "major", fixUpper: "major" });

                //chart.addAxis("x", { labels: data.data.xLabels });
                //chart.addSeries("Series 1", data.data.series);
                var registry = dependency.resolve("epi.storeregistry");
                registry.create("app.chartstore1", routes.getRestPath({ moduleArea: "app", storeName: "chartstore1" }));
                var chartstore = registry.get("app.chartstore1");

                chart.addSeries("Series 2", new DataSeries(chartstore, { query: { site: 1 } }, "value"));

                chart.render();
            },

            renderPieChart(chart, data) {
                chart.addPlot("default", {
                    type: "Pie",
                    radius: 100,
                    fontColor: "white"
                });
                chart.addAxis("x");
                chart.addAxis("y");

                chart.addSeries("", data.data.series);

                chart.render();
            },

            renderColumnChart(chart, data) {
                chart.addPlot("default", { type: "Columns", gap: 1 });
                chart.addAxis("y", { min: 1, max: 20, vertical: true, fixLower: "major", fixUpper: "major" });

                chart.addAxis("x", { labels: data.data.xLabels });
                chart.addSeries("Series 1", data.data.series);

                chart.render();
            }

        })
    }
);