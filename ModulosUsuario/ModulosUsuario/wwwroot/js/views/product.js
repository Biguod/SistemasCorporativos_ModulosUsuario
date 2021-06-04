var productFunctions = function () {
    return {
        deleteModalId: function (e) {
            var productId = e.getAttribute("deleteProductId");
            var deleteModal = document.getElementById("deleteModalAction");
            var action = "Product/Delete?productId=" + productId;
            deleteModal.setAttribute("action", action);
        },
        productImageOnChange: function (e) {
            debugger
            var fileName = $(e).val().split("\").pop();
            $(e).siblings(".custom-file-label").addClass("selected").html(fileName);
        }
    }
};

const productController = new productFunctions();