import axios from 'axios';

class AccountApi {
    static login(credentials){
        return axios.post('/api/account/login', credentials);
    }

    static getUserData(){
        return axios.get('/api/account/user-data');
    }
}

export default AccountApi;