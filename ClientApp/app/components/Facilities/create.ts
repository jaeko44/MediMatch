import { HttpClient, json } from 'aurelia-fetch-client';
import { inject } from 'aurelia-framework';

@inject(HttpClient)
export class CreateMP {
    http: HttpClient;
    public facility: any;
    public medicalId: number;

    constructor(http: HttpClient) {
        this.http = http;
    }

    CreateFacility() {
        console.log(this.facility);
        this.http.fetch('api/Facilities', {
            method: 'post',
            body: JSON.stringify(this.facility),
            headers: new Headers({
                'Content-Type': 'application/json'
            })
        })
            .then(response => {
                // do whatever here
                delete this.facility;
                console.log(response);
            }).catch(error => console.log(error));
    }
}


interface facility {
    id: any;
    facilityName: string;
    phoneNo : string;
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