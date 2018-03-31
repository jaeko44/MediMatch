import { Aurelia, PLATFORM } from 'aurelia-framework';
import { Router, RouterConfiguration } from 'aurelia-router';

export class App {
    router: Router;

    configureRouter(config: RouterConfiguration, router: Router) {
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
            settings: { icon: 'th-list' },
            moduleId: PLATFORM.moduleName('../MedicalProfessionals/list'),
            nav: true,
            title: 'Medical Professional List'
        },{
            route: 'medical/create',
            name: 'MedicalProfessionalList',
            settings: { icon: 'th-list' },
            moduleId: PLATFORM.moduleName('../MedicalProfessionals/create'),
            nav: true,
            title: 'Medical Professional Create'
        }, {
                route: 'medical/detail/:id/',
            name: 'MedicalProfessionalList',
            moduleId: PLATFORM.moduleName('../MedicalProfessionals/detail'),
            nav: false,
            title: 'Medical Professional Detail'
        }]);

        this.router = router;
    }
}
