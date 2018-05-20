import { inject } from 'aurelia-framework';
import { Data } from '../../data';
import { Common } from '../../common';

@inject(Data, Common)
export class ListApplicationUsers {
    private applicationUsers: any;
    private services: any;
    private data: Data;
    private filters: any;
    private common: any;

    constructor(data: Data, common: Common) {
        this.data = data;
        this.common = common;
        var applicationUserPromise = this.resolveApplicationUsers();
    }
    async resolveApplicationUsers() {
        try {
            let data = await this.data.getUsers();
            this.applicationUsers = data;
            console.log(this.applicationUsers);
            this.common.notify("GET", "Resolved Application Users", "success");
            return data;
        } catch (error) {
            this.common.notify("GET", "Resolved Application Users", "error");
            console.error(error);
            return null;
        }
    }
    async SearchUsers() {
        try {
            let data = await this.data.filterMedicalProfessionals(this.filters);
            this.applicationUsers = data;
            console.log(data);
            this.common.notify("FILTER", "Application Users", "success");
            return data;
        } catch (error) {
            this.common.notify("FILTER", "Application Users", "warning");
            console.error(error);
            return null;
        }
    }
}
