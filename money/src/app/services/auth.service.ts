
import { Injectable } from "@angular/core";
import { HttpClient } from "@angular/common/http";

@Injectable({
    providedIn: 'root'
})

export class AuthService{

    private userAuthPortal: boolean = false;
    private token: any;
    private user: any;

    constructor (private httpClient: HttpClient){

    }

    checkToken(){
        return Promise.resolve(true);
    }   

    authUser(status: boolean){    
        localStorage.setItem('userAuthPortal', JSON.stringify(status));
        this.userAuthPortal = status;
    }

    UserIsAuth(): Promise<boolean>{
        this.userAuthPortal = localStorage.getItem('userAuthPortal') == 'true';
        return Promise.resolve(this.userAuthPortal);
    }

    setToken(token: string){
        localStorage.setItem('token', token)
        this.token = token;
    }

    get getToken() {
        this.token = localStorage.getItem('token');
        return this.token;
    }

    cleanToken(){
        this.token = null;
        this.user = null;
    }

    cleanUserData(){
        this.authUser(false);
        this.cleanToken();
        localStorage.clear();
        sessionStorage.clear();
    }

    setEmailUser(email: string){
        localStorage.setItem('emailUser', email);
    }

    getEmailUser(){
        var emailUserLogged = localStorage.getItem('emailUser');

        if (emailUserLogged){
            return emailUserLogged;
        }
        else
        {
            this.cleanUserData();
            return "";
        }
    }
}

