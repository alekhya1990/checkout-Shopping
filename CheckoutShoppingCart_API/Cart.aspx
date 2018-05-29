<%@ Page Title="Cart" Language="C#" MasterPageFile="~/Site.Master"
    AutoEventWireup="true" CodeBehind="Default.aspx.cs" Inherits="CheckoutShoppingCart_API._Default" EnableSessionState="True" %>

<asp:Content ID="HeaderContent" runat="server" ContentPlaceHolderID="HeadContent">
    <script src="/Scripts/jquery-3.3.1.min.js"></script>
    <script type="text/javascript">
        function getCartProducts() {
            $.getJSON("api/Cart",
                function (data) {
                    $('#divProduct').empty(); // Clear the table header.
                    var totalItems = 0;
                    var totalCost = 0;

                    // Loop through the list of products.
                    var divcontent = "";
                    $.each(data, function (key, val) {

                        totalItems += val.Quantity;
                        totalCost += (val.Quantity * val.Price);

                        // Add a table row for the product. divtags
                        divcontent += '<div class="images">';
                        divcontent += '<figure>';
                        divcontent += '<img src="' + val.ImageUrl + '" alt="Photo" style="width:150px;height:150px;" />';
                        divcontent += '<figcaption>' + val.Name + '</figcaption>';
                        divcontent += '<figcaption> Price : ' + val.Price + ' € </figcaption>';
                        divcontent += '</figure>';
                        divcontent += '</div>';
                        divcontent += '<div class="cartDiv"><label>Quantity</label><input class="textbox" type="textbox" value="' + val.Quantity + '" id="' + val.ProductID + '" /></div>';
                        divcontent += '<div><input class="checkbox" type="checkbox" id="' + val.ProductID + '" /><label>  Remove</label></div>';
                        divcontent += '<div class="clearfix"></div>';
                    });


                    $('<div/>', { html: divcontent })  // Append the Product.
                        .appendTo($('#divProduct'));

                    $('#totalItems').text(totalItems);
                    $('#totalcost').text(totalCost);
                });
        }


        $(document).ready(function () {
            getCartProducts();

            $('#btnRemove').click(function () {
                RemoveItems();
            });

            $('#btnSaveChanges').click(function () {
                SaveChanges();
            });

            $('#btnClearItems').click(function () {
                ClearItems();
            });
        });


        function RemoveItems() {
            var selected = [];
            $('#divProduct input:checked').each(function () {
                selected.push($(this).attr('id'));
            });

            $.ajax({
                type: "POST",
                data: JSON.stringify(selected),
                url: "api/Cart",
                contentType: "application/json"
            });
        }

        function SaveChanges() {
            var items = [];
            var item = {};

            $('#divProduct').find(".textbox").each(function () {
                item = {};
                item.ProductID = $(this).attr('id');
                item.Quantity = $(this).val();
                items.push(item);


            });

            $.ajax({
                type: "POST",
                data: JSON.stringify(items),
                url: "api/Items",
                contentType: "application/json"
            });
        }

        function ClearItems() {
            var selected = [];
            $('#divProduct').find(".checkbox").each(function () {
                selected.push($(this).attr('id'));
            });

            $.ajax({
                type: "POST",
                data: JSON.stringify(selected),
                url: "api/Cart",
                contentType: "application/json"
            });
        }




    </script>
</asp:Content>

<asp:Content ID="BodyContent" runat="server" ContentPlaceHolderID="MainContent">
    <div>
        <div class='divheader'>
            <label>List of Products in Your Cart</label>
        </div>
    </div>
    <div class="clearfix"></div>
    <div style="overflow: auto;">
        <div style="float: right;">
            <button id='btnSaveChanges' class="main_btn_m hvr-underline-from-left_m" style="width: 300px; float: right; margin-right: 70px;">
                Save Quantity
            </button>
            <div class="clearfix"></div>
            <br />
            <button id='btnRemove' class="main_btn_m hvr-underline-from-left_m" style="width: 300px; float: right; margin-right: 70px;">
                Remove Items
            </button>
            <div class="clearfix"></div>
            <br />
            <button id='btnClearItems' class="main_btn_m hvr-underline-from-left_m" style="width: 300px; float: right; margin-right: 70px;">
                Clear Items
            </button>
            <div class="clearfix"></div>
            <br />
            <div>
                <label><b>Total Items: </b></label>
                <label id="totalItems"></label>
                <br />
                <label><b>Total Cost: </b></label>
                <label id="totalcost"></label> €
                <br />
                <br />
                <br />
                <button id='btnCheckout' class="main_btn_m hvr-underline-from-left_m" style="width: 300px; float: right; margin-right: 70px;">
                    Checkout
                </button>
            </div>
        </div>
        <div style="float: left;" id="divProduct">
        </div>
    </div>


</asp:Content>
