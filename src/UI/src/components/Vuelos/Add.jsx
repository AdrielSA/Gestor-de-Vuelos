import React from "react";
import { useNavigate } from "react-router-dom";
import axios from "axios";
import '../../assets/css/Style.css';
import { add } from "../../services/API";
import Header from "../Common/Header";

class Add extends React.Component{
    state={
        data:{
            "origen": "",
            "destino": "",
            "partida": "",
            "regreso": "",
            "pasajeros": 0
        }
    }

    handleChange = event => {
        this.setState({
            data:{
                ...this.state.data,
                [event.target.name] : event.target.value
            }
        })
    }

    handleSubmit = event => {
        event.preventDefault();
        let token = localStorage.getItem("token");
        axios.defaults.headers.common = {'Authorization': `Bearer ${token}`}
        axios.post(add, this.state.data)
        .then(res => {
            this.props.navigate("/vuelos");
        });
    }

    render(){
        return(
            <>
                <Header />
                <div className="wrapper fadeInDown">
                    <div id="formContent">
                        <div className="fadeIn first">
                            <h2>Agregar vuelo</h2>
                        </div>
                        <form className="form-horizontal" onSubmit={this.handleSubmit}>
                            <input type="text" id="origen" className="fadeIn second" name="origen"
                                placeholder="Origen" required onChange={this.handleChange} />
                            <input type="text" id="destino" className="fadeIn second" name="destino"
                                placeholder="Destino" required onChange={this.handleChange} />
                            <input type="text" id="partida" className="fadeIn third" name="partida"
                                placeholder="Partida" required onChange={this.handleChange} />
                            <input type="text" id="regreso" className="fadeIn third" name="regreso"
                                placeholder="Regreso" required onChange={this.handleChange} />
                            <input type="text" id="pasajeros" className="fadeIn third" name="pasajeros"
                                placeholder="Pasajeros" required onChange={this.handleChange} />
                            <input type="submit" className="fadeIn fourth" value="Crear" />
                        </form>
                        <div id="formFooter">
                            <a className="underlineHover" href="/vuelos">Cancelar</a>
                        </div>
                    </div>
                </div>
            </>
        );
    }
}

function WithNavigate(props) {
    let navigate = useNavigate();
    return <Add {...props} navigate={navigate} />
}

export default WithNavigate