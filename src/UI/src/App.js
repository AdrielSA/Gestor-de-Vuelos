import React from 'react';
import './assets/css/App.css';
import 'bootstrap/dist/css/bootstrap.css';

import Login from './components/Usuarios/Login.jsx';
import Register from './components/Usuarios/Register.jsx';
import Vuelos from './components/Vuelos/Vuelos.jsx';

import {BrowserRouter as Router, Routes, Route} from 'react-router-dom';


function App() {
  return (
    <React.Fragment>
      <Router>
        <Routes>
          <Route exact path="/" element={ <Login /> } />
          <Route exact path="/register" element={ <Register /> } />
          <Route exact path="/vuelos" element={ <Vuelos /> } />
        </Routes>
      </Router>
    </React.Fragment>
  );
}

export default App;
