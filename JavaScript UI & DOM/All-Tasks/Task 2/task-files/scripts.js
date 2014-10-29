$.fn.gallery = function(cols) {
    var $gallery = this;
    $gallery.addClass('gallery');
    if (!$(cols)) {
        cols = 4;
    };
    $gallery.css('width', cols * 260 + 'px')

    var $galleryList = $gallery.children('.gallery-list');
    var $selected = $gallery.children('.selected');
    $selected.hide();

    $galleryList.on('click', '.image-container', function() {
        $galleryList.addClass('blurred');
        $galleryList.addClass('disabled-background');
        if (!$galleryList.hasClass('disabled-background')) {
            var $currentImg = $(this).children();
            var $previousImg = $(this).prev().children();
            var $nextImg = $(this).next().children();

            var $currentLink = $currentImg.attr('src');
            var $previousLink = $previousImg.attr('src');
            var $nextLink = $nextImg.attr('src');

            if ($currentLink == 'imgs/1.jpg') {
                $previousLink = 'imgs/12.jpg';
            };
            if ($currentLink == 'imgs/12.jpg') {
                $nextLink = 'imgs/1.jpg';
            };

            $selected.children('.current-image').find('img').attr('src', $currentLink);
            $selected.children('.previous-image').find('img').attr('src', $previousLink);
            $selected.children('.next-image').find('img').attr('src', $nextLink);
        }
        $selected.show();
    })

    $selected.on('click', '.current-image', function() {
        $selected.hide();
        $galleryList.removeClass('blurred');
        $galleryList.removeClass('disabled-background');
    })
    $selected.on('click', '.next-image', function() {
        var $currentLinkGallery = $(this).children().attr('src');
        $nextLinkGallery = $("img[src='" + $currentLinkGallery + "']").parent().next().children().attr('src');
        if ($nextLinkGallery == 'imgs/12.jpg') {
            $nextLinkGallery = 'imgs/1.jpg';
        };
        $(this).children().attr('src', $nextLinkGallery);
        var $buffer = $(this).prev().children().attr('src');
        $(this).prev().children().attr('src', $currentLinkGallery);
        $(this).prev().prev().children().attr('src', $buffer);
    })
    $selected.on('click', '.previous-image', function() {
        var $currentLinkGallery = $(this).children().attr('src');
        $nextLinkGallery = $("img[src='" + $currentLinkGallery + "']").parent().prev().children().attr('src');
        if ($nextLinkGallery == 'imgs/1.jpg') {
            $nextLinkGallery = 'imgs/12.jpg';
        };
        $(this).children().attr('src', $nextLinkGallery);
        var $buffer = $(this).next().children().attr('src');
        $(this).next().children().attr('src', $currentLinkGallery);
        $(this).next().next().children().attr('src', $buffer);
    })
};