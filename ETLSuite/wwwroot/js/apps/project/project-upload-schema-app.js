//Project Upload Schema App

(function ($, Vue, util, initializers) {
    var name = "ProjectUploadSchemaApp";
    util.CheckDependencies(name, arguments);

    //ctor
    initializers.ProjectUploadSchemaApp = function (projectId) {
        console.debug(name + " init");


    };

})(jQuery, Vue, app.Util, app.Initializers);