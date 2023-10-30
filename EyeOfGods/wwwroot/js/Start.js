document.addEventListener("DOMContentLoaded", function () {
    //GetUnitsStat();
})

function GetUnitsStat() {
    fetch("/api/GensAndStat/GetUnitsStat")
        .then(response => response.json())
        .catch(error => alert('Не удалось получить статистику. ', error))
        //.then(data => LoadStatResult(data))
        //.catch(error => alert('Не удалось загрузить результат. ', error));
};

function LoadStatResult(data) {
    InsertText('unitsCount' ,data.unitsCount);
    InsertText('infantryCount', data.infantryCount);
    InsertText('cavaleryCount', data.cavaleryCount);
    InsertText('monsterCount', data.monsterCount);
    InsertText('giantsCount', data.giantsCount);
    InsertText('artilleryCount', data.artilleryCount);
    InsertText('venicleCount', data.venicleCount);
    InsertText('aviationCount', data.aviationCount);
};

function InsertText(id, text) {
    let unitsCount = getElementById(id);
    unitsCount.innerHTML = text;
}



async function GenerateUnits() {
    let count = document.getElementById("count").value;

    const response = await fetch(`/api/GensAndStat/GenUnit?count=${count}`, {
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