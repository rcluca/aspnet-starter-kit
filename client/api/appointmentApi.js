import axios from 'axios';

class AppointmentApi {
    static getPurposes(){
        return axios.get('/api/appointment/purposes');
    }

    static create(appointment){
        return axios.post('/api/appointment/create', appointment);
    }
}

export default AppointmentApi;