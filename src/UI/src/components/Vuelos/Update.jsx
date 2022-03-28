import React from "react";
import { useParams, useNavigate } from "react-router-dom";
import axios from "axios";
import Header from "../Common/Header";
import '../../assets/css/Style.css';
import { get, update } from "../../services/API";

class Update extends React.Component{
    state={
        data:{
            "origen": "",
            "destino": "",
            "partida": "",
            "regreso": "",
            "pasajeros": 0
        }
    }

    componentDidMount(){
        let token = localStorage.getItem("token");
        axios.defaults.headers.common = {'Authorization': `Bearer ${token}`}
        axios.get(`${get}${this.props.id}`)
        .then(res => {
            this.setState({
                data:{
                    origen: res.data.data.origen,
                    destino: res.data.data.destino,
                    partida: res.data.data.partida,
                    regreso: res.data.data.regreso,
                    pasajeros: res.data.data.pasajeros
                }
            });
        });
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
        axios.put(`${update}${this.props.id}`, this.state.data)
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
                            <h2>Actualizar vuelo</h2>
                        </div>
                        <form className="form-horizontal" onSubmit={this.handleSubmit}>
                            <input type="text" id="origen" className="fadeIn second" name="origen"
                                placeholder="Origen" value={this.state.data.origen} required onChange={this.handleChange} />
                            <input type="text" id="destino" className="fadeIn second" name="destino"
                                placeholder="Destino" value={this.state.data.destino} required onChange={this.handleChange} />
                            <input type="text" id="partida" className="fadeIn third" name="partida"
                                placeholder="Partida" value={this.state.data.partida} required onChange={this.handleChange} />
                            <input type="text" id="regreso" className="fadeIn third" name="regreso"
                                placeholder="Regreso" value={this.state.data.regreso} required onChange={this.handleChange} />
                            <input type="text" id="pasajeros" className="fadeIn third" name="pasajeros"
                                placeholder="Pasajeros" value={this.state.data.pasajeros} required onChange={this.handleChange} />
                            <input type="submit" className="fadeIn fourth" value="Actualizar" />
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
    let { id } = useParams();
    return <Update {...props} navigate={navigate} id={id} />
}

export default WithNavigate