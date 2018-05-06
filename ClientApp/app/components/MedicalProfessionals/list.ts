import { inject } from 'aurelia-framework';
import { Data } from '../data';

@inject(Data)
export class ListMP {
    public medicalProfessionals: any;
    private data: Data;

    constructor(data: Data) {
        this.data = data;
        var newPromise = this.resolveMedicalProfessionals();
        console.log("Medical Profesionals retrieved from data class");
        console.log(newPromise);
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
}
