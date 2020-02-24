import axios from 'axios';


function GetIpAddress(){
    const publicIp = require('public-ip');
    (async()=>{
        return await publicIp.v4();
    })();
}

function GetLocation(){
    let ipAddress = GetIpAddress();
    axios.get("https://ipapi.co/"+ipAddress+"/json/").then(res=>{
    });
}

export default GetLocation;