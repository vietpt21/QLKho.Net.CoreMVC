$(document).ready(function () {
    // Initialize DataTable
    var table = $('#tblDataSanPham').DataTable({
        "columnDefs": [
            { "targets": [0], "visible": false, "searchable": false } // Hide ID column
        ]
    });

    // Load initial data into the DataTable
    loadDataTable();

    function loadDataTable() {
        $.ajax({
            url: '/api/SanPhamApi',
            method: 'GET',
            success: function (response) {
                var html = '';
                response.forEach(function (item) {
                    html += '<tr data-id="' + item.Id + '">' +
                        '<td>' + item.TenSanPham + '</td>' +
                        '<td>' + item.HienThi + '</td>' +
                        '<td>' + item.NhomSanPham + '</td>' +
                        '<td>' + item.HangSanXuat + '</td>' +
                        '<td><img src="/Images/' + item.HinhAnh + '" alt="Image" width="100"></td>' +
                        '<td>' +
                        '<a class="btn btn-outline-secondary btn-sm edit" data-id="' + item.Id + '" title="Edit"><i class="fas fa-pencil-alt"></i></a> ' +
                        '<a class="btn btn-outline-danger btn-sm delete" data-id="' + item.Id + '" title="Delete"><i class="fas fa-trash-alt"></i></a>' +
                        '</td>' +
                        '</tr>';
                });
                $('#tblDataSanPham tbody').html(html);
                attachEventHandlers(); // Reattach event handlers
            },
            error: function (xhr, status, error) {
                console.error('Error fetching data:', xhr.responseText);
            }
        });
    }

    function attachEventHandlers() {
        // Handle edit button click
        $('#tblDataSanPham tbody').on('click', '.edit', function () {
            var id = $(this).closest('tr').data('id');
            $.ajax({
                url: '/api/SanPhamApi/' + id,
                method: 'GET',
                success: function (item) {
                    $('#Id').val(item.Id);
                    $('#TenSanPham').val(item.TenSanPham);
                    $('#HienThi').val(item.HienThi);
                    $('#NhomSanPham').val(item.NhomSanPham);
                    $('#HangSanXuat').val(item.HangSanXuat);
                    $('#HinhAnh').attr('src', '/Images/' + item.HinhAnh);

                    $('#DiaChi').val(item.DiaChi);
                    $('#ThongTin').val(item.ThongTin);
                    $('#HanSuDung').val(item.HanSuDung ? new Date(item.HanSuDung).toISOString().slice(0, 16) : '');
                    $('#QuyCach').val(item.QuyCach);
                    $('#Dvt').val(item.Dvt);
                    $('#GiaNhap').val(item.GiaNhap);
                    $('#SLToiThieu').val(item.SLToiThieu);
                    $('#SLToiDa').val(item.SLToiDa);
                    $('#SLNhap').val(item.SLNhap);
                    $('#SLXuat').val(item.SLXuat);
                    $('#SLTon').val(item.SLTon);
                    $('#TrangThai').val(item.TrangThai);
                    $('#Ghichu').val(item.Ghichu);
                    $('#NgayTao').val(item.NgayTao ? new Date(item.NgayTao).toISOString().slice(0, 16) : '');
                    $('#NgayCapNhat').val(item.NgayCapNhat ? new Date(item.NgayCapNhat).toISOString().slice(0, 16) : '');
                    $('#NguoiTao').val(item.NguoiTao);
                    $('#editSanPhamModalLabel').text('Edit San Pham');
                    $('#editSanPhamModal').modal('show');
                },
                error: function (xhr, status, error) {
                    console.error('Error fetching data:', error);
                }
            });
        });

        // Handle delete button click
        $('#tblDataSanPham tbody').on('click', '.delete', function () {
            var id = $(this).closest('tr').data('id');
            if (confirm('Are you sure you want to delete this item?')) {
                $.ajax({
                    url: '/api/SanPhamApi/' + id,
                    method: 'DELETE',
                    success: function () {
                        table.row($(this).closest('tr')).remove().draw();
                    },
                    error: function (xhr, status, error) {
                        console.error('Error deleting data:', error);
                    }
                });
            }
        });
    }

    // Handle form submission for editing product
    $('#editSanPhamForm').on('submit', function (e) {
        e.preventDefault(); // Prevent default form submission

        // Create FormData object from the form
        var formData = new FormData(this);
        var id = $('#Id').val(); // Get the product ID from a hidden input or elsewhere

        $.ajax({
            url: '/api/SanPhamApi/' + id,
            method: 'PUT',
            data: formData,
            processData: false, // Prevent jQuery from automatically transforming the data into a query string
            contentType: false, // Set contentType to false to allow multipart/form-data
            success: function (response) {
                $('#editSanPhamModal').modal('hide'); // Hide the modal
                $('#editSanPhamForm')[0].reset(); // Reset the form
                loadDataTable(); // Reload DataTable
            },
            error: function (xhr, status, error) {
                console.error('Error updating data:', xhr.responseText);
            }
        });
    });

    // Handle form submission for adding new product
    $('#addSanPhamForm').on('submit', function (e) {
        e.preventDefault();
        var formData = new FormData(this);
        $.ajax({
            url: '/api/SanPhamApi',
            method: 'POST',
            data: formData,
            processData: false,
            contentType: false,
            success: function () {
                $('#addSanPhamModal').modal('hide');
                $('#addSanPhamForm')[0].reset();
                loadDataTable();
            },
            error: function (xhr, status, error) {
                console.error('Error adding data:', xhr.responseText);
            }
        });
    });

    // Show modal when button is clicked
    $('#addSanPhamBtn').on('click', function () {
        $('#addSanPhamModal').modal('show');
    });
});