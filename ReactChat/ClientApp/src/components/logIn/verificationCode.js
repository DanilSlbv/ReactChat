import React,{Component} from 'react';
import ReactDom from 'react-dom';


export default class LoadVerificationCode extends Component{

    render(){
        return(
            <div id="verificationCodeInput">
                <div class="grid-item" style={{paddingTop: 0,}}>
                    <input onChange={this.onInputChange} name="PhoneNumber" placeholder="Phone number" class="shadowBorder"></input>
                </div>
                <div id="buttonGrid" class="grid-item">
                    <button id="phoneNumberId" class="button shadowBorder" onKeyPress={this.isNumberKey} onClick={this.onStartClick}>Continue</button>
                </div>
            </div>
        );
    }
}

ReactDOM.render(<LoadVerificationCode></LoadVerificationCode>,document.getElementById("logInPart"));