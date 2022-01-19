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
                let cellText = document.createTextNode(`${i}${j}`);
                cell.appendChild(cellText);
                cell.id = getRandomColor();
                cell.style.background = cell.id;
                cell.className = getRandomColor();
                row.appendChild(cell);
                // Delegating table events
                cell.onclick = function(event) {
                let target = event.target;
                if (target.tagName != 'TD') return;
                
                if(target.style.background != cell.id) {
                    target.style.background = cell.id;
                } else {
                    target.style.background = cell.className;
                }
                };
            }
            tblBody.appendChild(row);
        }
        table.appendChild(tblBody);
        document.getElementById('root').append(table);
    }
}   
function getRandomColor() {
    var o = Math.round, r = Math.random, s = 255;
    return 'rgba(' + o(Math.floor(r())*s) + ', ' + o(r()*s) + ', ' + o(r()*s) + ', ' + parseFloat(r().toFixed(2)) + ')';
}
