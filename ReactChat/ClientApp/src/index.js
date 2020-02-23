import 'bootstrap/dist/css/bootstrap.css';
import React from 'react';
import ReactDOM from 'react-dom';
import App from './App';
import registerServiceWorker from './registerServiceWorker';
import Header from './components/header/header';
import Loading from './components/loading/Loading';
import Notification from './components/notification/notification';

const baseUrl = document.getElementsByTagName('base')[0].getAttribute('href');
const rootElement = document.getElementById('root');
const loadingElement = document.getElementById('loading');

ReactDOM.render(<Loading></Loading>,loadingElement);
ReactDOM.render(<App></App>,rootElement);
registerServiceWorker();

