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
                                    '<div class="card-body" >' +
                                    '<div class="MainInfo"><p>MainInfo' + data.wsMainInfo + '</p></div>' +
                                    '<div>' +
                                        '<div style="float: left; padding-right: 20px;">' +
                                        '<i id="Location" class="fas fa-map-marker-alt" style="width:15px; font-size:18px"></i> ' + data.wsLocationType + '<br />' +
                                        '<i id="Rating" class="fa fa-star-o" style="width:20px; font-size:18px"></i>' + data.wsRating  + '<br />' +
                                        '<i id="NoOfLessons" class="fas fa-info-circle" style="width:20px; font-size:18px"></i>' + data.wsNoOfLessons + ' Lessons'  + '<br />' +
                                    '</div>' +
                                    '<div id="LessonSchedule" style="width:150px; float: right;"><strong>Lessons: </strong>' + data.wsLessonSchedule +
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
