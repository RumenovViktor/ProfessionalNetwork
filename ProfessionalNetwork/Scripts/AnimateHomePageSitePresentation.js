(function () {
    (function () {
        var requestAnimationFrame =
            window.requestAnimationFrame ||
            window.mozRequestAnimationFrame ||
            window.webkitRequestAnimationFrame ||
            window.msRequestAnimationFrame;

        window.requestAnimationFrame = requestAnimationFrame;
    }());

    var canvas = document.getElementById('textPresentCanvas'),
        context = canvas.getContext('2d'),
        circles = [],
        xCoord = 100,
        yCoord = 100;

    canvas.width = 300;
    canvas.height = 300;

    createCircle(xCoord, yCoord, '| | |', function () {
    });

    function createCircle(x, y, text, callback) {
        var radius = 65;
        var endPercent = 101;
        var curPerc = 0;
        var counterClockwise = false;
        var circ = Math.PI * 2;
        var quart = Math.PI / 2;

        context.lineWidth = 10;
        context.strokeStyle = '#16a085';
        context.shadowOffsetX = 0;
        context.shadowOffsetY = 0;

        function doText(context, x, y, text) {
            context.lineWidth = 1;
            context.fillStyle = "#16a085";
            context.lineStyle = "#16a085";
            context.font = "26px sans-serif";
            context.fillText(text, x - 15, y + 5);
        }

        function animate(current) {
            var circle = null;

            context.lineWidth = 6;
            context.clearRect(0, 0, canvas.width, canvas.height);
            context.beginPath();
            context.arc(x, y, radius, -(quart), ((circ) * current) - quart, false);
            context.stroke();
            curPerc += 2;

            if (circle !== null) {
                context.beginPath();
                context.arc(circle.x, circle.y, radius, -(quart), ((circ) * circle.curr) - quart, false);
                context.stroke();
                doText(context, circle.x, circle.y, circle.text);
            }

            if (curPerc < endPercent) {
                requestAnimationFrame(function () {
                    animate(curPerc / 100)
                });
            } else {
                circle = {
                    x: x,
                    y: y,
                    curr: current,
                    text: text
                };

                doText(context, x, y, text);

                if (callback) {
                    callback.call();
                }
            }
        }

        animate();
    }
})()