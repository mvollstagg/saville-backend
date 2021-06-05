$(document).ready(function () {
  //slider

  $(".maslahatlar-detail-slider").owlCarousel({
    items: 1,
    loop: true,
    dots: false,
    margin: 15,
    nav: true,
    autoplay: false,
    autoplayHoverPause: true,
    autoplayTimeout: 4000,
    smartSpeed: 800,
    navText: [
      '<i class="bi bi-arrow-left"></i>',
      '<i class="bi bi-arrow-right"></i>',
    ],
  });

  $("#home_maslahat_slider").owlCarousel({
    items: 4,
    loop: false,
    dots: false,
    margin: 50,
    nav: true,
    autoplay: false,
    autoplayHoverPause: true,
    autoplayTimeout: 4000,
    smartSpeed: 800,
    navText: [
      '<i class="bi bi-arrow-left"></i>',
      '<i class="bi bi-arrow-right"></i>',
    ],
    responsive: {
      0: {
        items: 1,
      },
      685: {
        items: 2,
      },
      992: {
        items: 3,
      },
      1200: {
        items: 4,
      },
      1600: {
        items: 4,
      },
    },
  });

  $("#ourproductslider").owlCarousel({
    loop: true,
    nav: true,
    items: 3,
    margin: 0,
    center: true,
    dots: false,
    mouseDrag: false,
    autoplay: false,
    autoplayHoverPause: true,
    autoplayTimeout: 4000,
    smartSpeed: 1200,
    navText: [
      '<i class="bi bi-arrow-left"></i>',
      '<i class="bi bi-arrow-right"></i>',
    ],
    responsive: {
      0: {
        items: 1,
      },
      685: {
        items: 3,
      },
      992: {
        items: 3,
      },
      1200: {
        items: 3,
      },
      1600: {
        items: 3,
      },
    },
  });

  //tab menu js
  $(".home-tab .product").hide();
  $(".home-tab .product").first().show();
  $(".home-tab .nav-pills .nav-item").on("click", function () {
    let indexing = $(this).index();
    $(".home-tab .product").hide();
    $(".home-tab .product").eq(indexing).show();
    $(".home-tab .nav-pills .nav-item").removeClass("active");
    $(this).addClass("active");
  });

  $(".down-lang > .dropdown-menu > li").click(function (e) {
    $(".btn-lang > span").text($(this).text());
  });

  $(".btn-lang").click(function () {
    $(".btn-lang").removeClass("active");
    $(this).addClass("active");
  });

  $(".filter-search> .dropdown-menu > li").click(function (e) {
    $(".btn-filter > span").text($(this).text());
  });

  $(".dropdown > .btn").on("show.bs.dropdown", function () {
    $(this).children(".bi-chevron-down").toggleClass("rotate-90s");
  });

  $(".dropdown > .btn").on("hidden.bs.dropdown", function () {
    $(this).children(".bi-chevron-down").removeClass("rotate-90s");
  });

  $(".menu-btn").on("click", function (e) {
    $(this).toggleClass("open");
    $(".toggle").toggleClass("toggle--active");
  });

  $(document).on("click", function (event) {
    var collapse = $(".accordion");
    if (collapse !== event.target && !collapse.has(event.target).length) {
      $(".collapse").collapse("hide");
    }
  });

  $(".saville-item").hover(function () {
    $(this).addClass("active");
  });

  $(".saville-item").mouseleave(function () {
    $(".saville-item").removeClass("active");
  });
});

jQuery("img.svg").each(function () {
  var $img = jQuery(this);
  var imgID = $img.attr("id");
  var imgClass = $img.attr("class");
  var imgURL = $img.attr("src");
  jQuery.get(
    imgURL,
    function (data) {
      var $svg = jQuery(data).find("svg");
      if (typeof imgID !== "undefined") {
        $svg = $svg.attr("id", imgID);
      }
      if (typeof imgClass !== "undefined") {
        $svg = $svg.attr("class", imgClass + " replaced-svg");
      }
      $svg = $svg.removeAttr("xmlns:a");
      if (!$svg.attr("viewBox") && $svg.attr("height") && $svg.attr("width")) {
        $svg.attr(
          "viewBox",
          "0 0 " + $svg.attr("height") + " " + $svg.attr("width")
        );
      }
      $img.replaceWith($svg);
    },
    "xml"
  );
});



