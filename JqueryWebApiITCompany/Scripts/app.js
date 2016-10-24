//$(document).ready(function () {
//   $('#table_companies').dataTable({
//       "sAjaxSource": "/api/companies",
//       //"bServerSide": true,
//       //"bProcessing": true,
//       "deferRender": true,
//        "aoColumns": [
//            { "aData": "Rank" },
//            { "aData": "CompanyName"},
//            { "aData": "Industries" },
//            { "aData": "Revenue"},
//            { "aData": "FiscalYear"},
//            { "aData": "Employees" },
//            { "aData": "MarketCap"},
//            { "aData": "Headquarters" },
//            { "aData": null, "sClass": "functions" }
//        ],
//        "aoColumnDefs": [
//            { "bSortable": false, "aTargets": [0] }
//        ],
//        "lengthMenu": [[10, 25, 50, 100, -1], [10, 25, 100, "All"]],
//        "oLanguage": {
//            "oPaginate": {
//                "sFirst": " ",
//                "sPrevious": " ",
//                "sNext": " ",
//                "sLast": " ",
//            },
//            "sLengthMenu": "Records per page: _MENU_",
//            "sInfo": "Total of TOTAL_ records (showing _START_ to _END_)",
//            "sInfoFiltered": "(filtered from _MAX_ total records)"
//        }
//    });
//})

$(document).ready(function () {

    
    // On page load: datatable
    var table_companies = $('#table_companies').DataTable({
        ajax: "/api/companies/",
        columns: [
          { "data": "id" },
          { "data": "name" },
          { "data": "industry" },
          { "data": "revenue" },
          { "data": "fiscalYear" },
          { "data": "employees" },
          { "data": "marketCap" },
          { "data": "headquarters" },
          //{ "data": "functions" }
        ],
        //"aoColumnDefs": [
        //  { "bSortable": false, "aTargets": [-1] }
        //],
        //"lengthMenu": [[10, 25, 50, 100, -1], [10, 25, 50, 100, "All"]],
        //"oLanguage": {
        //    "oPaginate": {
        //        "sFirst": " ",
        //        "sPrevious": " ",
        //        "sNext": " ",
        //        "sLast": " ",
        //    },
        //    "sLengthMenu": "Records per page: _MENU_",
        //    "sInfo": "Total of _TOTAL_ records (showing _START_ to _END_)",
        //    "sInfoFiltered": "(filtered from _MAX_ total records)"
        //}        
    });
});