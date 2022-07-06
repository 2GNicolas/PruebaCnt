// Please see documentation at https://docs.microsoft.com/aspnet/core/client-side/bundling-and-minification
// for details on configuring this project to bundle and minify static web assets.

// Write your JavaScript code.

// Accedemos al botón
var emailInput = document.getElementById('yearsfumando_id');

// evento para el input radio del "si"
document.getElementById('fumaPositivo').addEventListener('click', function (e) {
    console.log('Vamos a habilitar el input text');
    emailInput.disabled = false;
});

// evento para el input radio del "no"
document.getElementById('fumaNegativo').addEventListener('click', function (e) {
    console.log('Vamos a deshabilitar el input text');
    emailInput.disabled = true;
});
