import axios from 'axios';

class AccountApi {
    static login(credentials){
        return axios.post('/api/account/login', credentials);
    }

    static logout(){
        return axios.post('/api/account/logout');
    }

    static getUserData(){
        return axios.get('/api/account/user-data');
    }
}

export default AccountApi;