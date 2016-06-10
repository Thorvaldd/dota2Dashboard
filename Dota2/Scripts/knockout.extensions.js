ko.bindingHandlers.menu = {
    init: function (element, valueAccessor, allBindings, viewModel, bindingContext) {
        $(element).preventDefault();
	    $(element).closest('ul').find('li').removeClass('active');
	    $(element).closest('li').addClass('active');
	    
        
	}
}