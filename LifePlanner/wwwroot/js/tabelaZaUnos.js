function addRow() {
    let table;
    let inHtml1, inHtml2;
    if (location.href.includes('Vjezba')) {
        table = document.getElementById("VjezbeTabela");
        inHtml1 = '<input type="text" name="Vjezbe[' + counter + ']" />';
        inHtml2 = '<input type="button" id="Vjezbe[' + counter + ']" onclick="obrisi(this)" value="Obrisi" /">';
    }
    else if (location.href.includes('Jelo')) {
        table = document.getElementById("SastojciTabela");
        inHtml1 = '<input type="text" name="Sastojci[' + counter + ']" />';
        inHtml2 = '<input type="button" id="Sastojci[' + counter + ']" onclick="obrisi(this)" value="Obrisi" /">';
    }
    var row = table.insertRow(-1);
    var cell1 = row.insertCell(0);
    var cell2 = row.insertCell(1);
    cell1.innerHTML = inHtml1;
    cell2.innerHTML = inHtml2;
    counter++;
}

function obrisi(el) {
let inputZaBrisanje;
    var allInputs = document.getElementsByTagName("input");
    for (var x = 0; x < allInputs.length; x++)
        if (allInputs[x].name == el.id) {
            inputZaBrisanje = allInputs[x];
            break;
        }
    inputZaBrisanje.value = "";
    inputZaBrisanje.style.visibility = "hidden";
    el.style.visibility = "hidden";
    return false;
}
