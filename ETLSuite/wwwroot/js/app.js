//App

(function ($, util, services, models, initializers) {
    var name = "App";
    util.CheckDependencies(name, arguments);
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

})(jQuery, app.Util, app.Services, app.Models, app.Initializers);
