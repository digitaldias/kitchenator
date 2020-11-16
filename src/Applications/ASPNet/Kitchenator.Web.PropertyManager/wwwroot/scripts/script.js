function initializeMap() {
    // 60.2362325,17.7927358,6.19z
    var latlng = new google.maps.LatLng(60.2362325, 17.7927358);
    var options = {
        zoom: 6.19, center: latlng,
        mapTypeId: google.maps.MapTypeId.ROADMAP
    };
    var map = new google.maps.Map(document.getElementById("map"), options);
}