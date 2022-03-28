import React from 'react';
import './assets/css/App.css';
import 'bootstrap/dist/css/bootstrap.min.css';

import Login from './components/Usuarios/Login.jsx';
import Register from './components/Usuarios/Register.jsx';
import Vuelos from './components/Vuelos/Vuelos.jsx';
import Update from './components/Vuelos/Update.jsx';
import Add from './components/Vuelos/Add.jsx';

import {BrowserRouter as Router, Routes, Route } from 'react-router-dom';
import PrivateRoute from './components/Common/PrivateRoute.jsx';


function App() {
  return (
    <React.Fragment>
      <Router>
        <Routes>
          <Route exact path="/" element={ <Login /> } />
          <Route exact path="/register" element={ <Register /> } />
          <Route exact path="/vuelos" element={ <PrivateRoute><Vuelos /></PrivateRoute> } />
          <Route exact path="/add" element={ <PrivateRoute><Add /></PrivateRoute> } />
          <Route exact path="/update/:id" element={ <PrivateRoute><Update /></PrivateRoute> } />
        </Routes>
      </Router>
    </React.Fragment>
  );
}

export default App;
