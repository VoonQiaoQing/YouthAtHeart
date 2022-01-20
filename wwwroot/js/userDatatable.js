$(document).ready(function () {
    'use strict';
    $("#userDatatable").removeAttr('width').DataTable({
        "processing": true,
        "serverSide": true,
        "filter": true,
        "ajax": {
            "url": 'api/User',
            //DemoGrid/LoadData
            "type": "POST",
            "datatype": "json"
        },

        "columns": [
            { "data": "userId", "name": "userId" },
            { "data": "username", "name": "username" },
            { "data": "email", "name": "email" }
        ],
        fixedColumns: true,
    },
        })