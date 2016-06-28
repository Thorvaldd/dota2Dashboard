var bind = document.getElementById('bindContainer');
function ViewModel() {
    var self = this;
    this.UserInfo = ko.mapping.fromJS([]);
    self.nick = ko.observable();
    self.Games = ko.observableArray([]);
    self.recentMatches = ko.mapping.fromJS([]);

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
            self.recentMatches(result.RecentlyPlayedGames.map(function(match) {
                return ko.mapping.fromJS(match);
            }));
            bindScrollBar();
        });
    }

    self.getRecentGames = function (rootModel, currentModel, event) {
        $.get('/Stats/GetMatchHistor?accountId=' + rootModel.SteamId(), function (result) {
            self.Games(result.Matches.map(function(match) {
                var model = new GamesModel(match);
                return model;
            }));
        });
    }

    function bindScrollBar() {
        var recentGames = $('#recent-games').height();
        $('#recent-games').height(recentGames).perfectScrollbar({
            suppressScrollX: true
        });
    }

   
}

function GamesModel(param) {
    var self = this;
    self.MatchId = ko.observable();
    self.Players = ko.observable();
    self.LobbyTypeDescription = ko.observable();

    if (param != undefined) {
        self.MatchId(param.MatchId);
        self.Players(param.Players.length);
        self.LobbyTypeDescription(param.LobbyTypeDescription);
    }
   
}

ko.cleanNode(bind);
ko.applyBindings(new ViewModel(), bind);
