import React from 'react';
import { Navbar, Nav, NavItem } from 'react-bootstrap'
import { connect } from 'react-redux';
import Link from '../Link';
import s from './Header.css';

class Header extends React.Component {

  render() {
    const {
      user
    } = this.props;

    const accountNav = !user.isLoggedIn ?
    (
      <Nav pullRight>
        <NavItem eventKey={1} href="#"><Link to="/account/login">Login</Link></NavItem>
      </Nav>
    ) :
    (
      <Nav pullRight>
        <NavItem eventKey={1} href="#">{user.email} ({user.role})</NavItem>
        <NavItem eventKey={2} href="#"><Link to="/account/logout">Logout</Link></NavItem>
      </Nav>      
    )

    return (
      <header>
        <Navbar>
          <Navbar.Header>
            <Navbar.Brand>
              <a href="#">Tempus Health Tracker</a>
            </Navbar.Brand>
          </Navbar.Header>
          <Nav>
            <NavItem eventKey={1} href="#"><Link to="/">Home</Link></NavItem>
            <NavItem eventKey={2} href="#"><Link to="/about">About</Link></NavItem>
          </Nav>
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
