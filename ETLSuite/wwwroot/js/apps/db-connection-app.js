
//Db Connection App

(function ($, Vue, util, configService, projectService) {
    var name = "DbConnectionApp";
    util.CheckDependencies(name, arguments);

    var template = "DbConnectionEdit";

    var modal = util.AppModal;

    //ctor
    app.Initializers.DbConnectionApp = function (projectId) {
        console.debug(name + " init");        

        var notif = util.Notification("#dbConnectionAppNotification");

        var app = new Vue({
            el: "#dbConnectionApp",
            data: {
                Definitions: [],
                EditTemplate: null
            },
            created: function () {
                var self = this;
                this.GetAll = function () {                    
                    configService.GetAllDefinitions(projectId)
                        .done(function (resp) {
                            if (resp) {
                                self.Definitions = resp.Data;
                                if (resp.Success == false) {
                                    notif.UI(resp.Notification, true);
                                }
                            }

                        });
                };               

                //init
                try {
                    this.GetAll();
                    //get template and cache it
                    projectService.GetConfigurationEditTemplate(template).done(function (resp) {
                        if (resp) {
                            self.EditTemplate = resp;
                        }
                    });
                } catch (err) {
                    notif.UI("An error occurred loading connection definitions.", true);
                    throw err;
                }
            },
            methods: {
                EditConnection: function (id) {
                    if (id && this.EditTemplate) {
                        try {
                            modal.SetTemplate(this.EditTemplate);
                            modal.Show();
                        } catch (err) {
                            notif.UI("An error occurred loading the connection definition.", true);
                            throw err;
                        }
                    }
                }
            }
        })


    };

})(jQuery, Vue, app.Util, app.Services.ProjectConfigurationService, app.Services.ProjectService);