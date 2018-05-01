import { HttpClient } from 'aurelia-fetch-client';
import { inject } from 'aurelia-framework';

@inject(HttpClient)
export class DetailFacility {
    http: HttpClient;
    public facility: facility;
    public medicalId: number;
    public googleMapsKey: string = "AIzaSyBkkj6qQ0qLfTGHYJPuL9asFAAk9hlguJ4";
    public facilityAddress: string;
    public clientAddress: string;

    constructor(http: HttpClient) {
        this.http = http;
    }
    activate(params: { id: string; }) {
        this.http.fetch('api/Facilities/' + params.id)
            .then(result => result.json() as Promise<facility>)
            .then(data => {
                this.facility = data;
                this.facilityAddress = this.facility.location.streetNo + "+" +
                    this.facility.location.street + "," +
                    this.facility.location.suburb + "+" +
                    this.facility.location.postCode;
                this.clientAddress = this.facilityAddress;
                this.getLocation();
                console.log(data);
            });
    }
    getLocation() {
        if (navigator.geolocation) {
            navigator.geolocation.getCurrentPosition((position) => {
                // create the map here, because we only have access to position inside of this function
                // even if we store in a global variable, it only gets updated once this callback runs
                this.http.fetch('https://maps.googleapis.com/maps/api/geocode/json?latlng=' + position.coords.latitude + "," + position.coords.longitude + "&key=" + this.googleMapsKey)
                    .then(result => result.json() as Promise<any>)
                    .then(data => {
                        console.log(data);
                        this.clientAddress = data.results[0].formatted_address;
                        console.log(this.clientAddress);
                    });
            });
        } else {
            this.clientAddress = this.facilityAddress;
        }
    }
    showPosition(position, self) {
        console.log(position);
        //this.clientAddress = position.coords.latitude + "+" + position.coords.longitude;

        console.log(self.clientAddress);
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