import axios from 'axios';

class PatientApi {
    static names(){
        return axios.get('/api/patient/names');
    }
}

export default PatientApi;