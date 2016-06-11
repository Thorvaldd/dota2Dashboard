var Routing = function(appRoot, selector, defaultRoute) {
    
    function getUrlFromHash(hash) {
        var url = hash.replace('#/', '');
        if (url === appRoot)
            url = defaultRoute;

        return url;
    }

    return {
        init: function() {
            Sammy(selector, function() {
                this.get(/\#\/(.*)/, function(ctx) {
                    var url = getUrlFromHash(ctx.path);
                    ctx.load(url).swap();
                });
            }).run('#/');
        }
    }
}