
//SCROLL UP

$(window).scroll(function() {
    if ($(this).scrollTop() >= 50) {        // If page is scrolled more than 50px
        $("#return-to-top").fadeIn(200);    // Fade in the arrow
    } else {
        $('#return-to-top').fadeOut(200);   // Else fade out the arrow
    }
});
$("#return-to-top").click(function() {      // When arrow is clicked
    $("body,html").animate({
        scrollTop : 0                       // Scroll to top of body
    }, 1000);
});

//NAVBAR FIXED

$(window).scroll(function() {
    if ($(document).scrollTop() > 600) {
      $('#navbar-custom').addClass('color-change');
      document.querySelector("#navbar-custom").removeAttribute("style")
    } else {
      $('#navbar-custom').removeClass('color-change');
      document.querySelector("#navbar-custom").setAttribute("style","background:transparent !important");
    }
  });

//   SLIDER STARTS HERE

var slideIndex = 1;
showDivs(slideIndex);

function plusDivs(n) {
  showDivs(slideIndex += n);
}

function showDivs(n) {
  var i;
  var x = document.getElementsByClassName("mySlides");
  if (n > x.length) {slideIndex = 1}
  if (n < 1) {slideIndex = x.length}
  for (i = 0; i < x.length; i++) {
    x[i].style.display = "none";  
  }
  x[slideIndex-1].style.display = "block";  
}
