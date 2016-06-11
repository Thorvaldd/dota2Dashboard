$(function() {
    $('.bold a').click(function (e) {
        e.preventDefault();
        var a = $(this);
        var url = a.attr('href');
        var executeScript = a.data('get');
        var rebindUrl = a.attr('href');
        a.closest('ul').find('li').removeClass('active');
        a.closest('li').addClass('active');

        $.ajax({
            url: url,
            method: 'GET',
            dataType: 'html',
            success: function (html) {
                //load partialview
                $('.container').html(html);
                //change url
                window.history.pushState(null, null, rebindUrl.split('/').filter(x => x !== '')[0]);
                $.getScript('/Scripts/pages/' + executeScript + '.js');
            }
        });
    });
})