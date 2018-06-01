# Project Title - Checkout Shopping

This project is a Web API developed for an online watch store. The application allows the customer to view the available variety of watches with its price. It provides flexibility to select mutiple items at a time, decide and change the quantity for each item. Customers can save the selected products in the Cart before checkout and payment. Any item before purchase can be removed from the Cart based on the interest of the customer.Finally the total amount and items for purchase are displayed in the invoice section for the user to proceed with the payment. 



## Getting Started

Please follow below steps to get started with the application.
1. Download checkout shopping cart project from the url https://github.com/alekhya1990/checkout-Shopping
1. Open Visual Studio 2013
2. Select File Option in visual studio --> Open --> select the 'CheckoutShoppingCart_API.sln' file from the project floder and load the project
3. Select Debug menu option --> Start Degugging
4. The application will load the 'Products' page in the defualt web browser which set up in visual studio 


### Prerequisites

1. Windows 7 operating system
2. .Net framework 4.5
3. Visual Studio 2013


### Application usage

Below is the step by step usage of the application

1. Application loads 'Products' as the launch page
2. On Products page, user see the list of latest available watches which can be purchased in Checkout Shopping site
3. User could select different variety of watches in one go and add the items to Cart by clicking on 'Add to Cart' button on the top right corner of the Products page
4. Once the items are added to cart, user will still stay on the Products page for further selection and will be displayed with total no. of items in cart on the top of the page
5. After the complete selection, user can navigate to the Cart page by click on 'Cart' menu option
6. In Cart page, user will be displayed with the list of watches selected in the Products page with default Quantity set to 1 and an option to Remove for each item
7. User is allowed to change the quatity of each item by updating the number in the Quatity box and click 'Save Quantity' button which update the Total Items and Total Price in the invoice section
8. User is also allow to Clear the complete cart list by click on 'Clear Items' button and indivduall remove the items by selecting each item and click on 'Remove Items' button after selection
9. Once the complete list is finalised in the Cart section, user can proceed with Checkout/Purchase by clicking on 'Checkout' button (This button doesn't have built in functionality in this project, but a provision to extend the funationality is still available)
10. User ca also view the list of previous purchases on orders in the Order page. Navigate to this page by clicking on 'Order' menu item.



## Running the tests
1. On the Build menu, choose Build Solution.

2. If there are no errors, the UnitTestExplorer window appears with Display_Products_withValidItems_InSession listed in the Not Run Tests group. If Test Explorer does not appear after a successful build, choose Test on the menu, then choose Windows, and then choose Test Explorer.

Choose Run All to run the test. As the test is running the status bar at the top of the window is animated. At the end of the test run, the bar turns green if all the test methods pass, or red if any of the tests fail.

In this case, the test does fail. The test method is moved to the Failed Tests. group. Select the method in Test Explorer to view the details at the bottom of the window.

Example: In this project, an example test case is built to throw an ArgumentOutOfRange exception. This exception is thrown because the total no .of variety items in cart exceeds the total variety in the products list.


## Deployment

Below are the steps for deployment

1. Clean the project by selecting 'Clean Project' option under Debug menu
2. Build the project by selecting 'Build Project' option under Debug menu
3. Create the deployable artefacts in a local folder by selecting 'Publish' otion under Debug menu. Once clicked on Publish, it creates the files which can be used to run the application
4. Open IIS 8 and create a virtual directory user default website
5. Make sure that the default web site is mapped to an application pool which supports .net framework 4.5
6. Right click on the vrtual folder and go to Advance Settings option
7. In Advance settings, select the physical path and map it to the published folder on the local machine.
8. Project would be ready to be browsed from the web browser


## Built With

* .Net framework 4.5
* Visual studio 2013
* c#
* Web API
* .Net Client libraries
* .Net Core components
* LinQ



