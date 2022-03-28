import React from "react";
import { useNavigate } from "react-router-dom";
import axios from "axios";
import '../../assets/css/Style.css';
import Header from "../Common/Header";
import { getall, remove } from '../../services/API.js';

class Vuelos extends React.Component{
    state={
        vuelos:[]
    }

    updateVuelo = id =>{
        this.props.navigate(`/update/${id}`);
    }

    addVuelo = () =>{
        this.props.navigate("/add");
    }

    deleteVuelo = id =>{
        let token = localStorage.getItem("token");
        axios.defaults.headers.common = {'Authorization': `Bearer ${token}`}
        axios.delete(`${remove}${id}`)
        .then(res => {
            this.componentDidMount();
        });
    }

    componentDidMount(){
        let token = localStorage.getItem("token");
        axios.defaults.headers.common = {'Authorization': `Bearer ${token}`}
        axios.get(getall)
        .then(res =>{
            this.setState({
                vuelos: res.data.data
            });
        });
    }

    render(){
        return(
            <>
                <Header />
                <div className="container my-5">
                    <input type="button" id="btnS" onClick={this.addVuelo} value="Añadir" />
                    <table className="table table-hover table-bordered">
                        <thead>
                            <tr>
                                <th scope="col">ID</th>
                                <th scope="col">Origen</th>
                                <th scope="col">Destino</th>
                                <th scope="col">Partida</th>
                                <th scope="col">Regreso</th>
                                <th scope="col">Pasajeros</th>
                                <th></th>
                            </tr>
                        </thead>
                        <tbody>
                            {this.state.vuelos.map((value, index) => {
                                return (
                                    <tr key={index}>
                                        <td>{value.id}</td>
                                        <td>{value.origen}</td>
                                        <td>{value.destino}</td>
                                        <td>{value.partida}</td>
                                        <td>{value.regreso}</td>
                                        <td>{value.pasajeros}</td>
                                        <td>
                                            <input type="button" id="btnS" onClick={() => this.updateVuelo(value.id)} value="Editar" />
                                            <input type="button" id="btnS" style={{"background":"gray"}} onClick={() => this.deleteVuelo(value.id)} value="Eliminar" />
                                        </td>
                                    </tr>
                                )
                            })}
                        </tbody>
                    </table>
                </div>
            </>
        );
    }
}

function WithNavigate(props) {
    let navigate = useNavigate();
    return <Vuelos {...props} navigate={navigate} />
}

export default WithNavigate