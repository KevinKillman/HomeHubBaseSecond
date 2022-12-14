var satMap = null;
var markerData;
const originalZoom = 14;
const footballMarkerPath = "./assets/football_marker.png";
const stationMarkerPath = "./assets/stationmarker.png";

function renderGoogleMapComponent(containerID, googleApiKey, markerJson) {
  if (markerJson != null && markerJson != "") {
    let parsedMarkerJson = JSON.parse(markerJson)
    if (parsedMarkerJson != null) {
      markerData = getMapMarkersFromData(parsedMarkerJson);
    }
  }

  if (containerID != null && googleApiKey != null) {
    renderSatelliteMap(containerID, googleApiKey);
  }
}

function renderSatelliteMap(containerID, apiKey) {
  if (satMap == null) {
    satMap = $(containerID).dxMap({
      center: "Kansas",
      zoom: originalZoom,
      height: 400,
      width: "100%",
      provider: "google",
      apiKey: { google: apiKey },
      markers: markerData,
      type: "satellite",
    }).dxMap("instance");
  } else {
    satMap.option("markers", markerData);
    if (markerData.length == 1) {
      satMap.option("zoom", originalZoom)
    }
  }
}

function disposeSatMap() {
  satMap = null;
}

function getMapMarkersFromData(data) {
  return data.map(y => {
    return {
      iconSrc: y.Path,
      location: y.GeoPoint,
      tooltip: {
        text: "<span>" + y.Name + "</span></hr></br><span>" + y.TooltipText + "</span>"
      }
    }
  })
}

