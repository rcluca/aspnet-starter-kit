import React from 'react';
import { Navbar, Nav, NavItem } from 'react-bootstrap'
import { connect } from 'react-redux';
import Link from '../Link';
import s from './Header.css';
import AccountApi from '../../api/accountApi'
import history from '../../history';
import * as actionTypes from '../../reducers/actionTypes'
import * as roles from '../../common/roles'

class Header extends React.Component {
  logout(){
    AccountApi.logout()
    .then(() => {
      this.props.dispatch({
          type: actionTypes.LOGOUT_SUCCESS
      });
      history.push('/account/loggedOut');
    })
    .catch((error) => {
      console.log(error);
    });
  }

  render() {
    const {
      user
    } = this.props;

    let userNav;
    if (user.isLoggedIn){
      if (user.role === roles.PATIENT){
        userNav = (
          <Nav>
            <NavItem eventKey={1} href="#"><Link to="/patient/profile">Profile</Link></NavItem>
          </Nav>
        );
      }
      else {
        userNav = (
          <Nav>
            <NavItem eventKey={1} href="#"><Link to="/physician/patients">Patients</Link></NavItem>
          </Nav>
        );
      }
    }

    const accountNav = !user.isLoggedIn ?
    (
      <Nav pullRight>
        <NavItem eventKey={1} href="#"><Link to="/account/login">Login</Link></NavItem>
      </Nav>
    ) :
    (
      <Nav pullRight>
        <NavItem eventKey={1} href="#">{user.email} ({user.role})</NavItem>
        <NavItem eventKey={2} href="#" onClick={() => this.logout()}>Logout</NavItem>
      </Nav>      
    )

    return (
      <header>
        <Navbar>
          <Navbar.Header>
            <Navbar.Brand>
              <Link to="/">Health Tracker</Link>
            </Navbar.Brand>
          </Navbar.Header>
          {userNav}
          {accountNav}
        </Navbar>
      </header>
    );
  }
}

function mapStateToProps(state) {
  return {
    user: state.user
  };
}

export default connect(mapStateToProps, null)(Header);
