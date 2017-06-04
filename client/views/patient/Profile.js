import React, { PropTypes } from 'react';
import {
    Grid,
    Row,
    Col,
    Table,
    Button,
    Modal,
    Form,
    FormGroup,
    FormControl,
    ControlLabel
} from 'react-bootstrap'
import orderBy from 'lodash.orderby'
import Link from '../../components/Link';
import AppointmentApi from '../../api/appointmentApi'

class Profile extends React.Component {
    constructor(props) {
        super(props);

        this.state = {
            cancellingAppointment: false,
            appointmentToCancelId: 0,
            cancellationReason: ""
        }
    }
    cancelAppointment(e){
        e.preventDefault();

        const {
            user
        } = this.props;

        const {
            appointmentToCancelId,
            cancellationReason
        } = this.state;

        AppointmentApi.cancel({
            id: appointmentToCancelId,
            cancellationReason
        })
        .then(() => {
            this.setState({
                cancellingAppointment: false
            })            
            alert("Appointment was successfully canceled.");
        })
        .catch((error) => {
            console.log(error);
        });
    }
    hideCancelModal(){
        this.setState({
            cancellingAppointment: false,
            appointmentToCancelId: 0,
            cancellationReason: ""            
        })
    }
    render() {
        const {
            firstName,
            lastName,
            dateOfBirth,
            email,
            phoneNumber,
            address1,
            address2,
            city,
            state,
            zip,
            appointments
        } = this.props.profile;

        const formattedDateOfBirth = new Date(dateOfBirth).toLocaleDateString();
        const sortedAppointments = orderBy(appointments, ['dateAndTime'], ['desc']);

        return (
            <div>
                <Modal show={this.state.cancellingAppointment} onHide={() => this.hideCancelModal()}>
                    <Modal.Header closeButton>
                        <Modal.Title>Cancel Appointment {this.state.appointmentToCancelId}</Modal.Title>
                    </Modal.Header>

                    <Modal.Body>
                        <Form horizontal>
                            <FormGroup>
                                <Col componentClass={ControlLabel} sm={2}>
                                    Cancellation Reason
                                </Col>
                                <Col sm={10}>
                                    <FormControl componentClass="textarea" onChange={(e) => this.setState({ cancellationReason: e.target.value })} />                
                                </Col>
                            </FormGroup>
                        </Form>                    
                    </Modal.Body>

                    <Modal.Footer>
                        <Button bsStyle="warning" onClick={(e) => this.cancelAppointment(e)}>Cancel Appointment</Button>
                    </Modal.Footer>
                </Modal>
                <Grid>
                    <Row>
                        <Col sm={4}>
                            <h4>Personal Info</h4>
                            <p>{firstName} {lastName}</p>
                            <p>DOB: {formattedDateOfBirth}</p>
                        </Col>
                        <Col sm={4}>
                            <h4>Contact</h4>
                            <p>{email}</p>
                            <p>{phoneNumber}</p>
                        </Col>
                        <Col sm={4}>
                            <h4>Address</h4>
                            <address>
                                <p>{address1}{address2 ? `, ${address2}` : ''}</p>
                                <p>{city}, {state}</p>
                                <p>{zip}</p>
                            </address>
                        </Col>                                        
                    </Row>
                </Grid>
                <h4>Appointments <small><Link to="/appointment/create">Schedule an Appointment</Link></small></h4>
                <Table condensed>
                    <thead>
                    <tr>
                        <th>Id</th>
                        <th>Physician</th>
                        <th>Date and Time</th>
                        <th>Purpose</th>
                        <th>Created Date and Time</th>
                        <th>Created By</th>
                        <th>Is Approved</th>
                        <th>Is Canceled</th>
                        <th>Cancelation Reason</th>
                        <th />
                    </tr>
                    </thead>
                    <tbody>
                        {sortedAppointments.map((appointment) => {
                            const dateAndTime = new Date(appointment.dateAndTime);
                            const cancelButton = !appointment.isCanceled && dateAndTime.getTime() > Date.now() ?
                            (
                                <Button bsStyle="warning" onClick={() => this.setState({ cancellingAppointment: true, appointmentToCancelId: appointment.id})}>
                                    Cancel
                                </Button>              
                            ) : "";

                            return (
                                <tr key={appointment.id}>
                                    <td>{appointment.id}</td>
                                    <td>{appointment.physician}</td>
                                    <td>{appointment.dateAndTime}</td>
                                    <td>{appointment.purpose}</td>
                                    <td>{appointment.createdDateTime}</td>
                                    <td>{appointment.createdBy}</td>
                                    <td>{appointment.isApproved ? "Yes" : "No"}</td>
                                    <td>{appointment.isCanceled ? "Yes" : "No"}</td>
                                    <td>{appointment.cancelationReason}</td>
                                    <td>
                                        {cancelButton}                                      
                                    </td>
                                </tr>
                            );
                        })}
                    </tbody>
                </Table>                
            </div>
        );
    }
}

export default Profile;