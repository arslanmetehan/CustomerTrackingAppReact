import React, { Component } from 'react';
import './styles/login.css';
import LoginForm from './LoginForm';


export class Login extends Component {
    static displayName = Login.name;



  render () {
    return (
    <LoginForm/>
    );
  }
}
