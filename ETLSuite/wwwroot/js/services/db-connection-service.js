
//Db Connection Data Service
(function ($, util, services) {
    var name = "DbConnectionService";
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
    function SaveSqlServerConnection(connection) {
        return $.post(urls.DbConnectionData_SaveSqlServerConnection, {
            vm: connection
        })
            .done(function (resp) {
                return resp;
            });
    }

    services.DbConnectionService = app.Services.DbConnectionService || {
        GetAllDefinitions: GetAllDefinitions,
        GetDefinition: GetDefinition,
        SaveSqlServerConnection: SaveSqlServerConnection
    };

})(jQuery, app.Util, app.Services);