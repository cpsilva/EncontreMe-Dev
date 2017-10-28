angular.module('encontreMe').controller('indexController', function ($scope, $http, recursoListaDesaparecido) {

    recursoListaDesaparecido.query(function (result) {
        $scope.pessoasDesaparecidas = result
    }, function (erro) {
        ngNotify.set('Não foi possivel buscar todos as pessoas', 'error')
        console.log(erro);
    });

});



