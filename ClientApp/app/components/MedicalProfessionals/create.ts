import { HttpClient, json } from 'aurelia-fetch-client';
import { inject } from 'aurelia-framework';

@inject(HttpClient)
export class Detail {
    http: HttpClient;
    public medicalProfessional: medicalProfessional;
    public medicalId: number;

    constructor(http: HttpClient) {
        this.http = http;
    }

    CreateMedicalProfessional() {
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
                delete this.medicalProfessional;
                console.log(response);
            }).catch (error => console.log(error));
    }
}

interface medicalProfessional {
    id: any;
    firstMidName: string;
    lastName: string;
    serviceCategory: string;
    /** Foreign key for Facility */
    facilityId: any;
    hoursActive: any[];
    notes: string;
    email: string;
    phoneNumber: string;
    feedback: any[];
}
interface hoursActive {
    id: any;
    weekDays: string;
    hours: string;
}
interface reviews {
    id: any;
    title: string;
    rating: number;
    comment: string;
    time: Date;
    userId: number;
}