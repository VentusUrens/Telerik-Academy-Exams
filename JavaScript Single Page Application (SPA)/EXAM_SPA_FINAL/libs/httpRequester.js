define(['jquery', 'q'], function ($, Q) {
    'use strict';

    var httpRequester = (function () {
        var getJSON = function (url, headers) {
            var deferred = Q.defer();

            $.ajax({
                url: url,
                type: 'GET',
                contentType: 'application/json',
                headers: headers || {},
                timeout: 10000,
                success: function (success) {
                    deferred.resolve(success);
                },
                error: function (error) {
                    deferred.reject(error);
                }
            });

            return deferred.promise;
        };

        var postJSON = function (url, data) {
            var deferred = Q.defer();

            $.ajax({
                url: url,
                type: 'POST',
                data: JSON.stringify(data),
                contentType: 'application/json',
                timeout: 10000,
                success: function (success) {
                    deferred.resolve(success);
                },
                error: function (error) {
                    deferred.reject(error);
                }
            });

            return deferred.promise;
        };

        var deleteJSON = function (url) {
            var deferred = Q.defer();

            $.ajax({
                url: url,
                type: 'POST',
                data: {_method: 'delete'},
                timeout: 10000,
                success: function (success) {
                    deferred.resolve(success);
                },
                error: function (error) {
                    deferred.reject(error);
                }
            });

            return deferred.promise;
        };

        return {
            getJSON: getJSON,
            postJSON: postJSON,
            deleteJSON: deleteJSON
        };
    }());

    return httpRequester;
});