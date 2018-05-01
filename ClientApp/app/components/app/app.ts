import { Aurelia, PLATFORM } from 'aurelia-framework';
import { Router, RouterConfiguration } from 'aurelia-router';

export class App {
    router: Router;

    configureRouter(config: RouterConfiguration, router: Router) {
        var token = sessionStorage.getItem('token');
        let isAuthenticated = false;
        if (token != null) {
            isAuthenticated = true;
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
            nav: isAuthenticated,
            title: 'Medical Professional Create'
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
            name: 'FacilitiesList',
            settings: { icon: 'plus-square' },
            moduleId: PLATFORM.moduleName('../Facilities/create'),
            nav: isAuthenticated,
            title: 'Facilities Create'
        }, {
                route: 'facilities/detail/:id/',
            name: 'FacilitiesList',
            moduleId: PLATFORM.moduleName('../Facilities/detail'),
            nav: false,
            title: 'Facilities Detail'
        }]);

        this.router = router;
    }
}
