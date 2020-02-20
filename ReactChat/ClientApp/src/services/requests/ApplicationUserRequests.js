import axios from 'axios';

function createAccount() {
     axios.get("https://localhost:44326/ApplicationUser/CreateAccount").then(res=>{debugger;})
}
export default createAccount;
