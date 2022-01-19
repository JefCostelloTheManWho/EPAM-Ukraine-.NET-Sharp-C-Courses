function buildTable() {
    let rows = document.getElementById('rows').value;
    let columns = document.getElementById('columns').value; 

    if(rows <= 0 || columns <= 0) {
        alert(`Wrong input numbers use only 0-9 digits`);
    } else {
        let oldTable = document.getElementById('newTable');
        let table = document.createElement("table");
        table.id = "newTable";
        if(oldTable != null) {
            oldTable.remove();
        }
        let tblBody = document.createElement("tbody");

    for(let i=1;i<=rows;i++) {
        let row = document.createElement("tr");
        for(let j=1;j<=columns;j++) {
            let cell = document.createElement("td");
            row.appendChild(cell);
            }
            tblBody.appendChild(row);
        }
        table.appendChild(tblBody);
        document.getElementById('root').append(table);
        }
}


