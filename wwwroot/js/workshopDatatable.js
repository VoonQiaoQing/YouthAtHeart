$(document).ready(function () {
    $("#workshopDatatable").removeAttr('width').DataTable({
        "processing": true,
        "serverSide": true,
        "filter": true,
        "ajax": {
            "url":'api/WorkshopListing',
            //DemoGrid/LoadData
            "type": "POST",
            "datatype": "json"
        },
        scrollY: "300px",
        scrollX: "500px",
        "columnDefs": [{
            "targets": [0, 19],
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
            { "data": "wsCoverImage", "name": "wsCoverImage" },
            { "data": "wsEnvImage", "name": "wsEnvImage" },
            { "data": "wsName", "name": "wsName" },
            { "data": "wsMainInfo", "name": "wsMainInfo" },

            { "data": "wsExtraInfo", "name": "wsExtraInfo" },
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
            { "data": "teacherId", "name": "teacherId" },
            {
                "data": "wsId",
                "render": function (data, row) {
                    return '<a class="btn btn-danger" href="/WorkshopListing/Delete/' + data + '">Delete</a>';
                    //return '<p><a asp-page="/EditWorkshop" asp-route-id="@' + data + '">Edit</a></p>';
                }
            },
            {
                "data": "wsId",
                "render": function (data, row)
                {
                    return '<a class="btn btn-success" href="/WorkshopListing/Edit/' + data + '">Edit</a>';
                }
            },
            {
                "data": "wsId",
                "render": function (data, row) {
                    return '<a class="btn btn-primary" href="/WorkshopListing/Book/' + data + '">Book</a>';
                }
            },
            {
                "data": "wsId",
                "render": function (data, row) {
                    return '';
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
