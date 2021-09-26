const loadMoreNews = (blogId, pageNumber) => {
    $.ajax({
        url: `umbraco/surface/News/GetMoreNews?blogId=${blogId}&pageNumber=${pageNumber}`,
        success: function (result) {
            document.getElementById('load-more-news').remove();
            document.getElementById('load-more-news-div').remove();
            $('.articles .row').append(result);
        }
    });
}