import React from "react";
import '../../assets/css/Style.css';

class Header extends React.Component{
    render(){
        return(
            <nav id="nav">
                <h3>Gestor de vuelos</h3>
                <button id="logout">Cerrar sesión</button>
            </nav>
        );
    }
}

export default Header