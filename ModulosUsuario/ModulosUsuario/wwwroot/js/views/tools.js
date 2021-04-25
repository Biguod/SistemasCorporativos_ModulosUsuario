var toolsFunctions = function () {
    return {
        deleteModalId: function (e) {
            var toolsId = e.getAttribute("deleteToolsId");
            var deleteModal = document.getElementById("deleteModalAction");
            var action = "Tools/Delete?toolsId=" + toolsId;
            deleteModal.setAttribute("action", action);
        }
    }
};

const toolsController = new toolsFunctions();