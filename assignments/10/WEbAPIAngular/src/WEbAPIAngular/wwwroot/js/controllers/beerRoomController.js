'use strict'

(function () {
    angular.module('BeerRoomApplication').controller('beerRoomController', beerRoomController);

    beerRoomController.$inject = ['$window', 'roomService'];

    function beerRoomController($window, beerRoomService) {
        var vm = this;
        vm.beers = [];

        vm.GetAllBeers = function () {
            var promise = beerRoomController.GetAllRooms();
            promise.then(function (result) {
                vm.beers = result.data;
            }, function (result) {
                vm.errors = result.data;
            });
            }
    }
})();