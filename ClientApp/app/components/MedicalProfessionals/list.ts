import { inject } from 'aurelia-framework';
import { Data } from '../data';
import PromptBoxes from 'prompt-boxes';

@inject(Data)
export class ListMP {
    private medicalProfessionals: any;
    private services: any;
    private data: Data;
    private filters: any;
    private PromptBoxes: any;

    constructor(data: Data) {
        var pb = new PromptBoxes({ 
            toastDir: 'top',        // What position to show the toast (top | bottom)
            toastMax: 3,            // Max number of toasts to display at once
            promptAsAbsolute: true  // Whether to show prompt as position absolute (fixes ios input bug)
          });
        this.PromptBoxes = pb;
        this.data = data;
        var medicalProfessionalPromise = this.resolveMedicalProfessionals();
        var medicalProfessionalPromise = this.resolveServices();
    }
    async resolveMedicalProfessionals() {
        try {
            let data = await this.data.getMedicalProfessionals();
            this.medicalProfessionals = data;
            console.log(this.medicalProfessionals);
            this.PromptBoxes.success("Succesfully loaded medical professionals");
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
            this.PromptBoxes.success("Filtered medical professionals");
            return data;
        } catch(error) {
            this.PromptBoxes.error("Error filtering medical professionals");
            console.error(error);
            return null;
        }
    }
}
