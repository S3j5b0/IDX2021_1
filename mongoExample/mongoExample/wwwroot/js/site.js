// Please see documentation at https://docs.microsoft.com/aspnet/core/client-side/bundling-and-minification
// for details on configuring this project to bundle and minify static web assets.

// Write your JavaScript code.

function showsucces(){
    if (document.contains(document.getElementById("searchNotification"))) {
        document.getElementById("searchNotification").remove();
    }
    const ptag = document.createElement("p");
    ptag.setAttribute('id', 'searchNotification')
    const node = document.createTextNode("User found, friend added");
    ptag.appendChild(node);
    document.getElementById("responseContainer").append(ptag);
}

function showFauilure(){
    if (document.contains(document.getElementById("searchNotification"))) {
        document.getElementById("searchNotification").remove();
    }
    const ptag = document.createElement("p");
    ptag.setAttribute('id', 'searchNotification')
    const node = document.createTextNode("No such user");
    ptag.appendChild(node);
    document.getElementById("responseContainer").append(ptag);
}
function alreadyTaken(){
    if (document.contains(document.getElementById("searchNotification"))) {
        document.getElementById("searchNotification").remove();
    }
    const ptag = document.createElement("p");
    ptag.setAttribute('id', 'searchNotification')
    const node = document.createTextNode("User already is already your friend");
    ptag.appendChild(node);
    document.getElementById("responseContainer").append(ptag);
}
function GetUserAPI() {
    var sParam=document.getElementById('fname').value.toString();
    let baseurl = "https://localhost:5001/API/GetUser?name=";
    baseurl += sParam
    $.ajax({ type: "POST", url: baseurl,
        data: "{s:sParam}",
        contentType: "application/json; charset=utf-8",
        success: function(retValue) {
            if (retValue == "true"){
                showsucces();
            } else if (retValue == "false") {
                showFauilure();
            } else if (retValue == "already"){
                alreadyTaken();
            }},
        failure: function (jqXHR, textStatus, errorThrown) {
            alert("failure"); }, });
} 