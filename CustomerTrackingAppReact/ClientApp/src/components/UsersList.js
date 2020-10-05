import React, { Component, useState, useEffect } from 'react';
import { apiPOST, apiGET } from '../functions/api';
import { useHistory } from "react-router-dom";
import './styles/users.css';

export default function UsersList(props) {
    let users = [];
    const [user, setUser] = useState({
        Username: '',
        FullName: '',
        Email: '',
        Gender: '',
        Phone: '',
        Type: '',
        BirthYear: '',}); 
    const getActiveUsers = async function () {
        const response = await apiGET('api/User/GetActiveUsers');


        if (response.success && response.data != null) {
            users = response.data;

        }
        else {
            alert(response.errorMessage);
        }
        
    }
    const getActiveUserHandler = function () {
        getActiveUsers();
    }
    


   const listingUsers = () => {
        for (let i = 0; i < users.length; i++) {
            if (users[i] != null) {
              const list=  (<div className="users clearfix">
                    <div className="clearfix user-line-box" id="user-id-##user.Id##">
                        <a className="user-info profile-btn" href="'+ userProfileLink +'">{users[i].Username}</a>
                        <div className="user-info">users[i].FullName</div>
                        <div className="user-info">users[i].Email</div>
                        <div className="user-info">users[i].Gender</div>
                        <div className="user-info">users[i].Phone</div>
                        <div className="user-info">users[i].Type</div>
                        <div className="user-info">users[i].BirthYear</div>
                    </div>
                </div>)
            }
            else {
                break;
            }
        };
    }
    const userList = listingUsers();
    const userTable = (
        <div className="user-list clearfix" id="user-list">
            <div className="user-info-titles clearfix">
                <div>Username</div>
                <div>FullName</div>
                <div>Email</div>
                <div>Gender</div>
                <div>Phone</div>
                <div>Type</div>
                <div>Birth Year</div>
            </div>
            {userList}
        </div>
    );
    useEffect(getActiveUserHandler, []);
    //const result = createTable;
    return userTable;
}
