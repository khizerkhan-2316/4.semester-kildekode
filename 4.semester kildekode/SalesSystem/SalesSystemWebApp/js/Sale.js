

const buttons = document.querySelectorAll(".add-salesline-btn");

const salesLine = [];
let discount = 0;
let paymentOption = "";
let totalPrice = 0;
let paidAmount = 0;
let amountToReturn = 0;




function paidAmountEventHandler(evt) {
    try {

        if (!isNaN(parseFloat(evt.target.value))) {
            paidAmount = parseFloat(evt.target.value)
        } else {
            paidAmount = 0;
            const root = document.getElementById("root-content");
            const errorModal = createModal("Fejl!", "Beløb betalt skal være et tal!");
            root.insertBefore(errorModal, root.firstChild);

        }

    } catch (e) {
        alert(e);
    }


}


function discountEventHandler(evt) {
    try {

        if (!isNaN(parseFloat(evt.target.value)) && evt.target.value >= 1 && evt.target.value <= 100) {
            discount = parseFloat(evt.target.value)
        } else {
            discount = 0;
            const root = document.getElementById("root-content");
            const errorModal = createModal("Fejl!", "Discount er valgfrit, men skal være et tal mellem 1-100");
            root.insertBefore(errorModal, root.firstChild);
        }

    } catch (e) {
        alert(e);
    }

}


function handleSaleDetails(evt) {
    totalPrice = calculateTotalPrice();
    amountToReturn = calculateAmountToReturn();

    const row = document.getElementById("sale-detail-row");
    const childList = row.childNodes;

    childList[1].innerHTML = totalPrice;
    childList[3].innerHTML = paidAmount;
    childList[5].innerHTML = paymentOption;
    childList[7].innerHTML = discount;
    childList[9].innerHTML = amountToReturn;


    if (isSaleValid()) {
        document.getElementById("submit-btn").removeAttribute("disabled");
    }

}

function setPaymentOptionCard() {
    paymentOption = "Dankort";
}

function setPaymentOptionMobilePay() {
    paymentOption = "MobilePay";
}

function setPaymentOptionCash() {
    paymentOption = "Kontant";
}



document.getElementById("amount-paid-input").addEventListener("change", (evt) => paidAmountEventHandler(evt));
document.getElementById("discount-input").addEventListener("change", (evt) => discountEventHandler(evt));
document.getElementById("calculate-details").addEventListener("click", (evt) => handleSaleDetails(evt));
document.getElementById("card-payment-option").addEventListener("click", (evt) => setPaymentOptionCard());
document.getElementById("mobilepay-payment-option").addEventListener("click", (evt) => setPaymentOptionMobilePay());
document.getElementById("cash-payment-option").addEventListener("click", (evt) => setPaymentOptionCash());
document.getElementById("submit-btn").addEventListener("click", async (evt) => await finalizeSale());



function calculateAmountToReturn() {
    return paidAmount - totalPrice;
}


function calculateTotalPrice() {
    let sum = 0;

    salesLine.forEach(line => {

        sum += line.TotalPrice;
    })

    if (discount != 0) {
        sum = sum - ((sum / 100) * discount);
    }

    return sum;
}

function addSalesLine(evt, index) {

    let salesLineExist = false;

    const tableRow = document.querySelectorAll(".product-details-row")[index];


    const saleLine = extractData(tableRow.getElementsByTagName("td"));

    salesLine.forEach(line => {
        if (line.Product.Name === saleLine.Product.Name) {
            salesLineExist = true;
            line.Quantity += 1;

            if (line.Product.SalePrice == null) {
                line.TotalPrice += line.Product.Price;

            } else {
                line.TotalPrice += line.Product.SalePrice;

            }
        }
    })

    if (salesLineExist === false) {
        salesLine.push(saleLine);
    }
}

function uuidv4() {
    return ([1e7] + -1e3 + -4e3 + -8e3 + -1e11).replace(/[018]/g, c =>
        (c ^ crypto.getRandomValues(new Uint8Array(1))[0] & 15 >> c / 4).toString(16)
    );
}


function formatSalesLineData(data) {
    return {
        salesLineId: data.SalesLineId,
        productName: data.Product.Name,
        quantity: data.Quantity,
        productPrice: data.Product.Price,
        productSalePrice: data.Product.SalePrice,
        salesLinePrice: data.TotalPrice,
        category: data.Product.Category.Name
    }
}

function deleteSaleLineEventHandler(evt, td, sl) {

    if (salesLine.length == 1) {
        removeAllChildNodes(document.getElementById("sales-line-tbody"));
        document.getElementById("sales-line-table").style.visibility = "hidden";
        salesLine.pop();
        document.getElementById("sales-line-paragraph").style.visibility = "visible";

    } else {

        const index = salesLine.findIndex(element => element.SalesLineId === sl.SalesLineId);
        td.remove();
        salesLine.splice(index, 1);
    }
}

function createSalesLineTableRow(salesLineData) {
    const tableRow = document.createElement("tr");

    const keys = Object.keys(salesLineData);

    console.log(keys);
    keys.forEach(key => {
        const td = document.createElement("td");
        td.innerHTML = salesLineData[key];
        tableRow.appendChild(td);

    })

    const buttonTd = document.createElement("td");
    const button = document.createElement("button");

    button.classList.add("btn", "btn-danger");
    button.innerHTML = "Slet salgslinje";

    button.addEventListener("click", (evt) => deleteSaleLineEventHandler(evt, tableRow, salesLineData));

    buttonTd.appendChild(button);
    tableRow.appendChild(buttonTd);




    return tableRow;
}

function extractData(childNodeList) {

    return {
        SalesLineId: uuidv4(),
        Quantity: 1,
        TotalPrice: childNodeList[5].innerHTML === "" ? 1 * parseFloat(childNodeList[4].innerHTML) : 1 * parseFloat(childNodeList[5].innerHTML),
        Product: {
            ProductId: childNodeList[0].innerHTML,
            Name: childNodeList[2].innerHTML,
            Description: childNodeList[3].innerHTML,
            Price: parseFloat(childNodeList[4].innerHTML),
            SalePrice: childNodeList[5].innerHTML === "" ? null : parseFloat(childNodeList[5].innerHTML),
            Category: { CategoryId: childNodeList[6].innerHTML, Name: childNodeList[7].innerHTML }

        },

    };
}

function removeAllChildNodes(parent) {
    while (parent.firstChild) {
        parent.removeChild(parent.firstChild);
    }
}


buttons.forEach((btn, index) => {
    btn.addEventListener("click", (evt) => {
        const paragraph = document.getElementById("sales-line-paragraph");
        document.getElementById("sales-line-table").style.visibility = "visible";

        if (paragraph !== null) {
            document.getElementById("sales-line-paragraph").style.visibility = "hidden";
        }

        addSalesLine(evt, index);

        removeAllChildNodes(document.getElementById("sales-line-tbody"));

        salesLine.forEach(line => {
            document.getElementById("sales-line-tbody").appendChild(createSalesLineTableRow(formatSalesLineData(line)));
        })
    });
})



function isSaleValid() {



    if (salesLine.length === 0) {
        return false;
    }

    if (totalPrice == 0 && paidAmount !== 0) {
        return false;
    }

    if (totalPrice !== 0 && paidAmount == 0) {
        return false;
    }

    if (paymentOption === "") {
        return false;
    }

    if (amountToReturn < 0) {
        return false;
    }



    return true;
}

function getSaleObject() {



    return {
        SaleId: uuidv4(),
        TotalPrice: totalPrice,
        AmountReturned: amountToReturn,
        Discount: discount === 0 ? null : discount,
        SaleDate: new Date().toISOString(),
        SalesLines: salesLine,
        PaymentOption: { PaymentOptionId: uuidv4(), Name: paymentOption },
        Payment: { PaymentId: uuidv4(), AmountPaid: paidAmount, PaymentDate: new Date().toISOString() }

    };



}


async function finalizeSale() {

    const sale = JSON.stringify(getSaleObject());


    const response = await fetch("https://localhost:44357/api/Sale", {
        method: 'POST',
        cache: 'no-cache',
        mode: 'cors',
        headers: {
            'Accept': 'application/json',
            'Content-Type': 'application/json',
        },

        body: sale,


    });

    const root = document.getElementById("root-content");

    if (response.ok) {
        const modal = createModal("Salg afsluttet!", "Salget er hermed færdiggjort!");
        root.insertBefore(modal, root.firstChild);
        setTimeout(() => window.location.reload(), 2000);

    } else if (response.status === 500) {

        const errorModal = createModal("Fejl!", "Der skete en fejl. Prøv igen.");
        root.insertBefore(errorModal, root.firstChild);

    } else if (response.status === 400) {

        const errorModal = createModal("Fejl!", "Der skete en fejl 400");
        root.insertBefore(errorModal, root.firstChild);
    }


}

function modalHandler() {
    const root = document.getElementById("modal");
    root.remove();
}


function createModal(title, text) {
    const modal = document.createElement("div");
    const modalContainer = document.createElement("div");
    const modalHeading = document.createElement("div");
    const heading = document.createElement("h2");
    const paragraph = document.createElement("p");
    const buttonContainer = document.createElement("div");
    const button = document.createElement("button");


    modal.className = "modal-main-container";
    modal.id = "modal";
    modalContainer.className = "modalContainer";
    modalHeading.className = "modalHeading";
    buttonContainer.className = "button-container";
    button.className = "btn btn-primary";




    heading.innerHTML = title;
    paragraph.innerHTML = text;
    button.innerHTML = "Okay";

    modal.addEventListener("click", () => modalHandler());
    button.addEventListener("click", () => modalHandler());


    modal.appendChild(modalContainer);
    modalContainer.appendChild(modalHeading);
    modalHeading.appendChild(heading);
    modalContainer.appendChild(paragraph);
    modalContainer.appendChild(buttonContainer);
    buttonContainer.appendChild(button);

    return modal;

}




