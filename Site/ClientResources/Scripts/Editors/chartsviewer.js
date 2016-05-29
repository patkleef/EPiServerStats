define([
    "dojo/_base/declare",
    "dojo/dnd/Source",
    "dojo/dnd/common",
    "dojo/parser",
    "dojo/ready",
    "dojo/when",
     "dojo/_base/lang",
    "dojo/_base/array",
    "dojo/text!./Templates/chartsviewtemplate.html",
    "dijit/_TemplatedMixin",
    "dijit/_Widget",
    

    "epi/dependency",
    "epi/routes",

    "dojo/domReady!",
], function (
    declare,
    Source,
    common,
    parser,
    ready,
    when,
    lang,
    array,
    template,
    _TemplatedMixin,
    _Widget,

    dependency,
    routes
) {
    return declare("app.editors.chartsviewer",
        [_Widget, _TemplatedMixin], {
            templateString: template,
            statsStore: null,
            contentStore: null,
            source: null,

            postCreate: function () {                

                ready(this, function () {
                    this.source = new Source("charts-menu-list", { copyOnly: true, selfAccept: "false", creator: this.chartsViewItemCreator });

                    var registry = dependency.resolve("epi.storeregistry");
                    registry.create("app.chartstore", routes.getRestPath({ moduleArea: "app", storeName: "chartstore" }));
                    this.statsStore = registry.get("app.chartstore");
                    
                    dojo.when(this.statsStore.query(
                        {
                        }), lang.hitch(this, function (value) {
                            var arr = [];
                            array.forEach(value, function (val, i) {
                                arr.push(val);
                            });
                            this.source.insertNodes(false, arr);
                        }));
                });                
            },

            chartsViewItemCreator: function (item, hint) {
                if (hint == "avatar") {
                    var div = document.createElement("div");
                    div.appendChild(document.createTextNode(item.name));

                    return { node: div, data: item, type: ["charts-menu-item"] };
                }
                else {
                    var uniqueId = common.getUniqueId();
                    var li = document.createElement("li");
                    li.setAttribute("id", uniqueId);

                    var span = document.createElement("span");
                    span.setAttribute("class", "list-icon epi-iconTiles");

                    li.appendChild(span);
                    li.appendChild(document.createTextNode(" " + item.name));

                    return { node: li, data: item, type: ["charts-menu-item"] };
                }                
            }
        });
});

