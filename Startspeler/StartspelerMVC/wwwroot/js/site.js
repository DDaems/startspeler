// Please see documentation at https://docs.microsoft.com/aspnet/core/client-side/bundling-and-minification
// for details on configuring this project to bundle and minify static web assets.

// Write your JavaScript code.

//Evenement uitklapbaar heading

var Event = document.getElementsByClassName("Eventheader");
var i;
for (i = 0; i < Event.length; i++) {
    Event[i].addEventListener("click", function () {
        this.classList.toggle("active");
        var content = this.nextElementSibling;
        if (content.style.display === "block") {
            content.style.display = "none";
        } else {
            content.style.display = "block";
        }
    });
}

//Om ervoor te zorgen dat je enkel een getal ingeeft (waarde 0-9). Kommagetallen niet toegestaan!
function isNumberKey(evt) {
    var charCode = (evt.which) ? evt.which : evt.keyCode;
    if (charCode < 48 || charCode > 57)
        return false;
    return true;
}