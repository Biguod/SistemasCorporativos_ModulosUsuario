var unityTypeFunctions = function () {
    return {
        deleteModalId: function (e) {
            var unityTypeId = e.getAttribute("deleteUnityTypeId");
            var deleteModal = document.getElementById("deleteModalAction");
            var action = "UnityType/Delete?unityTypeId=" + unityTypeId;
            deleteModal.setAttribute("action", action);
        }
    }
};

const unityTypeController = new unityTypeFunctions();