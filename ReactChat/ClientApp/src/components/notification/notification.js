import React, { Component }  from 'react';
import '../../styles/importStyles';

export default class Notification extends Component{

    static loadSuccessNotification(message){
        this.removeOldNotification();
        document.getElementById("result").classList.add("successNotification");
        document.getElementById("messageElem").nodeValue=message;
    }

    static loadErrorNotification(message){
        this.removeOldNotification();
        document.getElementById("result").classList.add("errorNotification");
    }

    static removeOldNotification(){
        document.getElementById("messageElem").nodeValue="";
        document.getElementById("result").classList.remove("successNotification");
        document.getElementById("result").classList.remove("errorNotification");
    }

    render(){
        return(
            <div class="notificationPosition">
                <div id="result"></div>
                <div id="message" class="messagePosition">
                    <p id="messageElem" class="messageText"></p>
                </div>
            </div>
        );
    }
}