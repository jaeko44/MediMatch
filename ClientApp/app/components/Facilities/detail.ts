import { HttpClient } from 'aurelia-fetch-client';
import { inject } from 'aurelia-framework';

@inject(HttpClient)
export class DetailFacility {
    http: HttpClient;
    public facility: facility[];
    public medicalId: number;

    constructor(http: HttpClient) {
        this.http = http;
    }
    activate(params: { id: string; }) {
        this.http.fetch('api/Facility/' + params.id)
            .then(result => result.json() as Promise<facility[]>)
            .then(data => {
                this.facility = data;
            });
    }

    getfeedbackRating() {

    }
}

interface facility {
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
    website: string;
    phoneNo: string;
    email: string;
    medicalProfessionals: any[];
    facilitySupport: any[];
}
interface address {
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
}
interface decimalDegrees {
    id: any;
    latitude: number;
    longtitude: number;
}
interface facilitySupport {
    id: any;
    supportName: string;
    supportDescription: string;
}