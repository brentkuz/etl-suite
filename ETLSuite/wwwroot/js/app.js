//namespaces
var app = app || {};
app.Util = app.Util || {};
app.Services = app.Services || {};
app.Models = app.Models || {};

(function ($) {
    console.log("load common")

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

    //setup utilities
    app.Util.CheckDependencies = function (caller, deps) {
        console.log(caller + " loaded");
        for (var i = 0; i < deps.length; i++) {
            var dep = deps[i];
            if (!dep || dep == null)
                console.log(caller + ": Missing dependency at argument idx = " + i);
        }
    }

    app.Util.Session = {
        get: function (key) {
            var s = window.sessionStorage[key];
            return s == null ? null : JSON.parse(s);
        },
        set: function (key, obj) {
            window.sessionStorage[key] = JSON.stringify(obj);
        },
        reset: function (key) {
            window.sessionStorage[key] = null;
        }
    }
    


})(jQuery);
