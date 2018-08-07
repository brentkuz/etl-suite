
//Db Connection App

(function ($, Vue, util, configService, projectService) {
    var name = "DbConnectionApp";
    util.CheckDependencies(name, arguments);


    var modal = util.AppModal;

    var tmplCache = {};    

    //ctors
    function initSqlServerEditApp(id) {
        var notif = util.Notification("#sqlEditNotification");

        var sqlEdit = new Vue({
            el: "#sqlServerEditApp",
            data: {
                Selected: {},
                SaveSuccess: false
            },
            created: function () {
                this.GetById = function (id) {
                    var self = this;
                    configService.GetDefinition(id)
                        .done(function (resp) {
                            if (resp) {
                                self.Selected = resp.Data;
                                if (resp.Success === false) {
                                    notif.UI(resp.Notification, true);
                                }
                            }
                        });
                };

                try {
                    this.GetById(id);
                } catch (err) {
                    notif.UI("An error occurred loading the connection.", true);
                    throw err;                    
                }

            },
            methods: {
                Submit: function () {
                    var self = this;
                    try {
                        configService.SaveConnection(self.Selected, "SqlServer")
                            .done(function (resp) {
                                if (resp) {
                                    if (resp.Success) {
                                        self.SaveSuccess = true;
                                    } else {
                                        self.SaveSuccess = false;
                                        notif.UI("Your changes were not saved.", true);
                                    }
                                }
                            });

                    } catch (err) {
                        notif.UI("An error occurred saving.", true);
                        this.SaveSuccess = false;
                        throw err;
                    }
                }
            }
        });
    }

    app.Initializers.DbConnectionApp = function (projectId) {
        console.debug(name + " init"); 
        var notif = util.Notification("#dbConnectionAppNotification");

        var app = new Vue({
            el: "#dbConnectionApp",
            data: {
                Definitions: [],
                Selected: null
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
                    var self = this;
                    if (id !== undefined && dbType !== undefined) {
                        try {
                            if (tmplCache.hasOwnProperty(dbType)) {
                                //use cached template
                                modal.SetTemplate(tmplCache[dbType]);
                                initSqlServerEditApp(id);
                                modal.Show();
                            } else {
                                //get template and cache it
                                projectService.GetDbConnectionEditTemplate(dbType).done(function (resp) {
                                    if (resp) {
                                        modal.SetTemplate(resp);
                                        initSqlServerEditApp(id);
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