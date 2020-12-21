// Here I will add code for client side validation for our custom validation (age range validation)

$.validator.unobtrusive.adapters.add("agerangevalidation", ["minage", "maxage"], function (options) {
    options.rules["agerangevalidation"] = options.params;
    options.messages["agerangevalidation"] = options.message;
});

$.validator.addMethod("agerangevalidation", function (value, elements, params) {
    if (value) {
        var valDate = new Date(value);
        if ((new Date().getFullYear() - valDate.getFullYear()) < parseInt(params.minage) ||
            (new Date().getFullYear() - valDate.getFullYear()) > parseInt(params.maxage)
        ) {
            return false;
            //validation failed
        }
    }
    return true;
});
