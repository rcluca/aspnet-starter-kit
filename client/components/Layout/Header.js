/**
 * ASP.NET Core Starter Kit (https://dotnetreact.com)
 *
 * Copyright © 2014-present Kriasoft, LLC. All rights reserved.
 *
 * This source code is licensed under the MIT license found in the
 * LICENSE.txt file in the root directory of this source tree.
 */

import React from 'react';
import { Navbar, Nav, NavItem } from 'react-bootstrap'
import Link from '../Link';
import s from './Header.css';

class Header extends React.Component {

  render() {
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
        </Navbar>
      </header>
    );
  }

}

export default Header;
