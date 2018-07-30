//namespaces
var app = app || {};
app.Util = app.Util || {};
app.Services = app.Services || {};
app.Models = app.Models || {};

(function ($) {
    var name = "App";
    CheckDependencies(name, arguments);

    //pub/sub
    var topics = {};

    $.Topic = function (id) {
        var callbacks,
            topic = id && topics[id];
        if (!topic) {
            callbacks = $.Callbacks();
            topic = {
                publish: callbacks.fire,
                subscribe: callbacks.add,
                unsubscribe: callbacks.remove
            };
            if (id) {
                topics[id] = topic;
            }
        }
        return topic;
    };

    function CheckDependencies(caller, deps) {
        console.log(caller + " loaded");
        for (var i = 0; i < deps.length; i++) {
            var dep = deps[i];
            if (!dep || dep == null)
                console.log(caller + ": Missing dependency at argument idx = " + i);
        }
    }


    //setup utilities
    app.Util.CheckDependencies = CheckDependencies;

    app.Util.Session = {
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

    app.Util.Notification = {
        Alert: function (msg) {
            //$("#alertModal").modal("show");
            alert(msg);
        },
        Log: function (caller, msg) {

        }
    };

})(jQuery);
