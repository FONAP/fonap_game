// Import Knex Module
const KNEX = require('../../database/database');
const LIST = [];

function addUser(user) {
    KNEX('users').insert(user)
        .then(() => {
            return JSON.stringify({
                data: user,
                message: {
                    info: 'Usuario creado con éxito',
                    status: 200
                }
            });
        })
        .catch(() => {
            return JSON.stringify({
                data: user,
                message: {
                    info: 'No se pudo crear el usuario',
                    status: 400
                }
            });
        });
}

module.exports = {
    store: addUser 
}
