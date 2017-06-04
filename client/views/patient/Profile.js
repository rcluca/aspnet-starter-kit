import React, { PropTypes } from 'react';
import {
    Grid,
    Row,
    Col
} from 'react-bootstrap'

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
            zip
        } = this.props.profile;

        const formattedDateOfBirth = new Date(dateOfBirth).toLocaleDateString();

        return (
            <Grid>
                <Row>
                    <Col sm={4}>
                        <p>{firstName}, {lastName}</p>
                        <p>{formattedDateOfBirth}</p>
                    </Col>
                    <Col sm={4}>
                        <p>{email}</p>
                        <p>{phoneNumber}</p>
                    </Col>
                    <Col sm={4}>
                        <address>
                            <p>{address1}{address2 ? `, ${address2}` : ''}</p>
                            <p>{city}, {state}</p>
                            <p>{zip}</p>
                        </address>
                    </Col>                                        
                </Row>
            </Grid>
        );
    }
}

export default Profile;