$(document).ready(function () {
    $("#workshopDatatable").removeAttr('width').DataTable({
        "processing": true,
        "serverSide": true,
        "filter": true,
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
            "searchable": false
        }],

        "columns": [
            //{ "data": "wsId", "name": "wsId", "autoWidth": true },
            { "data": "wsId", "name": "wsId" },
            /*            {
                            "data": { wsId: "wsId", wsCoverImage: "wsCoverImage", wsEnvImage: "wsEnvImage" },
                            "render": function (data, row) {
                                return '<div class="card" style="width: 18rem;"><img class="card-img-top" src = "..." alt = "Card image cap" ><div class="card-body"><h5 class="card-title">' + data.wsId + '</h5><p class="card-text">Some quick example text to build on the card title and make up the bulk of the card content.</p><a href="#" class="btn btn-primary">Go somewhere</a></div></div >';
                            }
                        },*/
/*            {
                "data": "wsCoverImage",
                "render": function (data, row) {
                    return '<img src="/Image/' + data + '"  style="width:100px; height: 100px;"/>';
                    //return '<p><a asp-page="/EditWorkshop" asp-route-id="@' + data + '">Edit</a></p>';
                }
            },
            {
                "data": "wsEnvImage",
                "render": function (data, row) {
                    return '<img src="/Image/' + data + '"  style="width:100px; height: 100px;"/>';
                    //return '<p><a asp-page="/EditWorkshop" asp-route-id="@' + data + '">Edit</a></p>';
                }
            },
            { "data": "wsName", "name": "wsName" },
            { "data": "wsMainInfo", "name": "wsMainInfo" },*/

/*            { "data": "wsExtraInfo", "name": "wsExtraInfo" },
            { "data": "wsType", "name": "wsType" },
            { "data": "wsLocationType", "name": "wsLocationType" },
            { "data": "wsLocationDetails", "name": "wsLocationDetails" },
            { "data": "wsLessonSchedule", "name": "wsLessonSchedule" },

            { "data": "regStartDate", "name": "regStartDate" },
            { "data": "regEndDate", "name": "regEndDate" },
            { "data": "firstLesDate", "name": "firstLesDate" },
            { "data": "endLesDate", "name": "endLesDate" },
            { "data": "wsPrice", "name": "wsPrice" },

            { "data": "wsTotalAttendees", "name": "wsTotalAttendees" },
            { "data": "wsRating", "name": "wsRating" },
            { "data": "dateCreated", "name": "dateCreated" },
            { "data": "dateUpdated", "name": "dateUpdated" },
            { "data": "teacherId", "name": "teacherId" },*/
/*            {
                "data": "wsId",
                "render": function (data, row) {
                    return '<a class="btn btn-danger" href="/WorkshopListing/Delete/' + data + '">Delete</a>';
                    //return '<p><a asp-page="/EditWorkshop" asp-route-id="@' + data + '">Edit</a></p>';
                }
            },
            {
                "data": "wsId",
                "render": function (data, row) {
                    return '<a class="btn btn-success" href="/WorkshopListing/Edit/' + data + '">Edit</a>';
                }
            },
            {
                "data": "wsId",
                "render": function (data, row) {
                    return '<a class="btn btn-primary" href="/WorkshopListing/Book/' + data + '">Book</a>';
                }
            },*/
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
                },
                "render": function (data, row) {
                    return '<div class="col-sm-7">' +
                        '<div class="card text-dark bg-light">' +
                        '<div class="card-header bg-primary text-warning"><div>' + data.regStartDate + '</div><h4 class="text-center">' + data.wsName + '</h4></div>' +
                                    '<div class="container">' +
                        '<div class="card-body" style="float: left;">' +
                        '<p class="card-text text-left"><img src="/Image/' + data.wsCoverImage + '" style="width:150px; height: 120px;"></p>' +
                        '<i class="fas fa-info-circle" style="font-size:18px"> ' + data.wsPresentAttendees + "/" + data.wsTotalAttendees + '</i>' +
                                    '</div>' +
                                    '<div class="card-body">' +
                                    '<div id="MainInfo">MainInfo' + data.wsMainInfo + '</div>' +
                                    '<div>' +
                                        '<div style="float: left; padding-right: 20px;">' +
                                        '<i id="Location" class="fas fa-map-marker-alt" style="font-size:18px"> ' + data.wsLocationType + '</i>' +
                                        '<i id="Rating" class="fa fa-star-o" style="font-size:18px">' + data.wsRating + '</i>' +
                                        '<div id="LocationDetails"> ' + data.wsLocationDetails +'</div>' +
                                    '</div>' +
                                    '<div id="LessonSchedule" style="width:150px; float: left;">' + data.wsLessonSchedule +
                                '</div>' +
                            '</div>' +
                        '</div>' +
                        '</div>' +
                        '<div style="height: 70px;" class="card-footer bg-primary border-warning text-center">' +
                        '<a style="float: right;" class="btn btn-primary" href="/WorkshopListing/Book/' + data.wsId + '"><i class="fas fa-shopping-cart"> Book</i></a>' +
                        '<a style="float: right;" href="#" class="btn btn-warning">Details</a>' +
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

//        <p><a class='btn btn-success' asp-page="CreateWorkshop">Create a New Workshop</a></p>

//"<a href='#' class='btn btn-danger' onclick=UpdateWorkshop('" + row.wsId + "'); >Delete</a>"

/*		<a href="../prod/song/updatesong/${row.song_uuid}">
			<i class="fa fa-edit"></i>
		</a>*/
