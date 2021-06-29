
var saleFunctions = function () {
    return {
        deleteModalId: function (e) {
            var productTransactionId = e.getAttribute("deleteSaleId");
            var action = "CancelProductReserved?productTransactionId=" + productTransactionId;
            var buttonConfirm = document.getElementById("buttonConfirm");
            buttonConfirm.setAttribute("action", action);
            buttonConfirm.setAttribute("deleteSaleId", productTransactionId);

        },
        deleteSale: function (e) {
            var action = e.getAttribute("action");
            var productTransactionId = e.getAttribute("deleteSaleId");

            fetch(action, {
                method: "POST",          // HTTP Method
                body: productTransactionId // Data to send
            }).then(t => window.location.reload());
        },
        fillUseraddress: function () {
            var selectedAddressId = document.getElementById("AddressUserId").selectedOptions[0].value;
            var allAddressDetails = document.getElementsByClassName("addressDetails");

            for (var i = 0; i < allAddressDetails.length; i++) {
                allAddressDetails[i].setAttribute("hidden", "hidden");
            }

            var addressDetails = document.getElementById("addressId" + selectedAddressId);
            addressDetails.removeAttribute("hidden");
        },
        fillPayment: function () {
            var selectedPaymentMethodId = document.getElementById("PaymentMethodId").selectedOptions[0].value;
            var allPaymentMethodsDetails = document.getElementsByClassName("paymentMethodsDetails");

            for (var i = 0; i < allPaymentMethodsDetails.length; i++) {
                allPaymentMethodsDetails[i].setAttribute("hidden", "hidden");
            }

            var paymentMethodDetails = document.getElementById("paymentMethodId" + selectedPaymentMethodId);
            paymentMethodDetails.removeAttribute("hidden");
        }
    }
};

const saleController = new saleFunctions();