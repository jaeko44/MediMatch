import { HttpClient, json } from 'aurelia-fetch-client';
import { inject } from 'aurelia-framework';

@inject(HttpClient)
export class CreateMP {
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
    hoursActive: any[];
    notes: string;
    email: string;
    phoneNumber: string;
    reviews: any[];
    facilityId: any;
    facility: {
        id: any;
        facilityName: string;
        location: {
            id: any;
            postCode: string;
            street: string;
            streetNo: string;
            suburb: string;
            coordinates: {
                id: any;
                latitude: number;
                longtitude: number;
                address: any;
                addressId: any;
            };
            facility: any;
            facilityId: any;
        };
        website: string;
        phoneNo: string;
        email: string;
        medicalProfessionals: any[];
        facilitySupport: any[];
    };
}
interface hoursActive {
    id: any;
    weekDays: string;
    hours: string;
    medicalProfessionalId: any;
}
interface review {
    id: any;
    title: string;
    rating: number;
    comment: string;
    time: Date;
    userId: number;
    medicalProfessionalId: any;
}