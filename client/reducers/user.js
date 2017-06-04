import initialState from '../store/initialState';
import { LOGIN_SUCCESS, DEFAULT_USER } from './actionTypes'

export default (state = initialState.user, action) => {
  switch (action.type) {
    case LOGIN_SUCCESS: {
      return Object.assign({}, state, {
        isLoggedIn: true,
        email: action.email,
        role: action.role
      });
    }
    case DEFAULT_USER: {
      return Object.assign({}, state, action.user);
    }

    default:
      return state;
  }
};
