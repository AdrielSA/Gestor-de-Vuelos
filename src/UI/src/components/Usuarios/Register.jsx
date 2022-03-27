import React from "react";
import { useNavigate } from "react-router-dom";

class Register extends React.Component{
    render(){
        return(
            <div>
                Register Page
            </div>
        );
    }
}

function WithNavigate(props) {
    let navigate = useNavigate();
    return <Register {...props} navigate={navigate} />
}

export default WithNavigate