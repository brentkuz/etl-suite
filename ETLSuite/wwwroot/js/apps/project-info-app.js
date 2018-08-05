
//Project Info App

(function ($, Vue, util, projectService) {
    var name = "ProjectInfoApp";
    util.CheckDependencies(name, arguments);

    var notif = util.Notification();

    //ctor
    app.Initializers.ProjectInfoApp = function (projectId) {
        console.debug(name + " init");

        var projectInfo = new Vue({
            el: "#projectInfoApp",
            data: {
                Id: projectId,
                Name: "",
                Description: "",
                SelectedStatus: "",
                StatusOptions: [],
                SaveSuccess: false                
            },
            created: function () {
                this.BindData = function (p) {
                    this.Name = p.Name;
                    this.Description = p.Description;
                    this.SelectedStatus = p.SelectedStatus;

                    for (var key in p.StatusOptions) {
                        if (!p.StatusOptions.hasOwnProperty(key)) continue;

                        this.StatusOptions.push({
                            Value: key,
                            Text: p.StatusOptions[key]
                        })
                    };
                };
                this.GetProjectInfo = function (id) {
                    var self = this;
                    projectService.GetProjectInfo(id).done(function (resp) {
                        if (resp) {
                            if (resp.Success && resp.Data) {
                                var p = resp.Data;
                                self.BindData(p);
                            }
                        }
                    })
                };

                //init 
                try {
                    this.GetProjectInfo(projectId);
                    this.SaveSuccess = false;

                } catch (err) {
                    notif.UI("An error occurred loading the project", true);
                    throw err;
                }
            },
            methods: {
                submit: function (e) {
                    e.preventDefault();
                    var self = this;
                    try {
                        self.SaveSuccess = false;
                        projectService.SaveProjectInfo({
                            Id: this.Id,
                            Name: this.Name,
                            Description: this.Description,
                            SelectedStatus: this.SelectedStatus
                        }).done(function (resp) {
                            if (resp) {
                                if (resp.Success) {
                                    self.SaveSuccess = true;
                                } else {
                                    self.SaveSuccess = false;
                                    notif.UI(resp.Notification, true);
                                    self.BindData(resp.Data);
                                }
                            }

                        });
                        
                    } catch (err) {
                        notif.UI("An error occurred saving your changes", true);
                        self.SaveSuccess = false;
                        throw err;
                    }
                    
                }
            }
        })
    };

})(jQuery, Vue, app.Util, app.Services.ProjectService);
