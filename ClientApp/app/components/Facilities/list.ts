import { HttpClient } from 'aurelia-fetch-client';
import { inject } from 'aurelia-framework';

@inject(HttpClient)
export class Fetchdata {
    public Facility: facility[];

    constructor(http: HttpClient) {
        http.fetch('api/Facilities')
            .then(result => result.json() as Promise<facility[]>)
            .then(data => {
                this.Facility = data;
            });
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
    email: string;
    medicalProfessionals: any[];
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