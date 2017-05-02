$('.btn-toggle-handphone').on('click', function () {
    var pageIndex = parseInt($('#HandphonePageIndex').val());
    var pageCount = parseInt($('#HandphonePageCounts').val())

    if ($(this).val == 0) {
        if (pageIndex != 0) {
            pageIndex--;
        }
    }
    else {
        if (pageIndex != pageCount) {
            pageIndex++;
        }
    }

    var url = "/Admin/ListOfHandphone"

    $.get(url, { PageIndex: pageIndex }, function (data) {
        $('div#handphone').html(data);
    })
});

$('.btn-toggle-brand').on('click', function () {
    var pageIndex = parseInt($('#BrandPageIndex').val());
    var pageCount = parseInt($('#BrandPageCounts').val())

    if ($(this).val == 0) {
        if (pageIndex != 0) {
            pageIndex--;
        }
    }
    else {
        if (pageIndex != pageCount) {
            pageIndex++;
        }
    }

    var url = "/Admin/ListOfBrand"

    $.get(url, { PageIndex: pageIndex }, function (data) {
        $('div#brand').html(data);
    })
});