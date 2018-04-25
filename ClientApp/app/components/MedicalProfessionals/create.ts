import { HttpClient, json } from 'aurelia-fetch-client';
import { inject } from 'aurelia-framework';
import { activationStrategy } from 'aurelia-router';

@inject(HttpClient)
export class CreateMP {
    http: HttpClient;
    public medicalProfessional: any;
    public medicalId: number;

    constructor(http: HttpClient) {
        this.http = http;
        //let services: any[] = [{ id: 1, category: "General Practitioner" }, { id: 2, category: "Dentist" }];
        let medic: any = { firstMidName: "Test", lastName: "TestL", id: 1 };
        //medic.services = services;
        this.medicalProfessional = medic;
    }

    CreateMedicalProfessional() {
        console.log("Sending the following Medical Professional to Server");
        console.log(this.medicalProfessional);
        this.http.fetch('api/MedicalProfessionals', {
            method: 'post',
            body: JSON.stringify(this.medicalProfessional),
            headers: new Headers({
                'Content-Type': 'application/json'
            })
        })
            .then(response => {
                // do whatever here
                //delete this.medicalProfessional;
                console.log(response);
            }).catch (error => console.log(error));
    }
}