import { HttpClient } from 'aurelia-fetch-client';
import { inject, observable } from 'aurelia-framework';
import { Data } from '../data';
import { Common } from '../common';

@inject(HttpClient, Data, Common)
export class DetailFacility {
    http: HttpClient;
    public facility: facility;
    public medicalId: number;
    public googleMapsKey: string = "AIzaSyBkkj6qQ0qLfTGHYJPuL9asFAAk9hlguJ4";
    public facilityAddress: string;
    public clientAddress: string;
    private data: Data;
    private common: Common;
    @observable
    private showDirections: boolean = false;

    constructor(http: HttpClient, data: Data, common: Common) {
        this.http = http;
        this.data = data;
        this.common = common;
    }

    private showDirectionsChanged(newValue: string, oldValue: string) {
        console.log("Showing Directions: " + this.showDirections);
        if (this.showDirections == true) {
            this.getLocation();
            if (this.clientAddress == null) {
                this.common.notify("GET", "User Location", "error");
            }
            else {
                this.common.notify("SHOW", "Directions", "success");
            }
        }
    }

    activate(params: { id: string; }) {
        this.http.fetch('api/Facilities/' + params.id)
            .then(result => result.json() as Promise<facility>)
            .then(data => {
                this.facility = data;
                this.facilityAddress = this.facility.location.streetNo + "+ " +
                    this.facility.location.street + ", " +
                    this.facility.location.suburb + " + " +
                    this.facility.location.state + " + " +
                    this.facility.location.postCode;
                this.clientAddress = this.facilityAddress;
                this.getLocation();
                console.log(data);
            });
    }
    getLocation() {
        if (this.clientAddress == null) {
            if (navigator.geolocation) {
                navigator.geolocation.getCurrentPosition((position) => {
                    // create the map here, because we only have access to position inside of this function
                    // even if we store in a global variable, it only gets updated once this callback runs
                    console.log(position);
                    this.http.fetch('https://maps.googleapis.com/maps/api/geocode/json?latlng=' + position.coords.latitude + "," + position.coords.longitude + "&key=" + this.googleMapsKey)
                        .then(result => result.json() as Promise<any>)
                        .then(data => {
                            console.log(data);
                            this.clientAddress = data.results[0].formatted_address;
                            console.log(this.clientAddress);
                        }).catch(error => {
                            this.common.notify("GET", "User Address", "error");
                            this.clientAddress = null;
                            return null;
                        });
                });
            } else {
                this.clientAddress = null;
                return null;
            }
        }
        else {
            return this.clientAddress;
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
        state: string;
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