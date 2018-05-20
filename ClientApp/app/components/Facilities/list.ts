import { inject } from 'aurelia-framework';
import { Data } from '../data';
import { Common } from '../common';

@inject(Data, Common)
export class ListFacilities {
    public Facilities: any;
    public data: Data;
    public filters: any;
    public common: any;
    public location: any;
    public sort: Sort;

 
    constructor(data: Data, common: Common) {
        this.data = data;
        this.common = common;
        this.resolveFacilities();
        this.sort = {
            property: "facility.facilityName",
            direction: "ascending"
        }
    }
    async resolveFacilities() {
        try {
            let data = await this.data.getFacilities();
            this.Facilities = data;
            this.getLocation();
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
            let data = null;
            if (this.filters.identity != undefined || this.filters.location != undefined || this.filters.any != undefined) {
                data = await this.data.filterFacilities(this.filters);
            }
            console.log(data);
            if (data != null) {
                this.Facilities = data;
                this.common.notify("FILTER", "Facilities", "success");
            }
            else {
                this.common.notify("FILTER", "Filters missing", "warning");
            }
            
            return data;
        } catch (error) {
            this.common.notify("FILTER", "Facilities", "warning");
            console.error(error);
            return null;
        }
    }

    CaclulateFacilitiesDistance() {
        var lat2 = self.sessionStorage.getItem("usr_latitude");
        var long2 = self.sessionStorage.getItem("usr_longitude");
        if (lat2 != undefined || long2 != undefined) {
            this.Facilities.forEach(facility => {
                var lat1 = facility.location.coordinates.latitude;
                var long1 = facility.location.coordinates.longitude

                var distance = this.getDistanceFromLatLonInKm(lat1, long1, lat2, long2);
                facility.distance = distance;
                console.log(distance);
            });
        }
        else {
            this.common.notify("CALCULATE", "Distance (user coordinates missing)", "warning");
        }

    }

    getDistanceFromLatLonInKm(lat1, lon1, lat2, lon2) {
        var R = 6371; // Radius of the earth in km
        var dLat = this.deg2rad(lat2 - lat1);  // deg2rad below
        var dLon = this.deg2rad(lon2 - lon1);
        var a =
            Math.sin(dLat / 2) * Math.sin(dLat / 2) +
            Math.cos(this.deg2rad(lat1)) * Math.cos(this.deg2rad(lat2)) *
            Math.sin(dLon / 2) * Math.sin(dLon / 2)
            ;
        var c = 2 * Math.atan2(Math.sqrt(a), Math.sqrt(1 - a));
        let d = R * c; // Distance in km
        let dS = d.toFixed(2); // 1.24
        return dS; 
    }

    deg2rad(deg) {
        return deg * (Math.PI / 180)
    }

    getLocation() {
        var options = {
            enableHighAccuracy: true,
            timeout: 5000,
            maximumAge: 0
        };
        if (navigator.geolocation) {
            navigator.geolocation.getCurrentPosition(this.positionFound, this.positionError, options);
        } else {
            this.location = null;
        }
        this.CaclulateFacilitiesDistance();
    }
    positionFound(position) {
        console.log("Finally found position");
        self.sessionStorage.setItem("usr_latitude", position.coords.latitude);
        self.sessionStorage.setItem("usr_longitude", position.coords.longitude);
    }
    positionError(error) {
        console.log(error);
    }
}

interface Sort {
    property: string;
    direction: string;
}