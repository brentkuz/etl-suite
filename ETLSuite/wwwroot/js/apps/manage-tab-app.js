//Manage Tab App

(function ($, Vue, util, initProjectInfoApp) {
    var name = "ManageTabApp";
    var contentTargetEl = "#contentTarget";
    
    util.CheckDependencies(name, arguments);

    //map tab name to an app init function
    var tabAppMap = {
        "Info": initProjectInfoApp
    };

    $(function () {
        var tabs = new Vue({
            el: "#manageTabApp",
            data: {
                CurrentTab: null
            },
            created: function () {

            },
            methods: {
                ChangeTab: function (tab) {    
                    try {
                        $.get("/Project/GetTab?tab=" + tab, function (resp) {
                            $(contentTargetEl).html(resp);
                            var init = tabAppMap[tab];

                            if (init)
                                init();
                            else
                                console.log(name + ": Failed to init " + tab + " tab app.");
                        },
                            "html");

                        this.CurrentTab = tab;
                    } catch{
                        console.log(name + " failed to load tab");
                    }
                }
            }
        })

    })

})(jQuery, Vue, app.Util, app.Init.ProjectInfoApp);