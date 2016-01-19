/**
 * Created by Dinu Marius-Constantin on 16.01.2016.
 */
$(document).ready(function() {
    setTimeout(function() {
        var lat = document.getElementById("latitude-value").value;
        var lng = document.getElementById("longitude-value").value;
        var currentMarker = new google.maps.Marker({position: new google.maps.LatLng(lat, lng)});
        PF('map').addOverlay(currentMarker);
        currentMarker.setTitle(document.getElementById("marker-title").value);
    }, 1000);
});