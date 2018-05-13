import 'bootstrap-notify';
import $ from 'jquery';

export class Common {
    constructor() {

    }
    notify(title: string, message: string, type: string) {
        let faIcon : string;
        if (type == "success") {
            faIcon = "fa fa-check";
        }
        else if (type == "warning") {
            faIcon = "fa fa-warning"
        }
        else if (type == "error") {
            faIcon = "fa fa-exclamation-triangle"
        }
        $.notify({
            icon: faIcon,
            title: title,
            message: message,
            animate: {
                enter: 'animated zoomInDown',
                exit: 'animated zoomOutUp'
            },
            newest_on_top: true
        }, {
            type: type,
            delay: 2000,
            placement: {
                from: "bottom",
                align: "right"
            }
        });
    }
}