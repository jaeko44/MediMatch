import { HttpClient, json } from 'aurelia-fetch-client';
import { inject, Aurelia } from 'aurelia-framework';
import { Authentication } from '../authentication'

@inject(HttpClient, Authentication)
export class CreateFacility {
    http: HttpClient;
    public facility: any;
    public medicalId: number;

    constructor(http: HttpClient, authentication: Authentication) {
        //
        console.log("Constructor: Create Facility Triggered");
        var auth_token = localStorage.getItem("auth_token");
        var token = sessionStorage.getItem('access_token');
        console.log(token);
        var allCookies = document.cookie;
        this.http = http;
    }

    CreateFacility() {
        console.log(this.facility);
        this.http.fetch('api/Facilities', {
            method: 'post',
            body: JSON.stringify(this.facility),
            headers: new Headers({
                'Content-Type': 'application/json'
            })
        })
            .then(response => {
                // do whatever here
                delete this.facility;
                console.log(response);
            }).catch(error => console.log(error));
    }
}