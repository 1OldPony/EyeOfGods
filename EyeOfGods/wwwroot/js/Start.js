document.addEventListener("DOMContentLoaded", function () {
    getUnitsStat();


})


function minusGenUnCount() {
    document.getElementById("count").stepDown();
}
function plusGenUnCount() {
    document.getElementById("count").stepUp();
}










function getUnitsStat() {
    fetch("/api/GensAndStat/GetUnitsStat")
        .then(response => response.json())
        .catch(er => console.log(`Не удалось получить статистику. ${er}`))
        .then(data => loadStatResult(data))
        .catch(er => console.log(`Не удалось загрузить результат. ${er}`));
};

function generateRndUnits() {
    let count = document.getElementById("count").value;
    let url = new URL('/api/GensAndStat/GenRndUnit', 'https://localhost:5001');
    url.searchParams.set('count', `${count}`);

    fetch(url, {
        method: "POST"
    })
        .then(() => getUnitsStat())
        .catch(er => console.log(`Не удалось сгенерировать юниты. ${er}`));
};

function deleteAllUnits() {

    fetch('/api/GensAndStat/ClearUnits', {
        method: 'DELETE'
    })
        .then(() => getUnitsStat())
        .catch(er => console.log(`Не удалось очистить базу. ${er}`));
};


function loadStatResult(data) {
    insertText('unitsCount', data.unitsCount);
    insertText('infantryCount', data.infantryCount);
    insertText('cavaleryCount', data.cavaleryCount);
    insertText('monsterCount', data.monsterCount);
    insertText('giantsCount', data.giantsCount);
    insertText('artilleryCount', data.artilleryCount);
    insertText('venicleCount', data.venicleCount);
    insertText('aviationCount', data.aviationCount);

    insertStatDataRows('defChars', data['defenceChars']);
    insertStatDataRows('endChars', data['enduranceChars']);
    insertStatDataRows('mentChars', data['mentalChars']);

    insertText('MWCount', data.meleeWeaponsCount);
    insertStatDataRows('MWTypes', data['meleeWeaponsTypes']);

    insertText('RWCount', data.rangeWeaponsCount);
    insertStatDataRows('RWTypes', data['rangeWeaponsTypes']);

    insertText('shieldsCount', data.shieldsCount);
};

function insertText(id, text) {
    let unitsCount = document.getElementById(id);
    unitsCount.textContent = text;
};

function insertStatDataRows(id, object) {
    let container = document.getElementById(id);
    let newRows = [];

    for (x in object) {
        let row = document.createElement('div');
        row.className = 'statisticsDataRow';
        row.textContent = `${object[x].name} - ${object[x].usageCount}`

        newRows.push(row);
    };

    container.replaceChildren("", ...newRows);
};


