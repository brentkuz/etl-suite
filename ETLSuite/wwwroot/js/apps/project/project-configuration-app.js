
//Project Configuration App

(function ($, Vue, util, initDbConnectionApp) {
    var name = "ProjectConfigurationApp";
    util.CheckDependencies(name, arguments);

    //ctor
    app.Initializers.ProjectConfigurationApp = function (projectId) {
        console.debug(name + " init");

        initDbConnectionApp(projectId);

    };

})(jQuery, Vue, app.Util, app.Initializers.DbConnectionApp);