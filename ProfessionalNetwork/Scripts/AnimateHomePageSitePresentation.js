(function () {
    var requestAnimationFrame = window.requestAnimationFrame || window.mozRequestAnimationFrame || window.webkitRequestAnimationFrame || window.msRequestAnimationFrame;
    window.requestAnimationFrame = requestAnimationFrame;
}());

var canvas = document.getElementById('textPresentCanvas');
var context = canvas.getContext('2d');
canvas.width = 300;
canvas.height = 300;
var circles = [];

createCircle(100, 100, '| | |', function () {
});

function createCircle(x, y, text, callback) {
    var radius = 75;
    var endPercent = 101;
    var curPerc = 0;
    var counterClockwise = false;
    var circ = Math.PI * 2;
    var quart = Math.PI / 2;

    context.lineWidth = 10;
    context.strokeStyle = '#34495e';
    context.shadowOffsetX = 0;
    context.shadowOffsetY = 0;

    function doText(context, x, y, text) {
        context.lineWidth = 1;
        context.fillStyle = "#34495e";
        context.lineStyle = "#34495e";
        context.font = "26px sans-serif";
        context.fillText(text, x - 15, y + 5);
    }
    function animate(current) {
        context.lineWidth = 10;
        context.clearRect(0, 0, canvas.width, canvas.height);
        context.beginPath();
        context.arc(x, y, radius, -(quart), ((circ) * current) - quart, false);
        context.stroke();
        curPerc++;
        if (circles.length) {
            for (var i = 0; i < circles.length; i++) {
                context.lineWidth = 10;
                context.beginPath();
                context.arc(circles[i].x, circles[i].y, radius, -(quart), ((circ) * circles[i].curr) - quart, false);
                context.stroke();
                doText(context, circles[i].x, circles[i].y, circles[i].text);
            }
        }
        if (curPerc < endPercent) {
            requestAnimationFrame(function () {
                animate(curPerc / 100)
            });
        } else {
            var circle = { x: x, y: y, curr: current, text: text };
            circles.push(circle);
            doText(context, x, y, text);
            if (callback) callback.call();
        }
    }

    animate();
}