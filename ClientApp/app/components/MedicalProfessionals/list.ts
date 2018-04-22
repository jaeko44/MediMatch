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