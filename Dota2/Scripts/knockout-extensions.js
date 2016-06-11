

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