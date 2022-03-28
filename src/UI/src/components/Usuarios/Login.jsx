import React from "react";
import axios from "axios";
import '../../assets/css/Style.css';
import { useNavigate } from "react-router-dom";
import { login } from '../../services/API.js';

class Login extends React.Component {
    state = {
        data:{
            "correo":"",
            "contraseña":""
        }
    }

    handleChange = event => {
        this.setState({ 
            data:{
                ...this.state.data,
                [event.target.name]: event.target.value,
            },
            error:false,
            msg:""
        });
    }

    handleSubmit = event => {
        event.preventDefault();
        axios.post(login, this.state.data)
        .then(res => {
            localStorage.setItem("token", res.data.token);
            localStorage.setItem("expire", res.data.expiryDate);
            this.props.navigate("/vuelos");
        }).catch(error => {
            console.log(error);
            this.setState({
                error: true,
                msg: "Hubo un error."
            });
        });
    }

    render() {
        return (
            <React.Fragment>
                <div className="wrapper fadeInDown">
                    <div id="formContent">
                        
                        <div className="fadeIn first">
                            <h2>Inicio de Sesión</h2>
                        </div>
                        <form onSubmit={this.handleSubmit}>
                            <input type="text" id="login" className="fadeIn second" name="correo"placeholder="Correo" required onChange={this.handleChange} />
                            <input type="password" id="password" className="fadeIn third" name="contraseña" placeholder="Contraseña" required onChange={this.handleChange} />
                            <input type="submit" className="fadeIn fourth" value="Iniciar Sesión" />
                        </form>
                        {this.state.error === true &&
                            <div className="alert alert-danger" role="alert">
                                {this.state.msg}
                            </div>  
                        }
                        <div id="formFooter">
                            <a className="underlineHover" href="/register">Registrarse</a>
                        </div>
                    </div>
                </div>
            </React.Fragment>
        )
    }
}

function WithNavigate(props) {
    let navigate = useNavigate();
    return <Login {...props} navigate={navigate} />
}

export default WithNavigate