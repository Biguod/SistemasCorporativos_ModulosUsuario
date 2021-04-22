var productFunctions = function () {
    return {
        deleteModalId: function (e) {
            var productId = e.getAttribute("deleteProductId");
            var deleteModal = document.getElementById("deleteModalAction");
            var action = "Product/Delete?productId=" + productId;
            deleteModal.setAttribute("action", action);
        }
    }
};

const productController = new productFunctions();