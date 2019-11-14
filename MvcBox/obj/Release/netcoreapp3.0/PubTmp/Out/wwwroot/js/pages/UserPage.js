var map;
// Initialize and add the map

function loadData(map) {
    //запрос стартует по факту вызова, но
    $.ajax({
        url: '/api/container/getboxeslocation/',
        type: 'GET',
        contentType: "application/json",
        //результат ты получаешь как бы в отдельном потоке по факту ответа от серверного метода
        success: function (boxes) {
            //map.data.addGeoJson(boxes);
            //и тогда уже продолжаешь работу
            setMarkers(map, boxes);
        }
    });
    //но не здесь, здесь код продолжит выполняться без ожидания ответа от ajax
}

function initMap() {
    map = new google.maps.Map(document.getElementById('map'), {
        zoom: 2,
        center: new google.maps.LatLng(2.8, -187.3),
        mapTypeId: 'terrain'
    });
    loadData(map);
}
function setMarkers(map, objects) {
    //используй let вместо var, это объявление локалной переменной
    for (let i = 0; i < objects.length; i++) {
        let object = objects[i];
        let myLatLng = new google.maps.LatLng(object.latitude, object.longitude);
        let marker = new google.maps.Marker({
            position: myLatLng,
            map: map
        });
    }
}