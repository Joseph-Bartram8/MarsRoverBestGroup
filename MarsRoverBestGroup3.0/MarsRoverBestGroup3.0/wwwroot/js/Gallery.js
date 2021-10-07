function menuClick(element) {
    resetMenus();
    document.getElementById(element.id).className = "d_submenu d_submenu_selected";
    resetCopy();
    switch (element.id) {
        case "mGallery":
            document.getElementById("copyGallery").style.display = "block";
            break;
        case "mConverter":
            document.getElementById("copyConverter").style.display = "block";
            break;
    }
}

function resetMenus() {
    document.getElementById("mGallery").className = "d_submenu";
    document.getElementById("mConverter").className = "d_submenu";
}

function resetCopy() {
    document.getElementById("copyGallery").style.display = "none";
    document.getElementById("copyConverter").style.display = "none";
}

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