function HeroesViewModel() {
    var self = this;

   self.Model = ko.mapping.fromJS([]);
   self.Model.extend({
        infinitescroll: {}
    });

    $(window).resize(function() {
        
    });

    $.get('/Heroes/GetHeroes', function(data) {
        ko.mapping.fromJS(data, self.Model);
    });
    
}

ko.applyBindings(new HeroesViewModel())