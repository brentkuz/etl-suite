
//Project Configuration App

(function ($, Vue, util) {
    var name = "ProjectConfigurationApp";
    util.CheckDependencies(name, arguments);

    //ctor
    app.Initializers.ProjectConfigurationApp = function (projectId) {
        console.debug(name + " init");


    };

})(jQuery, Vue, app.Util);