import React, { PropTypes } from 'react';
import {
    Table
} from 'react-bootstrap'

class Patients extends React.Component {
    render() {
        return (
            <div>
                <Table condensed>
                    <thead>
                    <tr>
                        <th>Id</th>
                        <th>Name</th>
                        <th>Email</th>
                        <th>Phone Number</th>
                        <th>City</th>
                        <th>State</th>
                    </tr>
                    </thead>
                    <tbody>
                        {this.props.patients.map((patient) => {
                            return (
                                <tr key={patient.id}>
                                    <td>{patient.id}</td>
                                    <td>{patient.firstName} {patient.lastName}</td>
                                    <td>{patient.email}</td>
                                    <td>{patient.phoneNumber}</td>
                                    <td>{patient.city}</td>
                                    <td>{patient.state}</td>
                                </tr>
                            );
                        })}
                    </tbody>
                </Table>  
            </div>
        );
    }
}

export default Patients;