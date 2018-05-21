import { HttpClient, json } from 'aurelia-fetch-client';
import { inject, Aurelia, observable } from 'aurelia-framework';
import { Data } from '../data'

@inject(HttpClient, Data)
export class UpdateFacility {
    http: HttpClient;
    public facility: any;
    public medicalId: number;
    private token: string;
    private data: Data;
    private facilities: any;
    @observable
    private selectedFacility: any;

    constructor(http: HttpClient, data: Data) {
        this.data = data;
        this.resolveFacilities();
        console.log("Constructor: Create Facility Triggered");
        var token = sessionStorage.getItem('token');
        this.token = token;
        this.http = http;
    }
    //This method gets triggered via @observable class which is observing the selectedFacility string.
    private selectedFacilityChanged(newValue: string, oldValue: string) : void {
        this.facility = this.facilities.find(f => f.id === newValue);
        console.log(this.facility);
    }
    async UpdateFacility() {
        try {
            let result;
            if (this.facility != null) {
                result = await this.data.updateFacility(this.facility)
            }
            else {
                result = await this.data.createFacility(this.facility);
            }
            console.log(result);
            return result;
        } catch (error) {
            console.error(error);
            return null;
        }
    }
    async resolveFacilities() {
        try {
            let data = await this.data.getFacilities();
            this.facilities = data;
            return data;
        } catch(error) {
            console.error(error);
            return null;
        }
    }

}