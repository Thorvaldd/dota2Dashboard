function UserInfoViewModel() {
    var self = this;

    self.Model = ko.mapping.fromJS([]);

    self.getUserInfo = function(nickName) {
        $.get('/Stats/GetUserInfo?nickName=' + nickName, function(result) {
            ko.mapping.fromJS(result, self.Model);
        });
    }
}

ko.applyBinding(new UserInfoViewModel())