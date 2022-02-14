$(document).ready(function () {
    $("#workshopDatatable").removeAttr('width').DataTable({
        "drawCallback": countDown,
        "processing": true,
        "serverSide": true,
        "responsive": true,
        "filter": true,
        "orderMulti": true,
        "searching": true,
        "ajax": {
            "url": 'api/WorkshopListing',
            //DemoGrid/LoadData
            "type": "POST",
            "datatype": "json"
        },
        /*        scrollY: "300px",
                scrollX: "500px",*/
        "columnDefs": [{
            "targets": [0],
            "visible": false,
            "searchable": true
        }],

        "columns": [
            //{ "data": "wsId", "name": "wsId", "autoWidth": true },
            { "data": "wsId", "name": "wsId" },
            {
                "data": {
                    wsId: "wsId",
                    wsName: "wsName",
                    wsCoverImage: "wsCoverImage",
                    wsEnvImage: "wsEnvImage",
                    wsMainInfo: "wsMainInfo",
                    wsExtraInfo: "wsExtraInfo",
                    wsType: "wsType",
                    wsLocationType: "wsLocationType",
                    wsLocationDetails: "wsLocationDetails",
                    wsNoOfLessons: "wsNoOfLessons",
                    wsLessonSchedule: "wsLessonSchedule",
                    regStartDate: "regStartDate",
                    regEndDate: "regEndDate",
                    firstLesDate: "firstLesDate",
                    endLesDate: "endLesDate",
                    wsPrice: "wsPrice",
                    wsPresentAttendees: "wsPresentAttendees",
                    wsTotalAttendees: "wsTotalAttendees",
                    wsRatingAvg: "wsRatingAvg",
                    wsRatingTotal: "wsRatingTotal",
                    dateCreated: "dateCreated",
                    dateUpdated: "dateUpdated",
                    teacherId: "teacherId",
                }, "autoWidth": true,
                "render": function (data, row) {
                    return '<div class="col-sm-12">' +
                        '<div class="card text-dark bg-light">' +
                        '<div class="card-header bg-primary text-warning"><div>' + '<p id="' + data.wsId + '">' + countDown(data.wsId, data.regEndDate) + '</p>' + '</div><h4 class="text-center">' + data.wsName + '</h4></div>' +
                        '<div class="container">' +
                        '<div class="card-body" style="float: left;">' +
                        '<p class="card-text text-left"><img src="/Image/' + data.wsCoverImage + '" style="width:150px; height: 120px;"></p>' +
                        '<i class="fas fa-info-circle" style="font-size:18px"> ' + data.wsPresentAttendees + "/" + data.wsTotalAttendees + ' signed up!</i>' +
                        '</div>' +
                        '<div class="card-body" >' +
                        '<div><p class="MainInfo" style="white-space: normal; width: 350px;">' + data.wsMainInfo + '</p></div>' +
                        '<div>' +
                        '<div style="float: left; padding-right: 20px;"><br />' +
                        '<i id="Location" class="fas fa-map-marker-alt" style="width:15px; font-size:18px"></i> ' + data.wsLocationType + '<br />' +
                        '<i id="Rating" class="fa fa-star-o" style="width:20px; font-size:18px"></i>' + data.wsRatingAvg + '(' + data.wsRatingAvg + ')' + '<br />' +
                        '<i id="NoOfLessons" class="fas fa-user-circle" style="width:20px; font-size:18px"></i>' + data.wsNoOfLessons + ' Lessons' + '<br />' +
                        '</div>' +
                        '<div id="LessonSchedule" style="white-space: normal; width: 250px;" float: right;"><strong>Lessons: </strong><br />' + data.wsLessonSchedule +
                        '</div>' +
                        '</div>' +
                        '</div>' +
                        '</div>' +
                        '<div style="height: 70px;" class="card-footer bg-primary border-warning text-center">' +
                        '<a style="float: right;" class="btn btn-primary" href="/AllBookings/' + data.wsId + '"><i class="fas fa-shopping-cart">View Bookings </i></a>' +
                        '<a style="float: right;" class="btn btn-warning" href="/WorkshopListing/' + data.wsId + '/Details" >Details</a>' +
                        '<a style="float: right;" class="btn btn-danger" href="/WorkshopListing/Delete/' + data.wsId + '">Delete</a>' +
                        '<a style="float: right;" class="btn btn-success" href="/WorkshopListing/Edit/' + data.wsId + '">Edit</a>' +
                        '</div>' +
                        '</div>' +
                        '</div>';
                }
            },

        ],
        fixedColumns: true
    });
});


function countDown(id, regDate) {
    // Set the date we're counting down to
    var countDownDate = new Date(regDate).getTime();

    // Update the count down every 1 second
    var x = setInterval(function () {

        // Get today's date and time
        var now = new Date().getTime();

        // Find the distance between now and the count down date
        var distance = countDownDate - now;

        // Time calculations for days, hours, minutes and seconds
        var days = Math.floor(distance / (1000 * 60 * 60 * 24));
        var hours = Math.floor((distance % (1000 * 60 * 60 * 24)) / (1000 * 60 * 60));
        var minutes = Math.floor((distance % (1000 * 60 * 60)) / (1000 * 60));
        var seconds = Math.floor((distance % (1000 * 60)) / 1000);

        if (distance > 0) {

            document.getElementById(id).innerHTML = days + "d " + hours + "h "
                + minutes + "m " + seconds + "s left to register!";
        }
        else {
            clearInterval(x);
            document.getElementById(id).innerHTML = "Registration Closed!";
            document.getElementById(id).style.color = "red";
        }
    }, 1000);
}