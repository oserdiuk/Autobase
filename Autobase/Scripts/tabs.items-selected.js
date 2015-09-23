$(function () {
    var sortOptions = $('.nav-tabs').find('li');
    selectListItem(sortOptions[0]);

    sortOptions.click(function () {
        deselectAllItems(sortOptions);
        selectListItem($(this));
    });

    function deselectAllItems(items) {
        $(items).each(function () {
            $(this).removeClass('tabs-item-selected')
        });
    }

    function selectListItem(item) {
        $(item).addClass('tabs-item-selected');
    }

    $.ajax({
        type: "POST",
        url: "/Users/GetDrivers",
        datatype: "html",
        success: function (data) {
            $('#result').html(data);
        }
    });
});