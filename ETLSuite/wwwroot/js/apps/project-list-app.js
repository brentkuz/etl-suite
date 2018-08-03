//Project List App

(function ($, Vue, util, projectService) {
    var name = "ProjectListApp";
    util.CheckDependencies(name, arguments);

    var config = util.Config;
    var urls = util.Urls;

    var session = util.Session;

    var defaultSort = {
        Col: "Name",
        Dir: true
    };

    var notif = util.Notification();

    //bind ui
    $(function () {

        var projects = new Vue({
            el: "#projectListApp",
            data: {
                Projects: [],
                SortCol: "",
                SortDir: null,
                SearchPhrase: ""
            },
            created: function () {
                var self = this;

                this.updateSession = function (reset) {
                    if (reset)
                        session.Reset();
                    else
                        session.Set(name, {
                            SortCol: this.SortCol,
                            SortDir: this.SortDir,
                            SearchPhrase: this.SearchPhrase
                        })
                };

                this.GetProjects = function () {
                    try {
                        projectService.GetProjects().done(function (resp) {
                            if (resp) {
                                self.Projects = resp.Data;
                                if (resp.Success == false) {
                                    notif.UI(resp.Notification, true);
                                }
                            }
                        });
                    } catch (err) {
                        notif.UI("An error occurred loading projects", true);
                        throw err;
                    }
                };

                //init
                var prevSess = session.Get(name);
                if (prevSess != null) {
                    this.SortCol = prevSess.SortCol;
                    this.SortDir = prevSess.SortDir;
                    this.SearchPhrase = prevSess.SearchPhrase;
                } else {
                    this.SortCol = defaultSort.Col;
                    this.SortDir = defaultSort.Dir;
                }

                this.GetProjects();
            },
            methods: {
                Sort: function (col) {
                    if (this.SortCol == col)
                        this.SortDir = !this.SortDir;
                    else
                        this.SortDir = true;
                },
                CreateProject: function () {
                    var projectName = notif.Prompt("Please enter the name of your new project.");
                    window.location.href = urls.Project_Create + projectName;
                }
            }

        });
    });

})(jQuery, Vue, app.Util, app.Services.ProjectService)