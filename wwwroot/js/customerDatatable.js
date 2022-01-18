$(document).ready(function () {
    $("#customerDatatable").DataTable({
        "processing": true,
        "serverSide": true,
        "filter": true,
        "ajax": {
            "url":'api/Workshop2',
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
            { "data": "wsId", "name": "wsId", "autoWidth": true },
            { "data": "wsName", "name": "First Name", "autoWidth": true },
            { "data": "wsMainInfo", "name": "Last Name", "autoWidth": true },
            { "data": "wsExtraInfo", "name": "Contact", "autoWidth": true },
            { "data": "wsType", "name": "Email", "autoWidth": true },
            {
                "render": function (data, row) { return "<a href='#' class='btn btn-danger' onclick=DeleteCustomer('" + row.id + "'); >Delete</a>"; }
            },
        ]
    });
});
