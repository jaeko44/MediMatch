import { HttpClient, json } from 'aurelia-fetch-client';
import { inject, Aurelia } from 'aurelia-framework';
import { Authentication } from '../authentication'

@inject(HttpClient, Authentication)
export class CreateFacility {
    http: HttpClient;
    public facility: any;
    public medicalId: number;
    private token: string;

    constructor(http: HttpClient, authentication: Authentication) {
        //
        console.log("Constructor: Create Facility Triggered");
        var token = sessionStorage.getItem('token');
        this.token = token;
        this.http = http;
    }

    CreateFacility() {
        console.log(this.facility);
        this.http.fetch('api/Facilities', {
            method: 'post',
            body: JSON.stringify(this.facility),
            headers: new Headers({
                'Authorization': 'Bearer ' + this.token,
                'Content-Type': 'application/json'
            })
        })
            .then(response => {
                // do whatever here
                this.facility = null;
                if (response.status == 401) {
                    console.log("Unauthorized request");
                }
                console.log(response);
            }).catch(error => console.log(error));
    }
}