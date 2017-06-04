import React, { PropTypes } from 'react';
import { connect } from 'react-redux';
import history from '../../history';
import {
    Form,
    FormGroup,
    ControlLabel,
    FormControl,
    Col,
    Button
} from 'react-bootstrap'
import PatientApi from '../../api/patientApi';
import PhysicianApi from '../../api/physicianApi';
import * as roles from '../../common/roles'

class Create extends React.Component {
    constructor(props){
        super(props);

        this.state = {
            patientId: 0,
            physicianId: 0,
            dateAndTime: null,
            purposeId: 0,
            people: []
        };
    }
    componentDidMount(){
        const {
            user
        } = this.props;

        let names;

        if (user.role === roles.PATIENT)
            names = PhysicianApi.names()
        else
            names = PatientApi.names()

        names
        .then((response) => {
            this.setState({people: response.data});
        })
        .catch((error) => {
            console.log("Error getting names.");
        });
    }
    submit(e){
        e.preventDefault();

        // AccountApi.login(this.state)
        // .then((response) => {
        //     if (response.data.role === roles.PATIENT)
        //         history.push('/patient/profile');
        //     else
        //         history.push('/physician/patients');
        // })
        // .catch((error) => {
        //     console.log('Error logging in.');
        // });
    }
    render() {
        const {
            user
        } = this.props;

        const personLabel = user.role === roles.PATIENT ? "Physician" : "Patient";

        return (
            <Form horizontal>
                <FormGroup>
                    <Col componentClass={ControlLabel} sm={2}>
                        {personLabel}
                    </Col>
                    <Col sm={4}>
                        <FormControl componentClass="select">
                            <option key={0} value={0}>{`Select a ${personLabel}`}</option>
                            {this.state.people.map((person) => {
                                return <option key={person.id} value={person.id}>{person.name}</option>;
                            })}
                        </FormControl>                   
                    </Col>
                </FormGroup>
            </Form>
        );
    }
}

function mapStateToProps(state) {
  return {
    user: state.user
  };
}

export default connect(mapStateToProps, null)(Create);
