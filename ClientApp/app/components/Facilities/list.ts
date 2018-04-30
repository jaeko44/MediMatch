import { HttpClient } from 'aurelia-fetch-client';
import { inject } from 'aurelia-framework';

@inject(HttpClient)
export class ListFacilities {
    public Facilities: any[];

    constructor(http: HttpClient) {

        http.fetch('api/Facilities')
            .then(result => result.json() as Promise<any[]>)
            .then(data => {
                this.Facilities = data;
            });
    }
}