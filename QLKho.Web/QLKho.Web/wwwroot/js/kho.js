$(document).ready(function () {
    var table; // Variable to store DataTable instance

    // Initialize DataTable and load data via AJAX
    $.ajax({
        url: '/api/KhoApi',
        method: 'GET',
        success: function (response) {
            var data = response; // Assuming response is already an array of CongTy objects

            // Generate HTML based on data
            var html = '';
            data.forEach(function (item) {
                html += '<tr data-id="' + item.Id + '">' +
                    '<td data-field="Id">' + item.Id + '</td>' +
                    '<td data-field="TenKho">' + item.TenKho + '</td>' +
                    '<td data-field="TenViTri">' + item.TenViTri + '</td>' +
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
            $('#tblDataKho tbody').html(html);

            // Initialize DataTables
            table = $('#tblDataKho').DataTable({
                // DataTables configuration options
            });

            // Handle inline editing
            $('#tblDataKho tbody').on('click', '.edit', function () {
                var $btn = $(this).find('i');
                var $row = $(this).closest('tr');
                var id = $row.data('id');

                if ($btn.hasClass('fa-pencil-alt')) {
                    // Fetch data for the specific row
                    $.ajax({
                        url: '/api/KhoApi/' + id,
                        method: 'GET',
                        success: function (response) {
                            var item = response;

                            // Populate the row with the fetched data and make it editable
                            $row.find('td[data-field="TenKho"]').html('<input type="text" class="form-control" value="' + item.TenKho + '">');
                            $row.find('td[data-field="TenViTri"]').html('<input type="text" class="form-control" value="' + item.TenViTri + '">');
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
                        TenKho: $row.find('input').eq(0).val(), // Update field name to match backend
                        TenViTri: $row.find('input').eq(1).val(), // Update field name to match backend
                    };

                    $.ajax({
                        url: '/api/KhoApi/' + id,
                        method: 'PUT',
                        contentType: 'application/json',
                        data: JSON.stringify(updatedData),
                        success: function (response) {
                            console.log('Update successful:', response);
                            // Optionally, update the row data with response data
                            $row.find('td[data-field="TenKho"]').text(updatedData.TenKho);
                            $row.find('td[data-field="TenViTri"]').text(updatedData.TenViTri);
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
            $('#tblDataKho tbody').on('click', '.delete', function () {
                var $row = $(this).closest('tr');
                var id = $row.data('id');

                if (confirm('Are you sure you want to delete this item?')) {
                    $.ajax({
                        url: '/api/KhoApi/' + id,
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
            $('#addKhoForm').on('submit', function (e) {
                e.preventDefault();

                var newKho = {
                    TenKho: $('#TenKho').val(), // Removed unnecessary semi-colon
                    TenViTri: $('#TenViTri').val(),
                };

                $.ajax({
                    url: '/api/KhoApi',
                    method: 'POST',
                    contentType: 'application/json',
                    data: JSON.stringify(newKho),
                    success: function (response) {
                        console.log('Thêm thành công');
                        var item = response;

                        // Add new row to DataTable
                        var newRowHtml = '<tr data-id="' + item.Id + '">' +
                            '<td data-field="Id">' + item.Id + '</td>' +
                            '<td data-field="TenKho">' + item.TenKho + '</td>' +
                            '<td data-field="TenViTri">' + item.TenViTri + '</td>' +
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

                        // Close modal and reset form
                        $('#addKhoModal').modal('hide');
                        $('#addKhoForm')[0].reset();
                    },
                    error: function (xhr, status, error) {
                        console.error('Lỗi khi thêm dữ liệu:', error);
                        // Handle error response
                    }
                });
            });

            $('#addKhoBtn').on('click', function () {
                $('#addKhoModal').modal('show');
            });
        },
        error: function (xhr, status, error) {
            console.error('Error fetching data:', error);
        }
    });
});