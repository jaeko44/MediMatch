import { HttpClient, json } from 'aurelia-fetch-client';
import { inject } from 'aurelia-framework';
import { activationStrategy } from 'aurelia-router';

@inject(HttpClient)
export class CreateMP {
    http: HttpClient;
    private medicalProfessional: any;
    private medic: any;
    private facility: any;
    private facilities: any[];
    private services: any[];
    private medicalId: number;
    private token: string;

    constructor(http: HttpClient) {
        this.http = http;
        var token = sessionStorage.getItem('token');
        this.token = token;
        //let services: any[] = [{ id: 1, category: "General Practitioner" }, { id: 2, category: "Dentist" }];
        let medic: any = { firstMidName: "Test", lastName: "TestL" };
        //medic.services = services;
        this.medicalProfessional = medic;
        http.fetch('api/Facilities')
            .then(result => result.json() as Promise<any[]>)
            .then(data => {
                this.facilities = data;
            });
        console.log("this facilities: ");
        console.log(this.facilities);
        http.fetch('api/Services')
            .then(result => result.json() as Promise<any[]>)
            .then(data => {
                this.services = data;
            });
    }

    CreateMedicalProfessional() {
        console.log("Sending the following Medical Professional to Server");
        console.log(this.medicalProfessional);
        this.http.fetch('api/MedicalProfessionals', {
            method: 'post',
            body: JSON.stringify(this.medicalProfessional),
            headers: new Headers({
                'Authorization': 'Bearer ' + this.token,
                'Content-Type': 'application/json'
            })
        })
            .then(response => {
                // do whatever here
                //delete this.medicalProfessional;
                this.facility = null;
                if (response.status == 401) {
                    console.log("Unauthorized request");
                }
                console.log(response);
            }).catch (error => console.log(error));
    }
    attached() {

    }
    addService() {
        for (let service of this.services) {
            if (service.id == this.medicalProfessional.serviceId) {
                console.log("Service matched");
                var input = <HTMLInputElement>document.getElementById('serviceTags');
                input.value += " " + service.category;
                this.medicalProfessional.serviceId = null;
            }
        }
    }
}