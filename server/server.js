const express = require('express');
const router = require('./routes');

const app = express();
app.use(express.json());
app.use('/api/v1', router);

app.listen(7000, () => console.log('Server listening on port 7000'));
