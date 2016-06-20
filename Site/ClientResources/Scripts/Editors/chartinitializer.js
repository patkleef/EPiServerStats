define([
    // dojo
    "dojo",
    "dojo/_base/declare",

    // epi
    "epi/_Module",
    "epi/dependency",
    "epi/routes"
], function (
    // dojo
    dojo,
    declare,

    // epi
    _Module,
    dependency,
    routes
) {
    return declare([_Module], {
        // summary:
        //      Initialize the charts module
        // description:
        //      Register the chart store so it can be used in the other widgets
        // tags:
        //      public

        initialize: function () {
            // summary:
            //      Initialize
            // tags:
            //      public

            this.inherited(arguments);

            var registry = this.resolveDependency("epi.storeregistry");
            //Register the store
            registry.create("chartstore", this._getRestPath("chartstore"));
        },

        _getRestPath: function (name) {
            // summary:
            //      get path to the rest store
            // tags:
            //      private

            return routes.getRestPath({ moduleArea: "app", storeName: name });
        }
    });
});