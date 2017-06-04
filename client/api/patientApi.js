import axios from 'axios';

class PatientApi {
    static getNames(){
        return axios.get('/api/patient/names');
    }
}

export default PatientApi;