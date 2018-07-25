/// <binding AfterBuild='default' />
var gulp = require("gulp"),
    log = require("gulplog"),
    gutil = require("gulp-util")
merge = require("gulp-merge");


var deps = {
    "vue": {
        "dist/*": ""
    },
    "jquery": {
        "dist/*": ""
    },
    "jquery-validation": {
        "dist/*": ""
    },
    "jquery-validation-unobtrusive": {
        "dist/*": ""
    },
    "bootstrap": {
        "dist/**/*": ""
    },
    "lodash": {
        "lodash.js": ""
    },
    "lodash": {
        "lodash.min.js": ""
    }
}

gulp.task("default", function () {
    var streams = [];

    for (var prop in deps) {
        console.log("Prepping Scripts for: " + prop);
        for (var itemProp in deps[prop]) {
            streams.push(gulp.src("node_modules/" + prop + "/" + itemProp)
                .pipe(gulp.dest("wwwroot/vendor/" + prop + "/" + deps[prop][itemProp])));
        }
    }

    return merge(streams);
});