
    $(document).ready(function () {
        $('#increase').click(function () {
            modifyFontSize('increase');
        });
    $('#decrease').click(function () {
        modifyFontSize('decrease');
                                    });
    $('#reset').click(function () {
        modifyFontSize('reset');
                                    })
    function modifyFontSize(action) {
                                        var divElement = $('.demo');
    var currentFontSize = parseInt(divElement.css('font-size'));
    if (action == 'increase')
    currentFontSize += 3;
    else if (action == 'decrease')
    currentFontSize -= 3;
    else
    currentFontSize = 16;
    divElement.animate({'fontSize': currentFontSize }, 300);
                                    }
                                });
