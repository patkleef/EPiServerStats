define([
    "dojo",
    "dojo/_base/declare",
    "epi/_Module",
    "epi/dependency",
    "epi/routes"
], function (
    dojo,
    declare,
    _Module,
    dependency,
    routes
) {
    return declare([_Module], {
        initialize: function () {
            this.inherited(arguments);

            var registry = this.resolveDependency("epi.storeregistry");
            //Register the store
            registry.create("chartstore", this._getRestPath("chartstore"));
        },

        _getRestPath: function (name) {
            return routes.getRestPath({ moduleArea: "app", storeName: name });
        }
    });
});