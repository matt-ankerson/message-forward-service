var mongoose = require('mongoose');

var messageSchema = mongoose.Schema({

    originMessageId: String,
    timeRecieved: String,
    timeSent: String,
    messageContent: String,
    sender: String

});

module.exports = mongoose.model('Message', messageSchema);
