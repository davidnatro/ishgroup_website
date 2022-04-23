
$(function (){

    $('.rev_slider').slick({
        arrows: false,
        dots: true,
        autoplay : true,
        autoplaySpeed: 2000,
        infinite: true,
        slidesToShow: 3,
        slidesToScroll: 1,
        responsive: [
            {
                breakpoint: 750,
                settings: {
                    arrows: false,
                    dots: true,
                    autoplay : true,
                    autoplaySpeed: 2000,
                    infinite: true,
                    slidesToShow: 2,
                    slidesToScroll: 1,
                }
            },
            ]
    })
})

const $button = document.querySelector('button');
const $form = document.querySelector('form');

$button.addEventListener('click', e => {

    $form.scrollIntoView({
        block: 'center',
        behavior: 'smooth',
    });
});

function myFunction() {
    var x = document.getElementById("myTopnav");
    if (x.className === "topnav") {
        x.className += " responsive";
    } else {
        x.className = "topnav";
    }
}

