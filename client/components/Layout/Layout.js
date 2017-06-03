/**
 * ASP.NET Core Starter Kit (https://dotnetreact.com)
 *
 * Copyright © 2014-present Kriasoft, LLC. All rights reserved.
 *
 * This source code is licensed under the MIT license found in the
 * LICENSE.txt file in the root directory of this source tree.
 */

import React from 'react';
import Header from './Header';
import s from './Layout.css';

class Layout extends React.Component {

  render() {
    return (
        <div>
          <div className={s.ribbon}>
            <Header />
          </div>
          <main {...this.props} className={s.content} />
        </div>
    );
  }
}

export default Layout;
