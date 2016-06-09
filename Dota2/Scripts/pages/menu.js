var viewModel = {};
$(function () {
    $('.bold a').click(function (e) {
        $(this).closest('ul').find('li').removeClass('active');
        $(this).closest('li').addClass('active');
        e.preventDefault();
        var url = $(this).attr('href');
        var rebindUrl = $(this).data('rebindUrl');
        $.ajax({
            url: url,
            method: 'GET',
            dataType: 'html',
            success: function (html) {
                $('.container').html(html);

                window.history.pushState(null, null, url.split('/').filter(x=> x !== '')[0]);
                $.get(rebindUrl, function (data) {
                    viewModel.Model = ko.mapping.fromJS(data);

                    ko.applyBindings(viewModel, document.getElementById('bindContainer'));
                });
            }
        });

    });
});