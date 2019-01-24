// Please see documentation at https://docs.microsoft.com/aspnet/core/client-side/bundling-and-minification
// for details on configuring this project to bundle and minify static web assets.

// Write your Javascript code.
 setTimeout(function(){$(function(){
        $(".add-to-cart").click(function(){
            var id = $(this).attr("data-id");
            var url = "/api/bag/product?productId=" + id
            $.ajax({
                    type: "PUT",
                    url: url,
                    success: successFunc,
                    error: errorFunc
            });

        function successFunc(data, status) {
                alert(data);
            }

            function errorFunc() {
                alert('error');
            }

        });

 })

       $(".remove-from-bag").click(function(e){
            e.preventDefault();
            
            var id = $(this).attr("data-id");
            url = "https://localhost:5001/Secure/Bag" + "?productId=" + id;
                $.ajax({
                    beforeSend: function (xhr) {
                         xhr.setRequestHeader("XSRF-TOKEN",
                           $('input:hidden[name="__RequestVerificationToken"]').val());
                  },
                  url: url,
                  type: "POST"
                }).done(successFunc).fail(errorFunc)         
           
        })

            function successFunc(data, status) {
                console.log(arguments)
                window.location.reload(true); 
            }

            function errorFunc() {
                console.log(arguments)
            }





 },200);
 