import React, { Component }  from 'react';
import "../../styles/importStyles";

export default class Loading extends Component{

    static startLoading(){
        document.getElementById("loadingPosition").classList.add("loadingAppearance");
    }

    static endloading(){
        document.getElementById("loadingPosition").classList.remove("loadingAppearance");
    }

    render(){
        return(<div id="loadingPosition" class = "loadingPosition">
            <img  class="loadingImage" src="https://image.flaticon.com/icons/svg/552/552621.svg"></img>
        </div>);
    }
}
