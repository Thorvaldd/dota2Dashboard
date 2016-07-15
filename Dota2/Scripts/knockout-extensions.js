

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

        var lineChartData = {
            labels: ['K', 'D', 'A'],
            datasets: [
                {
                    data: [kda.Kills(), kda.Deaths(), kda.Assists()]
                },
            ]
        }
        $(element)
            .mouseenter(function (e) {
                var dynamicChartEl = "<canvas id='kda-"+ e.pageX + "'></canvas>";
                console.log('X->' + e.pageX + ' Y->' + e.pageY);
                swal({
                    title: 'KDA stats',
                    confirmButtonText: 'X',
                    text: dynamicChartEl,
                    html: true
                    
                });
                var ctx = document.getElementById('kda-' + e.pageX).getContext('2d');
                var lineChart = new Chart(ctx).Line(lineChartData, {
                    pointDotRadius: 5,
                    bezierCurve: false,
                    scaleShowVerticalLines: false,
                    options: {
                        title: {
                            xPadding: 8
                        },
                        fill: false
                    },
                });
            })
            .mouseleave(function(e) {
                console.log('Leaving chart');
            });
    }
}