import React from "react";
import { useNavigate } from "react-router-dom";
import '../../assets/css/Style.css';
import axios from "axios";
import { register } from '../../services/API.js';

class Register extends React.Component{
    state = {
        data:{
            "nombre":"",
            "correo":"",
            "contraseña":"",
            "confirmar":""
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
        if (this.state.data.contraseña === this.state.data.confirmar) {
            axios.post(register, this.state.data)
            .then(res => {
                this.props.navigate("/");
            }).catch(error => {
                console.log(error);
                this.setState({
                    error: true,
                    msg: "Hubo un error"
                });
            });
        }else{
            this.setState({
                error: true,
                msg: "Las contraseñas no coinciden."
            });
        }
    }

    render(){
        return(
            <React.Fragment>
                <div className="wrapper fadeInDown">
                    <div id="formContent">
                        
                        <div className="fadeIn first">
                            <h2>Registro</h2>
                        </div>
                        <form onSubmit={this.handleSubmit}>
                            <input type="text" id="nombre" className="fadeIn second" name="nombre"placeholder="Nombre" required onChange={this.handleChange} />
                            <input type="text" id="correo" className="fadeIn second" name="correo"placeholder="Correo" required onChange={this.handleChange} />
                            <input type="password" id="password" className="fadeIn third" name="contraseña" placeholder="Contraseña" required onChange={this.handleChange} />
                            <input type="password" id="confirmar" className="fadeIn third" name="confirmar" placeholder="Confirmar Contraseña" required onChange={this.handleChange} />
                            <input type="submit" className="fadeIn fourth" value="Registrarme" />
                        </form>
                        {this.state.error === true &&
                            <div className="alert alert-danger" role="alert">
                                {this.state.msg}
                            </div>  
                        }
                        <div id="formFooter">
                            <a className="underlineHover" href="/">Iniciar Sesión</a>
                        </div>
                    </div>
                </div>
            </React.Fragment>
        );
    }
}

function WithNavigate(props) {
    let navigate = useNavigate();
    return <Register {...props} navigate={navigate} />
}

export default WithNavigate