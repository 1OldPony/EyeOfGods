document.addEventListener("DOMContentLoaded", function () {
    GetUnitsStat();
})

function GetUnitsStat() {
    fetch("/api/GensAndStat/GetUnitsStat")
        .then(response => response.json())
        .catch(error => alert('Не удалось получить статистику. ', console.log(error)))
        .then(data => LoadStatResult(data))
        .catch(error => alert('Не удалось загрузить результат. ', console.log(error)));
};

function LoadStatResult(data) {
    document.getElementById('unitsCount').innerText = data.unitsCount;
    //InsertText('unitsCount' ,data.unitsCount);
    document.getElementById('infantryCount').innerText = data.infantryCount;
    //InsertText('infantryCount', data.infantryCount);
    document.getElementById('cavaleryCount').innerText = data.cavaleryCount;
    //InsertText('cavaleryCount', data.cavaleryCount);
    document.getElementById('monsterCount').innerText = data.monsterCount;
    //InsertText('monsterCount', data.monsterCount);
    document.getElementById('giantsCount').innerText = data.giantsCount;
    //InsertText('giantsCount', data.giantsCount);
    document.getElementById('artilleryCount').innerText = data.artilleryCount;
    //InsertText('artilleryCount', data.artilleryCount);
    document.getElementById('venicleCount').innerText = data.venicleCount;
    //InsertText('venicleCount', data.venicleCount);
    document.getElementById('aviationCount').innerText = data.aviationCount;
    //InsertText('aviationCount', data.aviationCount);


    document.getElementById("defChars")
};

function InsertText(id, text) {
    let unitsCount = getElementById(id);
    unitsCount.innerHTML = text;
}

function InsertStatDataRows(id, object) {
    for (x in object) {

        console.log(object[x])
    }
}



async function GenerateRndUnits() {
    let count = document.getElementById("count").value;

    await fetch(`/api/GensAndStat/GenUnit?count=${count}`, {
        method: "POST",
        headers: {
            "Accept": "application/json",
            'Content-Type': 'application/json'
        },
        //body: JSON.stringify(здесь должна быть форма)
    });
    ////// если запрос прошел нормально
    // if (response.ok === true) {
    //     // получаем данные
    //     alert("Урааа!!!");
    //     // добавляем полученные элементы в таблицу
    //     // users.forEach(user => rows.append(row(user)));
    // }
    // else {
    //     alert("Фуууу!!!");
    // }
}

function deleteItem(id) {
    fetch(`${uri}/${id}`, {
        method: 'DELETE'
    })
        .then(() => getItems())
        .catch(error => console.error('Unable to delete item.', error));
}