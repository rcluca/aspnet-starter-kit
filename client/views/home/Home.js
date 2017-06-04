/**
 * ASP.NET Core Starter Kit (https://dotnetreact.com)
 *
 * Copyright © 2014-present Kriasoft, LLC. All rights reserved.
 *
 * This source code is licensed under the MIT license found in the
 * LICENSE.txt file in the root directory of this source tree.
 */

import React, { PropTypes } from 'react';

const title = 'ASP.NET Core Starter Kit';
const link = 'https://github.com/kriasoft/aspnet-starter-kit';

class Home extends React.Component {

  static propTypes = {
    articles: PropTypes.array.isRequired,
  };

  componentDidMount() {
    document.title = title;
  }

  render() {
    return (
      <div>
        <h3>
          Welcome to the ancient world!
        </h3>
        <p>
          Here we do medicine right!  Login at the top to begin.
        </p>
      </div>
    );
  }
}

export default Home;
