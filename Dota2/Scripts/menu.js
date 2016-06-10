$(function() {
    $('.bold a').click(function (e) {
        e.preventDefault();
        var a = $(this);
        var url = a.attr('href');
        var rebindUrl = a.attr('data-rebind-url');
        a.closest('ul').find('li').removeClass('active');
        a.closest('li').addClass('active');

        $.ajax({
            url: url,
            method: 'GET',
            dataType: 'html',
            success: function (html) {
                //load partialview
                $('.container').html(html);
                var bindableNode = document.getElementById('bindContainer');
                //change url
                window.history.pushState(null, null, rebindUrl.split('/').filter(x => x !== '')[0]);
                //get data associated with current page
                $.get(rebindUrl, function (heroes) {
                    var viewModel = {};
                    viewModel.Model = ko.mapping.fromJS(heroes);

                    ko.cleanNode(bindableNode);
                    ko.applyBindings(viewModel, bindableNode);
                });
            }
        });
    });
})