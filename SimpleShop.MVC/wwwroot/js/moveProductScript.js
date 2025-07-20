function moveSelected(fromTableId, toTableId, toModelPrefix, fromModelPrefix) {
    const fromTable = document.getElementById(fromTableId);
    const toTable = document.getElementById(toTableId);
    const selected = fromTable.querySelectorAll("input.form-check-input:checked");

    selected.forEach(input => {
        const row = input.closest("tr");
        toTable.querySelector("tbody").appendChild(row);
    });

    updateIndexes(toTableId, toModelPrefix);
    updateIndexes(fromTableId, fromModelPrefix);
}

function updateIndexes(tableId, modelPrefix) {
    const table = document.getElementById(tableId);
    const rows = table.querySelectorAll("tbody tr");

    rows.forEach((row, index) => {
        const inputs = row.querySelectorAll("input");

        inputs.forEach(input => {
            const name = input.getAttribute("name");
            const id = input.getAttribute("id");

            if (name) {
                const newName = name
                    .replace(/^(AvailableShopProducts|AssignedShopProducts)/, modelPrefix)
                    .replace(/\[\d+\]/, `[${index}]`);
                input.setAttribute("name", newName);
            }

            if (id) {
                const newId = id
                    .replace(/^(AvailableShopProducts|AssignedShopProducts)/, modelPrefix)
                    .replace(/_\d+_/, `_${index}_`);
                input.setAttribute("id", newId);
            }
        });
    });
}


document.getElementById("moveToAssign").addEventListener("click", function () {
    moveSelected("availableProducts", "assignedProducts", "AssignedShopProducts", "AvailableShopProducts");
});

document.getElementById("deleteFromAssign").addEventListener("click", function () {
    moveSelected("assignedProducts", "availableProducts", "AvailableShopProducts", "AssignedShopProducts");
});