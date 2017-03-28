'use script';

(function () {
    var application = angular.module('ChatRoomApplication');

    application.factory('roomService', roomService);

    roomService.$inject = ['$http'];

    function roomService($http) {
        var service = {};

        service.GetAllBeers = function(){
            return $http.get('/api/beers');
        }
    }
})();