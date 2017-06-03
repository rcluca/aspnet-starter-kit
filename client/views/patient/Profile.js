import React, { PropTypes } from 'react';

class Profile extends React.Component {
    render() {
        return <div>{this.props.profile.name}</div>;
    }
}

export default Profile;