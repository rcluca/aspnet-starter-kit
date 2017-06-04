import axios from 'axios';

class PhysicianApi {
    static names(){
        return axios.get('/api/physician/names');
    }
}

export default PhysicianApi;