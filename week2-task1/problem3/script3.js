function getLocation() {

    if (!navigator.geolocation) {
        alert("Geolocation not supported by your browser.");
        return;
    }

    navigator.geolocation.getCurrentPosition(
        showPosition,
        showError,
        {
            enableHighAccuracy: true,
            timeout: 10000,
            maximumAge: 0
        }
    );
}

function showPosition(position) {

    const lat = position.coords.latitude;
    const lon = position.coords.longitude;

    // Show coordinates
    document.getElementById("coords").textContent =
        "Latitude: " + lat + " | Longitude: " + lon;

    // Show map using iframe
    document.getElementById("map").innerHTML =
        `<iframe 
            width="600" 
            height="450" 
            style="border:0"
            loading="lazy"
            allowfullscreen
            src="https://www.google.com/maps?q=${lat},${lon}&output=embed">
        </iframe>`;
}

function showError(error) {

    let message = "";

    switch(error.code) {
        case error.PERMISSION_DENIED:
            message = "Permission denied.";
            break;
        case error.TIMEOUT:
            message = "Request timed out.";
            break;
        case error.POSITION_UNAVAILABLE:
            message = "Location unavailable.";
            break;
        default:
            message = "Unknown error.";
    }

    document.getElementById("coords").textContent = message;
}
