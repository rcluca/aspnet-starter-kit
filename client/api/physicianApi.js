import axios from 'axios';

class PhysicianApi {
    static getNames(){
        return axios.get('/api/physician/names');
    }
}

export default PhysicianApi;