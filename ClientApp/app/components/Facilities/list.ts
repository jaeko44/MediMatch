import { inject } from 'aurelia-framework';
import { Data } from '../data';
import { Common } from '../common';

@inject(Data, Common)
export class ListFacilities {
    public Facilities: any;
    private data: Data;
    private filters: any;
    private common: any;


    constructor(data: Data, common: Common) {
        this.data = data;
        this.common = common;
        this.resolveFacilities();
    }
    async resolveFacilities() {
        try {
            let data = await this.data.getFacilities();
            this.Facilities = data;
            this.common.notify("GET", "Facilities", "success");
            return data;
        } catch (error) {
            this.common.notify("GET", "Facilities", "warning");
            console.error(error);
            return null;
        }
    }
    async SearchFacilities() {
        try {
            let data = await this.data.filterFacilities(this.filters);
            this.Facilities = data;
            console.log(data);
            this.common.notify("FILTER", "Facilities", "success");
            return data;
        } catch (error) {
            this.common.notify("FILTER", "Facilities", "warning");
            console.error(error);
            return null;
        }
    }
}