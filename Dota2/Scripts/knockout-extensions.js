

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
            showArea: false,
            stackBars: true,
            axisX : {
                labelInterPolationFnc: function(value) {
                    return value.split(/\s+/).map(function(word) {
                        return word[0];
                    }).join('');
                }
            }
        }

        new Chartist.Line($(element)[0], data);
    }
}

ko.bindingHandlers.swalChart = {
    init: function (element, valueAccessor, allBindings, viewModel, bindingContext) {
        var kda = ko.utils.unwrapObservable(valueAccessor());
        var data = {
            labels: ['K', 'D', 'A'],
            series: [
                [kda.Kills(), kda.Deaths(), kda.Assists()]
            ],
            low: 0,
            showArea: false,
            stackBars: true,
            axisX: {
                labelInterPolationFnc: function (value) {
                    return value.split(/\s+/).map(function (word) {
                        return word[0];
                    }).join('');
                }
            }
        }
        
       
        $(element)
            .mouseenter(function (e) {
                var dynaminChartEl = "<div class='kda-" + e.pageX + "'> </div>";
                console.log('X->' + e.pageX + ' Y->' + e.pageY);
                swal({
                    title: 'Chart',
                    confirmButtonText: 'X',
                    text: "<div class='kda-"+e.pageX+"'>123</div>",
                    html: true
                    
                });
                //$(element).append(dynaminChartEl);
                if (dynaminChartEl.length == 0)
                    return;

                new Chartist.Line($('kda-'+e.pageX)[0], data);
            })
            .mouseleave(function(e) {
                console.log('Leaving chart');
                //$('.sa-confirm-button-container').find('button').click();
            });
    }
}