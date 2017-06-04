import { createStore, applyMiddleware, compose, combineReducers } from 'redux';
import reducers from './store/index';

function buildRootReducer(allReducers) {
  return combineReducers(Object.assign({}, allReducers));
}

export default function (initialState, middlewares = []) {
    // Build middleware. These are functions that can process the actions
    // before they reach the store.
  const windowIfDefined = typeof window === 'undefined' ? null : window;
    // If devTools is installed, connect to it
  const devToolsExtension = windowIfDefined && windowIfDefined.devToolsExtension;
  const createStoreWithMiddleware = compose(
        applyMiddleware(...middlewares),
        devToolsExtension ? devToolsExtension() : f => f)(createStore);

    // Combine all reducers and instantiate the app-wide store instance
  const allReducers = buildRootReducer(reducers);
  const store = createStoreWithMiddleware(allReducers, initialState);

    // Enable Webpack hot module replacement for reducers
  if (module.hot) {
    module.hot.accept('./store', () => {
      /* eslint-disable global-require */
      const nextRootReducer = require('./store');
      /* eslint-enable global-require */
      store.replaceReducer(buildRootReducer(nextRootReducer));
    });
  }

  return store;
}