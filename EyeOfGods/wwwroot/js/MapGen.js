document.addEventListener("DOMContentLoaded", function () {
    getMapSchemes();
    getTerrOptions();

})



function getMapSchemes() {
    fetch("/api/MapGen/GetMapSchemes")
        .then(response => response.json())
        .catch(er => console.log(`Не удалось получить список схем. ${er}`))
        .then(data => loadMapSchemes(data))
        .catch(er => console.log(`Не удалось загрузить список схем. ${er}`));
};

function loadMapSchemes(data) {
    //let height = document.getElementById("fieldHeight").value;
    //let width = document.getElementById("fieldWidth").value;

    let size = (document.getElementById("mapSize").value).split('x');

    let selScheme;
    let allowed = false;

    let select = document.createElement('select');
    select.id = 'mapScheme';
    select.setAttribute('onchange', 'schemeSelect()');


    let optGroupAllow = document.createElement('optgroup');
    optGroupAllow.label = 'Схемы, подходящие по размерам';
    let optGroupDisall = document.createElement('optgroup');
    optGroupDisall.label = 'Схемы, не подходящие по размерам';

    for (let i = 0; i < data.length; i++) {
        for (let c = 0; c < data[i].length; c++) {
            if (data[i][c].mapHeight == size[1] && data[i][c].mapWidth == size[0]) {
                optGroupAllow = addSelectOption(optGroupAllow, data[i][c].id, data[i][c].name);
                allowed = true;

                if (selScheme == undefined) {
                    selScheme = data[i][c];
                }
                break;
            }
        }

        if (allowed == false) {
            optGroupDisall = addSelectOption(optGroupDisall, data[i][0].id, data[i][0].name, true);
        }
        allowed = false;
    }

    select.appendChild(optGroupAllow);
    select.appendChild(optGroupDisall);

    document.getElementById('mapScheme').replaceWith(select);

    updateSchemeOptions(selScheme);
};

function updateSchemeOptions(data) {
    setInputValue('numbOfCities', data.numbOfCities);
    setInputValue('numbOfResources', data.numbOfResources);
    setInputValue('numbOfTreasuries', data.numbOfTreasuries);
    setInputValue('godPresense', data.godPresense);
}
function schemeSelect() {
    let schemeId = document.getElementById('mapScheme').value;
    getScheme(schemeId)
}

function getScheme(id) {
    fetch(`/api/MapGen/GetMapScheme/${id}`)
        .then(response => response.json())
        .catch(er => console.log(`Не удалось получить схему. ${er}`))
        .then(data => updateSchemeOptions(data))
        .catch(er => console.log(`Не удалось загрузить схему. ${er}`));
}

/////////////////////////////////

function generateMap() {
    let shemeId = document.getElementById('mapScheme').value;
    let terrOptId = document.getElementById('terrainOptions').value;

    let url = new URL('/api/MapGen/GenMap', 'https://localhost:5001');
    url.searchParams.set('schemeId', `${shemeId}`);
    url.searchParams.set('optionsId', `${terrOptId}`);

    fetch(url)
        .then(response => response.json())
        .catch(er => console.log(`Не удалось получить схему. ${er}`))
        .then(data => fillTheMap(data))
        /*.then(data => setMapSize(data.scheme))*/
        .catch(er => console.log(`Не удалось установить размер карты. ${er}`));
        //.then(data => fillTheMap(data))
        //.catch(er => console.log(`Не удалось добавить на карту объекты. ${er}`));
}


function fillTheMap(data) {
    setMapSize(data);

    console.log(data);
    addMapObjects(data['interestPoints'], 'interestPoints');

    //console.log(data['terrains']);
    addMapObjects(data['terrains'], 'terrains');
}
function setMapSize(data) {
    let cellSize;
    let blockWidth = document.getElementById('content').offsetWidth;

    if (blockWidth >= document.documentElement.clientHeight) {
        cellSize = (document.documentElement.clientHeight / data.scheme.mapWidth).toFixed();
    }
    else {
        cellSize = ((blockWidth * Number(0.9)).toFixed() / data.scheme.mapWidth).toFixed();
    }
    //console.log("document.documentElement.clientHeight = " + document.documentElement.clientHeight);
    //console.log("data.scheme.mapWidth = " + data.scheme.mapWidth);
    //console.log("data.scheme.((blockWidth * Number(0.9)).toFixed() = " + (blockWidth * Number(0.9)).toFixed());
    //console.log("cellSize = " + cellSize);

    let map = document.createElement('div');
    map.id = 'map';
    map.className = 'map';
    //map.style.display = 'grid';
    console.log(`repeat(${data.scheme.mapWidth}, ${cellSize}px)`);

    map.style.gridTemplateColumns = `repeat(${data.scheme.mapWidth}, ${cellSize}px)`;
    map.style.gridTemplateRows = `repeat(${data.scheme.mapHeight}, ${cellSize}px)`;
    document.getElementById('map').replaceWith(map);
    showMap();
}

function showMap() {
    var mapBlock = document.getElementById('mapBlock');
    mapBlock.style.display = 'flex'
    mapBlock.style.height = 'auto'
}

function addMapObjects(data, objType) {
    let represent;

    for (var i = 0; i < data.length; i++) {
        //console.log("data[i] = " + data[i]);

        let newPoint = document.createElement('div');
        newPoint.style.gridColumnStart = data[i].xCoordinate;
        newPoint.style.gridColumnEnd = `span ${data[i].pointWidth}`;
        newPoint.style.gridRowStart = data[i].yCoordinate;
        newPoint.style.gridRowEnd = `span ${data[i].pointHeight}`;
        if (objType == 'interestPoints') {
            switch (data[i].type) {
                case 0:
                    represent = "red"
                    newPoint.setAttribute("Type", "Город");
                    break;
                case 1:
                    represent = "darkgoldenrod"
                    newPoint.setAttribute("Type", "Ресурсы");
                    break;
                case 2:
                    represent = "gold"
                    newPoint.setAttribute("Type", "Сокровища");
                    break;
                default:
                    represent = "gray"
                    newPoint.setAttribute("Type", "Ошибка");
                    break;
            }
            newPoint.setAttribute("PointNumber", `${data[i].pointNumber}`);
        }
        else {
            switch (data[i].type) {
                case 0:
                    represent = "green"
                    newPoint.setAttribute("Type", "Лес");
                    break;
                case 1:
                    represent = "darkgreen"
                    newPoint.setAttribute("Type", "Болото");
                    break;
                case 2:
                    represent = "blue"
                    newPoint.setAttribute("Type", "Вода");
                    break;
                default:
                    represent = "gray"
                    break;
            }
            newPoint.setAttribute("RefereceTo", `${data[i].referenceTo}`);
        }

        newPoint.style.backgroundColor = `${represent}`;

        document.getElementById('map').appendChild(newPoint);
    }
}

////////////////////////////////////////////////

function getTerrOptions() {
    fetch("/api/MapGen/GetTerrOptions")
        .then(response => response.json())
        .catch(er => console.log(`Не удалось получить список опций. ${er}`))
        .then(data => loadTerrOptions(data))
        .catch(er => console.log(`Не удалось загрузить список опций. ${er}`));
}

function loadTerrOptions(data) {
    let select = document.createElement('select');
    select.id = 'terrainOptions';
    select.setAttribute('onchange', 'terrOptSelect()');

    for (let i = 0; i < data.length; i++) {
        select = addSelectOption(select, data[i].id, data[i].optionsSetName);
    }
    document.getElementById('terrainOptions').replaceWith(select);

    updateTerrOptions(data[0]);
}

function updateTerrOptions(data) {
    setInputValue('forestDensity', data.forestDensity);
    setInputValue('swampDensity', data.swampDensity);
    setInputValue('waterDensity', data.waterDensity);
}

function terrOptSelect() {
    let terrId = document.getElementById('terrainOptions').value;
    getTerrOption(terrId)
}

function getTerrOption(id) {
    fetch(`/api/MapGen/GetTerrOption/${id}`)
        .then(response => response.json())
        .catch(er => console.log(`Не удалось получить список опций. ${er}`))
        .then(data => updateTerrOptions(data))
        .catch(er => console.log(`Не удалось загрузить список опций. ${er}`));
}

////////////////////////////////////////////////

function setInputValue(elemId, value) {
    document.getElementById(elemId).value = value;
}
function addSelectOption(parent, value, text, boolDisabled = false) {
    let option = document.createElement('option');
    option.value = value;
    option.text = text;
    if (boolDisabled) {
        option.disabled = true;
    }

    parent.appendChild(option);

    return parent;
}





//function insertText(id, text) {
//    let unitsCount = document.getElementById(id);
//    unitsCount.textContent = text;
//};

//function insertStatDataRows(id, object) {
//    let container = document.getElementById(id);
//    let newRows = [];

//    for (x in object) {
//        let row = document.createElement('div');
//        row.className = 'simpleRowData';
//        row.textContent = `${object[x].name} - ${object[x].usageCount}`

//        newRows.push(row);
//    };

//    container.replaceChildren("", ...newRows);
//};


//function generateRndUnits() {
//    let count = document.getElementById("count").value;
//    let url = new URL('/api/UnitsGen/GenRndUnit', 'https://localhost:5001');
//    url.searchParams.set('count', `${count}`);

//    fetch(url, {
//        method: "POST"
//    })
//        .then(() => getUnitsStat())
//        .catch(er => console.log(`Не удалось сгенерировать юниты. ${er}`));
//};

//function deleteAllUnits() {

//    fetch('/api/UnitsGen/ClearUnits', {
//        method: 'DELETE'
//    })
//        .then(() => getUnitsStat())
//        .catch(er => console.log(`Не удалось очистить базу. ${er}`));
//};


//function loadStatResult(data) {
//    insertText('unitsCount', data.unitsCount);
//    insertText('infantryCount', data.infantryCount);
//    insertText('cavaleryCount', data.cavaleryCount);
//    insertText('monsterCount', data.monsterCount);
//    insertText('giantsCount', data.giantsCount);
//    insertText('artilleryCount', data.artilleryCount);
//    insertText('venicleCount', data.venicleCount);
//    insertText('aviationCount', data.aviationCount);

//    insertStatDataRows('defChars', data['defenceChars']);
//    insertStatDataRows('endChars', data['enduranceChars']);
//    insertStatDataRows('mentChars', data['mentalChars']);

//    insertText('MWCount', data.meleeWeaponsCount);
//    insertStatDataRows('MWTypes', data['meleeWeaponsTypes']);

//    insertText('RWCount', data.rangeWeaponsCount);
//    insertStatDataRows('RWTypes', data['rangeWeaponsTypes']);

//    insertText('shieldsCount', data.shieldsCount);
//};

//function insertText(id, text) {
//    let unitsCount = document.getElementById(id);
//    unitsCount.textContent = text;
//};

//function insertStatDataRows(id, object) {
//    let container = document.getElementById(id);
//    let newRows = [];

//    for (x in object) {
//        let row = document.createElement('div');
//        row.className = 'simpleRowData';
//        row.textContent = `${object[x].name} - ${object[x].usageCount}`

//        newRows.push(row);
//    };

//    container.replaceChildren("", ...newRows);
//};


