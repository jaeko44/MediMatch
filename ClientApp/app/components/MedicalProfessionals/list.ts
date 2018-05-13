import { inject } from 'aurelia-framework';
import { Data } from '../data';
import { Common } from '../common';

@inject(Data, Common)
export class ListMP {
    private medicalProfessionals: any;
    private services: any;
    private data: Data;
    private filters: any;
    private common: any;

    constructor(data: Data, common: Common) {
        this.data = data;
        this.common = common;
        var medicalProfessionalPromise = this.resolveMedicalProfessionals();
        var servicesPromise = this.resolveServices();
    }
    async resolveMedicalProfessionals() {
        try {
            let data = await this.data.getMedicalProfessionals();
            this.medicalProfessionals = data;
            console.log(this.medicalProfessionals);
            this.common.notify("GET", "Resolved Medical Professionals", "success");
            return data;
        } catch (error) {
            this.common.notify("GET", "Resolved Medical Professionals", "error");
            console.error(error);
            return null;
        }
    }
    async resolveServices() {
        try {
            let data = await this.data.getServices();
            this.services = data;
            return data;
        } catch(error) {
            console.error(error);
            return null;
        }
    }
    async SearchMedicalProfessionals() {
        try {
            let data = await this.data.filterMedicalProfessionals(this.filters);
            this.medicalProfessionals = data;
            console.log(data);
            this.common.notify("FILTER", "Medical Professionals", "success");
            return data;
        } catch (error) {
            this.common.notify("FILTER", "Medical Professionals", "warning");
            console.error(error);
            return null;
        }
    }
}
