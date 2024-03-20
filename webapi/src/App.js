import './App.css';
import React from 'react';
import { BrowserRouter as Router, Route, Switch } from 'react-router-dom';
import Login from './components/Login';
import Registration from './components/Registration';

function App() {
    return (
        <Router>
            <div>
                <h1>User Authentication and Registration</h1>
                <Switch>
                    <Route exact path="/" component={Login} />
                    <Route path="/register" component={Registration} />
                </Switch>
            </div>
        </Router>
    );
}

export default App;
