$(document).ready(function () {
    var table; // Variable to store DataTable instance

    // Initialize DataTable and load data via AJAX
    $.ajax({
        url: '/api/NhaCungCapApi',
        method: 'GET',
        success: function (response) {
            var data = response; // Assuming response is already an array of CongTy objects

            // Generate HTML based on data
            var html = '';
            data.forEach(function (item) {
                html += '<tr data-id="' + item.Id + '">' +
                    '<td data-field="Id">' + item.Id + '</td>' +
                    '<td data-field="TenNhaCungCap">' + item.TenNhaCungCap + '</td>' +
                    '<td>' +
                    '<a class="btn btn-outline-secondary btn-sm edit" title="Edit">' +
                    '<i class="fas fa-pencil-alt"></i>' +
                    '</a>' +
                    '<a class="btn btn-outline-danger btn-sm delete" title="Delete">' +
                    '<i class="fas fa-trash-alt"></i>' +
                    '</a>' +
                    '</td>' +
                    '</tr>';
            });

            // Add HTML to the table body
            $('#tblDataNhaCungCap tbody').html(html);

            // Initialize DataTables
            table = $('#tblDataNhaCungCap').DataTable({
                // DataTables configuration options
            });

            // Handle inline editing
            $('#tblDataNhaCungCap tbody').on('click', '.edit', function () {
                var $btn = $(this).find('i');
                var $row = $(this).closest('tr');
                var id = $row.data('id');

                if ($btn.hasClass('fa-pencil-alt')) {
                    // Fetch data for the specific row
                    $.ajax({
                        url: '/api/NhaCungCapApi/' + id,
                        method: 'GET',
                        success: function (response) {
                            var item = response;

                            // Populate the row with the fetched data and make it editable
                            $row.find('td[data-field="TenNhaCungCap"]').html('<input type="text" class="form-control" value="' + item.TenNhaCungCap + '">');
                            // Switch to save mode
                            $btn.removeClass('fa-pencil-alt').addClass('fa-save').attr('title', 'Save');
                        },
                        error: function (xhr, status, error) {
                            console.error('Error fetching data:', error);
                        }
                    });
                } else {
                    // Switch to edit mode and save data
                    var updatedData = {
                        Id: id, // Add Id to the data object
                        TenNhaCungCap: $row.find('input').val(),
                    };

                    $.ajax({
                        url: '/api/NhaCungCapApi/' + id,
                        method: 'PUT',
                        contentType: 'application/json',
                        data: JSON.stringify(updatedData),
                        success: function (response) {
                            console.log('Update successful:', response);
                            // Optionally, update the row data with response data
                            $btn.removeClass('fa-save').addClass('fa-pencil-alt').attr('title', 'Edit');
                        },
                        error: function (xhr, status, error) {
                            console.error('Error updating data:', error);
                            // Handle error response
                        }
                    });
                }
            });

            // Handle deletion
            $('#tblDataNhaCungCap tbody').on('click', '.delete', function () {
                var $row = $(this).closest('tr');
                var id = $row.data('id');

                if (confirm('Are you sure you want to delete this item?')) {
                    $.ajax({
                        url: '/api/NhaCungCapApi/' + id,
                        method: 'DELETE',
                        success: function (response) {
                            console.log('Deletion successful');
                            table.row($row).remove().draw();
                        },
                        error: function (xhr, status, error) {
                            console.error('Error deleting data:', error);
                            // Handle error response
                        }
                    });
                }
            });

            // Handle form submission for adding a new line
            $('#addNhaCungCapForm').on('submit', function (e) {
                e.preventDefault();

                var newNhaCungCap = {
                    TenNhaCungCap: $('#TenNhaCungCap').val(),
                };

                $.ajax({
                    url: '/api/NhaCungCapApi',
                    method: 'POST',
                    contentType: 'application/json',
                    data: JSON.stringify(newNhaCungCap),
                    success: function (response) {
                        console.log('Th�m th�nh c�ng');
                        var item = response;

                        // Th�m d�ng m?i v�o DataTable
                        var newRowHtml = '<tr data-id="' + item.Id + '">' +
                            '<td data-field="Id">' + item.Id + '</td>' +
                            '<td data-field="TenNhaCungCap">' + item.TenNhaCungCap + '</td>' +
                            '<td>' +
                            '<a class="btn btn-outline-secondary btn-sm edit" title="Edit">' +
                            '<i class="fas fa-pencil-alt"></i>' +
                            '</a>' +
                            '<a class="btn btn-outline-danger btn-sm delete" title="Delete">' +
                            '<i class="fas fa-trash-alt"></i>' +
                            '</a>' +
                            '</td>' +
                            '</tr>';
                        table.row.add($(newRowHtml)).draw();

                        // ?�ng modal v� l�m s?ch form
                        $('#addNhaCungCapModal').modal('hide');
                        $('#addNhaCungCapForm')[0].reset();
                    },
                    error: function (xhr, status, error) {
                        console.error('L?i khi th�m d? li?u:', error);
                        // X? l� ph?n h?i l?i
                    }
                });
            });


        },
        error: function (xhr, status, error) {
            console.error('Error fetching data:', error);
        }
    });

    $('#addNhaCungCapBtn').on('click', function () {
        $('#addNhaCungCapModal').modal('show');
    });
});