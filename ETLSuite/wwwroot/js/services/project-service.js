
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
    function GetTabTemplate(tab) {
        return $.get(urls.Project_GetTab + tab,
            function (resp) {
                return resp;
            },
            "html"
        );
    }
    function GetProjectInfo(id) {
        return $.getJSON(urls.ProjectData_GetProjectInfo + id)
            .done(function (resp) {
                return resp;
            });
    }
    function SaveProjectInfo(project) {
        return $.post(urls.ProjectData_SaveProjectInfo, project)
            .done(function (resp) {
                return resp;
            });
    }
    function GetDbConnectionEditTemplate(configType) {
        return $.get(urls.Project_GetDbConnectionEditTemplate + configType,
            function (resp) {
                return resp;
            },
            "html"
        );
           
    }

    services.ProjectService = app.Services.ProjectService || {
        GetProjects: GetProjects,
        GetTabTemplate: GetTabTemplate,
        GetProjectInfo: GetProjectInfo,
        SaveProjectInfo: SaveProjectInfo,
        GetDbConnectionEditTemplate: GetDbConnectionEditTemplate
    };

})(jQuery, app.Util, app.Services);