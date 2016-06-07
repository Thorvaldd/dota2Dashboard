function HeroesViewModel() {
    var self = this;

    self.HeroesModel = ko.mapping.fromJS([]);

    $.get('/Heroes/GetHeroes', function(data) {
        ko.mapping.fromJS(data, self.HeroesModel);
    });
    
}

ko.applyBindings(new HeroesViewModel())