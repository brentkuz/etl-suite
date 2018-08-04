
//Db Connection Data Service
(function ($, util, services) {
    var name = "DbConnectionService";
    util.CheckDependencies(name, arguments);

    var config = util.Config;
    var urls = util.Urls;

    function GetAllDefinitions(projectId) {
        return $.getJSON(urls.DbConnectionData_GetAll + projectId)
            .done(function (resp) {
                return resp;
            });
    }

    services.DbConnectionService = app.Services.DbConnectionService || {
        GetAllDefinitions: GetAllDefinitions
    };

})(jQuery, app.Util, app.Services);