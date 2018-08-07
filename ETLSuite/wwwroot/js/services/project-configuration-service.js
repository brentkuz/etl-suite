
//Project Configuration Data Service
(function ($, util, services) {
    var name = "ProjectConfigurationService";
    util.CheckDependencies(name, arguments);

    var config = util.Config;
    var urls = util.Urls;

    function GetAllDefinitions(projectId) {
        return $.getJSON(urls.DbConnectionData_GetAllDbConnections + projectId)
            .done(function (resp) {
                return resp;
            });
    }
    function GetDefinition(id) {
        return $.getJSON(urls.DbConnectionData_GetDefinition + id)
            .done(function (resp) {
                return resp;
            });
    }
    function SaveConnection(connection, type) {
        return $.post(urls.DbConnectionData_SaveConnection, {
            vm: connection,
            type: type
        })
            .done(function (resp) {
                return resp;
            });
    }

    services.ProjectConfigurationService = app.Services.DbConnectionService || {
        GetAllDefinitions: GetAllDefinitions,
        GetDefinition: GetDefinition,
        SaveConnection: SaveConnection
    };

})(jQuery, app.Util, app.Services);