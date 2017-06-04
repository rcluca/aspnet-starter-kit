import React, { PropTypes } from 'react';
import { connect } from 'react-redux';
import Datetime from 'react-datetime'
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
import AppointmentApi from '../../api/appointmentApi';
import * as roles from '../../common/roles'

class Create extends React.Component {
    constructor(props){
        super(props);

        this.state = {
            patientId: 0,
            physicianId: 0,
            people: [],
            dateAndTime: null,
            purposeId: 0,
            purposes: []
        };
    }
    componentDidMount(){
        const {
            user
        } = this.props;

        let names;

        if (user.role === roles.PATIENT)
            names = PhysicianApi.getNames()
        else
            names = PatientApi.getNames()

        names
        .then((response) => {
            this.setState({people: response.data});
        })
        .catch((error) => {
            console.log(error);
        });

        AppointmentApi.getPurposes()
        .then((response) => {
            this.setState({purposes: response.data});
        })
        .catch((error) => {
            console.log(error);
        });
    }
    selectPerson(e){
        const {
            user
        } = this.props;      

        if (user.role === roles.PATIENT)
            this.setState({ physicianId: parseInt(e.target.value) });
        else
            this.setState({ patientId: parseInt(e.target.value) });
    }
    submit(e){
        e.preventDefault();

        const {
            user
        } = this.props;

        const {
            patientId,
            physicianId,
            dateAndTime,
            purposeId
        } = this.state;

        AppointmentApi.create({
            patientId,
            physicianId,
            dateAndTime,
            purposeId
        })
        .then((response) => {
            if (user.role === roles.PATIENT)
                history.push('/patient/profile');
            else
                history.push('/physician/patients');
        })
        .catch((error) => {
            console.log('Error creating appointment.');
        });
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
                        <FormControl componentClass="select" onChange={(e) => this.selectPerson(e)}>
                            <option key={0} value={0}>{`Select a ${personLabel}`}</option>
                            {this.state.people.map((person) => {
                                return <option key={person.id} value={person.id}>{person.name}</option>;
                            })}
                        </FormControl>                   
                    </Col>
                </FormGroup>
                <FormGroup>
                    <Col componentClass={ControlLabel} sm={2}>
                        Date and Time
                    </Col>
                    <Col sm={4}>
                        <Datetime onChange={(momentDate) => this.setState({ dateAndTime: momentDate.format() })}/>               
                    </Col>
                </FormGroup>                 
                <FormGroup>
                    <Col componentClass={ControlLabel} sm={2}>
                        Purposes
                    </Col>
                    <Col sm={4}>
                        <FormControl componentClass="select" onChange={(e) => this.setState({ purposeId: parseInt(e.target.value) })}>
                            <option key={0} value={0}>Select a Purpose</option>
                            {this.state.purposes.map((purpose) => {
                                return <option key={purpose.id} value={purpose.id}>{purpose.name}</option>;
                            })}
                        </FormControl>                   
                    </Col>
                </FormGroup>
                <Col smOffset={2}>
                    <Button bsStyle="primary" onClick={(e) => this.submit(e)}>
                        Create
                    </Button>
                </Col>
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
