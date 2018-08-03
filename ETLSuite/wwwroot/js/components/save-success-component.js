//Vue Component - Save button

(function ($, Vue, util) {
    var name = "SaveButtonComponent";
    util.CheckDependencies(name, arguments);

    Vue.component("save-success", {
        props: [
            'value'
        ],
        template: '<span v-if="value === true"><img src="/images/icons/success-icon.png" width="25"/></span>'
    });

})(jQuery, Vue, app.Util);
