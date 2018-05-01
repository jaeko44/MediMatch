import { HttpClient } from 'aurelia-fetch-client';
import { inject } from 'aurelia-framework';
import { Aurelia, PLATFORM } from 'aurelia-framework';

@inject(HttpClient, Aurelia)
export class Authentication {
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
        if (Identity != null) {
            http = new HttpClient().configure(config => {
                config
                    .useStandardConfiguration()
                    .withBaseUrl(window.location.origin + "api/")
                    .withDefaults({
                        headers: {
                            'Content-Type': 'application/json'
                        }
                    })
                    .withInterceptor({
                        request(request: Request) {
                            request.headers.append('Authorization', 'Bearer ' + Identity);
                            return request;
                        }
                    });
            });
            aurelia.container.registerInstance(HttpClient, http);
            //Override current HttpClient Instance
            //aurelia.start().then(() => aurelia.setRoot(PLATFORM.moduleName('app')));
        }
        else {
            console.log("User is not authenticated");
        }
    }
    getCookie(name: string) {
        var regexp = new RegExp("(?:^" + name + "|;\s*" + name + ")=(.*?)(?:;|$)", "g");
        var result = regexp.exec(document.cookie);
        return (result === null) ? null : result[1];
    }
    activate() {
        this.loading = true;
        //Make an API call here to test if Authentication is Succesfull.

    }

}