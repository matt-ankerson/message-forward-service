var _ = require('lodash');
var Message = require('../models/message.js');

// This file behaves like a module. When 'required' by a consuming
// file, this file will return a function which accepts an 'app'.
// We can define methods for the app like the http verbs below.
module.exports = function(app) {
    
    // Create
    app.post('/message', function (req, res) {
        var newMessage = new Message(req.body);
        newMessage.save(function (err) {
            if (err) {
                res.json({info: 'error during message create', error: err});
            };
            res.json({info: 'message created successfully'});
        });
    });

    // Read
    app.get('/message', function (req, res) {
        Message.find(function (err, messages) {
            if (err) {
                res.json({info: 'error during find messages', error: err});
            };
            res.json({info: 'messages found successfully', data: messages});
        });
    });

    app.get('/message/:id', function (req, res) {
        Message.findById(req.params.id, function(err, message) {
            if (err) {
                res.json({info: 'error during find message', error: err});
            };
            if (message) {
                res.json({info: 'message found successfully', data: message});
            } else {
                res.json({info: 'message not found'});
            }
        });
    });

    // Update
    app.put('/message/:id', function (req, res) {
        Message.findById(req.params.id, function(err, message) {
            if (err) {
                res.json({info: 'error during find message', error: err});
            };
            if (message) {
                _.merge(message, req.body);
                message.save(function(err) {
                    if (err) {
                        res.json({info: 'error during update message', error: err});
                    }
                    res.json({info: 'message updated successfully'});
                });
            } else {
                res.json({info: 'message not found'});
            }
        });
    });

    // Delete
    app.delete('/message/:id', function (req, res) {
        Message.findByIdAndRemove(req.params.id, function(err) {
            if (err) {
                res.json({info: 'error during remove message', error: err});
            }
            res.json({info: 'message removed successfully'});
        });
    });
};
