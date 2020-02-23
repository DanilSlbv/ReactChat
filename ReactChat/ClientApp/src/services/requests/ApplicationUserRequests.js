import react,{Component} from 'react-dom';
import axios from 'axios';

export default function checkAccountIfExist(phoneNumber) {
     axios.get(`https://localhost:44326/ApplicationUser/CreateAccount?phoneNumber=${phoneNumber}`)
               .then(res=>{
                    this.state={UserId:res.Response.data,
                                AccountExist:res.Result.data}
               })
               .catch(err=>{
                    
               });
}



