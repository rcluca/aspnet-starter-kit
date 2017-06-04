import AccountApi from '../api/AccountApi'

export default new Promise((resolve, reject) => {
    AccountApi.getUserData()
    .then((response) => {
        resolve({
            isLoggedIn: response.data.email,
            email: response.data.email,
            role: response.data.role
        });
    })
    .catch((error) => {
        console.log(error);
        resolve({
            isLoggedIn: false,
            email: '',
            role: ''
        });
    });
});