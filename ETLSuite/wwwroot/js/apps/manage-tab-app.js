//Manage Tab App

(function (
    $,
    Vue,
    util,
    initProjectInfoApp,
    initProjectConfigurationApp,
    initProjectUploadSchemaApp,
    initProjectJobsApp
) {

    var name = "ManageTabApp";
    var contentTargetEl = "#contentTarget";
    
    util.CheckDependencies(name, arguments);

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
                    $.get("/Project/GetTab?tab=" + tab, function (resp) {
                        //load template
                        $(contentTargetEl).html(resp);

                        //init app
                        var init = tabAppMap[tab];

                        if (init)
                            init(projectId);
                        else
                            util.Log(name, "Failed to init " + tab + " tab app.")
                    },
                        "html");
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

                } catch(err){
                    util.Log(name, "Failed to init", err);
                }

            },
            methods: {
                ChangeTab: function (tab) {    
                    try {
                        this.InitTab(tab, config.ProjectId);
                    } catch(err){
                        util.Log(name, "Failed to load tab");
                    }
                }
            }
        })

    })

})(
    jQuery,
    Vue,
    app.Util,
    app.Initializers.ProjectInfoApp,
    app.Initializers.ProjectConfigurationApp,
    app.Initializers.ProjectUploadSchemaApp,
    app.Initializers.ProjectJobsApp
);