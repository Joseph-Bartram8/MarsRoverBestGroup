function showCard1() {
    document.getElementById('menu_button2').checked = true;
    document.getElementById('overlayClose').style.display = "block";
}

function showCard2() {
    document.getElementById('menu_button3').checked = true;
    document.getElementById('overlayClose1').style.display = "block";
}

function closeOverlay() {
    document.getElementById('overlayClose').style.display = "none";
    document.getElementById('overlayClose1').style.display = "none";
}