
var saleFunctions = function () {
    return {
        deleteModalId: function (e) {
            var productTransactionId = e.getAttribute("deleteSaleId");
            var deleteModal = document.getElementById("deleteModalAction");
            var action = "CancelProductReserved?productTransactionId=" + productTransactionId;
            deleteModal.setAttribute("action", action);
        }
    }
};

const saleController = new saleFunctions();