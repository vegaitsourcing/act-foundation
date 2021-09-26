const loadMore = (projectId, pageNumber) => {
    $.ajax({
        url: `umbraco/surface/projectslisting/GetMoreProjects?projectsId=${projectId}&pageNumber=${pageNumber}`,
        success: function (result) {
            document.getElementById('projects').innerHTML += result;
            document.getElementById('loadMore').remove();
        }
    });
}