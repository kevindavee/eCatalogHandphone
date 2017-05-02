$('.btn-admin-delete').on('click', function (e) {
    if (!confirm("Anda yakin mau menghapus data ini ?")) {
        e.preventDefault();
    }
});