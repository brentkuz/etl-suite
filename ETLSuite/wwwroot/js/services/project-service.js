
//Project Data Service
(function ($, util, services) {
    var name = "ProjectService";
    util.CheckDependencies(name, arguments);

    function GetProjects() {
        return $.getJSON("/ProjectData/GetProjects")
            .done(function (resp) {
                return resp;
            });
    }

    services.ProjectService = app.Services.ProjectService || {
        GetProjects: GetProjects
    };

})(jQuery, app.Util, app.Services);