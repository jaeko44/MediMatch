import { HttpClient, json } from 'aurelia-fetch-client';
import { inject } from 'aurelia-framework';
import { activationStrategy } from 'aurelia-router';

@inject(HttpClient)
export class CreateMP {
    http: HttpClient;
    public medicalProfessional: any;
    public medic: any;
    public facility: any;
    public facilities: any[];
    public services: any[];
    public medicalId: number;

    constructor(http: HttpClient) {
        this.http = http;
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
                'Content-Type': 'application/json'
            })
        })
            .then(response => {
                // do whatever here
                //delete this.medicalProfessional;
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