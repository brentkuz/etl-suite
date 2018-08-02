//Utility helpers

(function ($, util) {
    var name = "Util";
    CheckDependencies(name, arguments);

    //Check module dependencies and log
    function CheckDependencies(caller, deps) {
        console.debug(caller + " loaded");
        for (var i = 0; i < deps.length; i++) {
            var dep = deps[i];
            if (!dep || dep == null)
                console.debug(caller + ": Missing dependency at argument idx = " + i);
        }
    }
    util.CheckDependencies = CheckDependencies;

    //Session helper
    util.Session = {
        Get: function (key) {
            var s = window.sessionStorage[key];
            return s == null ? null : JSON.parse(s);
        },
        Set: function (key, obj) {
            window.sessionStorage[key] = JSON.stringify(obj);
        },
        Reset: function (key) {
            window.sessionStorage[key] = null;
        }
    };

    //Console logger
    util.Log = function (src, msg, err) {
        console.debug(src + ": " + msg + (err ? " - " + err.message : ""));
    };

    //User notifications
    util.Notification = function (el) {
        return {
            Alert: function (msg) {
                //TODO: add in fancy modal
                alert(msg);
            },
            InUI: function (msg) {
                $(el).html(msg);
            },
            Prompt: function (msg) {
                return prompt(msg);
            }
        }
    };

    //UI loader/spinner
    util.Loader = function (el) {
        return {
            Show: function () {

            },
            Hide: function () {

            }
        }
    };  

    //load urls
    $(function () {
        alert($("#urlConfig").html())
        util.Urls = JSON.parse($("#urlConfig").html());
    })

})(jQuery, app.Util);