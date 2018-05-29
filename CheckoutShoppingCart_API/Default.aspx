<%@ Page Title="Products" Language="C#" MasterPageFile="~/Site.Master"
    AutoEventWireup="true" CodeBehind="Default.aspx.cs" Inherits="CheckoutShoppingCart_API._Default" EnableSessionState="True"  %>

<asp:Content ID="HeaderContent" runat="server" ContentPlaceHolderID="HeadContent">
    <script src="/Scripts/jquery-3.3.1.min.js"></script>
    <script type="text/javascript">
        function getProducts() {
            $.getJSON("api/product",
                function (data) {
                    $('#divProduct').val(''); // Clear the table header.

                    // Loop through the list of products.
                    var divcontent = "";
                    var totalItems = 0;
                    $.each(data, function (key, val) {
                        if (val.isChecked == true)
                            totalItems += 1;

                        // Add a table row for the product.
                        divcontent += '<div class="images">';
                        divcontent += '<figure>';
                        divcontent += '<img src="' + val.ImageUrl + '" alt="Photo" style="width:150px;height:150px;"/>';
                        divcontent += '<figcaption>' + val.Name + '</figcaption>';
                        divcontent += '<figcaption> Price : ' + val.Price + ' € </figcaption>';
                        if (val.isChecked == true)
                            divcontent += '<figcaption><input type="checkbox" id="' + val.ProductID + '" Checked/></figcaption>';
                        else
                            divcontent += '<figcaption><input type="checkbox" id="' + val.ProductID + '" /></figcaption>';
                        divcontent += '</figure>';
                        divcontent += '</div>';

                    });

                    divcontent += '<div class="clearfix"></div>';

                    $('<div/>', { html: divcontent })  // Append the Product.
                        .appendTo($('#divProduct'));

                    $("#totalLabel").text(totalItems);

                });
        }


        $(document).ready(function () {
            getProducts();

            $('#btnAddToCart').click(function () {
                AddToCart();
            });

        });


        function AddToCart() {
            var selected = [];
            $('#divProduct input:checked').each(function() {
                selected.push($(this).attr('id'));
            });
            $.ajax({
                type: "POST",
                data: JSON.stringify(selected),
                url: "api/Product",
                contentType: "application/json"
            });
        }


    </script>
</asp:Content>

<asp:Content ID="BodyContent" runat="server" ContentPlaceHolderID="MainContent">
    <div>
        <div class='divheader'><label>Products</label></div>
        <div style="float:right;position:absolute; right:579px; top:89px;"><label><b>Items in Cart : </b></label><label id="totalLabel"></label></div>
        <button id='btnAddToCart' class="main_btn_m hvr-underline-from-left_m" style="width: 200px; float: right; margin-right: 70px;">
            Add to Cart
        </button>
    </div>
    <div class="clearfix"></div>
    <div id="divProduct">
    </div>
</asp:Content>
