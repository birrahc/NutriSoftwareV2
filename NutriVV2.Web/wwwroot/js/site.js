$(document).ready(function () {

    toastr.options = {
        "closeButton": false,
        "debug": false,
        "newestOnTop": false,
        "progressBar": false,
        "positionClass": "toast-top-center",
        "preventDuplicates": false,
        "onclick": null,
        "showDuration": "30000",
        "hideDuration": "55000",
        "timeOut": "5000",
        "extendedTimeOut": "222000",
        "showEasing": "swing",
        "hideEasing": "linear",
        "showMethod": "fadeIn",
        "hideMethod": "fadeOut",
        "onCloseClick": true
    };


    $('.form-control').mask("00,00", { reverse: true });
        
    



})

