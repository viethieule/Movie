import axios from 'axios';

const instance = axios.create({
    baseURL: 'https://localhost:44375/api/'
});

export default instance;