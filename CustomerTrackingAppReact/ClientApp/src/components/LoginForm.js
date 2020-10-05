import React, { Component, useState, useEffect } from 'react';
import './styles/login.css';
import './styles/details.css';
import { Redirect } from 'react-router-dom';
import { apiPOST, apiGET } from '../functions/api';
import { useHistory } from "react-router-dom";

export default function LoginForm(props)
{
    const usernameRef = React.useRef();
    const passwordRef = React.useRef();
    const [loading, setLoading] = useState(true);
    const [user, setUser] = useState(null);   
    // üst satýrla aþaðýsý ayný þey..
    /*const userState = useState(null);
    const user = userState[0];
    const setUser = userState[1];*/

    const history = useHistory();

    const getOnlineUser = async function () {
        const response = await apiGET('api/User/GetOnlineUser');


        if (response.success && response.data != null) {
            setUser({ username: response.data.username });
        }
        else {
            setUser(null);
        }
        setTimeout(()=> setLoading(false),1000);
    }

    const getOnlineUserHandler = function () {
        getOnlineUser();
    }

    useEffect(getOnlineUserHandler, []);

    const tryLogin = async function() {
        const username = usernameRef.current.value;
        const password = passwordRef.current.value;

        const response = await apiPOST('api/User/Login', { Username: username, Password: password });

        if (response.success) {
            setUser({ username: username });
            history.push("/");
        }
        else {
            alert(response.errorMessage);
        }
    }
    const tryLogout = async function () {
        const response = await apiPOST('api/User/Logout');
        if (response.success) {
            setUser(null);
        }
        else {
            alert(response.errorMessage);
        }
    }
    //const redirect = <Redirect to="/newsfeed" />;
    const online = (
        <div>
            <div>WELCOME {user?.username}</div>
            <div><button className="btn" onClick={tryLogout}>Logout</button></div>
        </div>
    );
    const pending = (
        <div>
            Loading !!!
        </div>
    );

    const offline = (
        <div className="user-login-form-out">
            <div className="user-login-form">
                <h1>Login</h1>
                <div className="login-col">Username</div>
                <div><input className="login-input" type="text" ref={usernameRef} /></div>
                <div className="login-col">Password</div>
                <div><input className="login-input" type="password" ref={passwordRef} /></div>
                <div>
                    <button className="btn" onClick={tryLogin}>Login</button>
                </div>
            </div>
        </div>
    );

    const result = loading ? pending : ( user ? online: offline );

    return result;
}
