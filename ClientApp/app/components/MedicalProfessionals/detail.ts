import { HttpClient } from 'aurelia-fetch-client';
import { inject } from 'aurelia-framework';

@inject(HttpClient)
export class DetailMP {
    http: HttpClient;
    public medicalProfessional: any;
    public medicalId: number;

    constructor(http: HttpClient) {
        this.http = http;
    }
    activate(params: { id: string; }) {
        this.http.fetch('api/MedicalProfessionals/' + params.id)
            .then(result => result.json() as Promise<any>)
            .then(data => {
                this.medicalProfessional = data;
                console.log(data);
            });
    }

    getfeedbackRating() {

    }
}