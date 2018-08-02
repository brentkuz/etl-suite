
//Project Data Service
(function ($, util, services) {
    var name = "ProjectService";
    util.CheckDependencies(name, arguments);

    var config = util.Config;
    var urls = util.Urls;

    function GetProjects() {
        return $.getJSON(urls.ProjectData_GetProjects)
            .done(function (resp) {
                return resp;
            });
    }
    function GetTab(tab) {
        return $.get(urls.Project_GetTab + tab, function (resp) {
                return resp;
            },
            "html"
        );
    }

    services.ProjectService = app.Services.ProjectService || {
        GetProjects: GetProjects,
        GetTab: GetTab
    };

})(jQuery, app.Util, app.Services);