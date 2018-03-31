import { HttpClient, json } from 'aurelia-fetch-client';
import { inject } from 'aurelia-framework';

@inject(HttpClient)
export class Detail {
    http: HttpClient;
    public medicalProfessional: medicalProfessional;
    public medicalId: number;

    constructor(http: HttpClient) {
        this.http = http;
    }

    CreateMedicalProfessional() {
        console.log(this.medicalProfessional);
        this.http.fetch('api/MedicalProfessionals', {
            method: 'post',
            body: JSON.stringify(this.medicalProfessional),
            headers: new Headers({
                'Content-Type': 'application/json'
            })
        })
            .then(response => {
                // do whatever here
                console.log(response);
            }).catch (error => console.log(error));
    }
}

interface medicalProfessional {
    MedicalId: number;
    FacilityName: string;
    LastName: string;
    FirstMidName: string;
    Location: {
        AddressId: number;
        PostCode: number;
        Street: number;
        StreetNo: number;
        Suburb: string;
        Coordinates: {
            Latitude: number;
            Longtitude: number;
        };
    };
    ServiceActive: {
        ActiveId: number;
        WeekDays: string;
        Hours: string;
    };
    Notes: string;
    Website: string;
    Email: string;
    PhoneNumber: string;
    Services: Service[];
    Facilities: Facility[];
    Feedback: Reviews[];
}
interface Service {
    ServiceId: number;
    ServiceType: string;
}
interface Facility {
    ServiceId: number;
    Support: string;
}
interface Aaddress {
    AddressId: number;
    PostCode: number;
    Street: number;
    StreetNo: number;
    Suburb: string;
    Soordinates: {
        latitude: number;
        longtitude: number;
    };
}
interface DecimalDegrees {
    latitude: number;
    longtitude: number;
}
interface HoursActive {
    activeId: number;
    weekDays: string;
    hours: string;
}
interface Reviews {
    reviewId: number;
    title: string;
    rating: number;
    comment: string;
    time: Date;
    userId: number;
}
