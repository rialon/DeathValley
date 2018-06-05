/// <reference path="jquery-3.0.0.js" />

var chart_global;
function drawChart(response) {
    if (chart_global) {
        chart_global.destroy();
    }
    if (!response.isValid) {
        showErrors(response.data);
        return;
    }
    $("#errorMessages").empty();
    var points = response.data;
    if (points.length < 1) {
        return;
    }
    var context = $("#chartCanvas")[0].getContext("2d");
    context.clearRect(0, 0, $("#chartCanvas").width(), $("#chartCanvas").height());

    var dataset = [];

    for (var i = 0; i < points.length; i++) {
        dataset.push({ x: points[i].X, y: points[i].Y });
    }

    var chartColors = { green: "rgb(75, 192, 192)", black: "rgb(0, 0, 0)" }

    chart_global = new Chart(context, {
        type: 'scatter',
        data: {
            datasets: [{
                borderColor: chartColors.green,
                data: dataset,
                pointBackgroundColor: chartColors.green,
                pointBorderColor: chartColors.green,
                showLine: true,
                fill: false
            }]
        },
        options: {
            responsive: false,
            maintainAspectRatio: false,
            legend: {
                display: false
            },
            scales: {
                xAxes: [{
                    ticks: {
                        fontColor: chartColors.black
                    },
                    gridLines: {
                        zeroLineColor: chartColors.black,
                        zeroLineWidth: 0.5
                    }
                }],
                yAxes: [{
                    ticks: {
                        fontColor: chartColors.black,
                    },
                    gridLines: {
                        zeroLineColor: chartColors.black,
                        zeroLineWidth: 0.5
                    }
                }]
            }
        }
    });
}

function showErrors(errors) {
    $("#errorMessages").empty();
    for (var i = 0; i < errors.length; i++) {
        $("#errorMessages").append($("<li>").html(errors[i]).addClass("field-validation-error"));
    }
}


