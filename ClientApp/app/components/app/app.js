import { PLATFORM } from 'aurelia-framework';
var App = /** @class */ (function () {
    function App() {
    }
    App.prototype.configureRouter = function (config, router) {
        config.title = 'MediMatchRMIT';
        config.map([{
                route: ['', 'home'],
                name: 'home',
                settings: { icon: 'home' },
                moduleId: PLATFORM.moduleName('../home/home'),
                title: 'Home'
            }, {
                route: 'medical/list',
                name: 'MedicalProfessionalList',
                settings: { icon: 'address-book' },
                moduleId: PLATFORM.moduleName('../MedicalProfessionals/list'),
                nav: true,
                title: 'Medical Professional List'
            }, {
                route: 'medical/create',
                name: 'MedicalProfessionalCreate',
                settings: { icon: 'user-md' },
                moduleId: PLATFORM.moduleName('../MedicalProfessionals/create'),
                nav: true,
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
            }, {
                route: 'facilities/create',
                name: 'FacilitiesList',
                settings: { icon: 'plus-square' },
                moduleId: PLATFORM.moduleName('../Facilities/create'),
                nav: true,
                title: 'Facilities Create'
            }, {
                route: 'facilities/detail/:id/',
                name: 'FacilitiesList',
                moduleId: PLATFORM.moduleName('../Facilities/detail'),
                nav: false,
                title: 'Facilities Detail'
            }]);
        this.router = router;
    };
    return App;
}());
export { App };
//# sourceMappingURL=app.js.map