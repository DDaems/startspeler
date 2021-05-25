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

//om de hidden tekstbox een categorienaam mee te geven.

function categorieselectie() {
    var categorie = document.getElementsByName('categorie');
    var categorieChecked;

    for (var i = 0; i < categorie.length; i++) {
        if (categorie[i].checked) {
            document.getElementById("toon").value = categorie[i].value;
        }
    }
}

function amountUp(id) {
    var aantal = parseInt(document.getElementById(id).value);
    aantal = aantal + 1;
    document.getElementById(id).value = aantal;
}

function amountDown(id) {
    var aantal = parseInt(document.getElementById(id).value);

    if (aantal == 0) {
        document.getElementById(id).value = aantal;
    } else {
        aantal = aantal - 1;
        document.getElementById(id).value = aantal;
    }
}

function Toevoegen(getal) {
    document.getElementById('code').value = document.getElementById('code').value + getal;
}

function Verwijder() {
    document.getElementById('code').value = document.getElementById('code').value.slice(0, -1);
}

$('input[name="categorie"]').change(function () {
    $(".radio-visibility").toggle($('.radio-selection').is(':checked'));
}).change(); //trigger change to see changes