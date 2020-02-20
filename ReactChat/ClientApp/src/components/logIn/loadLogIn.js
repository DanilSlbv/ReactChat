import React, { Component } from 'react';
import ReactDOM from 'react-dom';
import MainPage from '../main/mainPage';
import '../../styles/importStyles'; 
import Slider from 'infinite-react-carousel';
import createAccount from '../../services/requests/ApplicationUserRequests';

export default class LoadLogIn extends Component
{
    
    constructor(props) {
        super(props);
        this.state={
            UserName:'',
            FirstName:'',
            LastName:'',
            PhoneNumber:'',
            VerificationCode:''
        }
        this.onStartClick = this.onStartClick.bind(this);
        this.onInputChange = this.onInputChange.bind(this);
    }

    onStartClick(event) {
        debugger;
        createAccount();
    }

    onInputChange(event){
        const target = event.target;
        const value = target.value;
        this.setState({
            [target.name]:value
        });
    }

    render() {
        return (<div id="logInForm" class="form-center">
                <div class="grid-item" style={{paddingBottom: 0, paddingTop:0}}>
                    <label class="bigLabel">LOG IN</label>
                </div>
                <div class="grid-item" style={{paddingBottom: 0,}}>
                    <label class="smallLabel">New user? Just enter phone number.</label>
                </div>
                <div class="grid-item" style={{paddingTop: 0,}}>
                    <input onChange={this.onInputChange} name="PhoneNumber" placeholder="Phone number" class="shadowBorder"></input>
                </div>
                <div class="grid-item">
                    <button class="shadowBorder" onClick={this.onStartClick}>START</button>
                </div>
            </div>);
    }
}