$(function () {
    var sortOptions = $('.dropdown-menu').find('li').not('.divider');
    sortOptions.click(function () {
        deselectAllItems(sortOptions);
        selectListItem($(this));
    });

    function deselectAllItems(items) {
        $(items).each(function () {
            $(this).removeClass('listitem-selected')
        });
    }

    function selectListItem(item) {
        $(item).addClass('listitem-selected');
    }
});