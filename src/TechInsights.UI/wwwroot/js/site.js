﻿/**
* Template Name: BizLand - v1.1.1
* Template URL: https://bootstrapmade.com/bizland-bootstrap-business-template/
* Author: BootstrapMade.com
* License: https://bootstrapmade.com/license/
*/
!(function ($) {
    "use strict";


    // Preloader
    $(window).on('load', function () {
        if ($('#preloader').length) {
            $('#preloader').delay(100).fadeOut('slow', function () {
                $(this).remove();
            });
        }
    });

    // Activate smooth scroll on page load with hash links in the url
    $(document).ready(function () {
        if (window.location.hash) {
            var initial_nav = window.location.hash;
            if ($(initial_nav).length) {
                var scrollto = $(initial_nav).offset().top - scrolltoOffset;
                $('html, body').animate({
                    scrollTop: scrollto
                }, 1500, 'easeInOutExpo');
            }
        }
    });

    // Navigation active state on scroll
    var nav_sections = $('section');
    var main_nav = $('.nav-menu, .mobile-nav');

    //$(window).on('scroll', function () {
    //    var cur_pos = $(this).scrollTop() + 200;

    //    nav_sections.each(function () {
    //        var top = $(this).offset().top,
    //            bottom = top + $(this).outerHeight();

    //        if (cur_pos >= top && cur_pos <= bottom) {
    //            if (cur_pos <= bottom) {
    //                main_nav.find('li').removeClass('active');
    //            }
    //            main_nav.find('a[href="#' + $(this).attr('id') + '"]').parent('li').addClass('active');
    //        }
    //        if (cur_pos < 300) {
    //            $(".nav-menu ul:first li:first, .mobile-menu ul:first li:first").addClass('active');
    //        }
    //    });
    //});

    // Mobile Navigation
    if ($('.nav-menu').length) {
        var $mobile_nav = $('.nav-menu').clone().prop({
            class: 'mobile-nav d-lg-none'
        });
        $('body').append($mobile_nav);
        $('body').prepend('<button type="button" class="mobile-nav-toggle d-lg-none"><i class="fa fa-bars"></i></button>');
        $('body').append('<div class="mobile-nav-overly"></div>');

        $(document).on('click', '.mobile-nav-toggle', function (e) {
            $('body').toggleClass('mobile-nav-active');
            $('.mobile-nav-toggle i').toggleClass('fa fa-bars fa fa-times');
            $('.mobile-nav-overly').toggle();
        });

        $(document).on('click', '.mobile-nav .drop-down > a', function (e) {
            e.preventDefault();
            $(this).next().slideToggle(300);
            $(this).parent().toggleClass('active');
        });

        $(document).click(function (e) {
            var container = $(".mobile-nav, .mobile-nav-toggle");
            if (!container.is(e.target) && container.has(e.target).length === 0) {
                if ($('body').hasClass('mobile-nav-active')) {
                    $('body').removeClass('mobile-nav-active');
                    $('.mobile-nav-toggle i').toggleClass('icofont-navigation-menu icofont-close');
                    $('.mobile-nav-overly').fadeOut();
                }
            }
        });
    } else if ($(".mobile-nav, .mobile-nav-toggle").length) {
        $(".mobile-nav, .mobile-nav-toggle").hide();
    }

    // Toggle .header-scrolled class to #header when page is scrolled
    $(window).scroll(function () {
        if ($(this).scrollTop() > 100) {
            $('#header').addClass('header-scrolled');
            $('#topbar').addClass('topbar-scrolled');
        } else {
            $('#header').removeClass('header-scrolled');
            $('#topbar').removeClass('topbar-scrolled');
        }
    });

    if ($(window).scrollTop() > 100) {
        $('#header').addClass('header-scrolled');
        $('#topbar').addClass('topbar-scrolled');
    }

    // Init AOS
    function aos_init() {
        AOS.init({
            duration: 1000,
            once: true
        });
    }

    // Testimonials carousel (uses the Owl Carousel library)
    $(".testimonials-carousel").owlCarousel({
        autoplay: true,
        dots: true,
        loop: true,
        items: 1
    });

    $(window).on('load', function () {
        aos_init();
    });

})(jQuery);

function FormComplete(data) {
    $('#divloading').delay(100).fadeOut('slow', function () {
        $(this).hide();
    });
}

function contactFormSuccess(data) {
    $('#contactForm').hide();
    $("#contactForm")[0].reset();
    $('#success-message-container').show();
}

function contactFormFail(data) {
    $('#contactForm').hide();
    $('#error-message-container').show();
}

function commentsFormSuccess(data) {    
    var jsonResponse = JSON.parse(data);    
    var convertedDate = new Date(jsonResponse.PubDate);
    var month = convertedDate.toLocaleDateString('default', { month: 'long' });
    var day = convertedDate.getDay();
    var year = convertedDate.getFullYear();
    var pubDate = month + ' ' + day + ', ' + year;
    
    var codeBlock = '<article id="' + jsonResponse.Id + '" class="comment" itemprop="comment" itemscope itemtype="http://schema.org/Comment">' +
        '<h3>' +
        '<time datetime="' + jsonResponse.PubDate + '" itemprop = "datePublished" >' +
        '<a href="#' + jsonResponse.Id + '" title="Permalink (#' + jsonResponse.Id + ')">' + pubDate + '</a>' +
        '</time > ' +
        '</h3 > ' +
        '<div class="content">' +
        '<p itemprop="text">' + jsonResponse.Content + '</p>' +
        '<span itemprop="name">' + jsonResponse.Author + '</span>' +
        '</div>' +
        '</article >';
        
    $(codeBlock).insertAfter("#commentsTitle"); 
    $("#commentForm")[0].reset();
    $('#success-message-container').show();
}

function commentsFormFail(data) {    
    $('#error-message-container').show();
}

