import React, { Component } from 'react';
import { Route } from 'react-router';
import { Layout } from './components/Layout';
import { Login } from './components/Login';
import { Newsfeed } from './components/Newsfeed';
import { FetchData } from './components/FetchData';
import { Users } from './components/Users';
import { Link, useHistory } from "react-router-dom";


import './custom.css'

export default class App extends Component {
    static displayName = App.name;


    render() {
    return (
        <Layout>
            <Route exact path='/' component={Login} />
            <Route exact path='/newsfeed' component={Newsfeed} />
            <Route path='/users' component={Users} />
            <Route path='/fetch-data' component={FetchData} />
        </Layout>
    );
  }
}
