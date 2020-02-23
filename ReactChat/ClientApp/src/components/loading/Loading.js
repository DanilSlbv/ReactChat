import React, { Component }  from 'react';
import "../../styles/importStyles";

export default class Loading extends Component{
    render(){
        return(<div class = "loadingPosition">
            <img  class="loadingImage" src="https://image.flaticon.com/icons/svg/1665/1665580.svg" width="70px" height="70px"></img>
        </div>);
    }
}