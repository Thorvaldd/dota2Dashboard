var bind = document.getElementById('bindContainer');
function ViewModel() {
    var self = this;
    this.UserInfo = ko.mapping.fromJS([]);
    self.nick = ko.observable();

    self.getUserInfo = function (form) {
        $.get('/Stats/GetUserInfo?nickName=' + ko.toJS(form.nick), function (result) {
            self.UserInfo([]);
           self.UserInfo.push(ko.mapping.fromJS(result));
        });
    }
}

ko.cleanNode(bind);
ko.applyBindings(new ViewModel(), bind);