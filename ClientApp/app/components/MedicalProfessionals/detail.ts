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
    services: any[];
    hoursActive: any[];
    notes: string;
    email: string;
    phoneNumber: string;
    reviews: any[];
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
            };
        };
        locationId: any;
        website: string;
        phoneNo: string;
        email: string;
        medicalProfessionals: any[];
        facilitySupport: any[];
    };
    facilityId: any;
}
interface service {
    id: any;
    category: string;
}
interface hoursActive {
    id: any;
    weekDays: string;
    hours: string;
}
interface review {
    id: any;
    title: string;
    rating: number;
    comment: string;
    time: Date;
    userId: number;
    medicalProfessionalId: any;
    medicalProfessional: {
        id: any;
        firstMidName: string;
        lastName: string;
        services: any[];
        hoursActive: any[];
        notes: string;
        email: string;
        phoneNumber: string;
        reviews: any[];
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
                };
            };
            locationId: any;
            website: string;
            phoneNo: string;
            email: string;
            medicalProfessionals: any[];
            facilitySupport: any[];
        };
        facilityId: any;
    };
}