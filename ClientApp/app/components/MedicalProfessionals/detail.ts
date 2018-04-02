import { HttpClient } from 'aurelia-fetch-client';
import { inject } from 'aurelia-framework';

@inject(HttpClient)
export class DetailMP {
    http: HttpClient;
    public medicalProfessional: medicalProfessional[];
    public medicalId: number;

    constructor(http: HttpClient) {
        this.http = http;
    }
    activate(params: { id: string; }) {
        this.http.fetch('api/MedicalProfessionals/' + params.id)
            .then(result => result.json() as Promise<medicalProfessional[]>)
            .then(data => {
                this.medicalProfessional = data;
            });
    }

    getfeedbackRating() {

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