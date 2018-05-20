import { inject } from 'aurelia-framework';
import { activationStrategy } from 'aurelia-router';
import { Data } from '../../data';

@inject(Data)
export class UpdateMPAdmin {
    private medicalProfessional: any;
    private medicalProfessionalExists: boolean;
    private medic: any;
    private facility: any;
    private facilities: any;
    private services: any;
    private medicalId: number;
    private token: string;
    private data: Data;

    constructor(data: Data) {
        this.data = data;
        this.resolveFacilities();
        this.resolveServices();
        this.resolveMedicalProfessional()
    }
    async resolveMedicalProfessional() {
        try {
            let data = await this.data.getLoggedInMedicalProfessional();
            this.medicalProfessional = data;
            this.medicalProfessionalExists = true;
            return data;
        } catch (error) {
            this.medicalProfessionalExists = false;
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
    async UpdateMedicalProfessional() {
        try {
            let result;
            if (this.medicalProfessionalExists == true) {
                result = await this.data.updateMedicalProfessional(this.medicalProfessional)
            }
            else {
                result = await this.data.createMedicalProfessional(this.medicalProfessional);
            }
            console.log(result);
            return result;
        } catch (error) {
            console.error(error);
            return null;
        }
    }
    attached() {

    }
    addService() {
        for (let service of this.services) {
            if (service.id == this.medicalProfessional.serviceId) {
                console.log("Service matched");
                var input = <HTMLInputElement>document.getElementById('serviceTags');
                input.value += " " + service.category;
                this.medicalProfessional.serviceId = null;
            }
        }
    }
}