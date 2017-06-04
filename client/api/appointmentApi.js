import axios from 'axios';

class AppointmentApi {
    static getPurposes(){
        return axios.get('/api/appointment/purposes');
    }
}

export default AppointmentApi;