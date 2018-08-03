
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
                StatusOptions: []
            },
            created: function(){
                this.GetProjectInfo = function (id) {
                    var self = this;
                    projectService.GetProjectInfo(id).done(function (resp) {
                        if (resp) {
                            if (resp.Success && resp.Data) {
                                var p = resp.Data;
                                self.Name = p.Name;
                                self.Description = p.Description;
                                self.SelectedStatus = p.SelectedStatus;

                                for (var key in p.StatusOptions) {
                                    if (!p.StatusOptions.hasOwnProperty(key)) continue;

                                    self.StatusOptions.push({
                                        Value: key,
                                        Text: p.StatusOptions[key]
                                    })
                                };
                                                            
                            }
                        }
                    })
                }


                //init 
                try {
                    this.GetProjectInfo(projectId);

                } catch (err) {
                    notif.UI("An error occurred loading the project", true);
                    throw err;
                }
            },
            methods: {

            }
        })
    };

})(jQuery, Vue, app.Util, app.Services.ProjectService);
