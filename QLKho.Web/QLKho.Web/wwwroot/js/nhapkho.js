
    $(document).ready(function () {
        loadDataTable();

        function loadDataTable() {
            var dataTable = $('#tblDataNhapKho').DataTable({
                "processing": true,
                "serverSide": false, // Nếu sử dụng server-side processing thì set true và cấu hình server-side
                "ajax": {
                    "url": "/api/nhapkhoApi", // Đường dẫn API lấy dữ liệu
                    "type": "GET", // Phương thức GET
                    "dataSrc": "" // Dữ liệu được trả về là một mảng rỗng
                },
                "columns": [
                    { "data": "Id" },
                    { "data": "LoaiNhap" },
                    { "data": "NgayNhap" },
                    { "data": "NhaCungCapId" }, // Để lấy tên của nhà cung cấp từ object nhà cung cấp
                    { "data": "KhoId" }, // Để lấy tên kho từ object kho
                    { "data": "SoLuongNhap" },
                    { "data": "Nguoigiao" },
                    { "data": "NoiDungNhap" },
                    { "data": "NgayTao" },
                    { "data": "NgayCapNhat" },
                    { "data": "NguoiTao" },
                    {
                        "data": null,
                        "render": function (data, type, row) {
                            return '<button class="btn btn-sm btn-warning btn-edit" data-id="' + row.Id + '">Edit</button>';
                        }
                    }
                ]

            });
        }

        function reloadDataTable() {
            // Xóa DataTable hiện tại và tải lại dữ liệu mới
            var dataTable = $('#tblDataNhapKho').DataTable();
            dataTable.destroy(); // Xóa DataTable hiện tại
            loadDataTable(); // Tải lại DataTable với dữ liệu mới
        }

        $.ajax({
            url: '/api/NhaCungCapApi', // Thay đổi đường dẫn tùy theo tên controller và action của bạn
            method: 'GET',
            success: function (data) {
                var options = '';
                data.forEach(function (item) {
                    options += '<option value="' + item.Id + '">' + item.TenNhaCungCap + '</option>';
                });
                $('#NhaCungCapId').html(options);
            },
            error: function (error) {
                console.error('Error loading Nha Cung Cap:', error);
            }
        });

        $.ajax({
            url: '/api/KhoApi', // Thay đổi đường dẫn tùy theo tên controller và action của bạn
            method: 'GET',
            success: function (data) {
                var options = '';
                data.forEach(function (item) {
                    options += '<option value="' + item.Id + '">' + item.TenKho + '</option>';
                });
                $('#KhoId').html(options);
            },
            error: function (error) {
                console.error('Error loading Kho:', error);
            }
        });

        // Xử lý sự kiện khi form được submit
        $('#addNhapKhoForm').submit(function (event) {
            event.preventDefault();

            var formData = {
                LoaiNhap: $('#LoaiNhap').val(),
                NgayNhap: $('#NgayNhap').val(),
                NhaCungCapId: $('#NhaCungCapId').val(),
                KhoId: $('#KhoId').val(),
                SoLuongNhap: $('#SoLuongNhap').val(),
                Nguoigiao: $('#Nguoigiao').val(),
                NoiDungNhap: $('#NoiDungNhap').val(),
                NgayTao: $('#NgayTao').val(),
                NgayCapNhat: $('#NgayCapNhat').val(),
                NguoiTao: $('#NguoiTao').val()
            };

            $.ajax({
                type: 'POST',
                url: '/api/NhapKhoApi', // Thay đổi đường dẫn tùy theo tên controller của bạn
                contentType: 'application/json',
                data: JSON.stringify(formData),
                success: function (data) {
                    $('#addNhapKhoModal').modal('hide');
                    $('#addNhapKhoForm')[0].reset();
                    reloadDataTable(); // Gọi hàm reloadDataTable để tải lại dữ liệu
                },
                error: function (error) {
                    $('#message').html('<div class="alert alert-danger">Đã xảy ra lỗi khi thêm mới Nhập Kho!</div>');
                    console.error('Error:', error);
                }
            });
        });


        $('#btn-edit').on('click', function () {
            var id = $(this).data('id');

            // AJAX request to fetch data for the selected ID
            $.ajax({
                url: '/api/NhapKhoApi/' + id,
                method: 'GET',
                success: function (item) {
                    // Populate the modal with fetched data
                    $('#editNhapKhoModal').modal('show'); // Show the modal

                    // Assuming your fields are inside the modal body or form
                    $('#Id').val(item.Id);
                    $('#LoaiNhap').val(item.LoaiNhap);
                    //$('#NgayNhap').val(item.NgayNhap.slice(0, 10)); // Assuming NgayNhap is a date, slice to get date part
                    $('#NhaCungCapId').val(item.NhaCungCapId);
                    $('#KhoId').val(item.KhoId);
                    $('#SoLuongNhap').val(item.SoLuongNhap);
                    $('#Nguoigiao').val(item.Nguoigiao);
                    $('#NoiDungNhap').val(item.NoiDungNhap);
                    $('#NgayTao').val(item.NgayTao);
                    $('#NgayCapNhat').val(item.NgayCapNhat);
                    $('#NguoiTao').val(item.NguoiTao);

                },
                error: function (error) {
                    console.error('Error loading Nhập Kho details:', error);
                }
            });
        });



        $('#addNhapKhoBtn').on('click', function () {
            $('#addNhapKhoModal').modal('show');
        });
    });
