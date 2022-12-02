
// type: FeedDetailDto. Im going to send a Post request to the web API to CRUD Product feeds.

let title = "";
let description = "";
let format = "";
let limit = null;
const attributes = [createAttributeObject("ProductId")];
const categories = [];
const buildDate = new Date().toISOString();


const titleNode = document.getElementById("Feed_Title");
const descriptionNode = document.getElementById("Feed_Description");
const formatNode = document.getElementById("Feed_Format");
const limitNode = document.getElementById("Feed_Limit");
const propertyWrapperNode = document.getElementById("properties-wrapper");
const categoryWrapperNode = document.getElementById("categories-wrapper");
const submitButtonNode = document.getElementById("feed-submit-btn");


function uuidv4() {
    return ([1e7] + -1e3 + -4e3 + -8e3 + -1e11).replace(/[018]/g, c =>
        (c ^ crypto.getRandomValues(new Uint8Array(1))[0] & 15 >> c / 4).toString(16)
    );
}




//eventhandlers for nodes:

function titleEventHandler(evt) {
    try {
        title = evt.target.value;
    } catch (e) {
        alert(e);
    }
}

function descriptionEventHandler(evt) {

    try {
        description = evt.target.value;
    } catch (e) {
        alert(e);
    }
}


function formatEventHandler(evt) {

    try {
        format = formatNode.value;
    } catch (e) {
        alert(e);
    }

}

function limitEventHandler(evt) {
    try {
        if (evt.target.value !== "") {
            limit = parseInt(evt.target.value);
        } else {
            limit = null;
        }
    } catch (e) {
        alert(e);
    }
}





// adding eventlisteners:

titleNode.addEventListener("change", (evt) => titleEventHandler(evt));
descriptionNode.addEventListener("change", (evt) => descriptionEventHandler(evt));
formatNode.addEventListener("change", (evt) => formatEventHandler(evt));
limitNode.addEventListener("change", (evt) => limitEventHandler(evt));
propertyWrapperNode.addEventListener("click", () => extractCheckedProperties());
categoryWrapperNode.addEventListener("click", () => extractCheckedCategories());
submitButtonNode.addEventListener("click", async () => await finalizeFeed())


// functions for creating objects

function createAttributeObject(attribute) {

    return { FeedAttributeId: uuidv4(), Attribute: attribute }
}



function createCategoryObject(categoryId, categoryName) {

    return { FeedCategoryId: uuidv4(), CategoryId: categoryId, FeedCategoryName: categoryName }
}

function deleteObjectFromArray(array, key, attribute) {
    const index = array.findIndex((obj) => obj[key] === attribute);

    if (index > -1) {
        array.splice(index, 1);
    }
}



function extractCheckedProperties() {
    const childList = propertyWrapperNode.children;

    for (const node of childList) {

        const attributeName = node.lastElementChild.textContent;

        if (IsPropertyChecked(node.firstElementChild)) {
            if (!arrayContainsProperty(attributes, "Attribute",attributeName)) {
                attributes.push(createAttributeObject(attributeName));
            }
        } else {

            deleteObjectFromArray(attributes, "Attribute",attributeName);
        }
    }


}

function extractCheckedCategories() {
    const childList = categoryWrapperNode.children;

    for (const node of childList) {

        const categoryName = node.lastElementChild.textContent;
        const categoryId = node.firstElementChild.id;



        if (IsPropertyChecked(node.firstElementChild)) {
            if (!arrayContainsProperty(categories, "CategoryId", categoryId)) {
                categories.push(createCategoryObject(categoryId, categoryName));
            }
        } else {

            deleteObjectFromArray(categories, "CategoryId", categoryId);
        }
    }

    console.log(categories);

}

function arrayContainsProperty(array, key, property) {

    for (const item of array) {

        if (item[key] === property) {
            return true;
        }
    }

    return false;
}

function IsPropertyChecked(checkbox) {
    return checkbox.checked;
}


function feedObject() {

    return {
        FeedId: uuidv4(),
        Title: title,
        Description: description,
        Format: format,
        limit: limit,
        Attributes: attributes,
        Categories: categories,
        BuildDateTime: buildDate,
    }
}


function isEnteredDataValid() {

    if (title.trim().length < 4) {
        alert("Title skal være mindst 4 karakter")
        return false;
    }

    if (description.trim().length < 10) {
        alert("Beskrivelse skal være mindst 10 karakter")
        return false;
    }

    if (format.trim() === "") {
        alert("Format skal vælges.")
        return false;
    }

    if (limit !== null && !Number.isInteger(limit)) {
        return false;
    }

    if (attributes.length < 2) {
        alert("Der skal vælges mindst en attribut man vil have tilføjet!")
        return false;
    }

    if (categories.length < 0) {
        alert("Der skal vælges mindst en kategori man vil have tilføjet!")
        return false;
    }
   

    return true;
}


async function createFeed() {

    const feed = JSON.stringify(feedObject());
    console.log(feed);

    const response = await fetch("https://localhost:44357/api/Feed", {
        method: 'POST',
        cache: 'no-cache',
        mode: 'cors',
        headers: {
            'Accept': 'application/json',
            'Content-Type': 'application/json',
        },

        body: feed,
    });

    if (response.ok) {

        alert("Feed oprettet!");
       await history.back();
       await location.reload();
    } else if (response.status === 500) {

        alert("Fejl!, der skete en fejl. Prøv igen")

    } else if (response.status === 400) {

        alert("Fejl!", "Der skete en fejl 400");
    }

}


async function finalizeFeed() {

    if (!isEnteredDataValid()) {

        alert("Det indtastede data er ikke valid");
        return;
    }

    await createFeed();
}





