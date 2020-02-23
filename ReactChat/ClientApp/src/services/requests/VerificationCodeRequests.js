import react,{Component} from 'react';
import ReactDom from 'react-dom';
import axios from 'axios';


export default function ConfirmCode(userId , code,phoneNumber){
    const verificationCodeModel = {
        UserId : userId,
        Code:code,
        PhoneNumber:phoneNumber
    }
    axios.post("https://localhost:44326/VerificationCode/ConfirmCode",verificationCodeModel)
            .then(res=>{
                if(res.data==false)
                {
                    
                }
            })
            .catch(res=>{})
}