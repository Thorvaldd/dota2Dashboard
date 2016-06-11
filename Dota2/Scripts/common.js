//(function() {
//    var snackBarContainer = document.querySelector('#snackbar');
//    var handler = function(event) {
//        snackBarContainer.style.backgroundColor = '#fff';
//    }
//    window.addEventListener('load', function(event) {
//        var data = {
//            message: 'Api loaded',
//            timeout: 2000,
//            actionHandler: handler,
//            actionText: 'x'
//        }

//        snackBarContainer.MaterialSnackbar.showSnackbar(data);
//    });
//}());
function initThead() {
    if ($('body').hasClass('loaded')) {
        var $table = $('table');

        $table.on('floatThead', function (e, isFloated, $floatContainer) {
            if (isFloated) {
                $('table thead').addClass('floated');
            } else {
                $('table thead').removeClass('floated');
            }
        });

     
    }
    $('table').floatThead({
        position: 'fixed',
        top: 65
    });
}

window.addEventListener('scroll', initThead);