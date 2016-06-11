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

   "epi/dependency",
    "epi/routes"
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

   dependency,
   routes
) {
    return declare("app.editors.ChartWidget", [
        Widget
    ],
    {
        store: null,
        currentPageId: 0,
        chartId: 0,
        
        postCreate: function () {
            var registry = dependency.resolve("epi.storeregistry");
            this.store = registry.get("chartstore");

            dojo.when(this.store.query(
                {
                    currentPageId: this.currentPageId, chartId: this.chartId
                }), lang.hitch(this, this.renderChart));
        },

        renderChart: function (data) {
            var chartElement = domConstruct.create("div", { class: "chart" }, this.domNode);
            var chart = new Chart(chartElement);
            chart.title = data.title;
            chart.titlePos = data.titlePosition;
            chart.titleGap = 10;
            chart.titleFont = "20px Myriad,Helvetica,Tahoma,Arial,clean,sans-serif";

            if (data.theme != null)
            {
                chart.setTheme(dojo.getObject("dojox.charting.themes." + data.theme));
            }

            switch (data.chartType) {
                case "LineChart":
                    chart = this.renderLineChart(chart, data.data);
                    break;
                case "ColumnsChart":
                    chart = this.renderColumnsChart(chart);
                    break;
                case "PieChart":
                    chart = this.renderPieChart(chart);
                    break;
                case "BubblesChart":
                    chart = this.renderBubbleChart(chart);
                    break;
            }

            if (data.actionAndEffects != null) {
                var effectsArray = data.actionAndEffects.split(",");

                if (dojo.indexOf(effectsArray, "Highlight") !== -1) {
                    var chartHighlight = new dojox.charting.action2d.Highlight(chart, "default");
                }
                if (dojo.indexOf(effectsArray, "Magnify") !== -1) {
                    var chartMagnify = new Magnify(chart, "default", { scale: 2 });
                }
                if (dojo.indexOf(effectsArray, "MoveSlice") !== -1) {
                    var chartMoveSlice = new MoveSlice(chart, "default", { scale: 2, shift: 7 });
                }
                if (dojo.indexOf(effectsArray, "Shake") !== -1) {
                    var chartShake = new Shake(chart, "default", { shiftX: 5, shiftY: 5 });
                }
                if (dojo.indexOf(effectsArray, "Tooltip") !== -1) {
                    var chartTooltip = new Tooltip(chart, "default");
                }
                if (dojo.indexOf(effectsArray, "MouseZoomAndPan") !== -1) {
                    var chartMousezoomandpan = new MouseZoomAndPan(chart, "default", { axis: "x" });
                }
                if (dojo.indexOf(effectsArray, "MouseIndicator") !== -1) {
                    var chartMouseindicator = new MouseIndicator(chart,
                        "default",
                        {
                            series: "Series 1",
                            mouseOver: true,
                            font: "normal normal bold 12pt Tahoma",
                            fillFunc: function(v) {
                                return "green";
                            },
                            labelFunc: function(v) {
                                return "x: " + v.x + ", y:" + v.y;
                            }
                        });
                }
            }
            chart.render();

            if (data.showLegend == "True") {
                var chartLegendElement = domConstruct.create("div", { class: "chartLegend" }, chartElement);
                var selectableLegend = new SelectableLegend({ chart: chart, outline: true }, chartLegendElement);
            }
        },

        renderLineChart: function (chart, data) {
            chart.addPlot("default", { type: "Lines", tension: "X", markers: true });

            chart.addAxis("y", { vertical: data.yAxLabel.vertical, fixLower: data.yAxLabel.fixLowerOption, fixUpper: data.yAxLabel.fixUpperOption, title: data.yAxLabel.text, titleOrientation: data.yAxLabel.titleOrientation });
            chart.addAxis("x", { labels: data.xAxLabel.items, title: data.xAxLabel.text, titleOrientation: data.yAxLabel.titleOrientation });

            array.forEach(data.series, function (val, i) {
                chart.addSeries(val.name, val.series, { stroke: { color: val.color } });
            });
            return chart;
        },

        renderPieChart: function (chart) {
            chart.addPlot("default", { type: "Pie", tension: "X" });

            var dataSet1 = [{ y: 3, text: "2012" },
                            { y: 7, text: "2013" },
                            { y: 4, text: "2014" },
                            { y: 9, text: "2015" },
                            { y: 6, text: "2016" }];

            var dataSet2 = [2, 5, 2, 5, 7, 3, 1];

            chart.addSeries("Series 1", dataSet1);

            return chart;
        },

        renderBubbleChart: function (chart) {
            chart.addPlot("default", { type: "Bubble" });
            chart.addAxis("x", { natual: true, includeZero: true, max: 7 });
            chart.addAxis("y", { natual: true, vertical: true, includeZero: true, max: 10 });

            chart.addSeries("Series 1", [{ x: 3, y: 5, size: 1 }, { x: 1, y: 7, size: 1 }, { x: 4, y: 2, size: 3 }]);
            return chart;
        },

        renderColumnsChart: function (chart) {
            chart.addPlot("default", { type: "Columns", gap: 2 });
            chart.addAxis("y", { min: 1, max: 800, vertical: true, fixLower: "major", fixUpper: "major" });

            var lineChartXaxisData = [
                { value: 1, text: "2007" },
                { value: 2, text: "2008" },
                { value: 3, text: "2009" },
                { value: 4, text: "2010" },
                { value: 5, text: "2011" },
                { value: 6, text: "2012" },
                { value: 7, text: "2013" },
                { value: 8, text: "2014" },
                { value: 9, text: "2015" },
                { value: 10, text: "2016" }];

            chart.addAxis("x", { labels: lineChartXaxisData });
            chart.addSeries("Series 1", [90, 360, 230, 670, 410, 150, 480, 190, 290, 590]);
            return chart;
        }
    })
});