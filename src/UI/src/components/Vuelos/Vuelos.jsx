import React from "react";
import { useNavigate } from "react-router-dom";

class Vuelos extends React.Component{
    render(){
        return(
            <div>
                Vuelos Page
            </div>
        );
    }
}

function WithNavigate(props) {
    let navigate = useNavigate();
    return <Vuelos {...props} navigate={navigate} />
}

export default WithNavigate