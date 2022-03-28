import React from "react";
import '../../assets/css/Style.css';
import { useNavigate } from "react-router-dom";

class Header extends React.Component{
    logout = () =>{
        localStorage.removeItem("token");
        localStorage.removeItem("expire");
        this.props.navigate("/");
    }
    render(){
        return(
            <nav id="nav">
                <h3>Gestor de vuelos</h3>
                <button id="logout" onClick={this.logout}>Cerrar sesión</button>
            </nav>
        );
    }
}

function WithNavigate(props) {
    let navigate = useNavigate();
    return <Header {...props} navigate={navigate} />
}

export default WithNavigate