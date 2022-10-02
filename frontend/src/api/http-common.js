import axios from 'axios'

// axios
export const HTTP = axios.create({
    baseURL: `https://localhost:44303/api/v1`,
    headers: {
        "Content-Type": "application/json",
    }
})

// https://localhost:44303/api/v1

// https://cukcuk.manhnv.net/api/v1