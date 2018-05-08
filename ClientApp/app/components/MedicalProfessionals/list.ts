import { inject } from 'aurelia-framework';
import { Data } from '../data';

@inject(Data)
export class ListMP {
    private medicalProfessionals: any;
    private services: any;
    private data: Data;
    private filters: any;

    constructor(data: Data) {
        this.data = data;
        var medicalProfessionalPromise = this.resolveMedicalProfessionals();
        var medicalProfessionalPromise = this.resolveServices();

    }
    async resolveMedicalProfessionals() {
        try {
            let data = await this.data.getMedicalProfessionals();
            this.medicalProfessionals = data;
            console.log(this.medicalProfessionals);
            return data;
        } catch(error) {
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
            return data;
        } catch(error) {
            console.error(error);
            return null;
        }
    }
}
