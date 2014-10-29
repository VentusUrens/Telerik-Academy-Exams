/* global require */
(function () {
    'use strict';

    require.config({
        paths: {
            'jquery': '../libs/jquery-2.1.1',
            'sammy': '../libs/sammy',
            'q': '../libs/q',
            'httpRequester': '../libs/httpRequester'
        }
    });

    require(['jquery', 'sammy', 'httpRequester'], function ($, sammy, httpRequester) {

        var targetURL = 'http://jsapps.bgcoder.com';
        var sessionKey;
        var usernameFilter;

        // ATTACHING EVENTS
        $('#header').on('click','#btn-login', function(){
            console.log('Login-btn')
            window.location = '#/auth';
        });

        // ATTACHING EVENTS
        $('#header').on('click','#btn-go-to-register-page', function(){
            console.log('Register-btn')
            window.location = '#/user';
        });

        // ATTACHING EVENTS
        $('#header').on('click','#btn-logout', function(){
            console.log('Logout-btn');
            alert('You have successfully logged out!')
            sessionStorage.setItem('sessionKey', null);
            console.log(sessionKey);
            window.location= '#/auth';
        });

        // ATTACHING EVENTS
        $('#main-content').on('click', '#btn-login', function () {
            var username = $('#tb-userName').val() || 'unnamed';
            var password = $('#tb-password').val() || 'NO PASSWORD!';
            var authCode = CryptoJS.SHA1((username + password).toString());
            sessionStorage.setItem('username', username);
            sessionStorage.setItem('password', password);


            var newUser = {username: username, authCode: authCode.toString()};
            console.log(JSON.stringify(newUser));
            httpRequester.postJSON(targetURL + '/auth', {"username": username, "authCode": authCode.toString()})
                .then(function(success) {
                    sessionKey = success.sessionKey;
                    sessionStorage.setItem('sessionKey', sessionKey);
                    alert('Hello ' + success.username);
                    console.log(sessionKey);
                },function(error){
                    console.log(error);
                });

            window.location = '#/post';
        });

        // ATTACHING EVENTS
        $('#main-content').on('click', '#btn-go-to-register-page', function () {
            window.location = '#/user';
        });

        // ATTACHING EVENTS
        $('#main-content').on('click', '#btn-register-user', function () {
            var username = $('#tb-userName').val() || 'unnamed';
            var password = $('#tb-password').val() || 'NO PASSWORD!';
            var authCode = CryptoJS.SHA1((username + password).toString());
            sessionStorage.setItem('username', username);
            sessionStorage.setItem('password', password);

            var newUser = {username: username, authCode: authCode.toString()};
            console.log(JSON.stringify(newUser));
            httpRequester.postJSON(targetURL + '/user', {"username": username, "authCode": authCode.toString()})
                .then(function(success) {
                    alert('You have successfully registered a user: ' + username);
                },function(error){
                    alert('You have entered incorrect username or password! Please, try again with username of more than 6 symbols.');
                });

            window.location = '#/auth';
        });

        // ATTACHING EVENTS
        $('#main-content').on('click', '#btn-sendPost', function () {

            var postTitle = $('#tb-post-title').val();
            var postBody = $('#tb-post-body').val()
            var username = sessionStorage.getItem('username');
            var password = sessionStorage.getItem('password');
            var authString = username + password;
            var authCode = CryptoJS.SHA1((username + password).toString());
            var url = targetURL + '/post';
            var data = {title: postTitle, body: postBody};

            $.ajax({
                url: url,
                type: 'POST',
                data: JSON.stringify(data),
                contentType: 'application/json',
                headers: {"X-SessionKey": sessionStorage.getItem('sessionKey').toString()},
                timeout: 10000,
                success: function (success) {
                    console.log('You have successfully posted a new message!');
                },
                error: function (error) {
                    alert('You are not logged in. Please, log in to be able to post.');
                }
            });
        });

        //ROUTING
        var app = sammy('#main-content', function () {
            alert("Please note that the server is not active at the current moment.");
            this.get('#/user', function(){
                $('#main-content').load('templates/register-form.html');
            });

            this.get('#/auth', function () {
                $('#main-content').load('templates/login-form.html');
            });

            this.get('#/post', function () {
                $('#main-content').load('templates/posts-window.html');
                setInterval(getAllPosts, 2000);
            });

        });

        function getAllPosts() {
            var $tempContainer = $('<ul>');
            var url = 'http://jsapps.bgcoder.com/post';

            httpRequester.getJSON(url)
                .then(function (result) {

                    for (var i = result.length - 1; i >= 0; i--) {
//                        if (result[i].user.username.toLowerCase() === usernameFilter){
                        $('<li class="post-item">').html('<strong>'+
//                            'Id: ' + result[i].id +
                            '<br>Title: ' + '<span style="color: red">' + result[i].title + '</span>' +
                            '<br>Body: ' + '<span style="color: orangered">' + result[i].body + '</span>' +
                            '<br>Post date: ' + result[i].postDate +
                            '<br>By: ' + '<span style="color: red">' + result[i].user.username + '</span>' + ' with id: '+ result[i].user.id+
//                            '<br>All posts count: ' + result.length +
                            '</strong').appendTo($tempContainer);
                            }
//                    }
                    $('#post-items').html($tempContainer.html());
                    console.log('Posts updated.');

                }, function (error) {
                    console.log(error);
                })
                .done();
        }

        $(function () {
            app.run('#/auth');
        });
    });
}());