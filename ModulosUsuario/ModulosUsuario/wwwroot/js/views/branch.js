var branchFunctions = function () {
    return {
        deleteModalId: function (e) {
            var branchId = e.getAttribute("deleteBranchId");
            var deleteModal = document.getElementById("deleteModalAction");
            var action = "Branch/Delete?branchId=" + branchId;
            deleteModal.setAttribute("action", action);
        }
    }
};

const branchController = new branchFunctions();