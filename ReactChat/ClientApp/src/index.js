import 'bootstrap/dist/css/bootstrap.css';
import React from 'react';
import ReactDOM from 'react-dom';
import App from './App';
import registerServiceWorker from './registerServiceWorker';
import Header from './components/header/header';
import Loading from './components/loading/Loading';

const baseUrl = document.getElementsByTagName('base')[0].getAttribute('href');
const rootElement = document.getElementById('root');

ReactDOM.render(<Loading></Loading>,document.getElementById("loadingId"));
ReactDOM.render(<App></App>,rootElement);
registerServiceWorker();

