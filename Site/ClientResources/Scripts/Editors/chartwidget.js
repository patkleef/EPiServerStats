define([
    // dojo
   "dojo",
   "dojo/_base/declare",
   "dojo/dom-construct",
   "dojo/on",
   "dojo/_base/lang",
   "dojo/query",
   "dojo/dom-attr",
   "dojo/when",
   "dojo/_base/array",

   // dojox
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

   // dijit
   "dijit/_Widget",

   // epi
   "epi/dependency",
   "epi/routes"
], function (
    // dojo
   dojo,
   declare,
   domConstruct,
   on,
   lang,
   query,
   domAttr,
   when,
   array,

   // dojox
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

   // dijit
   Widget,

   // epi
   dependency,
   routes
) {
    return declare("app.editors.ChartWidget", [Widget], {
        // summary:
        //      Chart widget
        // description:
        //      Widget for rendering a chart
        // tags:
        //      public

        store: null,
        currentPageId: 0,
        chartId: 0,

        postCreate: function () {
            // summary:
            //      Create layout for the widget
            // tags:
            //      protected

            var registry = dependency.resolve("epi.storeregistry");
            this.store = registry.get("chartstore");

            dojo.when(this.store.query(
                {
                    currentPageId: this.currentPageId,
                    chartId: this.chartId
                }),
                lang.hitch(this, this._renderChart));
        },

        _renderChart: function (data) {
            // summary:
            //      Renders the chart 
            // tags:
            //      private

            var chartElement = domConstruct.create("div", { class: "chart" }, this.domNode);
            var chart = new Chart(chartElement);
            chart.title = data.title;
            chart.titlePos = data.titlePosition;
            chart.titleGap = 10;
            chart.titleFont = "20px Myriad,Helvetica,Tahoma,Arial,clean,sans-serif";

            if (data.theme != null) {
                chart.setTheme(dojo.getObject("dojox.charting.themes." + data.theme));
            }

            switch (data.chartType) {
            case "LineChart":
                chart = this._renderLineChart(chart, data.data);
                break;
            case "ColumnsChart":
                chart = this._renderColumnsChart(chart, data.data);
                break;
            case "PieChart":
                chart = this._renderPieChart(chart, data.data);
                break;
            case "BubblesChart":
                chart = this._renderBubbleChart(chart, data.data);
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

            if (data.showLegend) {
                var chartLegendElement = domConstruct.create("div", { class: "chartLegend" }, chartElement);
                var selectableLegend = new SelectableLegend({ chart: chart, outline: true }, chartLegendElement);
            }
        },

        _renderLineChart: function (chart, data) {
            // summary:
            //      Renders a line chart
            // tags:
            //      public

            chart.addPlot("default", { type: "Lines", tension: "X", markers: true });

            chart.addAxis("y",
            {
                vertical: data.yAxLabel.vertical,
                fixLower: data.yAxLabel.fixLowerOption,
                fixUpper: data.yAxLabel.fixUpperOption,
                title: data.yAxLabel.text,
                titleOrientation: data.yAxLabel.titleOrientation
            });
            chart.addAxis("x",
            {
                labels: data.xAxLabel.items,
                title: data.xAxLabel.text,
                titleOrientation: data.yAxLabel
                    .titleOrientation
            });

            array.forEach(data.series,
                function(val, i) {
                    chart.addSeries(val.name, val.series, { stroke: { color: val.color } });
                });
            return chart;
        },

        _renderPieChart: function (chart, data) {
            // summary:
            //      Renders a pie chart
            // tags:
            //      public

            chart.addPlot("default", { type: "Pie", tension: "X" });
            
            chart.addSeries(data.series.name, data.series.dataItems);

            return chart;
        },

        _renderBubbleChart: function (chart) {
            // summary:
            //      Renders a bubble chart
            // tags:
            //      public

            chart.addPlot("default", { type: "Bubble" });

            chart.addAxis("x", { natual: true, includeZero: true, max: 7 });
            chart.addAxis("y", { natual: true, vertical: true, includeZero: true, max: 10 });

            chart.addSeries("Series 1", [{ x: 3, y: 5, size: 1 }, { x: 1, y: 7, size: 1 }, { x: 4, y: 2, size: 3 }]);
            return chart;
        },

        _renderColumnsChart: function (chart, data) {
            // summary:
            //      Renders a columns chart
            // tags:
            //      public
            chart.addPlot("default", { type: "Columns", gap: 2 });

            chart.addAxis("y",
            {
                vertical: data.yAxLabel.vertical,
                fixLower: data.yAxLabel.fixLowerOption,
                fixUpper: data.yAxLabel.fixUpperOption,
                title: data.yAxLabel.text,
                titleOrientation: data.yAxLabel.titleOrientation
            });
            chart.addAxis("x",
            {
                labels: data.xAxLabel.items,
                title: data.xAxLabel.text,
                titleOrientation: data.yAxLabel
                    .titleOrientation
            });

            array.forEach(data.series,
                function (val, i) {
                    chart.addSeries(val.name, val.series, { stroke: { color: val.color } });
                });
            return chart;
        }
    });
});