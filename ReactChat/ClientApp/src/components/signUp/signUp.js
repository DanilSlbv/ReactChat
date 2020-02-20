import React, { Component } from 'react';
import ReactDOM from 'react-dom';
import MainPage from '../main/mainPage';
import '../../styles/importStyles'; 

export default class LoadLogIn extends Component
{
    constructor(props) {
        super(props);
        this.onStartClick = this.onStartClick.bind(this);
    }

    onStartClick() {
        ReactDOM.render(<MainPage></MainPage>, document.getElementById("root"));
    }

    render() {
        return (<div id="logInForm" class="form-center">
                <div class="grid-item">
                    <label>LOG IN</label>
                </div>
                <div class="grid-item">
                    <input class="shadowBorder"></input>
                </div>
                <div class="grid-item">
                    <button class="shadowBorder" onClick={this.onStartClick}>START</button>
                </div>
            </div>);
    }
}