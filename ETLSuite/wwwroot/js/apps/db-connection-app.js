
//Db Connection App

(function ($, Vue, util, configService, projectService) {
    var name = "DbConnectionApp";
    util.CheckDependencies(name, arguments);


    var modal = util.AppModal;

    var tmplCache = {};

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
                var self = this;
                this.GetAll = function () {                    
                    configService.GetAllDefinitions(projectId)
                        .done(function (resp) {
                            if (resp) {
                                self.Definitions = resp.Data;
                                if (resp.Success === false) {
                                    notif.UI(resp.Notification, true);
                                }
                            }

                        });
                };  
                this.GetById = function (id) {

                };

                //init
                try {
                    this.GetAll();
                } catch (err) {
                    notif.UI("An error occurred loading connection definitions.", true);
                    throw err;
                }
            },
            methods: {
                EditConnection: function (id, dbType) {
                    if (id !== undefined && dbType !== undefined) {
                        try {
                            if (tmplCache.hasOwnProperty(dbType)) {
                                //use cached template
                                modal.SetTemplate(tmplCache[dbType]);
                                modal.Show();
                            } else {
                                //get template and cache it
                                projectService.GetDbConnectionEditTemplate(dbType).done(function (resp) {
                                    if (resp) {
                                        modal.SetTemplate(resp);
                                        modal.Show();
                                        tmplCache[dbType] = resp;
                                    }
                                });
                            }
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