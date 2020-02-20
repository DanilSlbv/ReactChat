import React,{Component} from 'react';
import ReactDOM from 'react-dom';
import '../../styles/importStyles';
import LoadChats from './chats/chats';


export default class MainPage extends Component
{
    render(){
        return(<div><div id="chatsId"><LoadChats></LoadChats></div><div id="correspondenceId"></div></div>); 
    }
}