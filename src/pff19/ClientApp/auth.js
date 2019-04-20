import axios from 'axios'
import { store } from './store'

const auth = axios.create({
    baseURL: '/api/',
    transformRequest: [
        function(data, headers) {
            headers['Authorization'] = `Bearer ${store.getters['api/getToken']}`
            return data
        }
    ]
})

export default auth
