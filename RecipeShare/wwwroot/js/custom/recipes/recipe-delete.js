let selectedRecipeId = null;
let deleteModal;

document.addEventListener("DOMContentLoaded", function () {   
    deleteModal = new bootstrap.Modal(document.getElementById('deleteModal'));
   
    document.querySelectorAll('.delete-btn').forEach(button => {
        button.addEventListener('click', function (e) {
            e.preventDefault();
            selectedRecipeId = this.getAttribute('data-recipe-id');
            deleteModal.show();
        });
    });

    document.getElementById('confirmDeleteBtn').addEventListener('click', async () => {
        if (!selectedRecipeId) return;

        try {
            const response = await fetch(`/Recipes/Delete/${selectedRecipeId}`, {
                method: 'DELETE',
                headers: {
                    'X-Requested-With': 'XMLHttpRequest'
                }
            });

            if (response.ok) {
                location.reload();
            } else {
                alert('Failed to delete the recipe.');
            }
        } catch (error) {
            console.error(error);
            alert('An error occurred while deleting.');
        }
    });
});