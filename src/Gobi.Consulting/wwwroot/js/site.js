$(document).ready(() => {

    jQuery(function ($) {
        $(".mask-phone").mask("(99) 9?9999-9999");
    });


    $(".marquee--top").simplyScroll({
        pauseOnHover: false,
        pauseOnTouch: false,
        pauseButton: false
    });

    $(".marquee--bottom").simplyScroll({
        direction: "right",
        pauseOnHover: false,
        pauseOnTouch: false,
        pauseButton: false
    });

    // Anchor Animation
    jQuery('.anchor-animation').on('click', function (e) {

        e.preventDefault();

        const href = $(this).attr('href');

        $('html, body').animate({
            scrollTop: $(href).offset().top
        }, 'slow');
    });

    // Privacy checkbox
    $("#btn-acordo").click(() => $('#PrivacyPolicy').prop('checked', true));


    // CAPTCHA

    const captcha = new Captcha($('#canvas'), {
        length: 4
    });

    // api
    //captcha.refresh();
    //captcha.getCode();
    //captcha.valid("");

    $('#valid').on('click', function (e) {

        e.preventDefault();

        const valid = captcha.valid($('input[name="code"]').val());

        captcha.refresh();

        if (!valid) {

            Swal.fire({
                //title: 'Código inválido',
                text: 'Para prosseguir, é necessário preencher todos os campos obrigatórios e estar ciente da nossa Política de Privacidade.',
                icon: 'error',
                confirmButtonText: 'Ok',
                customClass: {
                    confirmButton: 'btn btn-info btn-swal',
                }
            });

            return;
        }

        const data = {
            name: document.querySelector("#Name").value,
            email: document.querySelector("#Email").value,
            phone: document.querySelector("#Phone").value,
            companyName: document.querySelector("#CompanyName").value,
            companySize: document.querySelector("#CompanySize").value,
            subject: document.querySelector("#Subject").value,
            privacyPolicy: document.querySelector("#PrivacyPolicy").checked,
            allowsContact: document.querySelector("#AllowsContact").checked
        };

        $.ajax(
            {
                type: "POST",
                url: "contact/send",
                headers:
                {
                    "XSRF-TOKEN": $("input[name='__RequestVerificationToken']").val()
                },
                data: data,
                success: function (data) {

                    if (data.success) 
                        document.getElementById("form").reset();

                    Swal.fire({
                        //title: data.message,
                        text: data.message,
                        icon: data.success ? 'success' : 'error',
                        confirmButtonText: 'Ok',
                        customClass: {
                            confirmButton: 'btn btn-info btn-swal',
                        }
                    });

                },
                error: function (data) {

                    Swal.fire({
                        //title: data.message,
                        text: data.message,
                        icon: 'error',
                        confirmButtonText: 'Ok',
                        customClass: {
                            confirmButton: 'btn btn-info btn-swal',
                        }
                    });
                }
            });

    })

});