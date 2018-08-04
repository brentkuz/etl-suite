
//Db Connection App

(function ($, Vue, util, connectionService) {
    var name = "DbConnectionApp";
    util.CheckDependencies(name, arguments);

    //ctor
    app.Initializers.DbConnectionApp = function (projectId) {
        console.debug(name + " init");        

        var notif = util.Notification("#dbConnectionAppNotification");

        var app = new Vue({
            el: "#dbConnectionApp",
            data: {
                Definitions: []
            },
            created: function () {
                this.GetAll = function () {
                    var self = this;
                    connectionService.GetAllDefinitions(projectId)
                        .done(function (resp) {
                            if (resp) {
                                self.Definitions = resp.Data;
                                if (resp.Success == false) {
                                    notif.UI(resp.Notification, true);
                                }
                            }

                        });
                }

                try {
                    this.GetAll();
                } catch (err) {
                    notif.UI("An error occurred loading connection definitions.", true);
                    throw err;
                }
            },
            methods: {

            }
        })


    };

})(jQuery, Vue, app.Util, app.Services.DbConnectionService);