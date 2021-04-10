var userFunctions = function () {
    return {
        deleteModalId: function (e) {
            var userId = e.getAttribute("deleteUserId");
            var deleteModal = document.getElementById("deleteModalAction");
            var action = "User/Delete?userId=" + userId;
            deleteModal.setAttribute("action", action);
        }
    }
};

const userController = new userFunctions();