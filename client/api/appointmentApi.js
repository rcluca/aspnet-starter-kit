import axios from 'axios';

class AppointmentApi {
    static getPurposes(){
        return axios.get('/api/appointment/purposes');
    }

    static create(appointment){
        return axios.post('/api/appointment/create', appointment);
    }

    static cancel(appointmentCancelation){
        return axios.put('/api/appointment/cancel', appointmentCancelation);
    }
}

export default AppointmentApi;