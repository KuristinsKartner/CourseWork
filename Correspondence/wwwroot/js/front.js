$(function () {
    var date = new Date();
    minvalue = document.getElementById('minyear').value;
    maxvalue = document.getElementById('maxyear').value;
    $("#slider-range").slider({
        range: true,
        min: 1900,
        max: date.getFullYear(),
        values: [minvalue, maxvalue],
        slide: function (event, ui) {
            $("#amount").val(ui.values[0] + " - " + ui.values[1] + " гг.");
        },
        stop: function (event, ui) {
            gopost();
        }
    });
    $("#amount").val($("#slider-range").slider("values", 0) +
        " - " + $("#slider-range").slider("values", 1) + "гг.");
})

let r = /\d+/;

//function ShowDropArea(name, property) {
//    document.getElementById(name).style.display = property;
//    switch (name) {
//        case 'drop-area1': {
//            document.getElementById('lblscan').style.display = property;
//            break;
//        }
//        case 'drop-area2': {
//            document.getElementById('lblformat').style.display = property;
//            break;
//        }
//        case 'drop-area3': {
//            document.getElementById('lblsverst').style.display = property;
//            break;
//        }
//        default:
//            alert("Error");
//            break;
//    }
//}

function unsetfileadded(el) {
    document.getElementsByClassName('input__wrapper').forEach(el => {
        if (el.classList.contains('fileadded'))
            el.classList.remove('fileadded')
    });
}
function defaultmodal() {
    document.getElementById('in__text_scan').textContent = defaultdroptext;
    document.getElementById('in__text_format').textContent = defaultdroptext;
    document.getElementById('in__text_sverst').textContent = defaultdroptext;

    document.getElementsByClassName('form-inner form-modal').forEach(el => el.style.pointerEvents = "all");
    document.getElementsByClassName('pic1').forEach(el => el.style.display = "inline-block");
    document.getElementsByClassName('input__file-button-wrapper input__file-icon-wrapper-delete').forEach(el => el.style.display = "inline-block");
}

// Объявить переменную модального окна в текущей области видимости
//var modal = document.getElementById('myModal');
var modal1 = document.getElementById('myModal1');
var modal2 = document.getElementById('myModal2');
var modal3 = document.getElementById('myModal3');
// Получение элемента <span>, который закрывает модальное окно

//var span1 = document.getElementsByClassName('close1')[0];
var span2 = document.getElementsByClassName('close2')[0];
var span3 = document.getElementsByClassName('close3')[0];
var span4 = document.getElementsByClassName('close4')[0];

// Когда пользователь нажимает кнопку, открывается pop-up форма 
document.getElementById('otchetaboutbook').onclick = function () {
     document.body.style.overflow = 'hidden';
    
    modal1.style.display = "block";
   
}
document.getElementById('otchetaboutauthors').onclick =  function () {
    
    document.body.style.overflow = 'hidden';

    modal2.style.display = "block";
}
document.getElementById('multiEditNotes').onclick = function () {
    document.body.style.overflow = 'hidden';
   
    modal3.style.display = "block";
}
// Когда пользователь нажимает кнопку (x) <span>, закрывается окно формы
//span1.onclick = function () {
    
//    modal.style.display = "none";
//    document.body.style.overflow = "";
//}
span2.onclick = function () {

    modal1.style.display = "none";
    document.body.style.overflow = "";
}
span3.onclick = function () {

    modal2.style.display = "none";
    document.body.style.overflow = "";
}
span4.onclick = function () {

    modal3.style.display = "none";
    document.body.style.overflow = "";
}
// Когда пользователь нажимает в любое место вне формы, закрыть окно формы
window.onclick = function (event) {
    
    if (event.target == modal1 || event.target == modal2 || event.target == modal3) {
        //if (modal.style.display == "block") {
        //    modal1.style.display = "none";
            
        //};
        if (modal1.style.display == "block") {
            modal1.style.display = "none";
      
        };
        if (modal2.style.display == "block") {
            modal2.style.display = "none";

        };
        if (modal3.style.display == "block") {
            modal3.style.display = "none";

        };
        document.body.style.overflow = "";
    }

    
}

// there are checkboxes

var varcheck = document.querySelectorAll('input.input_checkbox');
var count_checkboxes;
function FireUp(element) {

    if (!element.checked) {
        getParent(getParent(element)).classList.remove("mark");
    }
    else
        getParent(getParent(element)).classList.add("mark");
    count_checkboxes = 0;
    varcheck.forEach((one_check) => {
        if (one_check.checked == true)
            count_checkboxes++;
    });
    if (count_checkboxes > 0) {
        document.getElementById('cansel_check').removeAttribute('disabled');
        if (count_checkboxes == 1)
            close_group_edit()
        else
            open_group_edit();  
    }
    else {
        document.getElementById('cansel_check').setAttribute('disabled', true);
        disabled_edit();
    }
            
}

function check() {
    document.getElementById('choose_check').setAttribute('disabled', true);
    document.getElementById('cansel_check').removeAttribute('disabled');
   open_group_edit()
    varcheck.forEach((one_check)=>{
        one_check.checked = true;
        FireUp(one_check);
    })

}

function uncheck() {
    document.getElementById('choose_check').removeAttribute('disabled');
    document.getElementById('cansel_check').setAttribute('disabled', true);
    disabled_edit();
    varcheck.forEach((one_uncheck)=> {
        one_uncheck.checked = false;
        FireUp(one_uncheck);
    })
}

function gopost() {

    form = document.getElementById('filter');
    let url = '/Front/SetFilter';
    let formData = new FormData(form);

    fetch(url, {
        method: 'POST',
        body: formData,
    }).then(function (response) {
        if (!response.ok) {
            // Сервер вернул код ответа за границами диапазона [200, 299]
            return Promise.reject(new Error(
                'Response failed: ' + response.status + ' (' + response.statusText + ')'
            ))
        }
        return response.text();
    }).then(function (data) {
        window.location.reload();
        return data;
    }).then(        
        function (error) {
        return error;}
    );
}
function sorting() {
    var field = document.getElementById('field').value;
    var expression = document.getElementById('expression').value;
    let params = new URLSearchParams();
    params.set('expression', expression);
    params.set('field', field);
    let url = '/Front/Sorting';
    fetch(url, {
        method: 'POST',
        body: params,
    }).then(function (response) {
        if (!response.ok) {
            // Сервер вернул код ответа за границами диапазона [200, 299]
            return Promise.reject(new Error(
                'Response failed: ' + response.status + ' (' + response.statusText + ')'
            ))
        }
        return response.text();
    }).then(function (data) {
        window.location.reload();
        return data;
    }).then(
        function (error) {
            return error;
        }
    );
}
var defaultdroptext = "Загрузка файла";
async function download(element) {
    if (getParent(element).getElementsByClassName("input__file-button-text")[0].textContent != defaultdroptext) {
        let params = new URLSearchParams();
        let r = /\d+/;
        let idrec = document.getElementById('h3checknote').textContent;
        params.set('id', idrec.match(r));
        params.set('name', element.name);
        window.location.href = "Front/DownloadFile?id=" + idrec.match(r) + "&name=" + element.name;
    } 
}

////////////////
var table = document.getElementById("globaltable");
var totalRowCount = table.rows.length;
document.getElementById('countBooks').innerHTML = totalRowCount - 1;
//////////////



var rows = window.document.querySelectorAll("#globaltable tr");
var unique = "", countuniq = 0;
var listauthor = "", uniquegenre="", countgenre=0, listgenre="";
for (var i = 1; i < rows.length; i++) { // перебираем все строки
    var cols = rows[i].querySelectorAll('td'); // получаем столбцы

    if (cols[3].textContent != uniquegenre) {
        uniquegenre = cols[3].textContent;
        countgenre++;
        listgenre += "<br/>" + countgenre + ") <" + cols[3].textContent + ">";
        
    }
    if (cols[3].textContent != "" || cols[1].textContent != "") {
        listgenre += "<br/>" + "-" + cols[1].textContent;
    }
    

    if (cols[2].textContent != unique) { ///////// изменить на 2
        countuniq++;
        unique = cols[2].textContent;
        listauthor += "<br/>'" + cols[2].textContent+"'";
    }
}
document.getElementById('countAuthors').innerHTML = countuniq;
document.getElementById('listAuthors').innerHTML = listauthor;

document.getElementById('mytitle').innerHTML = countgenre;
document.getElementById('counttitle').innerHTML = listgenre;




//////////////////////

// выводим текст из столбца
   // for (var j = 0; j < cols.length; j++) { // перебираем все столбцы
        
    //}

//var Row = document.getElementById("somerow");
//var Cells = Row.getElementsByTagName("td");
//alert(Cells[0].innerText);