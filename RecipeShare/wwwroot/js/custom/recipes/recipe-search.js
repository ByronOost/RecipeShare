function fetchFilteredRecipes() {
    const term = $('#searchTerm').val();
    const tag = $('#dietaryTag').val();

    $.ajax({
        url: `/Recipes/Search`,
        type: 'GET',
        data: {
            term: term,
            dietaryTag: tag
        },
        success: function (partialViewHtml) {
            $('#recipeResults').html(partialViewHtml);
        }
    });
}

$(document).ready(function () {
    $('#searchTerm').on('input', fetchFilteredRecipes);
    $('#dietaryTag').on('change', fetchFilteredRecipes);
});