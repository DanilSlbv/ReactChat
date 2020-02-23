import React from 'react';
import ReactDOM from 'react-dom';
import '../../styles/importStyles';

export default class Header extends React.Component{
    constructor(props){
        super(props);
        this.onButnClick=this.onButnClick.bind(this);
    }


    onButnClick(event){
        document.getElementById("settingsBtn").classList.add("rotate-animation");
    }

    render(){
        return(<div class="header">
            <div class="elementHeaderLeft">
                <button id="searchBtn" class ="btn btn-border"></button>
            </div>
            <div class="elementHeaderRight">
                <button id="settingsBtn" class="btn btn-boarder" onClick={this.onButnClick}><img src="https://image.flaticon.com/icons/svg/2099/2099058.svg" class="imgStyle"></img></button>
                <button id="screenLockBrn" class = "btn btn-border"><img src="https://image.flaticon.com/icons/svg/481/481195.svg"></img></button>
            </div>
        </div>);
    }
}


