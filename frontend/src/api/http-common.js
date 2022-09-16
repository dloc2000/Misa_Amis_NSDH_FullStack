import axios from 'axios'

export const HTTP = axios.create({
    baseURL: `https://cukcuk.manhnv.net/api/v1`,
    headers: 'application/json'
})