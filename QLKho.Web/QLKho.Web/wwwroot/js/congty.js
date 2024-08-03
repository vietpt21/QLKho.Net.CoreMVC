$(document).ready(function () {
    var table; // Variable to store DataTable instance

    // Initialize DataTable and load data via AJAX
    $.ajax({
        url: '/api/CongTyApi',
        method: 'GET',
        success: function (response) {
            var data = response; // Assuming response is already an array of CongTy objects

            // Generate HTML based on data
            var html = '';
            data.forEach(function (item) {
                html += '<tr data-id="' + item.Id + '">' +
                    '<td data-field="Id">' + item.Id + '</td>' +
                    '<td data-field="TenCTy">' + item.TenCTy + '</td>' +
                    '<td data-field="TenDayDu">' + item.TenDayDu + '</td>' +
                    '<td data-field="NguoiDaiDien">' + item.NguoiDaiDien + '</td>' +
                    '<td data-field="DiaChi">' + item.DiaChi + '</td>' +
                    '<td data-field="SDT">' + item.SDT + '</td>' +
                    '<td data-field="Email">' + item.Email + '</td>' +
                    '<td data-field="Website">' + item.Website + '</td>' +
                    '<td data-field="NgayTao">' + item.NgayTao + '</td>' +
                    '<td data-field="NgayCapNhat">' + item.NgayCapNhat + '</td>' +
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
            $('#tblDataCongTy tbody').html(html);

            // Initialize DataTables
            table = $('#tblDataCongTy').DataTable({
                // DataTables configuration options
            });

            // Handle inline editing
            $('#tblDataCongTy tbody').on('click', '.edit', function () {
                var $btn = $(this).find('i');
                var $row = $(this).closest('tr');
                var id = $row.data('id');

                if ($btn.hasClass('fa-pencil-alt')) {
                    // Fetch data for the specific row
                    $.ajax({
                        url: '/api/CongTyApi/' + id,
                        method: 'GET',
                        success: function (response) {
                            var item = response;

                            // Populate the row with the fetched data and make it editable
                            $row.find('td[data-field="TenCTy"]').html('<input type="text" class="form-control" value="' + item.TenCTy + '">');
                            $row.find('td[data-field="TenDayDu"]').html('<input type="text" class="form-control" value="' + item.TenDayDu + '">');
                            $row.find('td[data-field="NguoiDaiDien"]').html('<input type="text" class="form-control" value="' + item.NguoiDaiDien + '">');
                            $row.find('td[data-field="DiaChi"]').html('<input type="text" class="form-control" value="' + item.DiaChi + '">');
                            $row.find('td[data-field="SDT"]').html('<input type="text" class="form-control" value="' + item.SDT + '">');
                            $row.find('td[data-field="Email"]').html('<input type="text" class="form-control" value="' + item.Email + '">');
                            $row.find('td[data-field="Website"]').html('<input type="text" class="form-control" value="' + item.Website + '">');
                            // Switch to save mode
                            $btn.removeClass('fa-pencil-alt').addClass('fa-save').attr('title', 'Save');
                        },
                        error: function (xhr, status, error) {
                            console.error('Error fetching data:', error);
                            alert('Error fetching data. Please try again.');
                        }
                    });
                } else {
                    // Switch to edit mode and save data
                    var updatedData = {
                        Id: id,
                        TenCTy: $row.find('td[data-field="TenCTy"] input').val(),
                        TenDayDu: $row.find('td[data-field="TenDayDu"] input').val(),
                        NguoiDaiDien: $row.find('td[data-field="NguoiDaiDien"] input').val(),
                        DiaChi: $row.find('td[data-field="DiaChi"] input').val(),
                        SDT: $row.find('td[data-field="SDT"] input').val(),
                        Email: $row.find('td[data-field="Email"] input').val(),
                        Website: $row.find('td[data-field="Website"] input').val()
                    };

                    $.ajax({
                        url: '/api/CongTyApi/' + id,
                        method: 'PUT',
                        contentType: 'application/json',
                        data: JSON.stringify(updatedData),
                        success: function (response) {
                            console.log('Update successful:', response);
                            $btn.removeClass('fa-save').addClass('fa-pencil-alt').attr('title', 'Edit');
                        },
                        error: function (xhr, status, error) {
                            console.error('Error updating data:', error);
                            alert('Error updating data. Please try again.');
                        }
                    });
                }
            });

            // Handle deletion
            $('#tblDataCongTy tbody').on('click', '.delete', function () {
                var $row = $(this).closest('tr');
                var id = $row.data('id');

                if (confirm('Are you sure you want to delete this item?')) {
                    $.ajax({
                        url: '/api/CongTyApi/' + id,
                        method: 'DELETE',
                        success: function (response) {
                            console.log('Deletion successful');
                            table.row($row).remove().draw();
                        },
                        error: function (xhr, status, error) {
                            console.error('Error deleting data:', error);
                            alert('Error deleting data. Please try again.');
                        }
                    });
                }
            });

            // Handle form submission for adding a new line
            $('#addCongTyForm').on('submit', function (e) {
                e.preventDefault();

                var newCongTy = {
                    TenCTy: $('#TenCTy').val(),
                    TenDayDu: $('#TenDayDu').val(),
                    NguoiDaiDien: $('#NguoiDaiDien').val(),
                    DiaChi: $('#DiaChi').val(),
                    SDT: $('#SDT').val(),
                    Email: $('#Email').val(),
                    Website: $('#Website').val()
                };

                $.ajax({
                    url: '/api/CongTyApi',
                    method: 'POST',
                    contentType: 'application/json',
                    data: JSON.stringify(newCongTy),
                    success: function (response) {
                        console.log('Creation successful');
                        var item = response;
                        var newRowHtml = '<tr data-id="' + item.Id + '">' +
                            '<td data-field="Id">' + item.Id + '</td>' +
                            '<td data-field="TenCTy">' + item.TenCTy + '</td>' +
                            '<td data-field="TenDayDu">' + item.TenDayDu + '</td>' +
                            '<td data-field="NguoiDaiDien">' + item.NguoiDaiDien + '</td>' +
                            '<td data-field="DiaChi">' + item.DiaChi + '</td>' +
                            '<td data-field="SDT">' + item.SDT + '</td>' +
                            '<td data-field="Email">' + item.Email + '</td>' +
                            '<td data-field="Website">' + item.Website + '</td>' +
                            '<td data-field="NgayTao">' + item.NgayTao + '</td>' +
                            '<td data-field="NgayCapNhat">' + item.NgayCapNhat + '</td>' +
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

                        $('#addCongTyModal').modal('hide');
                        $('#addCongTyForm')[0].reset();
                    },
                    error: function (xhr, status, error) {
                        console.error('Error creating data:', error);
                        alert('Error creating data. Please try again.');
                    }
                });
            });
        },
        error: function (xhr, status, error) {
            console.error('Error fetching data:', error);
            alert('Error fetching data. Please try again.');
        }
    });

    $('#addCongTyBtn').on('click', function () {
        $('#addCongTyModal').modal('show');
    });
});