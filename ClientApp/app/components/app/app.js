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
                nav: true,
                title: 'Home'
            }, {
                route: 'medical/list',
                name: 'MedicalProfessionalList',
                settings: { icon: 'th-list' },
                moduleId: PLATFORM.moduleName('../MedicalProfessionals/list'),
                nav: true,
                title: 'Medical Professional List'
            }, {
                route: 'medical/create',
                name: 'MedicalProfessionalList',
                settings: { icon: 'user-add' },
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
    };
    return App;
}());
export { App };
//# sourceMappingURL=app.js.map