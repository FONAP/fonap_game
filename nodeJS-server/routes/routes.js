// Import Components
const REGISTER = require('../components/register/network');

// Routes Named
const ROUTES = function(server) {
    server.use('/register', REGISTER);
}

// Export the routes
module.exports = ROUTES;