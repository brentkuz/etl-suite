
//Project Data Service

app.Services.ProjectService = app.Services.ProjectService || (function ($, util) {
    var name = "ProjectService";
    util.CheckDependencies(name, arguments);

    function GetProjects() {
        return $.getJSON("/ProjectData/GetProjects")
            .done(function (resp) {
                return resp;
            });
    }

    return {
        GetProjects: GetProjects

    };

})(jQuery, app.Util);