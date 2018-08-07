//Project Jobs App

(function ($, Vue, util, initializers) {
    var name = "ProjectJobsApp";
    util.CheckDependencies(name, arguments);

    //ctor
    initializers.ProjectJobsApp = function (projectId) {
        console.debug(name + " init");


    };

})(jQuery, Vue, app.Util, app.Initializers);