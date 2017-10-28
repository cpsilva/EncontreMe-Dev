angular.module('meusServicos', ['ngResource'])
    .factory('recursoListaDesaparecido', function ($resource) {
        return $resource('api/DESAPARECIDO/:desaparecidoId', null, {
            salvar: {
                method: 'POST'
            },
            atualizar: {
                method: 'PUT'
            },
            busca: {
                method: 'GET'
            },
            excluir: {
                method: 'DELETE'
            }
        })
    })

    .service('Map', function ($q) {
        var map = null;
        this.init = function (mapMarkerCallBack) {
            var options = {
                center: new google.maps.LatLng(-23.5486, -46.6392),
                zoom: 10,
                mapTypeId: 'roadmap',
                disableDefaultUI: false
            }
            map = new google.maps.Map(
                document.getElementById("map"), options
            );

            this.places = new google.maps.places.PlacesService(map);
            searchBox = new google.maps.places.SearchBox(document.getElementById('pac-input'));

            map.addListener('bounds_changed', function () {
                searchBox.setBounds(map.getBounds());
            });

            searchBox.addListener('places_changed', function () {
                var places = searchBox.getPlaces();

                if (places.length == 0) {
                    return;
                }

                var bounds = new google.maps.LatLngBounds();
                places.forEach(function (place) {
                    if (!place.geometry) {
                        console.log("Returned place contains no geometry");
                        return;
                    }
                    var marker = new google.maps.Marker({
                        map: map,
                        position: place.geometry.location
                    });

                    mapMarkerCallBack(place.geometry.location.lat(), place.geometry.location.lng());

                    if (place.geometry.viewport) {
                        bounds.union(place.geometry.viewport);
                    } else {
                        bounds.extend(place.geometry.location);
                    }
                });
                map.fitBounds(bounds);
            });
        }
        this.addMarker = function (lat, lgn) {
            var marker = new google.maps.Marker({
                map: map,
                position: { lat: parseFloat(lat), lng: parseFloat(lgn) }
            });
        }
    })

    .service('CompararImagem', function ($http) {
        this.compararImg = function (img, id) {
            return $http.post("/desaparecido/compararimagem", { Id: id, ImgBody: img });
        }
    });

