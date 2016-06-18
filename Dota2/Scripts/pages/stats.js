var bind = document.getElementById('bindContainer');
function ViewModel() {
    var self = this;
    this.UserInfo = ko.mapping.fromJS([]);
    self.nick = ko.observable();

    self.updateScrollBar = function () {
        var $container = $('#recent-games');
        setTimeout(function() {
            $container.scrollTop(1);
            $container.perfectScrollbar('update');
        }, 700);


    }

    self.getUserInfo = function (form) {
        $.get('/Stats/GetUserInfo?nickName=' + ko.toJS(form.nick), function (result) {
            self.UserInfo([]);
            self.UserInfo.push(ko.mapping.fromJS(result));
            bindScrollBar();
        });
    }

    function bindScrollBar() {
        var recentGames = $('#recent-games').height();
        $('#recent-games').height(recentGames).perfectScrollbar({
            suppressScrollX: true
        });
    }

   
}

ko.cleanNode(bind);
ko.applyBindings(new ViewModel(), bind);