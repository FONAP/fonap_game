// Import Components
const REGISTER = require('../components/register/network');
const SCORE = require('../components/score/network');

// Routes Named
const ROUTES = function(server) {
    server.use('/register', REGISTER);
    server.use('/score', SCORE);
}

// Export the routes
module.exports = ROUTES;