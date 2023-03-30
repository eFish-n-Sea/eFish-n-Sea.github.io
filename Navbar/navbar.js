$("#nav-placeholder").load("../../Navbar/nav.html", function() {
    var url = window.location.href;
    $("#nav-placeholder a").each(function() {
        if (url == (this.href)) {
            $(this).addClass("active");
            if ($(this).parent().hasClass("dropdown-content")) {
              $(".dropbtn").text($(this).text());
              $(".dropbtn").addClass("active");
          }
        }
    });
});

// this was an attempt at removing the active game from the games drop down ill play with it more later.
// $(document).ready(function() {
//     $("#nav a").each(function() {
//       if ($(this).attr("href") == window.location.pathname) {
//         $(this).addClass("active");
//       }
//     });
//     $(".dropdown-content a").each(function() {
//       if ($(this).attr("href") == window.location.pathname) {
//         $(this).addClass("active-page");
//       }
//     });
//     $(".dropbtn").addClass(function() {
//       return $(".dropdown-content .active-page").length > 0 ? "active" : "";
//     });
//     $(".dropdown-content .active-page").removeClass("active-page");
//   });