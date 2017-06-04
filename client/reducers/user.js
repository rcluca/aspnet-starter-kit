import initialState from '../store/initialState';
import { LOGIN_SUCCESS, LOGOUT_SUCCESS, DEFAULT_USER } from './actionTypes'

export default (state = initialState.user, action) => {
  switch (action.type) {
    case DEFAULT_USER: {
      return Object.assign({}, state, action.user);
    }    
    case LOGIN_SUCCESS: {
      return Object.assign({}, state, {
        isLoggedIn: true,
        email: action.email,
        role: action.role
      });
    }
    case LOGOUT_SUCCESS: {
      return Object.assign({}, state, {
        isLoggedIn: false,
        email: '',
        role: ''
      });
    }    

    default:
      return state;
  }
};
