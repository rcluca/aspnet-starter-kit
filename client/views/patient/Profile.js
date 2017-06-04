import React, { PropTypes } from 'react';
import {
    Grid,
    Row,
    Col,
    Table
} from 'react-bootstrap'
import orderBy from 'lodash.orderby'
import Link from '../../components/Link';

class Profile extends React.Component {
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
                <Table striped bordered condensed>
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
                    </tr>
                    </thead>
                    <tbody>
                        {sortedAppointments.map((appointment) => {
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