//Project List App

(function ($, Vue, util, projectService) {
    var name = "ProjectListApp";
    util.CheckDependencies(name, arguments);

    var session = app.Util.Session;
    var notif = app.Util.Notification;

    var defaultSort = {
        Col: "Name",
        Dir: true
    };

    var projects = new Vue({
        el: "#projectListApp",
        data: {
            Projects: [],
            SortCol: "",
            SortDir: null,
            Search: ""
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
                        Search: this.Search
                    })
            };
            
            this.GetProjects = function () {
                try {
                    projectService.GetProjects().done(function (resp) {                        
                        if (resp) {
                            self.Projects = resp.Data;
                            if (resp.Success == false) {
                                notif.Alert(resp.Notification);
                            }
                        }
                    });
                } catch{
                    notif.Log(name, err.message);
                }
            };

            //init
            var prevSess = session.Get(name);
            if (prevSess != null) {
                this.SortCol = prevSess.SortCol;
                this.SortDir = prevSess.SortDir;
                this.Search = prevSess.Search;
            } else {
                this.SortCol = defaultSort.Col;
                this.SortDir = defaultSort.Dir;
            }

            this.GetProjects();
        },
        methods: {
            sort: function (col) {
                if (this.SortCol == col)
                    this.SortDir = !this.SortDir;
                else
                    this.SortDir = true;
            }
        }

    });

})(jQuery, Vue, app.Util, app.Services.ProjectService)