function HeroesViewModel() {
    var self = this;

   self.HeroesModel = ko.mapping.fromJS([]);
    self.HeroesModel.extend({
        infinitescroll: {}
    });

    $(window).resize(function() {
        
    });

    $.get('/Heroes/GetHeroes', function(data) {
        ko.mapping.fromJS(data, self.HeroesModel);
    });
    
}

ko.applyBindings(new HeroesViewModel())