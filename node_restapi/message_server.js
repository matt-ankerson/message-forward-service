var express = require('express');

var app = express();

var bodyParser = require('body-parser');

var mongoose = require('mongoose');
mongoose.connect('mongodb://localhost/messages');

app.use(bodyParser.json());
app.use(bodyParser.urlencoded({
    extended: true
}));

// Pass the app as a param to the sub-module and execute the function.
var messages = require('./routes/message.js')(app);

var server = app.listen(3000, function () {
    console.log('Message server running at http://127.0.0.1:3000');
});
