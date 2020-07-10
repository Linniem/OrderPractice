var VUE_MODEL;
var BOOTSTRAP_VUE_MODEL;
var ORDERS_JSON;
var PRODUCT_JSON = { 'productId': '0', 'productName': 'productName' };

$(document).ready(function () {
    $.ajax({
        type: 'GET',
        url: '/api/Orders',
        dataType: 'json',
        success: function (response) {
            ORDERS_JSON = response;

            BindVueModel();
            AddConfirmBtEvent();
        }
    });

});

function BindVueModel() {
    VUE_MODEL = new Vue(
        {
            el: '#ordersTable',
            data: { items: ORDERS_JSON },
            methods: {
                GetProductInfo: function (productName) {
                    $.ajax({
                        type: 'GET',
                        url: `/api/Products/${productName}`,
                        dataType: 'json',
                        success: function (response) {
                            BOOTSTRAP_VUE_MODEL.$data.product = response;
                            $('#BootstrapModal').modal('show');
                        }
                    });
                }
            }
        }
    )

    BOOTSTRAP_VUE_MODEL = new Vue(
        {
            el: '#BootstrapModal',
            data: { product: PRODUCT_JSON }
        }
    )
}

function AddConfirmBtEvent() {
    $('#cofirmButton').click(() => {
        let patchQueue = GetCheckedDatas();
        SendAjaxRecursion(patchQueue);
    })
}

function SendAjaxRecursion(patchQueue) {
    let patchOrderId = patchQueue.shift();
    let vueItem = VUE_MODEL.$data.items.find(ele => ele.orderId == patchOrderId);

    let newStatusCode = 1;
    if (vueItem.statusCode == 1) {
        newStatusCode = 2;
    }
    let patchJsonData = [
        {
            'op': 'replace',
            'path': '/StatusCode',
            'value': newStatusCode
        }
    ]


    $.ajax({
        type: 'PATCH',
        url: `/api/Orders/update/${patchOrderId}`,
        data: JSON.stringify(patchJsonData),
        processData: false,
        contentType: 'application/merge-patch+json',
        success: function (response) {
            vueItem.statusName = response.statusName;
            vueItem.statusCode = response.statusCode;
            document.querySelector(`#${patchOrderId}`).checked = false;

            if (patchQueue.length > 0) {
                SendAjaxRecursion(patchQueue);
            }
        }
    });
}

function GetCheckedDatas() {
    let patchQueue = [];
    [...$('input')].forEach(checkBox => {
        if (checkBox.checked) {
            patchQueue.push(checkBox.value);
        }
    });
    return patchQueue;
}