let selectedCategory = '';

const fetchProjects = (projectId, pageNumber, categoryName, callback) => {
    $.ajax({
        url: `/umbraco/surface/projectslisting/GetMoreProjects?projectsId=${projectId}&pageNumber=${pageNumber}&categoryName=${categoryName}`,
        success: function (result) {
            callback(result);
        }
    });
}

const appendNewProjects = (projects) => {
    document.getElementById('loadMore').remove();
    document.getElementById('projects').innerHTML += projects;
}

const filterProjects = (btn, projects) => {
    const activeClass = 'categories__category--active';
    document.getElementById('projects').innerHTML = projects;
    const currentActive = document.getElementsByClassName(activeClass);
    if (currentActive.length > 0) {
        currentActive[0].classList.remove(activeClass);
        btn.classList.add(activeClass);
    }
}

const loadMoreProjects = (projectId, pageNumber) =>
    fetchProjects(projectId, pageNumber, selectedCategory, appendNewProjects);

const filterByCategory = (btn, projectId, pageNumber, categoryName) => {
    selectedCategory = categoryName;
    fetchProjects(projectId, pageNumber, categoryName, (result) => filterProjects(btn, result));
}
