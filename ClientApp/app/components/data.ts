import { HttpClient } from 'aurelia-fetch-client';
import { inject } from 'aurelia-framework';
import { Aurelia, PLATFORM } from 'aurelia-framework';

@inject(HttpClient, Aurelia)
export class Data {
    public username: string;
    private http: HttpClient;
    private loading: boolean = false;
    public BaseUrl: string;
    private token: string;


    constructor(http: HttpClient, aurelia: Aurelia) {
        //AspNetCore.Identity.Application is currently HTTP-Read Only meaning we cannot capture it in JavaScript. 
        //We need to find a new way to get Identity Authentication of a user when they are logged in.
        let Identity = sessionStorage.getItem("token");
        console.log("Identity of user: " + Identity);
        http = new HttpClient().configure(config => {
            config
                .useStandardConfiguration()
                .withBaseUrl(window.location.origin + "/api/")
                .withDefaults({
                    headers: {
                        'Content-Type': 'application/json'
                    }
                })
                .withInterceptor({
                    request(request: Request) {
                        if (Identity != null) {
                            request.headers.append('Authorization', 'Bearer ' + Identity);
                        }
                        return request;
                    }
                });
        });
        this.http = http;
        aurelia.container.registerInstance(HttpClient, http);
        //Override current HttpClient Instance
        //aurelia.start().then(() => aurelia.setRoot(PLATFORM.moduleName('app')));
    }

    activate() {
        this.loading = true;
        //Make an API call here to test if Authentication is Succesfull.
        let success: boolean = this.testSecurity();
        console.log("Succesfully Authorized: " + success);
        this.loading = false;
    }
    testSecurity() {
        this.http.fetch('Secure', {
            method: 'get'
        })
            .then(response => {
                // do whatever here
                if (response.status == 401) {
                    console.log("Unauthorized request");
                    return false;
                }
                console.log(response);
            }).catch(error => {
                console.log(error);
                return false;
            });
        return true;
    }
    getFacilities() {
        return new Promise((resolve, reject) => {
            this.http.fetch('Facilities')
                .then(result => result.json() as Promise<any[]>)
                .then(data => {
                    resolve(data);
                }).catch(error => {
                    console.log(error);
                    reject(error);
                });
        });
    }

    getFacilitiy(id: string) {
        let facility: any;
        this.http.fetch('Facilities/' + id)
            .then(result => result.json() as Promise<any>)
            .then(data => {
                facility = data;
                facility.facilityAddress = facility.location.streetNo + "+" +
                    facility.location.street + "," +
                    facility.location.suburb + "+" +
                    facility.location.postCode;
                console.log(data);
            });
        return facility;
    }

    createFacility(facility: any) {
        this.http.fetch('api/Facilities', {
            method: 'post',
            body: JSON.stringify(facility),
        }).then(response => {
            if (response.status == 401) {
                console.log("Unauthorized request");
                return false;
            }
            console.log(response);
        }).catch(error => {
            console.log(error);
            return false;
        });
        return true;
    }

    getMedicalProfessionals() {
        return new Promise((resolve, reject) => {
        this.http.fetch('MedicalProfessionals')
            .then(result => result.json() as Promise<any[]>)
            .then(data => {
                resolve(data);
            }).catch(error => {
                reject(error);
            });
        });
    }

    getMedicalProfessional(id: string) {
        let medicalProfessional: any;
        this.http.fetch('MedicalProfessionals/' + id)
            .then(result => result.json() as Promise<any>)
            .then(data => {
                medicalProfessional = data;
                console.log(data);
            });
        return medicalProfessional;
    }

    filterMedicalProfessionals(filters: any) {
        return new Promise((resolve, reject) => {
            console.log("Filters: Service: " + filters.service + " Identity: " + filters.identity + " Location: " + filters.location);
            let medicalProfessional: any;
            this.http.fetch('MedicalProfessionals/Filter', {
                headers: new Headers({
                    'service': filters.service,
                    'identity': filters.identity,
                    'location': filters.location, 
                    'any': filters.any
                })
            }).then(result => result.json() as Promise<any>)
                .then(data => {
                    resolve(data);
                }).catch(error => {
                    reject(error);
                });
        });
    }
    createMedicalProfessional(medicalProfessional: any) {
        this.http.fetch('MedicalProfessionals', {
            method: 'post',
            body: JSON.stringify(medicalProfessional),
        }).then(response => {
            if (response.status == 401) {
                console.log("Unauthorized request");
                return false;
            }
            console.log(response);
        }).catch(error => {
            console.log(error);
            return false;
        });
        return true;
    }

    getServices() {
        return new Promise((resolve, reject) => {
            this.http.fetch('Services')
                .then(result => result.json() as Promise<any[]>)
                .then(data => {
                    resolve(data);
                }).catch(error => {
                    reject(error);
                });
        });
    }
}


interface medicalProfessional {
    id: any;
    firstMidName: string;
    lastName: string;
    services: any[];
    hoursActive: any[];
    notes: string;
    email: string;
    phoneNumber: string;
    reviews: any[];
    facility: {
        id: any;
        facilityName: string;
        location: {
            id: any;
            postCode: string;
            street: string;
            streetNo: string;
            suburb: string;
            coordinates: {
                id: any;
                latitude: number;
                longtitude: number;
            };
        };
        locationId: any;
        website: string;
        phoneNo: string;
        email: string;
        medicalProfessionals: any[];
        facilitySupport: any[];
    };
    facilityId: any;
}
interface service {
    id: any;
    category: string;
}
interface hoursActive {
    id: any;
    weekDays: string;
    hours: string;
}
interface review {
    id: any;
    title: string;
    rating: number;
    comment: string;
    time: Date;
    userId: number;
    medicalProfessionalId: any;
    medicalProfessional: any;
}