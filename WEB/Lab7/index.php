<!doctype html>

<html lang="en">
<head>
  <meta charset="utf-8">

  <title>TV Shows</title>
  <meta name="description" content="The HTML5 Herald">
  <meta name="author" content="SitePoint">

  <script language="JavaScript" type="text/javascript" src="https://code.jquery.com/jquery-3.3.1.min.js"></script>

  <link rel="stylesheet" href="https://maxcdn.bootstrapcdn.com/bootstrap/4.0.0/css/bootstrap.min.css" integrity="sha384-Gn5384xqQ1aoWXA+058RXPxPg6fy4IWvTNh0E263XmFcJlSAwiGgFAW/dAiS6JXm" crossorigin="anonymous">
  <script src="https://code.jquery.com/jquery-3.2.1.slim.min.js" integrity="sha384-KJ3o2DKtIkvYIK3UENzmM7KCkRr/rE9/Qpg6aAZGJwFDMVNA/GpGFF93hXpG5KkN" crossorigin="anonymous"></script>
  <script src="https://cdnjs.cloudflare.com/ajax/libs/popper.js/1.12.9/umd/popper.min.js" integrity="sha384-ApNbgh9B+Y1QKtv3Rn7W3mgPxhU9K/ScQsAP7hUibX39j7fakFPskvXusvfa0b4Q" crossorigin="anonymous"></script>
  <script src="https://maxcdn.bootstrapcdn.com/bootstrap/4.0.0/js/bootstrap.min.js" integrity="sha384-JZR6Spejh4U02d8jOt6vLEHfe/JQGiRRSQQxSfFWpi1MquVdAyjUar5+76PVCmYl" crossorigin="anonymous"></script>

  <link rel="stylesheet" href="//code.jquery.com/ui/1.12.1/themes/base/jquery-ui.css">
  <link rel="stylesheet" href="/resources/demos/style.css">
  <script src="https://code.jquery.com/jquery-1.12.4.js"></script>
  <script src="https://code.jquery.com/ui/1.12.1/jquery-ui.js"></script>
  <!--[if lt IE 9]>
    <script src="https://cdnjs.cloudflare.com/ajax/libs/html5shiv/3.7.3/html5shiv.js"></script>
  <![endif]-->
</head>

<body>

        <header>
            <nav class="navbar navbar-expand-lg navbar-light bg-light">
                <a class="navbar-brand" href="#">TheBestCommerce</a>
                <button class="navbar-toggler" type="button" data-toggle="collapse" data-target="#navbarNavDropdown" aria-controls="navbarNavDropdown" aria-expanded="false" aria-label="Toggle navigation">
                    <span class="navbar-toggler-icon"></span>
                </button>
                <div class="collapse navbar-collapse" id="navbarNavDropdown">
                    <ul class="navbar-nav">
                        <li class="nav-item dropdown">
                            <a class="nav-link dropdown-toggle" href="#" id="navbarDropdownMenuLink" data-toggle="dropdown" aria-haspopup="true" aria-expanded="false">
                                ShoppingCart
                            </a>
                            <div id="cart" class="dropdown-menu" aria-labelledby="navbarDropdownMenuLink">

                            </div>
                        </li>
                    </ul>
                </div>
            </nav>
        </header>

        <div class = "container justify-content-center">
            <main>
                <input style="width: 100%; margin-top: 15px;" type="text" id="category" placeholder="Category" onkeyup="pageFunctionalityObj.changeCategory()">

                <div id="shoppingCards"></div>
                <nav style="width:100%" aria-label="Page navigation example">
                    <ul style="width:100%" class="pagination justify-content-center">
                        <li style="width:100%; text-align: center;" class="page-item" onclick="pageFunctionalityObj.prevPage()">
                            <a class="page-link" href="#" tabindex="-1"> <- </a>
                        </li>
                        <li style="width:100%; text-align: center;" class="page-item"><a class="page-link" id="pageDisplay">1</a></li>
                        <li style="width:100%; text-align: center;"class="page-item">
                            <a class="page-link" href="#" onclick="pageFunctionalityObj.nextPage()"> -> </a>
                        </li>
                    </ul>
                </nav>
            </main>

        </div>
        <br />


</body>

<script>

    $(document).on('click', '.cartItem', function () {
        $(this).remove();
    });

    class PageFunctionality {

        constructor() {
            this.page = 1;
            this.elemsPerPage = 2;
            this.category = "";
            this.getProducts();
        }

        getProducts() {
            // Get the products
            this.items = [];
            this.values = [];

            $.getJSON( "/scripts/products.php?action=select&page=" + this.page.toString() + "&category=" + this.category, function( data ) {


                $.each( data, function( key, val ) {
                    this.values.push(val);
                }.bind(this));

                for(var i = 0; i < this.values.length; i++) {

                    var item = `
                                <div style="width:100%" class="card text-center productCard">
                                      <div class="card-header">
                                        ${this.values[i]["productName"]}
                                      </div>
                                      <div class="card-body">
                                        <h5 class="card-title"> ${this.values[i]["productPrice"]} </h5>
                                        <p class="card-text">${this.values[i]["productDescription"]}</p>
                                        <a href="#" class="btn btn-primary" onclick="pageFunctionalityObj.addToShopingCard('${this.values[i]["productName"]}');">Add to cart</a>
                                      </div>
                                      <div class="card-footer text-muted">
                                         ${this.values[i]["productCategory"]}
                                      </div>
                                    </div>
                                    <div>
                                </div>
                            `;

                    this.items.push(item);
                }

                // Clear already rendered elements
                $("#shoppingCards").empty();

                // Render the products
                $( "<div>", {
                    html: this.items.join( "" )
                }).appendTo( "#shoppingCards" );

            }.bind(this));
        }

        nextPage() {
            if(this.values.length == this.elemsPerPage) {
                this.page += 1;
                this.getProducts()
            }
            this.displayPage();
        }

        prevPage() {
            if(this.page > 1) {
                this.page -= 1;
                this.getProducts(this.page);
            }
            this.displayPage();
        }

        displayPage() {
            document.getElementById("pageDisplay").innerHTML = this.page.toString();
        }

        changeCategory() {
            this.category = document.getElementById("category").value;
            this.page = 1;
            this.getProducts();
        }

        addToShopingCard(productName) {
            $( "<div>", {
                html: `<a class="dropdown-item cartItem" href="#">${productName}</a>`
            }).appendTo( "#cart" );

            // Remove Identical
            var seen = {};
            $('.cartItem').each(function() {
                var txt = $(this).text();
                if (seen[txt])
                    $(this).remove();
                else
                    seen[txt] = true;
            });
        }
    }

    var pageFunctionalityObj = new PageFunctionality()
</script>

<style>
    .productCard {
        margin-top:20px;
        margin-bottom: 20px;
        width:100%;
    }
</style>

</html>
