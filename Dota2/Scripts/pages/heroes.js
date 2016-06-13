var bind = document.getElementById('bindContainer');
function HeroesViewModel() {
    var self = this;
    self.loading = ko.observable(true);

   self.Model = ko.mapping.fromJS([]);
   self.Model.extend({
        infinitescroll: {}
    });

    $.get('/Heroes/GetHeroes', function(data) {
        ko.mapping.fromJS(data, self.Model);
        self.loading(false);
    });
}

ko.cleanNode(bind);
ko.applyBindings(new HeroesViewModel(), bind)