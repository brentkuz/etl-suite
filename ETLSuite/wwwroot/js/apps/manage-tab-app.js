//Manage Tab App

(function (
    $,
    Vue,
    util,
    projectService,
    initProjectInfoApp,
    initProjectConfigurationApp,
    initProjectUploadSchemaApp,
    initProjectJobsApp
) {

    var name = "ManageTabApp";
    var contentTargetEl = "#contentTarget";
    
    util.CheckDependencies(name, arguments);

    var config = util.Config;
    var urls = util.Urls;

    var notif = util.Notification();

    //map tab name to an app init function
    var tabAppMap = {
        "ProjectInfo": initProjectInfoApp,
        "ProjectConfiguration": initProjectConfigurationApp,
        "ProjectUploadSchema": initProjectUploadSchemaApp,
        "ProjectJobs": initProjectJobsApp
    };

    $(function () {       

        var tabs = new Vue({
            el: "#manageTabApp",
            data: {
                CurrentTab: null
            },
            created: function () {
                this.InitTab = function (tab, projectId) {
                    projectService.GetTabTemplate(tab).done(function (resp) {
                        //load template
                        $(contentTargetEl).html(resp);

                        //init app
                        var init = tabAppMap[tab];

                        if (init)
                            init(projectId);
                        else
                            util.Log(name, "Failed to init " + tab + " tab app.")
                    });
                };
                this.InitTabApp = function (tab, projectId) {
                    //init app
                    var init = tabAppMap[tab];
                    if (init)
                        init(projectId);
                    else
                        util.Log(name, "Failed to init " + tab + " tab app.");
                };


                //init
                try {
                    this.InitTab(config.CurrentTab, config.ProjectId);
                    this.CurrentTab = config.CurrentTab;
                } catch (err) {
                    notif.UI("An error occured loading the page", true);
                    throw err;
                }

            },
            methods: {
                ChangeTab: function (e) {  
                    console.log("ChangeTab")
                    try {
                        var tab = $(e.target).data("id");
                        this.InitTab(tab, config.ProjectId);
                        this.CurrentTab = tab;
                    } catch(err){
                        notif.UI("An error occured loading the tab", true);
                        throw err;
                    }
                }    
            }
        })

    })

})(
    jQuery,
    Vue,
    app.Util,
    app.Services.ProjectService,
    app.Initializers.ProjectInfoApp,
    app.Initializers.ProjectConfigurationApp,
    app.Initializers.ProjectUploadSchemaApp,
    app.Initializers.ProjectJobsApp
);