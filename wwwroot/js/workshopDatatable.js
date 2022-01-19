$(document).ready(function () {
    $("#workshopDatatable").DataTable({
        "processing": true,
        "serverSide": true,
        "filter": true,
        "ajax": {
            "url":'api/WorkshopListing',
            //DemoGrid/LoadData
            "type": "POST",
            "datatype": "json"
        },
        "columnDefs": [{
            "targets": [0],
            "visible": false,
            "searchable": false
        }],
        "columns": [
            { "data": "wsId"        , "name": "wsId", "autoWidth": true },
            { "data": "wsCoverImage", "name": "wsCoverImage", "autoWidth": true },
            { "data": "wsEnvImage"  , "name": "wsEnvImage", "autoWidth": true },
            { "data": "wsName"      , "name": "wsName", "autoWidth": true },
            { "data": "wsMainInfo", "name": "wsMainInfo", "autoWidth": true },

            { "data": "wsExtraInfo", "name": "wsExtraInfo", "autoWidth": true },
            { "data": "wsType"           , "name": "wsType", "autoWidth": true },
            { "data": "wsLocationType"   , "name": "wsLocationType", "autoWidth": true },
            { "data": "wsLocationDetails", "name": "wsLocationDetails", "autoWidth": true },
            { "data": "wsLessonSchedule", "name": "wsLessonSchedule", "autoWidth": true },

            { "data": "regStartDate", "name": "regStartDate", "autoWidth": true },
            { "data": "regEndDate", "name": "regEndDate", "autoWidth": true },
            { "data": "firstLesDate", "name": "firstLesDate", "autoWidth": true },
            { "data": "endLesDate"  , "name": "endLesDate", "autoWidth": true },
            { "data": "wsPrice", "name": "wsPrice", "autoWidth": true },

            { "data": "wsTotalAttendees", "name": "wsTotalAttendees", "autoWidth": true },
            { "data": "wsRating"        , "name": "wsRating", "autoWidth": true },
            { "data": "dateCreated"     , "name": "dateCreated", "autoWidth": true },
            { "data": "dateUpdated"     , "name": "dateUpdated", "autoWidth": true },
            { "data": "teacherId", "name": "teacherId", "autoWidth": true },
            {
                "render": function (data, row) { return "<a href='#' class='btn btn-danger' onclick=DeleteCustomer('" + row.id + "'); >Delete</a>"; }
            },
        ]
    });
});
