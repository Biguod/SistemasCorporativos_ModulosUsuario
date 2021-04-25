var materialFunctions = function () {
    return {
        deleteModalId: function (e) {
            var materialId = e.getAttribute("deleteMaterialId");
            var deleteModal = document.getElementById("deleteModalAction");
            var action = "Material/Delete?materialId=" + materialId;
            deleteModal.setAttribute("action", action);
        }
    }
};

const materialController = new materialFunctions();