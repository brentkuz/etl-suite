
//Project Configuration Data Service
(function ($, util, services) {
    var name = "ProjectConfigurationService";
    util.CheckDependencies(name, arguments);

    var config = util.Config;
    var urls = util.Urls;

    function GetAllDefinitions(projectId) {
        return $.getJSON(urls.DbConnectionData_GetAll + projectId)
            .done(function (resp) {
                return resp;
            });
    }
    function GetDefinition(id) {
        
    }

    services.ProjectConfigurationService = app.Services.DbConnectionService || {
        GetAllDefinitions: GetAllDefinitions
    };

})(jQuery, app.Util, app.Services);