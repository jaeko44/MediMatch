import { Aurelia, PLATFORM } from 'aurelia-framework';
import { Router, RouterConfiguration } from 'aurelia-router';

export class App {
    router: Router;

    configureRouter(config: RouterConfiguration, router: Router) {
        var token = sessionStorage.getItem('token');
        let isAuthenticated = false;
        let isAdmin = false;
        let isMedicalProfessional = false;
        let isPatient = false;
        let isModerator = false;
        if (token != null) {
            isAuthenticated = true;
            var decodedToken = this.parseJwt(token);
            console.log("Decoded Token of User: ")
            console.log(decodedToken);
            var userRole = decodedToken["http://schemas.microsoft.com/ws/2008/06/identity/claims/role"];
            if (userRole == "Admin") {
                isAdmin = true;
            }
            if (userRole == "MedicalProfessional") {
                isMedicalProfessional = true;
            }
            if (userRole == "Moderator") {
                isModerator = true;
            }
            if (userRole == "Patient") {
                isPatient = true;
            }
        }
        config.title = 'MediMatchRMIT';
        config.map([{
            route: [ '', 'home' ],
            name: 'home',
            settings: { icon: 'home' },
            moduleId: PLATFORM.moduleName('../home/home'),
            nav: true,
            title: 'Home'
        }, {
            route: 'medical/list',
            name: 'MedicalProfessionalList',
            settings: { icon: 'address-book' },
            moduleId: PLATFORM.moduleName('../MedicalProfessionals/list'),
            nav: true,
            title: 'Medical Professional List'
        },{
            route: 'medical/create',
            name: 'MedicalProfessionalCreate',
            settings: { icon: 'user-md' },
            moduleId: PLATFORM.moduleName('../MedicalProfessionals/create'),
            nav: isAdmin || isModerator,
            title: 'Medical Professional Create'
        }, {
            route: 'medical/update',
            name: 'MedicalProfessionalUpdate',
            settings: { icon: 'user-md' },
            moduleId: PLATFORM.moduleName('../MedicalProfessionals/update'),
            nav: isMedicalProfessional,
            title: 'Medical Professional Update'
        }, {
            route: 'medical/detail/:id/',
            name: 'MedicalProfessionalDetails',
            moduleId: PLATFORM.moduleName('../MedicalProfessionals/detail'),
            nav: false,
            title: 'Medical Professional Detail'
        }, {
            route: 'facilities/list',
            name: 'FacilitiesList',
            settings: { icon: 'building' },
            moduleId: PLATFORM.moduleName('../Facilities/list'),
            nav: true,
            title: 'Facilities List'
        },{
            route: 'facilities/create',
            name: 'FacilitiesCreate',
            settings: { icon: 'plus-square' },
            moduleId: PLATFORM.moduleName('../Facilities/create'),
            nav: isAdmin || isModerator,
            title: 'Facilities Create'
        }, {
            route: 'facilities/update',
            name: 'FacilitiesUpdate',
            settings: { icon: 'plus-square' },
            moduleId: PLATFORM.moduleName('../Facilities/create'),
            nav: isMedicalProfessional,
            title: 'Facility Update'
        }, {
            route: 'facilities/detail/:id/',
            name: 'FacilitiesDetail',
            moduleId: PLATFORM.moduleName('../Facilities/detail'),
            nav: false,
            title: 'Facilities Detail'
        }]);

        this.router = router;
    }
    parseJwt(token) {
        var base64Url = token.split('.')[1];
        var base64 = base64Url.replace('-', '+').replace('_', '/');
        return JSON.parse(window.atob(base64));
    }
}
