import { HttpClient } from 'aurelia-fetch-client';
import { inject } from 'aurelia-framework';

@inject(HttpClient)
export class ListMP {
    public medicalProfessionals: medicalProfessional[];

    constructor(http: HttpClient) {
        http.fetch('api/MedicalProfessionals')
            .then(result => result.json() as Promise<medicalProfessional[]>)
            .then(data => {
                this.medicalProfessionals = data;
                console.log("Succesfully received data from server");
                console.log(data);
            });
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