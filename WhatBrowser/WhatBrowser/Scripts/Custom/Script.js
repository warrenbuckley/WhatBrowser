//Wait until DOM ready
$(document).ready(function () {

    //Screen/monitor size
    var screenHeight = window.screen.height;
    var screenWidth = window.screen.width;
    console.log("Screen Res: " + screenHeight + " * " + screenWidth);

    //Update DOM elements
    $("#screenHeight").text(screenHeight);
    $("#screenWidth").text(screenWidth);

    //Viewport
    var viewHeight = window.innerHeight;
    var viewWidth = window.innerWidth;

    $("#viewHeight").text(viewHeight);
    $("#viewWidth").text(viewWidth);

    console.log("View Res: " + viewHeight + " * " + viewWidth);

    //On window resize update val's of viewport window
    $(window).resize(function () {
        $("#viewHeight").text(window.innerHeight);
        $("#viewWidth").text(window.innerWidth);
    });

    //Are cookies enabled?
    $("#mmmCookies").text(navigator.cookieEnabled);

    //Device Pixel Ratio
    $("#pixelRatio").text(window.devicePixelRatio);


    //Modernizr Stuff
    //Write out Modernizr Version to DOM
    $("#modernizrVersion").text(Modernizr._version);

    //Exclude list
    var excludeList = ['addTest', '_version', '_prefixes', '_domPrefixes', '_cssomPrefixes', 'mq', 'hasEvent', 'testProp', 'testAllProps', 'testStyles', 'prefixed'];

    //String to store HTML in
    var strHTML = "";

    //Lists out most true/false tests
    for (var test in Modernizr) {

        //Check we can not find the item in the exclude list array
        if ($.inArray(test, excludeList) == -1) {
            var obj = Modernizr[test];

            strHTML += "<h2 data-test-value='" + obj + "'>" + test + ": " + obj + "</h2>";

            console.log(test + " = " + obj);

            //If obj has child object (input & inputtypes)            
            for (var prop in obj) {
                if (obj.hasOwnProperty(prop)) {

                    strHTML += "<h3 data-test-value='" + obj[prop] + "'>" + prop + ": " + obj[prop] + "</h3>";

                    console.log(prop + " = " + obj[prop]);
                }
            }
        }
    }

    //Write out test results to DIV
    $("#modernizrTests").html(strHTML);

    //Get HTML in #browserResults & store in hidden field to post to controller
    var browserResults = $("#browserResults").html();
    $("#HTMLResults").val(browserResults);

});