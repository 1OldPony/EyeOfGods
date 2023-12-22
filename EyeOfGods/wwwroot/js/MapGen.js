document.addEventListener("DOMContentLoaded", function () {
    getMapSchemes();
    getTerrOptions();

})

class MapForm {
    mapName;
    questLevel;
    density;

    terrainOptionsId;
    schemeId;

    InterestPoints = [];
    Terrains = [];
}
class InterestPoint {
    pointNumber;
    pointHeight;
    pointWidth;
    xCoordinate;
    yCoordinate;
    pointType;
    description;
    pareWhithPoint;
}
class Terrain {
    //pointNumber;
    pointHeight;
    pointWidth;
    xCoordinate;
    yCoordinate;
    pointType;
    description;
    referenceTo;
    hasGodToken;
}


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
    let terrOptId = document.getElementById('terrOptions').value;
    let terrDensity = document.getElementById('terrDensity').value;
    let qLevel = document.getElementById('qLevel').value;

    let url = new URL('/api/MapGen/GenMap', 'https://localhost:5001');
    url.searchParams.set('schemeId', `${shemeId}`);
    url.searchParams.set('optionsId', `${terrOptId}`);
    url.searchParams.set('terrDensity', `${terrDensity}`);
    url.searchParams.set('qLevel', `${qLevel}`);

    fetch(url)
        .then(response => response.json())
        .catch(er => console.log(`Не удалось получить схему. ${er}`))
        .then(data => fillTheMap(data))
        .catch(er => console.log(`Не удалось заполнить карту. ${er}`));
}

function saveMap() {
    let mapF = new MapForm();
    mapF.mapName = document.getElementById('name').value;
    mapF.schemeId = document.getElementById('schemeId').value;
    mapF.terrainOptionsId = document.getElementById('terrainOptionsId').value;
    mapF.questLevel = document.getElementById('questLevel').value;
    mapF.density = document.getElementById('density').value;

    mapF.InterestPoints = formMapPoints('interestPoints');
    mapF.Terrains = formMapPoints('terrains');

    console.log(mapF);



    fetch(`/api/MapGen/SaveMap`, {
        method: 'POST',
        headers: {
            'Content-Type': 'application/json;charset=utf-8'
        },
        body: JSON.stringify(mapF)
    })
        .catch(er => console.log(`Не удалось сохранить карту. ${er}`));
}

function formMapPoints(pointsGroup) {
    let formedPoints = [];

    let points = document.getElementById(pointsGroup).getElementsByTagName('div');

    for (let i = 0; i < points.length; i++) {
        let terr = new Terrain();
        let intP = new InterestPoint();

        let inputs = points[i].getElementsByTagName('input');
        for (let s = 0; s < inputs.length; s++) {
            switch (inputs[s].id) {
                case "pointNumber":
                    if (pointsGroup == "interestPoints") {
                        intP.pointNumber = inputs[s].value;
                    }
                    else {
                        terr.pointNumber = inputs[s].value;
                    }
                    break;
                case "pointHeight":
                    if (pointsGroup == "interestPoints") {
                        intP.pointHeight = inputs[s].value;
                    }
                    else {
                        terr.pointHeight = inputs[s].value;
                    }
                    break;
                case "pointWidth":
                    if (pointsGroup == "interestPoints") {
                        intP.pointWidth = inputs[s].value;
                    }
                    else {
                        terr.pointWidth = inputs[s].value;
                    }
                    break;
                case "xCoordinate":
                    if (pointsGroup == "interestPoints") {
                        intP.xCoordinate = inputs[s].value;
                    }
                    else {
                        terr.xCoordinate = inputs[s].value;
                    }
                    break;
                case "yCoordinate":
                    if (pointsGroup == "interestPoints") {
                        intP.yCoordinate = inputs[s].value;
                    }
                    else {
                        terr.yCoordinate = inputs[s].value;
                    }
                    break;
                case "pareWhithPoint":
                    intP.pareWhithPoint = inputs[s].value;
                    break;
                case "referenceTo":
                    terr.referenceTo = inputs[s].value;
                    break;
                case "hasGodToken":
                    terr.hasGodToken = inputs[s].value;
                    break;
                case "description":
                    if (pointsGroup == "interestPoints") {
                        intP.description = inputs[s].value;
                    }
                    else {
                        terr.description = inputs[s].value;
                    }
                    break;
                case "type":
                    if (pointsGroup == "interestPoints") {
                        intP.pointType = inputs[s].value;
                    }
                    else {
                        terr.pointType = inputs[s].value;
                    }
                    break;
                default:
                    break;
            }
        }

        if (pointsGroup == "interestPoints") {
            formedPoints.push(intP);
        }
        else {
            formedPoints.push(terr);
        }
    }

    return formedPoints;
}

function fillTheMap(data) {
    setMapSize(data);

    addMapObjects(data['interestPoints'], 'interestPoints');

    addMapObjects(data['terrains'], 'terrains');

    crFormForMap(data);
}

function crFormForMap(data) {
    let form = document.createElement('div');
    form.setAttribute('id', 'mapForm');
    //form.setAttribute('hidden', true);

    let nameField = crFieldToForm('text', 'name', document.getElementById('mapName').value);
    form.appendChild(nameField);

    let qLevel = crFieldToForm('number', 'questLevel', data.questLevel);
    form.appendChild(qLevel);

    let density = crFieldToForm('number', 'density', data.density);
    form.appendChild(density);

    let terrOptId = crFieldToForm('number', 'terrainOptionsId', document.getElementById('terrOptions').value);
    form.appendChild(terrOptId);

    let schemeId = crFieldToForm('number', 'schemeId', document.getElementById('terrOptions').value);
    form.appendChild(schemeId);

    let intPoints = crPointsToForm(data['interestPoints'], 'interestPoint');
    intPoints.setAttribute('id', 'interestPoints')
    form.appendChild(intPoints);

    let terrPoints = crPointsToForm(data['terrains'], 'terrain');
    terrPoints.setAttribute('id', 'terrains')
    form.appendChild(terrPoints);


    document.getElementById('mapForm').replaceWith(form);
}

function crPointsToForm(points, id) {
    let pointsDiv = document.createElement('div');

    for (var i = 0; i < points.length; i++) {
        let point = document.createElement('div');
        point.setAttribute('id', id+`${i}`);

        let pNumber = crFieldToForm('number', 'pointNumber', points[i].pointNumber);
        point.appendChild(pNumber);

        let pHeight = crFieldToForm('number', 'pointHeight', points[i].pointHeight);
        point.appendChild(pHeight);

        let pWidth = crFieldToForm('number', 'pointWidth', points[i].pointWidth);
        point.appendChild(pWidth);

        let xCoord = crFieldToForm('number', 'xCoordinate', points[i].xCoordinate);
        point.appendChild(xCoord);

        let yCoord = crFieldToForm('number', 'yCoordinate', points[i].yCoordinate);
        point.appendChild(yCoord);

        if (points[i].pareWhithPoint != undefined) {
            let pareWhith = crFieldToForm('number', 'pareWhithPoint', points[i].pareWhithPoint);
            point.appendChild(pareWhith);
        }

        if (points[i].referenceTo != undefined) {
            let referenceTo = crFieldToForm('number', 'referenceTo', points[i].referenceTo);
            point.appendChild(referenceTo);
        }

        let pType = crFieldToForm('number', 'type', points[i].type);
        point.appendChild(pType);

        let pDesc = crFieldToForm('text', 'description', points[i].description);
        point.appendChild(pDesc);

        if (points[i].hasGodToken != undefined) {
            let pGodToken = crFieldToForm('text', 'hasGodToken', points[i].hasGodToken);
            point.appendChild(pGodToken);
        }

        pointsDiv.appendChild(point);
    }

    return pointsDiv;
}

function crFieldToForm(type, id, value) {
    let input = document.createElement('input');
    input.setAttribute('type', type);
    input.setAttribute('id', id);
    input.setAttribute('name', id);
    if (type == 'checkbox') {
        input.checked = value;
    }
    else {
        input.value = value;
    }

    return input;
}
function mapNameChange() {
    if (document.getElementById('name') != null) {
        document.getElementById('name').value = document.getElementById('mapName').value;
    }
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

    let map = document.createElement('div');
    map.id = 'map';
    map.className = 'map';

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

        let newPoint = document.createElement('div');
        newPoint.style.gridColumnStart = data[i].xCoordinate;
        newPoint.style.gridColumnEnd = `span ${data[i].pointWidth}`;
        newPoint.style.gridRowStart = data[i].yCoordinate;
        newPoint.style.gridRowEnd = `span ${data[i].pointHeight}`;

        ///////////////////////////
        newPoint.style.display = `flex`;
        newPoint.style.justifyContent = `center`;
        newPoint.style.alignItems = `center`;

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

            ///////////////////////////
            let pointNumb = document.createElement('div');
            pointNumb.innerText = `${ data[i].pointNumber }`;
            pointNumb.style.fontSize = `80px`;
            pointNumb.style.fontWeight = `800`;
            newPoint.appendChild(pointNumb);
        }
        else {
            switch (data[i].type) {
                case 0:
                    represent = "green"
                    newPoint.setAttribute("Type", "Лес");
                    break;
                case 1:
                    represent = "#142f14"
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
            newPoint.style.opacity = `0.7`;

            ///////////////////////////
            let pointNumb = document.createElement('div');
            if (data[i].hasGodToken) {
                pointNumb.innerText = `${data[i].referenceTo}*`;
            }
            else {
                pointNumb.innerText = `${data[i].referenceTo}`;
            }
            pointNumb.style.fontSize = `60px`;
            newPoint.appendChild(pointNumb);

            //console.log(`К точке ${data[i].referenceTo}, Х = ${data[i].xCoordinate}, Y = ${data[i].yCoordinate}`);
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
    select.id = 'terrOptions';
    select.setAttribute('onchange', 'terrOptSelect()');

    for (let i = 0; i < data.length; i++) {
        select = addSelectOption(select, data[i].id, data[i].optionsSetName);
    }
    document.getElementById('terrOptions').replaceWith(select);

    try {
        updateTerrOptions(data[0]);
    } catch (e) {
        console.log(`Апдейт опций террейна не сработал ${e}`);
    }
}

function updateTerrOptions(data) {
    setInputValue('forestDensity', data.forestDensity);
    setInputValue('swampDensity', data.swampDensity);
    setInputValue('waterDensity', data.waterDensity);

    if (document.getElementById('TerrainOptionsId') != null) {
        document.getElementById('TerrainOptionsId').value = document.getElementById('terrOptions').value;
    }
}

function terrOptSelect() {
    let terrId = document.getElementById('terrOptions').value;
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


