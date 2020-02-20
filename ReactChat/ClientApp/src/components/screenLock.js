import React from 'react';
import ReactDOM from 'react-dom';
import '../index.css'; 
import '../styles/animation.css';
import '../styles/grid.css'; 

function LoadScreenLock() {
    const clockElement = 
    <div class="screenLockContainer">
        <div class="clockContainer">
                <h2 class="clockItem">{new Date().toLocaleDateString()}</h2>
                <h2 class="clockItem">{new Date().toLocaleTimeString()}</h2>
        </div>
    </div>;
    ReactDOM.render(clockElement,document.getElementById("root"));
    setInterval(LoadScreenLock,1000);
}

export default LoadScreenLock;