const loadMoreCampaigns = (campaignId, pageNumber) => {
    $.ajax({
        url: `umbraco/surface/CurrentCampaigns/GetMoreCampaigns?campaignId=${campaignId}&pageNumber=${pageNumber}`,
        success: function (result) {
            document.getElementById('load-more-campaigns').remove();
            document.getElementById('load-more-campaigns-div').remove();
            $('.campaigns .row').append(result);
        }
    });
}