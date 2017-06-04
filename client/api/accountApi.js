import axios from 'axios';

class AccountApi {
    static login(credentials){
        return axios.post('/api/account/login', credentials);
    }
}

export default AccountApi;