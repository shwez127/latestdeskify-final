// Please see documentation at https://docs.microsoft.com/aspnet/core/client-side/bundling-and-minification
// for details on configuring this project to bundle and minify static web assets.

// Write your JavaScript code.

$(document).ready(function () {
    $('#myTable').DataTable({
        lengthMenu: [
            [5, 10],
            [5, 10],

        ],
    });
});



$(document).ready(function () {
    $('#example').DataTable({
        order: [[0, 'desc']],
        lengthMenu: [
            [5, 10],
            [5, 10],

        ],
    });
});