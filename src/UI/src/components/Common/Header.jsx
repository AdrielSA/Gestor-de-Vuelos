import React from "react";
import '../../assets/css/Style.css';
import { useNavigate } from "react-router-dom";

class Header extends React.Component{
    state={
        rol:""
    }

    logout = () =>{
        let keysToRemove = ["token", "rol"];
        keysToRemove.forEach(key => localStorage.removeItem(key))
        this.props.navigate("/");
    }

    componentDidMount(){
        this.setState({
            rol: localStorage.getItem("rol")
        });
    }

    render(){
        return(
            <nav id="nav">
                <h3>Gestor de vuelos</h3>
                <div id="rightNav">
                    <span style={{"fontSize":"0.7rem"}}>{this.state.rol}</span>
                    <button id="logout" onClick={this.logout}>Cerrar sesión</button>
                </div>
            </nav>
        );
    }
}

function WithNavigate(props) {
    let navigate = useNavigate();
    return <Header {...props} navigate={navigate} />
}

export default WithNavigate