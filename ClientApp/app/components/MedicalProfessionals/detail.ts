import { HttpClient } from 'aurelia-fetch-client';
import { inject } from 'aurelia-framework';

@inject(HttpClient)
export class Detail {
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
}

interface medicalProfessional {
    medicalId: number;
    facilityName: string;
    lastName: string;
    firstMidName: string;
    location: {
        addressId: number;
        postCode: number;
        street: number;
        streetNo: number;
        suburb: string;
        coordinates: {
            latitude: number;
            longtitude: number;
        };
    };
    serviceActive: {
        activeId: number;
        weekDays: string;
        hours: string;
    };
    notes: string;
    website: string;
    email: string;
    phoneNumber: string;
    services: service[];
    facilities: facility[];
    feedback: reviews[];
}
interface service {
    serviceId: number;
    serviceType: string;
}
interface facility {
    serviceId: number;
    support: string;
}
interface address {
    addressId: number;
    postCode: number;
    street: number;
    streetNo: number;
    suburb: string;
    coordinates: {
        latitude: number;
        longtitude: number;
    };
}
interface decimalDegrees {
    latitude: number;
    longtitude: number;
}
interface hoursActive {
    activeId: number;
    weekDays: string;
    hours: string;
}
interface reviews {
    reviewId: number;
    title: string;
    rating: number;
    comment: string;
    time: Date;
    userId: number;
}
