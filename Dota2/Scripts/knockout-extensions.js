

ko.bindingHandlers.loadingList = {

    init: function (element, valueAccessor) {
        ko.utils.unwrapObservable(valueAccessor());

        if (valueAccessor() == true) {
            $(element).wrap($('<div>', {
                "class": "loading"
            }));
            $(element).before($('<div>', {
                "class": "loading_inner"
            }));
        } else {
            $(element).parent().parent().replaceWith($(element));
        }
    },
    update: function (element, valueAccessor, allBindingsAccessor) {
        ko.utils.unwrapObservable(valueAccessor());

        if (valueAccessor() == true) {
            $(element).wrap($('<div>', {
                "class": "loading"
            }));
            $(element).before($('<div>', {
                "class": "loading_inner"
            }));
        } else {
            $(element).parent().parent().replaceWith($(element));
        }
    }
};

ko.bindingHandlers.kdachart = {
    init: function(element, valueAccessor, allBindings, viewModel, bindingContext) {
        var kda = ko.utils.unwrapObservable(valueAccessor());
        var data = {
            labels: ['K', 'D', 'A'],
            series: [
                [kda.Kills(), kda.Deaths(), kda.Assists()]
            ],
            low: 0,
            showArea: false
        }

        new Chartist.Line($(element)[0], data);
    }
}