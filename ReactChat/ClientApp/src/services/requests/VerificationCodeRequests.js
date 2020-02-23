import react,{Component} from 'react';
import ReactDom from 'react-dom';
import axios from 'axios';
import Loading from '../../components/loading/Loading';


export default function ConfirmCode(userId , code,phoneNumber){
    Loading.startLoading();
    const verificationCodeModel = {
        UserId : userId,
        Code:code,
        PhoneNumber:phoneNumber
    }
    axios.post("https://localhost:44326/VerificationCode/ConfirmCode",verificationCodeModel)
            .then(res=>{
                Loading.endloading();
                if(res.data==false)
                {
                    
                }
            })
            .catch(res=>{
                Loading.endloading();
            })
}