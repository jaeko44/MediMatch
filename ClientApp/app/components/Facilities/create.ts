import { HttpClient, json } from 'aurelia-fetch-client';
import { inject, Aurelia } from 'aurelia-framework';
import { Data } from '../data'

@inject(HttpClient, Data)
export class CreateFacility {
    http: HttpClient;
    public facility: any;
    public medicalId: number;
    private token: string;
    private data: Data;

    constructor(http: HttpClient, data: Data) {
        this.data = data;
        console.log("Constructor: Create Facility Triggered");
        var token = sessionStorage.getItem('token');
        this.token = token;
        this.http = http;
    }

    async CreateFacility() {
        try {
            let result = await this.data.createFacility(this.facility);
            this.facility = null;
            return result;
        } catch (error) {
            console.error(error);
            return null;
        }
    }
}