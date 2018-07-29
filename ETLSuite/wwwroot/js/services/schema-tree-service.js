//Schema Tree Data Service

app.Services.SchemaTreeService = app.Services.SchemaTreeService || (function ($, util) {
    var name = "SchemaTreeService";
    util.CheckDependencies(name, arguments);


    return {
        Name: name
    };

})(jQuery, app.Util);

