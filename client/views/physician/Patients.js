import React, { PropTypes } from 'react';
import {
    Table,
    FormControl
} from 'react-bootstrap'

class Patients extends React.Component {
    constructor(props){
        super(props);

        this.state = {
            allPatients: this.props.patients,
            filteredPatients: null
        }
    }
    filterByName(e){
        e.preventDefault();

        const {
            allPatients
        } = this.state;

        const filterValues = e.target.value.split(' ');

        const filteredPatients = allPatients.filter((patient) => {
            let foundMatch = false;
            filterValues.forEach((filterValue) => {
                const lowerFilterValue = filterValue.toLowerCase();
                if (patient.firstName.toLowerCase().includes(lowerFilterValue)
                    || patient.lastName.toLowerCase().includes(lowerFilterValue)){
                        foundMatch = true;
                        return;
                    }
            });
            return foundMatch;
        });

        this.setState({ filteredPatients });
    }
    render() {
        const {
            allPatients,
            filteredPatients
        } = this.state;

        const patients = filteredPatients ? filteredPatients : allPatients;

        return (
            <div>
                <FormControl
                    type="text"
                    placeholder="Filter by name..."
                    onBlur={(e) => this.filterByName(e)}
                />
                &nbsp;
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
                        {patients.map((patient) => {
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