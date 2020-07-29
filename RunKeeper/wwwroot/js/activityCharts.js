
// Set new default font family and font color to mimic Bootstrap's default styling
Chart.defaults.global.defaultFontFamily = '-apple-system,system-ui,BlinkMacSystemFont,"Segoe UI",Roboto,"Helvetica Neue",Arial,sans-serif';
Chart.defaults.global.defaultFontColor = '#292b2c';

var chartData = JSON.parse(document.getElementById('ChartData').value);

// Bar Chart Example
var ctx = document.getElementById("activityBarChart");
//var myLineChart = new Chart(ctx, {
//    type: 'bar',
//    data: {
//        labels: ["January", "February", "March", "April", "May", "June"],
//        datasets: [{
//            data: [4215, 5312, 6251, 7841, 9821, 14984],
//        }],
//    }
//});

var myLineChart = new Chart(ctx, {
    type: 'bar',
    data: {
        labels: ["January", "February", "March", "April", "May", "June"],
        datasets: [{
            data: chartData,
        }],
    }
});