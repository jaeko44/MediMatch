import { HttpClient, json } from 'aurelia-fetch-client';
import { inject } from 'aurelia-framework';
import { activationStrategy } from 'aurelia-router';
import { Data } from '../data';

@inject(HttpClient, Data)
export class CreateMP {
    http: HttpClient;
    private medicalProfessional: any;
    private medic: any;
    private facility: any;
    private facilities: any;
    private services: any;
    private medicalId: number;
    private token: string;
    private data: Data;

    constructor(http: HttpClient, data: Data) {
        this.http = http;
        this.data = data;
        this.resolveFacilities();
        this.resolveServices();
    }
    async resolveFacilities() {
        try {
            let data = await this.data.getFacilities();
            this.facilities = data;
            return data;
        } catch(error) {
            console.error(error);
            return null;
        }
    }
    async resolveServices() {
        try {
            let data = await this.data.getServices();
            this.services = data;
            return data;
        } catch(error) {
            console.error(error);
            return null;
        }
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