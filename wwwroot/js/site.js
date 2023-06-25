// Please see documentation at https://docs.microsoft.com/aspnet/core/client-side/bundling-and-minification
// for details on configuring this project to bundle and minify static web assets.

// Write your JavaScript code.
const RESPONSE_STATUS = {
    OK: 200,
    METHOD_NOT_ALLOWD: 505,
    NOT_FOUND: 404,
    FORBIDDEN: 403,
    UNAUTHORIZED: 401,
    BAD_REQUEST: 400,
    INTERNAL_SERVER: 500
}
function post(requestURL, body, headers) {
    return new Promise(function (resolve, reject) {
        let XMLHttpRequest = window.XMLHttpRequest || ActiveXObject("Microsoft.XMLHTTP");
        let req = new XMLHttpRequest();
        req.open("POST", requestURL, true);
        req.setRequestHeader('Content-Type', 'application/json');

        //attached hearders
        if (headers) {
            for (let key in headers) {
                req.setRequestHeader(key, headers[key]);
            }
        }

        req.addEventListener("load", function () {
            if (req.status == RESPONSE_STATUS.OK) resolve(req.responseText);
            else if (req.status == RESPONSE_STATUS.NOT_FOUND) throw "NOT_FOUND";
        });
        req.addEventListener("error", function (event) {
            reject(event);
        });
        req.send(JSON.stringify(body));
    });
}
function serialize(data) {
    let obj = {};
    for (let [key, value] of data) {
        if (obj[key] !== undefined) {
            if (!Array.isArray(obj[key])) {
                obj[key] = [obj[key]];
            }
            obj[key].push(value);
        } else {
            if (value) obj[key] = value;
            else obj[key] = null;
        }
    }
    return obj;
}
function getData() {
    let formData = new FormData(document.querySelector('#filter'));
    let filter = serialize(formData);

    post('/todo/listfind', filter).then(data => {
        document.getElementById('list_find').innerHTML = data;
    });
}

document.addEventListener('DOMContentLoaded', () => {
    document.getElementById('filter_name').onkeyup = (e) => {
        getData();
    };
    const activeElement = document.getElementById('filter_active');
    const btnElements = document.querySelectorAll(".active-btn");
    btnElements.forEach(function (btnElement) {
        btnElement.addEventListener('click', function (e) {
            activeElement.value = e.target.dataset.active;
            btnElements.forEach(function (btn) {
                btn.classList.remove('btn-primary');
            });
            activeElement.classList.add('btn-primary');
            getData();
        });
    });
    
});
