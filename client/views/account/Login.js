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
import AccountApi from '../../api/AccountApi';
import * as actionTypes from '../../reducers/actionTypes'
import * as roles from '../../common/roles'

class Login extends React.Component {
    constructor(props){
        super(props);

        this.state = {
            email: '',
            password: ''
        };
    }
    submit(e){
        e.preventDefault();

        AccountApi.login(this.state)
        .then((response) => {
            this.props.dispatch({
                type: actionTypes.LOGIN_SUCCESS,
                email: this.state.email,
                role: response.data.role
            });
            if (response.data.role === roles.PATIENT)
                history.push('/patient/profile');
            else
                history.push('/physician/patients');
        })
        .catch((error) => {
            console.log('Error logging in.');
        });
    }
    render() {
        return (
            <Form horizontal>
                <FormGroup>
                    <Col componentClass={ControlLabel} sm={2}>
                        Email
                    </Col>
                    <Col sm={4}>
                        <FormControl
                            type="email"
                            value={this.state.email}
                            onChange={(e) => this.setState({ email: e.target.value })}
                        />                        
                    </Col>
                </FormGroup>
                <FormGroup>
                    <Col componentClass={ControlLabel} sm={2}>
                        Password
                    </Col>
                    <Col sm={4}>
                        <FormControl
                            type="password"
                            value={this.state.password}
                            onChange={(e) => this.setState({ password: e.target.value })}
                        />                            
                    </Col>
                </FormGroup>                
                <Col smOffset={2}>
                    <Button bsStyle="primary" onClick={(e) => this.submit(e)}>
                        Login
                    </Button>
                </Col>
            </Form>
        );
    }
}

export default connect(null, null)(Login);
